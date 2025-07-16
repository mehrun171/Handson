create table clients
(
client_id int constraint pkey primary key not null,
client_name varchar(40) not null,
c_address varchar(30),
email varchar(30) constraint un unique,
phone varchar(10),
business varchar(20) not null
);

insert into clients values
(1001,'ACME Utilities','Noida','contact@acmeutil.com','9567880032','Manufacturing'),
(1002,'Trackon Consultants','Mumbai','consult@trackon.com','8734210090','Consultant'),
(1003,'MoneySaver Distributors','Kolkata','save@moneysaver.com','7799886655','Reseller'),
(1004,'MoneySaver Distributors','Chennai','justice@lawful.com','9210342219','Professiona');

select * from clients;


create table employees
(
empno int constraint pkey2 primary key not null,
ename varchar(20) not null,
job varchar(15),
salary varchar(7)  check (salary>0),
deptno varchar(2),
);

create table departments
(
deptno varchar(2) constraint pkey3 primary key,
dname varchar(12) not null,
loc varchar(20)
);

alter table employees
add constraint fkey1 foreign key (deptno) references departments(deptno)

insert into employees (empno, ename, job, salary, deptno) values (7001, 'Sandeep', 'Analyst', 25000, 10);
insert into employees (empno, ename, job, salary, deptno) values (7002, 'Rajesh', 'Designer', 30000, 10);
insert into employees (empno, ename, job, salary, deptno) values (7003, 'Madhav', 'Developer', 40000, 20);
insert into employees (empno, ename, job, salary, deptno) values (7004, 'Manoj', 'Developer', 40000, 20);
insert into employees (empno, ename, job, salary, deptno) values (7005, 'Abhay', 'Designer', 35000, 10);
insert into employees (empno, ename, job, salary, deptno) values (7006, 'Uma', 'Tester', 30000, 30);
insert into employees (empno, ename, job, salary, deptno) values (7007, 'Gita', 'Tech. writer', 30000, 40);
insert into employees (empno, ename, job, salary, deptno) values (7008, 'Priya', 'Tester', 35000, 30);
insert into employees (empno, ename, job, salary, deptno) values (7009, 'Nutan', 'Developer', 45000, 20);
insert into employees (empno, ename, job, salary, deptno) values (7010, 'Smita', 'Analyst', 20000, 10);
insert into employees (empno, ename, job, salary, deptno) values (7011, 'Anand', 'Project mgr', 65000, 10);

select * from employees

insert into departments
values
(10,'Design','Pune'),
(20,'Development','Pune'),
(30,'Testing','Mumbai'),
(40,'Document','Mumbai');

select * from departments

create table projects
(
project_id int constraint pk_projects primary key not null,
descr varchar(30) not null,
start_date date,
planned_end_date date,
actual_end_date date,
budget varchar(10) check (budget>0),
client_id int,
constraint fk_client foreign key (client_id) references clients(client_id)
);

insert into projects values
(401,'Inventory','01-Apr-11','01-Oct-11','31-Oct-11','150000',1001);
insert into projects values
(402,'Accounting','01-Aug-11','01-Jan-12',null,'500000',1002),
(403,'Payroll','01-Oct-11','31-Dec-11',null,'75000',1003),
(404,'Contact Mgmt','01-Nov-11','31-Dec-11',null,'50000',1004);

select * from projects;

create table empprojecttasks
(
project_id int,
empno int ,
start_date date,
end_date date,
task varchar(20) not null,
status varchar(15) not null,
primary key (project_id,empno),
foreign key (project_id) references projects (project_id),
foreign key (empno) references employees(empno)
);

insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed');
insert into empprojecttasks (project_id, empno, start_date, end_date, task, status) values (402, 7004, '2011-10-01', null, 'Coding', 'In Progress');


select * from empprojecttasks;