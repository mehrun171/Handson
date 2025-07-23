 --1.	Write a query to display your birthday( day of week)
 
 select datename(day, '2003-10-21') as date_of_Birthday, datename(weekday, '2003-10-21') as day_of_week_of_Birthday


--2.	Write a query to display your age in days
  
 select datediff(day, '2003-10-21', getdate()) as my_age_in_days


--3.	Write a query to display all employees information those who joined before 5 years in the current month
--(Hint : If required update some HireDates in your EMP table of the assignment)

DISABLE TRIGGER trigger_holidaysrestriction_on_emp ON emp

update emp set hire_date = '2015-July-03' where empno = 7782
update emp set hire_date = '2023-OCTOBER-21' where empno = 7900 
update emp set hire_date = '2019-July-29' where empno = 7499
 
select *
from emp
where datediff(year, cast(hire_date as date), getdate()) >= 5
  and month(cast(hire_date as date)) = month(getdate()) --allen and clark op


/*4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction

	a. First insert 3 rows 

	b. Update the second row sal with 15% increment  

        c. Delete first row.

After completing above all actions, recall the deleted row without losing increment of second row.*/

begin transaction

-- inserting rows--
insert into employees values (1111, 'person1','Tester', 28000, 20,28000),
(2222, 'person2','Developer', 45000, 20,45000),
(3333, 'person3','QA analyst', 32000, 10,32000)

select * from employees

-- updating 2nd row sal with 15%
update employees set sal = sal * 1.15 where empno = 2222

save transaction tr1
 -- c. Delete first row.

delete from employees where empno = 1111
rollback transaction tr1
commit

 
/*5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions

	a.     For Deptno 10 employees 15% of sal as bonus.

	b.     For Deptno 20 employees  20% of sal as bonus

	c      For Others employees 5%of sal as bonus*/
 
create or alter function calculate_bonus (@deptno int, @salary int) returns int
as
begin
    declare @bonus int

    if @deptno = 10
        set @bonus = @salary * 0.15
    else if @deptno = 20
        set @bonus = @salary * 0.20
    else
        set @bonus = @salary * 0.05

    return @bonus
end

select empno, ename, salary, deptno, dbo.calculate_bonus(deptno, salary) as Bonus
from emp;




--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
 
create or alter proc update_emp_sal
as
begin
    update emp
    set salary = salary + 500
    where 
	salary < 1500 and deptno = (select deptno from dept where dname = 'Sales')
end

exec update_emp_sal

select * from emp where deptno=(select deptno from dept where dname = 'Sales') --ward,martin,james should be updated

ENABLE TRIGGER trigger_holidaysrestriction_on_emp ON emp
