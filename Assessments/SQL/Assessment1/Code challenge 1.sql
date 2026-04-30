create database Assessment
use Assessment

/*Create a book table with id as primary key and provide the appropriate data type to other 
attributes .isbn no should be unique for each book*/

create table Books (
    id int primary key,
    title varchar(50),
    author varchar(50),
    isbn bigint unique,
    published_date datetime
);

insert into Books (id, title, author, isbn, published_date)
values 
(1, 'My First SQL book',  'Mary Parker', 981483029127,  '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
(3, 'My Third SQL book',  'Cary Flint', 523120967812, '2015-10-18 14:05:44');



--1.Write a query to fetch the details of the books written by author whose name ends with er

select * from Books
where author like '%er';

---------------------------------------------------------------------------------------------------------------
--Create and insert values in reviews table

create table reviews (
    id int primary key,
    book_id int,
    reviewer_name varchar(50),
    content varchar(50),
    rating int,
    published_date datetime,
    foreign key (book_id) references Books(id)
);

insert into reviews (id, book_id, reviewer_name, content, rating, published_date) values 
    (1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
    (2, 2, 'John Smith', 'My Second review', 5, '2017-10-13 15:05:12'),
    (3, 3, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

-----------------------------------------------------------------------------------------------------------

--2.Write a query to fetch the details of the books written by author whose name ends with er

select 
    b.title,
    b.author,
    r.reviewer_name
from books b
join reviews r
    on b.id = r.book_id;


--3.Display the reviewer name who reviewed more than one book.

select reviewer_name from reviews
group by reviewer_name
having count(book_id) > 1;


-------------------------------------------------------------------------------
--create and insert values in customer table 

create table customer (
    id int primary key,
    name varchar(50),
    age int,
    address varchar(30),
    salary decimal(10,2)
);

insert into customer values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'Mp', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);

---------------------------------------------------------------------------------

--4.Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select name from customer
where address like '%o%'
  and address in (
        select address from customer
        group by address
        having count(*) > 1
  );


  ---------------------------------------------------------------------------------------
  --create and insert values in orders table 

  create table orders (
    OID int primary key,
    Date datetime,
    customer_id int,
    amount decimal(10,2)
);

insert into orders (OID, Date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000.00),
(100, '2009-10-08 00:00:00', 3, 1500.00),
(101, '2009-11-20 00:00:00', 2, 1560.00),
(103, '2008-05-20 00:00:00', 4, 2060.00);

-------------------------------------------------------------------------------------------------

--5.Write a query to display the Date,Total no of customer placed order on same Date

select Date,
count(distinct customer_id) as totalcustomers from orders
group by Date;


------------------------------------------------------------------------------------------------------
--create and insert values in Employee table 

create table Employee (
    id int primary key,
    name varchar(50),
    age int,
    address varchar(30),
    salary decimal(10,2)
);

insert into Employee values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'Mp',NULL),
(7, 'Muffy', 24, 'Indore',NULL);


--------------------------------------------------------------------------------------------

--6.Display the Names of the Employee in lower case, whose salary is null

select lower(name) as employeename
from employee
where salary is null;

----------------------------------------------------------------------------------------------

--create and insert values in Student table 

create table studentdetails (
    registerno int primary key,
    name varchar(50),
    age int,
    qualification varchar(20),
    mobileno bigint,
    mail_id varchar(100),
    location varchar(50),
    gender char(1)
);


insert into studentdetails (registerno, name, age, qualification, mobileno, mail_id, location, gender) values
(2, 'sai', 22, 'b.e', 9952836777, 'sai@gmail.com', 'chennai', 'm'),
(3, 'kumar', 20, 'bsc', 7890125648, 'kumar@gmail.com', 'madurai', 'm'),
(4, 'selvi', 22, 'b.tech',8904567342, 'selvi@gmail.com', 'selam', 'f'),
(5, 'nisha', 25, 'm.e', 7834672310, 'nisha@gmail.com', 'theni', 'f'),
(6, 'saisaran', 21, 'b.a', 7890345678, 'saran@gmail.com','madurai','f'),
(7, 'tom', 23, 'bca', 8901234675, 'tom@gmail.com', 'pune','m');

-----------------------------------------------------------------------------------------------------------------

--7.Write a sql server query to display the Gender,Total no of male and female from the above relation.

select gender, 
count(*) as totalcount
from studentdetails
group by gender;




