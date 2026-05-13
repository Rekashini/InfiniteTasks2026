--1.Create Database
create database Employeemanagement;

use Employeemanagement;

--2.Create Table
create table Employee_Details (
    Empno int primary key,
    EmpName varchar(50) not null,
    Empsal numeric(10,2) check (empsal >= 25000),
    Emptype char(1) check (emptype in ('f', 'p'))
);

-- Question 1 TO DO:
create procedure Insert_EmployeeDetails
(
    @EmpName varchar(50),
    @Empsal numeric(10,2),
    @Emptype char(1)
)
as
begin

    declare @Empno int;

    select @Empno = isnull(max(Empno),1000) + 1
    from Employee_Details;

    insert into Employee_Details
    values(@Empno, @EmpName, @Empsal, @Emptype);

end;

select * from Employee_Details;


-- Question 2
create procedure updateemployeesal
    @empid int,
    @updatedsalary decimal(18,2) output
as
begin
    update Employee_Details
    set Empsal = Empsal + 100
    where Empno = @empid;

    select @updatedsalary = Empsal
    from Employee_Details
    where Empno = @empid;
end