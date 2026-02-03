select productid,salemonth,amount,
sum(amount) over(
    partition by productid
    order by salemonth
    rows between unbounded preceding and current row
) as cumulative_sales
from sales;
