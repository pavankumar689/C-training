create table customers(customerid int identity primary key,customername varchar(100),customerphone varchar(20),customercity varchar(50));

create table salespersons(salespersonid int identity primary key,salespersonname varchar(100));

create table products(productid int identity primary key,productname varchar(100));

create table orders(orderid int primary key,orderdate date,customerid int,salespersonid int,foreign key(customerid) references customers(customerid),foreign key(salespersonid) references salespersons(salespersonid));

create table orderdetails(orderdetailid int identity primary key,orderid int,productid int,quantity int,unitprice decimal(10,2),foreign key(orderid) references orders(orderid),foreign key(productid) references products(productid));


with cte as(
select orderid,sum(cast(q.value as int)*cast(p.value as decimal(10,2))) totalsales
from sales_raw
cross apply string_split(quantities,',') q
cross apply string_split(unitprices,',') p
group by orderid
)
select totalsales
from(
select totalsales,dense_rank() over(order by totalsales desc) rnk from cte
)t
where rnk=3;


select salesperson,sum(cast(q.value as int)*cast(p.value as decimal(10,2))) totalsales
from sales_raw
cross apply string_split(quantities,',') q
cross apply string_split(unitprices,',') p
group by salesperson
having sum(cast(q.value as int)*cast(p.value as decimal(10,2)))>60000;


with cust as(
select customername,sum(cast(q.value as int)*cast(p.value as decimal(10,2))) totalsales
from sales_raw
cross apply string_split(quantities,',') q
cross apply string_split(unitprices,',') p
group by customername
)
select customername,totalsales
from cust
where totalsales>(select avg(totalsales) from cust);


select upper(customername) customername,month(convert(date,orderdate)) ordermonth
from sales_raw
where month(convert(date,orderdate))=1 and year(convert(date,orderdate))=2026;
