select * 
from products p
where not exists(select 1 from sales s where s.productid=p.productid);
