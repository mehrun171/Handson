CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    LastName VARCHAR(50),
    FirstName VARCHAR(50),
    Title VARCHAR(50),
    City VARCHAR(30),
    Country VARCHAR(30)
);

INSERT INTO Employees VALUES 
('Davolio', 'Nancy', 'Sales Representative', 'Seattle', 'USA'),
('Fuller', 'Andrew', 'Vice President, Sales', 'Tacoma', 'USA'),
('Leverling', 'Janet', 'Sales Representative', 'Kirkland', 'USA'),
('Peacock', 'Margaret', 'Sales Representative', 'Redmond', 'USA'),
('Buchanan', 'Steven', 'Sales Manager', 'London', 'UK');
