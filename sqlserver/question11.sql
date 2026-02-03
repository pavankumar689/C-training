CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);

CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20),
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10),
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


CREATE TABLE Bonus
(
    BonusID INT IDENTITY(1,1) PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);


INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');

INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);

INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000),
(9, 102, '2024-02-10', 'Deposit', 60000);


--Question 1
create or alter proc dateRangeAggregation
@startDate date,
@EndDate date,
@AccountId int
as
begin
  select 
  sum(case when transactiontype='Deposit' then amount else 0 end) as DepositedAmount,
  sum(case when transactiontype='withdraw' then amount else 0 end)as WithdrawedAmount from transactions where 
  AccountID=@accountid and transactiondate between @startDate and @EndDate
end;

exec dateRangeAggregation '2024-01-05','2024-02-10',101;


--Question 2
insert into bonus (accountid, bonusmonth, bonusyear, bonusamount, createddate)
select t.accountid,
    month(t.transactiondate),
    year(t.transactiondate),
    1000,
    getdate()
from transactions t
where t.transactiontype = 'deposit'
group by
    t.accountid,
    month(t.transactiondate),
    year(t.transactiondate)
having sum(t.amount) > 50000
and not exists
(
    select 1
    from bonus b
    where b.accountid = t.accountid
      and b.bonusmonth = month(t.transactiondate)
      and b.bonusyear  = year(t.transactiondate)
);


--Question-3
select
    c.customername,
    a.accountnumber,
    a.openingbalance
    + isnull(t.totaldeposit, 0)
    - isnull(t.totalwithdraw, 0)
    + isnull(b.totalbonus, 0) as currentbalance
from customers c
join accounts a
    on c.customerid = a.customerid
left join
(
    select
        accountid,
        sum(case when transactiontype = 'deposit' then amount else 0 end) as totaldeposit,
        sum(case when transactiontype = 'withdraw' then amount else 0 end) as totalwithdraw
    from transactions
    group by accountid
) t
    on t.accountid = a.accountid
left join
(
    select
        accountid,
        sum(bonusamount) as totalbonus
    from bonus
    group by accountid
) b
    on b.accountid = a.accountid;'


