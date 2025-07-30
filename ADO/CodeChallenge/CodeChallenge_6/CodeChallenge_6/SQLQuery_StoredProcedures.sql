create table Employee_Details (
    EmpId int identity(1,1) primary key,
    Name varchar(30),
    Gender varchar(7),
    Salary decimal(10,2),
    NetSalary as (Salary - (Salary * 0.10))
);

/*emp id 2 values were deleted by me*/

select * from Employee_Details

create or alter proc InsertEmployeeDetails
    @Name nvarchar(30),
    @Gender nvarchar(7),
    @Salary decimal(10,2)
as
begin
    insert into Employee_Details (Name, Gender, Salary)
    values (@Name, @Gender, @Salary)

    Select top 1 EmpId
	from Employee_Details
	where Name=@Name and Salary =@Salary
	order by EmpId DESC;
end


create or alter proc UpdateEmployeeSalary
	@EmpId int,
	@UpdatedSalary decimal(10,2) output
as
begin
	update Employee_Details
	set Salary=Salary+100
	where EmpId=@EmpId

	Select @UpdatedSalary=Salary from Employee_Details 
	where EmpId=@EmpId
end

