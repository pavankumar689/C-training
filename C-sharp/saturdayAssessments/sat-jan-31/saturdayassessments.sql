--question 2;
with order_totals as (
select o.order_id,sum(oi.quantity * p.unit_price) as total_sales
from orders o
join order_items oi on o.order_id = oi.order_id
join product_master p on oi.product_id = p.product_id
group by o.order_id)
select order_id, total_sales from (
select order_id,total_sales,
dense_rank() over (order by total_sales desc) as rnk from order_totals) t 
where rnk = 3;


with customer_totals as (
select o.customer_id,sum(oi.quantity * p.unit_price) as total_purchase from orders o join order_items oi on o.order_id = oi.order_id
join product_master p on oi.product_id = p.product_id
group by o.customer_id
)
select customer_id, total_purchase
from (
select 
customer_id,
total_purchase,
dense_rank() over (order by total_purchase desc) as rnk
from customer_totals
) t
where rnk = 3;


--question 3
select s.sales_person_name,
sum(oi.quantity * p.unit_price) as total_sales
from orders o
join sales_master s on o.sales_person_id = s.sales_person_id
join order_items oi on o.order_id = oi.order_id
join product_master p on oi.product_id = p.product_id
group by s.sales_person_name
having sum(oi.quantity * p.unit_price) > 60000;


--question-4
select c.customername,sum(oi.quantity * p.unit_price) as total_spent
from customer_master c
join orders o on c.customerid = o.customer_id
join order_items oi on o.order_id = oi.order_id
join product_master p on oi.product_id = p.product_id
group by c.customername
having sum(oi.quantity * p.unit_price) >
(select avg(customer_total)from (select 
sum(oi.quantity * p.unit_price) as customer_total
from orders o
join order_items oi on o.order_id = oi.order_id
join product_master p on oi.product_id = p.product_id
group by o.customer_id
) x
);


--question-5
select upper(c.customername) as customername,month(o.orderdate) as order_month,o.orderdate
from orders o join customer_master c on o.customer_id = c.customerid
where year(o.orderdate) = 2026 and month(o.orderdate) = 1;
