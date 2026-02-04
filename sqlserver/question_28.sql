select d.deptname,e.name as employeename,e.salary as highestsalary
from employees e
join department d on e.deptid=d.deptid
where e.salary=(
select max(e2.salary)
from employees e2
where e2.deptid=e.deptid
)
and e.deptid in(
select deptid
from employees
group by deptid
having avg(salary)>70000
);
