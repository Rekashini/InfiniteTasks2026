use Assignment2

select * from Emp

--1. Write a query to display your birthday( day of week)
select datename(WeekDay, '2005-01-31') as Birthday_Day;

--2. Write a query to display your age in days
select datediff(day, '2005-01-31', getdate()) as Age_in_days;

--3. Write a query to display all employees information those who joined before 5 years in the current month
select empno, ename, hiredate from emp 
where hiredate < dateadd(year, -5, getdate())
 and month(hiredate) = month(getdate());


-- 4. create table employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction

Begin Transaction;

-- a. first insert 3 rows
insert into emp values (1001, 'Rika', 'HR', null, getdate(), 7000, null, 10);
insert into emp values (1002, 'Ram', 'Analyst', 7265, getdate(), 5000, null, 20);
insert into emp values (1003, 'Athul', 'Manager', 7235, getdate(), 9000, null, 30);

-- b. update the second row sal with 15% increment  
update emp
set sal = sal * 1.15
where empno = 1002;

save transaction AfterUpdate;

-- c. delete first row
delete from emp
where empno = 1001;

-- after completing above all actions, recall the deleted row without losing increment of second row
rollback transaction AfterUpdate;
commit;


-- 5. create a user defined function calculate bonus for all employees of a given dept

go
create function calculate_Bonus(@deptno int, @sal int)
returns decimal(10,2)
as
begin
    declare @bonus decimal(10,2);

-- 	a.For Deptno 10 employees 15% of sal as bonus.
    if @deptno = 10
        set @bonus = @sal * 0.15;

-- b.For Deptno 20 employees  20% of sal as bonus

    else if @deptno = 20
        set @bonus = @sal * 0.20;

-- c.For Others employees 5%of sal as bonus
    else
        set @bonus = @sal * 0.05;

    return @bonus;
end;

go

--execute
select 
    empno, 
    ename, 
    deptno, 
    sal,
    dbo.calculate_bonus(deptno, sal) as bonus
from emp;
go


-- 6.update salary for employees in dept 30 with salary less than 1500

create procedure update_sales_salary
as
begin
   
    update emp
    set sal = sal + 500
    where deptno = 30
      and sal < 1500;
end;

--to execute
exec update_sales_salary;

go