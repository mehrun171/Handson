/*1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions

Print the payslip neatly with all details*/

create or alter proc generate_pay_slip @empid int
as
begin
declare 
        @empname varchar(20),
        @designation varchar(50),
        @salary int,
        @hra int,
        @da int,
        @pf int,
        @it int,
        @deductions int,
        @grosssalary int,
        @netsalary int
select 
        @empname = ename,
        @designation = job,
        @salary = salary
from emp where empno = @empid

    if @empname is null
    begin
        print 'employee not exists'
        return
    end

    set @hra = 0.1 * @salary
    set @da = 0.2 * @salary
    set @pf = 0.8 * @salary
    set @it = 0.5 * @salary
    set @deductions = @pf + @it
    set @grosssalary = @salary + @hra + @da
    set @netsalary = @grosssalary - @deductions

    print 'PAY-SLIP'
    print 'Employee ID: ' + cast(@empid as varchar(10))
    print 'Employee Name: ' + @EmpName
    print 'Designation: ' + @Designation
    print 'Basic Salary: ' + cast(@salary as varchar(10))
    print 'HRA : ' + cast(@hra as varchar(10))
    print 'DA : ' + cast(@da as varchar(10))
    print 'PF : ' + cast(@pf as varchar(10))
    print 'IT : ' + cast(@it as varchar(10))
	print 'Deductions: ' + cast(@deductions as varchar(10))
    print 'Gross Salary : ' + cast(@grosssalary as varchar(10))
    print 'Net Salary : ' + cast(@netsalary as varchar(10))
end

exec generate_pay_slip @empid = 133;


/*2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like
“Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

Note: Create holiday table with (holiday_date,Holiday_name). 
Store at least 4 holiday details. try to match and stop manipulation */

create table holiday
(
holiday_date date,
holiday_name varchar(20)
)

select * from holiday

insert into holiday values
('2025-08-15','Independence Day'),
('2025-12-25','Christmas'),
('2025-01-26','Republic Day'),
('2025-01-01','New Year')

create or alter trigger trigger_holidaysrestriction_on_emp
on emp
after insert,update,delete
as 
begin
declare @date_today date='2025-01-01'
declare @holidayname varchar(20)
select @holidayname=holiday_name from holiday where holiday_date=@date_today
if @holidayname is not null
	begin
	raiserror('Restricted operations',16,1)
	rollback transaction
	end
end

declare @date_today DATE = '2025-08-15'

insert into emp values 
(133,'Mehr','Trainee',8762,'2025-06-06',16000,47,30)

delete from emp where empno = 133;

insert into emp values 
(133, 'Mehr', 'Trainee', 8762, '2025-06-06', 16000, 47, 30);
 
