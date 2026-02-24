create table Employees(
EmpId nvarchar(50) primary key not null,
Name nvarchar(50) not null,
Department nvarchar(10) not null,
Phone bigint not null,
Email nvarchar(30) not null
)

create table orders(
OrderId int primary Key not null,
EmpId nvarchar(50) not null,
OrderAmount money not null,
OrderDate Date not null
foreign key (EmpId) references employees(empid)
)

INSERT INTO Employees VALUES
('E101','Pavan Kumar','IT',9876543210,'pavan@gmail.com'),
('E102','Rahul Sharma','HR',9876501234,'rahul@gmail.com'),
('E103','Sneha Reddy','FIN',9876512345,'sneha@gmail.com'),
('E104','Amit Verma','IT',9876523456,'amit@gmail.com'),
('E105','Priya Singh','MKT',9876534567,'priya@gmail.com');

INSERT INTO Orders VALUES
(1,'E101',15000,'2026-01-10'),
(2,'E101',22000,'2026-01-15'),
(3,'E102',18000,'2026-01-18'),
(4,'E103',25000,'2026-02-01'),
(5,'E104',12000,'2026-02-05'),
(6,'E105',30000,'2026-02-07'),
(7,'E101',17000,'2026-02-10');

create or Alter proc sp_GetEmployeesByDepartment
@Department nvarchar(10)
as
begin
select * from employees where Department=@Department;
end

exec sp_GetEmployeesByDepartment 'IT';

create or alter proc sp_GetDepartmentEmployeeCount
@Department nvarchar(10),
@TotalCount int output
as 
begin
select @TotalCount=Count(*) from Employees where Department=@Department
end

CREATE PROC sp_GetEmployeeOrders
AS
BEGIN
    SELECT 
        e.Name,
        e.Department,
        o.OrderId,
        o.OrderAmount,
        o.OrderDate
    FROM Employees e
    INNER JOIN Orders o
    ON e.EmpId = o.EmpId;
END

CREATE PROC sp_GetDuplicateEmployees
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE Phone IN
    (
        SELECT Phone
        FROM Employees
        GROUP BY Phone
        HAVING COUNT(*) > 1
    )
    OR Email IN
    (
        SELECT Email
        FROM Employees
        GROUP BY Email
        HAVING COUNT(*) > 1
    );
END

