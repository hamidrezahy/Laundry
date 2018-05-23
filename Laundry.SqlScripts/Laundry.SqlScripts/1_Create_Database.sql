CREATE DATABASE Laundry ;
SELECT NAME FROM sys.databases ;
GO

USE Laundry;
GO

CREATE TABLE Employee 
(
    Employee_ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25),
    FullName AS FirstName + ' ' + LastName,
    Phone NVARCHAR(12),
    Email NVARCHAR(50),
    Salary INT,
    EmergencyPhone NVARCHAR(12),
    Gender NVARCHAR(5),
    [State] NVARCHAR(25),
    [City] NVARCHAR(20),
    [Street] NVARCHAR(35),
    [Other] NVARCHAR(100),
    [Address] AS [State] + ' - ' + [City] + ' - ' + [Street] + ' - ' + [Other]
);
GO

CREATE TABLE Customer 
(
    Customer_ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25),
    FullName AS FirstName + ' ' + LastName,
    Phone NVARCHAR(12),
    Email NVARCHAR(50),
    [State] NVARCHAR(25),
    [City] NVARCHAR(20),
    [Street] NVARCHAR(35),
    [Other] NVARCHAR(100),
    [Address] AS [State] + ' - ' + [City] + ' - ' + [Street] + ' - ' + [Other]
);
GO

CREATE TABLE [Service] 
(
    Service_ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(40),
    Cost INT,
    Category NVARCHAR(12)
);
GO

CREATE TABLE [Order] 
(
    Order_ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Employee_ID INT FOREIGN KEY REFERENCES Employee(Employee_ID),
    Customer_ID INT FOREIGN KEY REFERENCES Customer(Customer_ID),
    Service_ID INT FOREIGN KEY REFERENCES [Service](Service_ID),
    [Name] NVARCHAR(40),
    [Description] NVARCHAR(100),
    Cost INT,
    [Date] DATETIME,
    [DeliveryDate] DATETIME
);
GO

SELECT * FROM Employee ;
GO

SELECT * FROM Customer ;
GO

SELECT * FROM [Service] ;
GO

SELECT * FROM [Order] ;
GO