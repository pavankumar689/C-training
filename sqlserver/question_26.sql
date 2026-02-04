create clustered index idx_orders_orderid on orders(orderid);

create nonclustered index idx_orders_customerid_orderdate on orders(customerid,orderdate);

-- explanation
-- clustered index is created on orderid because it is usually the primary key and organizes table data physically which avoids heap storage and improves overall performance.
-- composite nonclustered index is created on (customerid,orderdate) because the query filters first on customerid (equality condition) and then on orderdate (range condition).
-- this index allows sql server to perform index seek instead of table scan which significantly reduces io and improves query performance on large tables (20 million rows).
