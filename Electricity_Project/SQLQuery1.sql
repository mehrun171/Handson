CREATE DATABASE ElectricityBillDB
GO

CREATE TABLE ElectricityBill (
    consumer_number VARCHAR(20) PRIMARY KEY,
    consumer_name VARCHAR(50) NOT NULL,
    units_consumed INT NOT NULL,
    bill_amount FLOAT NOT NULL
)

CREATE TABLE AdminLogin (
    username VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50) NOT NULL
)

INSERT INTO AdminLogin (username, password)
VALUES ('admin', 'admin123')

select * from ElectricityBill