CREATE TABLE Customers (
    CustId INT PRIMARY KEY IDENTITY(1,1),
    CustName VARCHAR(100) NOT NULL,
    Phone VARCHAR(10) NOT NULL,
    MailId VARCHAR(100) NOT NULL,
    IsDeleted BIT DEFAULT 0
)

CREATE TABLE Trains (
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100) NOT NULL,
    Source VARCHAR(100) NOT NULL,
    Destination VARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1
)

CREATE TABLE TrainClasses (
    TrainClassId INT PRIMARY KEY IDENTITY(1,1),
    TrainNo INT FOREIGN KEY REFERENCES Trains(TrainNo),
    Class VARCHAR(20) CHECK (Class IN ('Sleeper', '2AC', '3AC')),
    Availability INT CHECK (Availability >= 0),
    MaxAvailability INT CHECK (MaxAvailability >= 0),
    CostPerSeat DECIMAL(10,2) CHECK (CostPerSeat > 0)
)

CREATE TABLE Reservations (
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    CustId INT FOREIGN KEY REFERENCES Customers(CustId),
    TrainNo INT FOREIGN KEY REFERENCES Trains(TrainNo),
    TravelDate DATE CHECK (TravelDate >= GETDATE()),
    Class VARCHAR(20) CHECK (Class IN ('Sleeper', '2AC', '3AC')),
    BerthAllotment VARCHAR(50),
    TotalCost DECIMAL(10,2) CHECK (TotalCost >= 0),
    BookingDate DATE DEFAULT GETDATE(),
    IsDeleted BIT DEFAULT 0
)


CREATE TABLE Cancellations (
    CancelId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT FOREIGN KEY REFERENCES Reservations(BookingId),
    RefundAmount DECIMAL(10,2) CHECK (RefundAmount >= 0),
    CancellationDate DATE DEFAULT GETDATE(),
    TicketCancelled BIT DEFAULT 1
)

INSERT INTO Trains (TrainNo, TrainName, Source, Destination)
VALUES 
(101, 'Garib Rath', 'Visakhapatnam', 'Hyderabad'),
(102, 'MGR mail', 'Visakhapatnam', 'Chennai'),
(103, 'Rajadhani Express', 'Delhi', 'Kerala'),
(104, 'Deccan Express', 'Hyderabad', 'Visakhapatnam'),
(105, 'Coromandel Express', 'Chennai', 'Visakhapatnam'),
(106, 'KeralaExpress', 'Kerala', 'Delhi')

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(101, 'Sleeper', 100, 100, 600.00),
(101, '2AC', 50, 50, 1400.00),
(101, '3AC', 75, 75, 1000.00)

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(102, 'Sleeper', 90, 90, 550.00),
(102, '2AC', 30, 30, 1150.00),
(102, '3AC', 60, 60, 850.00)

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(103, 'Sleeper', 90, 90, 600.00),
(103, '2AC', 45, 45, 1100.00),
(103, '3AC', 55, 55, 950.00)

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(104, 'Sleeper', 70, 70, 520.00),
(104, '2AC', 45, 45, 970.00),
(104, '3AC', 30, 30, 730.00)

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(105, 'Sleeper', 95, 95, 550.00),
(105, '2AC', 40, 40, 1080.00),
(105, '3AC', 75, 75, 880.00)

INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat)
VALUES 
(106, 'Sleeper', 100, 100, 850.00),
(106, '2AC', 45, 45, 1300.00),
(106, '3AC', 65, 65, 1050.00)

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY(1001,1),
	FullName VARCHAR(100),
    Username VARCHAR(20) NOT NULL UNIQUE,
    Password VARCHAR(8) NOT NULL,
);

ALTER TABLE Customers
ADD Username VARCHAR(20) UNIQUE,
    Password VARCHAR(8);
	
INSERT INTO Admins
VALUES ('System Administrator','Admin1', 'rrs@123','Admin')

select * from Admins

INSERT INTO Customers VALUES 
('Shamshi', '99887755', 'shams@user.com', 0,'shams@123', 'mypwd','User')

ALTER TABLE Admins ADD Role VARCHAR(20) DEFAULT 'Admin';
ALTER TABLE Customers ADD Role VARCHAR(20) DEFAULT 'User';

select * from Customers
select * from Trains
select * from Reservations
select * from Cancellations
