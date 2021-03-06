
namespace FurnitureRepair
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ServiceLabel = new System.Windows.Forms.Label();
            this.FurnitureLabel = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            this.DiscountPercentLabel = new System.Windows.Forms.Label();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.SumTakenLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.cbFurniture = new System.Windows.Forms.ComboBox();
            this.QuantityLbox = new System.Windows.Forms.TextBox();
            this.PercentTbox = new System.Windows.Forms.TextBox();
            this.TotalSumTbox = new System.Windows.Forms.TextBox();
            this.SumTakenTbox = new System.Windows.Forms.TextBox();
            this.dummy = new System.Windows.Forms.Label();
            this.dummy2 = new System.Windows.Forms.Label();
            this.dummy3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServiceLabel
            // 
            resources.ApplyResources(this.ServiceLabel, "ServiceLabel");
            this.ServiceLabel.Name = "ServiceLabel";
            // 
            // FurnitureLabel
            // 
            resources.ApplyResources(this.FurnitureLabel, "FurnitureLabel");
            this.FurnitureLabel.Name = "FurnitureLabel";
            // 
            // Quantity
            // 
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.Name = "Quantity";
            // 
            // DiscountPercentLabel
            // 
            resources.ApplyResources(this.DiscountPercentLabel, "DiscountPercentLabel");
            this.DiscountPercentLabel.Name = "DiscountPercentLabel";
            // 
            // TotalSumLabel
            // 
            resources.ApplyResources(this.TotalSumLabel, "TotalSumLabel");
            this.TotalSumLabel.Name = "TotalSumLabel";
            // 
            // SumTakenLabel
            // 
            resources.ApplyResources(this.SumTakenLabel, "SumTakenLabel");
            this.SumTakenLabel.Name = "SumTakenLabel";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbService
            // 
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.FormattingEnabled = true;
            resources.ApplyResources(this.cbService, "cbService");
            this.cbService.Name = "cbService";
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // cbFurniture
            // 
            this.cbFurniture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFurniture.FormattingEnabled = true;
            resources.ApplyResources(this.cbFurniture, "cbFurniture");
            this.cbFurniture.Name = "cbFurniture";
            // 
            // QuantityLbox
            // 
            resources.ApplyResources(this.QuantityLbox, "QuantityLbox");
            this.QuantityLbox.Name = "QuantityLbox";
            this.QuantityLbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityLbox_KeyPress);
            // 
            // PercentTbox
            // 
            resources.ApplyResources(this.PercentTbox, "PercentTbox");
            this.PercentTbox.Name = "PercentTbox";
            this.PercentTbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PercentTbox_KeyPress);
            // 
            // TotalSumTbox
            // 
            resources.ApplyResources(this.TotalSumTbox, "TotalSumTbox");
            this.TotalSumTbox.Name = "TotalSumTbox";
            this.TotalSumTbox.ReadOnly = true;
            // 
            // SumTakenTbox
            // 
            resources.ApplyResources(this.SumTakenTbox, "SumTakenTbox");
            this.SumTakenTbox.Name = "SumTakenTbox";
            // 
            // dummy
            // 
            resources.ApplyResources(this.dummy, "dummy");
            this.dummy.Name = "dummy";
            // 
            // dummy2
            // 
            resources.ApplyResources(this.dummy2, "dummy2");
            this.dummy2.Name = "dummy2";
            // 
            // dummy3
            // 
            resources.ApplyResources(this.dummy3, "dummy3");
            this.dummy3.Name = "dummy3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.dummy3);
            this.Controls.Add(this.dummy2);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.SumTakenTbox);
            this.Controls.Add(this.TotalSumTbox);
            this.Controls.Add(this.PercentTbox);
            this.Controls.Add(this.QuantityLbox);
            this.Controls.Add(this.cbFurniture);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SumTakenLabel);
            this.Controls.Add(this.TotalSumLabel);
            this.Controls.Add(this.DiscountPercentLabel);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.FurnitureLabel);
            this.Controls.Add(this.ServiceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServiceLabel;
        private System.Windows.Forms.Label FurnitureLabel;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label DiscountPercentLabel;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.Label SumTakenLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.ComboBox cbFurniture;
        public System.Windows.Forms.TextBox QuantityLbox;
        public System.Windows.Forms.TextBox PercentTbox;
        public System.Windows.Forms.TextBox TotalSumTbox;
        public System.Windows.Forms.TextBox SumTakenTbox;
        private System.Windows.Forms.Label dummy;
        private System.Windows.Forms.Label dummy2;
        private System.Windows.Forms.Label dummy3;
    }
}

