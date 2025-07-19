--SQL ASSIGNMENT 4


--1.	Write a T-SQL Program to find the factorial of a given number.
declare @number int  
set @number = 3
declare @factorial_ans int 
set @factorial_ans = 1
declare @counter int = 1

while @counter <= @number
begin
    set @factorial_ans = @factorial_ans * @counter
    set @counter += 1
end

print 'The Factorial of the number is:' + cast(@factorial_ans as varchar(8))





--2.	Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create or alter proc multiplication_table @number int, @x int
as
begin
declare @temp int
set @temp=1
while @temp<=@x
 begin
  print cast(@number as varchar(8)) + ' X ' + cast(@temp as varchar(8)) + ' = ' + cast(@number*@temp as varchar(8))
  set @temp +=1
 end
end

exec multiplication_table 7,10





--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

/*student table

Sid       Sname   
1         Jack
2         Rithvik
3         Jaspreeth
4         Praveen
5         Bisa
6         Suraj

Marks table

Mid      Sid     Score
1        1        23
2        6        95
3        4        98
4        2        17
5        3        53
6        5        13*/

create table student (
    Sid int not null,
    Sname varchar(20) not null
);

insert into student (Sid, Sname) values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

create table marks (
    Mid int not null,
    Sid int not null,
    Score int not null
);

insert into marks (Mid, Sid, Score) values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

create function check_status(@marks int) returns varchar(4)
as
begin
declare @status varchar(4)
 if @marks>=50
 begin
	set @status='PASS'
 end
 else
 begin
	set @status='FAIL'
 end
return @status
end

select stu.Sname as 'Student_Name', marks.Score as 'Student_Score',dbo.check_status(marks.Score) as 'Student_Status'
from student stu join marks marks on stu.Sid=marks.Sid