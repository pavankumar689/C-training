select oi.*
from orderitems oi
left join orders o
on oi.orderid = o.orderid
where o.orderid is null;


