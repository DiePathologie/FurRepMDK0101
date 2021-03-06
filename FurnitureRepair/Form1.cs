using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureRepair
{
    /* 1) Для просмотра сводной таблицы есть сформированный View в экземпляре баз данных MebelProject, там актуальные данные после проведения проедуры покупки,
       так как мы работаем в процессе с базой данных из папки Debug, в корневом каталоге /repo MebelProject не обновляется так как в файле App.config стоит указатель на DataDirectoty,
       а именно на раздел Debug. Если указать абсолютный путь до БД в MebelProject, то данные будут обновляться и в ней, но это неудобно, так как его необходимо прописывать вручную,
       эта же практика подразумевает просмотр приложения на другом компьютере.!ВАЖНО! Соответсвенно для просмотра при загрузке проекта выбрать в Soulution Explorer файл MebelProject
       Он появится в списке Server Explorer, далее необходимо на файле MebelProject.mdf вызвать контекстное меню и выбрать ModifyConnection/Изменить подключение. Далее надо выбрать
       файл MebelProject.mdf в скаченной папке bin/debug/MebelProject. Все вносимые данные будут сразу же  доступны к просмотру.
     */

    /* 2) Не совcем понятно предназначение Текстбокса 'Cумма принято', возможно предполагалось отображать сдачу = принято - сумма покупки. */


    public partial class Form1 : Form
    {

        string cn_string = ConfigurationManager.ConnectionStrings["MebelProject"].ConnectionString;
        [Serializable]
        class Mebel
        {
            public int mebel_id { get; set; }
            public string mebel_name { get; set; }
        }

        [Serializable]
        class Uslugi
        {
            public int usl_id { get; set; }
            public string usl_name { get; set; }
            public int meb_id { get; set; }
            public int usl_price { get; set; }
        }

        List<Mebel> furnitures = new List<Mebel>();
        List<Uslugi> services = new List<Uslugi>();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cn_string);

            conn.Open();
            SqlCommand cmdUsl = new SqlCommand("SELECT * FROM uslugi",conn);
            SqlDataReader dr = cmdUsl.ExecuteReader();
            while (dr.Read())
            {
                cbService.Items.Add(dr["usl_name"]);
                services.Add(new Uslugi() { 
                    usl_id = ((int)dr["usl_id"]),
                    usl_name = dr["usl_name"] as string,
                    meb_id = ((int)dr["meb_id"]),
                    usl_price = ((int)dr["price"])
                    
                });
            }
            conn.Close();

            conn.Open();
            SqlCommand cmdMeb = new SqlCommand("SELECT mebel.meb_id, uslugi.meb_id, mebel_name FROM mebel JOIN uslugi ON mebel.meb_id=uslugi.meb_id", conn);
            SqlDataReader dr1 = cmdMeb.ExecuteReader();
            
            while (dr1.Read())
            {
                cbFurniture.Items.Add(dr1["mebel_name"]);
                furnitures.Add(new Mebel()
                {
                    mebel_name = dr1["mebel_name"] as string,
                    mebel_id = ((int)dr1["meb_id"])
                });
            }
            conn.Close();
        }
        
        private string[] getFurnitureById(int id)
        {
            return furnitures.Where(line => line.mebel_id == id).Select(l => l.mebel_name).ToArray();
        }

        public void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cbFurniture.Items.Clear();
            int id = services[cbService.SelectedIndex].usl_id;
            dummy2.Text = services[cbService.SelectedIndex].usl_price.ToString(); 
            foreach (string name in getFurnitureById(id))
            {
                this.cbFurniture.Items.Add(name);
            }
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
                int quanitity = int.Parse(QuantityLbox.Text);  
                decimal discount = Decimal.Parse(PercentTbox.Text);
                decimal PRICE = int.Parse(dummy2.Text);
                decimal summa = (quanitity * PRICE) - ((quanitity * PRICE) * discount / 100);

                TotalSumTbox.Text = summa.ToString();
            }
            catch
            {
                if ((PercentTbox.Text == "") || (PercentTbox.Text == ""))
                {
                    MessageBox.Show(
                    "Ошибка исходных данных.\n" + "Необходимо ввести данные в поля 'Количество' и 'Скидка'.",
                     "Подсчет",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            decimal quan = int.Parse(QuantityLbox.Text);
            int usl_id = services[cbService.SelectedIndex].usl_id;
            decimal usl_price = services[cbService.SelectedIndex].usl_price;
            decimal disc = Decimal.Parse(PercentTbox.Text);

            decimal summaSkidki = ((usl_price * quan) * disc) / 100;
            dummy.Text = summaSkidki.ToString();

            decimal bezSk = usl_price * quan;
            dummy2.Text = bezSk.ToString();

            decimal totalSum = bezSk - summaSkidki;
            TotalSumTbox.Text = totalSum.ToString(); 

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


            string sqlExpression = "INSERT INTO sales (quan, usl_id, disc, sale_date, total) VALUES (@quan, @usl_id, @disc, @sale_date, @totalSum); SET @sale_id=SCOPE_IDENTITY()";
            //using (SqlConnection connection = new SqlConnection(conn))
            using (SqlConnection connection = new SqlConnection(cn_string))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlParameter sale_dateParam = new SqlParameter("@sale_date", myDateTime);
                command.Parameters.Add(sale_dateParam);

                // создаем параметр для quan
                SqlParameter quanParam = new SqlParameter("@quan", quan);
                // добавляем параметр к команде
                command.Parameters.Add(quanParam);

                // создаем параметр для usl_id
                SqlParameter usl_idParam = new SqlParameter("@usl_id", usl_id);
                // добавляем параметр к команде
                command.Parameters.Add(usl_idParam);

                SqlParameter discParam = new SqlParameter("@disc", disc);
                command.Parameters.Add(discParam);

                SqlParameter totalsumParam = new SqlParameter("@totalSum", totalSum);
                command.Parameters.Add(totalsumParam);

                SqlParameter sale_idParam = new SqlParameter
                {
                    ParameterName = "@sale_id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };

                command.Parameters.Add(sale_idParam);

                command.ExecuteNonQuery();

            }
            
        }

        private void QuantityLbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void PercentTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                
                if (!(e.KeyChar >= '0') && (e.KeyChar <= '9') && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
               
                if (e.KeyChar == '.')

                    e.KeyChar = ',';

                if (e.KeyChar == ',')
                {
                    // в поле редактирования не может
                    // быть больше одной запятой и запятая
                    // не может быть первым символом
                    if ((PercentTbox.Text.IndexOf(',') != -1) ||
                          (PercentTbox.Text.Length == 0))
                    {
                        e.Handled = true;
                    }
                    return;
                }
        }
    } 
}
