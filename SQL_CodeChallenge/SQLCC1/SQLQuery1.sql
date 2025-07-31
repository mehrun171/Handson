create table books
(
id int constraint pkey primary key not null,
title varchar(100) not null,
author varchar(15) not null,
isbn varchar(20) unique not null,
published datetime not null
);

select * from books

insert into books (id,title,author,isbn,published)
values
(1,'My First SQL book','Mary Parker','981483029127','2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer','857300923713','1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint','523120967812','2015-10-18 14:05:44')
;

--------1st query------
Select * from books
Where author like '%er';



create table reviews
(
review_id int constraint pkey2 primary key not null,
book_id int,
reviewer_name varchar(20) not null,
content varchar(100) not null,
rating int  not null,
published_date datetime not null,
foreign key(book_id) references books(id)
);

select * from reviews;

insert into reviews (review_id,book_id,reviewer_name,content,rating,published_date)
values
(1,1,'John Smith','My First review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12'),
(3,3,'Alice Walker','Another review',1,'2017-10-22 23:47:10')
;



-------2nd query-------
select title,author,reviewer_name from books b join
reviews r on b.id=r.book_id;



-------3rd query-------
select reviewer_name
from reviews
group by reviewer_name
having count(book_id) > 1;


create table customers
(
id int constraint pkey3 primary key not null,
cust_name varchar(20) not null,
cust_age int not null,
cust_address varchar(50) not null,
salary float not null
);

select * from customers

insert into customers(id,cust_name,cust_age,cust_address,salary)
values
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00);

-------4th query-------

select cust_name from customers
where cust_address like '%o%';

create table orders
(
oid int constraint pkey4 primary key not null,
odate datetime not null,
customer_id int not null,
amount float not null,
foreign key(customer_id) references customers(id)
);

select * from orders

insert into orders (oid,odate,customer_id,amount)
values
(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060);

-------5th query-------

Select odate,Count(customer_id) As no_of_customers
From orders
Group By odate
Having Count(customer_id) > 1;


create table employees
(
id int constraint pkey5 primary key not null,
cust_name varchar(20) not null,
cust_age int not null,
cust_address varchar(50) not null,
salary float 
);

select * from employees

insert into employees(id,cust_name,cust_age,cust_address,salary)
values
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null);


-------6th query-------

select lower(cust_name) from employees
where salary is null;

create table studentdetails
(
regno int not null,
name varchar(20) not null,
age int not null,
qualification varchar(40) not null,
mobno varchar(10) not null,
mailid varchar(20) not null,
location varchar(40) not null,
gender char not null
);

select * from studentdetails

insert into studentdetails(regno,name,age,qualification,mobno,mailid,location,gender)
values
(2,'Sai',22,'B.E','9952836777','Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC','7890125648','Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech','890456342','selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E','7834672310','Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A','7890345678','saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA','8901234675','Tom@gmail.com','Pune','M');


------7th Query------

select gender,count(*) as total_gender_count
from studentdetails
group by gender
    
