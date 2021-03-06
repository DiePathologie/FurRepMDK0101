SELECT sales.sale_id AS '№' , sales.sale_date AS Дата, uslugi.usl_name AS Услуга, mebel.mebel_name AS Мебель,uslugi.price AS Цена,sales.quan AS Количество, sales.disc AS Скидка, sales.total AS Стоимость
FROM sales
INNER JOIN uslugi
ON sales.usl_id = uslugi.usl_id
INNER JOIN mebel
ON mebel.meb_id = uslugi.meb_id
