CREATE DATABASE Laundry ;
SELECT NAME FROM sys.databases ;
GO

USE Laundry;
GO

CREATE TABLE Employee 
(
    E_FirstName NVARCHAR(25),
    E_LastName NVARCHAR(25),
    E_FullName AS E_FirstName + ' ' + E_LastName,

    E_Email NVARCHAR(50),
    E_Phone NVARCHAR(12),
    E_EmergencyPhone NVARCHAR(12),

	E_NCode NVARCHAR(10) NOT NULL PRIMARY KEY,

    E_Salary INT,
    E_Gender NVARCHAR(5),

    E_State NVARCHAR(25),
    E_City NVARCHAR(30),
    E_Street NVARCHAR(35),
    E_Other NVARCHAR(100),
    E_Address AS E_State + ' - ' + E_City + ' - ' + E_Street + ' - ' + E_Other

);
GO

CREATE TABLE Customer 
(
    C_FirstName NVARCHAR(25),
    C_LastName NVARCHAR(25),
    C_FullName AS C_FirstName + ' ' + C_LastName,

    C_Phone NVARCHAR(12) NOT NULL PRIMARY KEY,

    C_State NVARCHAR(25),
    C_City NVARCHAR(30),
    C_Street NVARCHAR(35),
    C_Other NVARCHAR(100),
    C_Address AS C_State + ' - ' + C_City + ' - ' + C_Street + ' - ' + C_Other
);
GO

CREATE TABLE [Service] 
(
    S_ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    S_Name NVARCHAR(40),
    S_Cost INT,
    S_Category NVARCHAR(12)
);
GO

CREATE TABLE [Order] 
(
    O_ID INT NOT NULL IDENTITY (1,1),
    E_NCode NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Employee(E_NCode),
    C_Phone NVARCHAR(12) NOT NULL FOREIGN KEY REFERENCES Customer(C_Phone),
    S_ID INT NOT NULL FOREIGN KEY REFERENCES [Service](S_ID),


    O_Name NVARCHAR(40),
    O_Description NVARCHAR(100),

    O_Cost INT,

    O_Date DATETIME NOT NULL,
    O_DeliveryDate DATETIME,
	PRIMARY KEY (O_ID,E_NCode,C_Phone,S_ID,O_Date)
);
GO



CREATE PROCEDURE GetEmployeeList
	AS	
		SELECT * 
		FROM dbo.Employee
		ORDER BY 
			E_LastName ASC,
			E_FirstName ASC;
GO

CREATE PROCEDURE GetEmployeeByState
	@E_State NVARCHAR(25)
	AS	
		SELECT 			
			E_FirstName,
			E_LastName,
			E_FullName,
			E_Email
			E_Phone,
			E_NCode,
			E_EmergencyPhone,
			E_Salary,
			E_Gender,
			E_City,
			E_Street,
			E_Other,
			E_Address
		FROM dbo.Employee
		WHERE E_State=@E_State
		ORDER BY 
			E_LastName ASC,
			E_FirstName ASC;
GO

CREATE PROCEDURE GetEmployeeByCity
	@E_City NVARCHAR(30)
	AS	
		SELECT 			
			E_FirstName,
			E_LastName,
			E_FullName,
			E_Email
			E_Phone,
			E_NCode,
			E_EmergencyPhone,
			E_Salary,
			E_Gender,
			E_State,
			E_Street,
			E_Other,
			E_Address
		FROM dbo.Employee
		WHERE E_City=@E_City
		ORDER BY 
			E_LastName ASC,
			E_FirstName ASC;
GO

CREATE PROCEDURE GetEmployeeByGender
	@E_Gender NVARCHAR(5) 
	AS	
		SELECT 		
			E_FirstName,
			E_LastName,
			E_FullName,
			E_Email
			E_Phone,
			E_NCode,
			E_EmergencyPhone,
			E_Salary,
			E_State,
			E_City,
			E_Street,
			E_Other,
			E_Address
		FROM dbo.Employee
		WHERE E_Gender=@E_Gender
		ORDER BY 
			E_LastName ASC,
			E_FirstName ASC;
GO

CREATE PROCEDURE GetEmployeeByNCode
	@E_NCode NVARCHAR(10)
	AS	
		SELECT 		
			E_FirstName,
			E_LastName,
			E_FullName,
			E_Email
			E_Phone,
			E_EmergencyPhone,
			E_Salary,
			E_Gender,
			E_State,
			E_City,
			E_Street,
			E_Other,
			E_Address
		FROM dbo.Employee
		WHERE E_NCode=@E_NCode
		ORDER BY 
			E_LastName ASC,
			E_FirstName ASC;
GO



CREATE PROCEDURE GetCustomerList
	AS	
		SELECT * 
		FROM dbo.Customer
		ORDER BY 
			C_LastName ASC,
			C_FirstName ASC;
GO

CREATE PROCEDURE GetCustomerByState
	@C_State NVARCHAR(25)
	AS	
		SELECT 		
			C_FirstName,
			C_LastName,
			C_FullName,
			C_Phone,
			C_City,
			C_Street,
			C_Other,
			C_Address
		FROM dbo.Customer
		WHERE C_State=@C_State
		ORDER BY 
			C_LastName ASC,
			C_FirstName ASC;
GO

CREATE PROCEDURE GetCustomerByCity
	@C_City NVARCHAR(30)
	AS	
		SELECT 			
			C_FirstName,
			C_LastName,
			C_FullName,
			C_Phone,
			C_State,
			C_Street,
			C_Other,
			C_Address
		FROM dbo.Customer
		WHERE C_City=@C_City
		ORDER BY 
			C_LastName ASC,
			C_FirstName ASC;
GO

CREATE PROCEDURE GetCustomerByPhone
	@C_Phone NVARCHAR(12)
	AS	
		SELECT 			
			C_FirstName,
			C_LastName,
			C_FullName,
			C_State,
			C_City,
			C_Street,
			C_Other,
			C_Address
		FROM dbo.Customer
		WHERE C_Phone=@C_Phone
		ORDER BY 
			C_LastName ASC,
			C_FirstName ASC;
GO



CREATE PROCEDURE GetServiceList
	AS	
		SELECT * 
		FROM dbo.[Service]
		ORDER BY S_Name ASC;
GO

CREATE PROCEDURE GetServiceByCategory
	@S_Category NVARCHAR(12)
	AS	
		SELECT 
			S_ID,
			S_Name,
			S_Cost
		FROM dbo.[Service]
		WHERE S_Category=@S_Category
		ORDER BY S_Name ASC;
GO

CREATE PROCEDURE GetServiceByID
	@S_ID INT
	AS	
		SELECT
			S_Name,
			S_Cost,
			S_Category
		FROM dbo.[Service]
		WHERE S_ID=@S_ID;
GO



CREATE PROCEDURE GetOrderList
	AS	
		SELECT 
			ord.O_ID,
			emp.E_FullName,
			ctm.C_FullName,
			srv.S_Name,
			srv.S_Category,
			ord.O_Name,
			ord.O_Cost,
			ord.O_Date,
			ord.O_DeliveryDate
		FROM dbo.[Order] ord
		JOIN	
		dbo.Employee emp ON	ord.E_NCode=emp.E_NCode
		JOIN 
		dbo.Customer ctm ON	ord.C_Phone=ctm.C_Phone
		JOIN 
		dbo.[Service] srv ON ord.S_ID=srv.S_ID
		ORDER BY ord.O_Date DESC
GO

CREATE PROCEDURE GetOrderByEmployee
	@E_NCode NVARCHAR(10)
	AS
		SELECT 
			ord.O_ID,
			ctm.C_FullName,
			srv.S_Name,
			ord.O_Name,
			ord.O_Description,
			ord.O_Cost,
			ord.O_Date,
			ord.O_DeliveryDate
		FROM dbo.[Order] ord
		JOIN	
		dbo.Customer ctm ON	ord.C_Phone=ctm.C_Phone
		JOIN 
		dbo.[Service] srv ON ord.S_ID=srv.S_ID
		WHERE ord.E_NCode=@E_NCode
		ORDER BY ord.O_Date DESC;
GO

CREATE PROCEDURE GetOrderByCustomer
	@C_Phone NVARCHAR(10)
	AS
		SELECT 
			ord.O_ID,
			emp.E_FullName,
			srv.S_Name,
			ord.O_Name,
			ord.O_Description,
			ord.O_Cost,
			ord.O_Date,
			ord.O_DeliveryDate
		FROM dbo.[Order] ord
		JOIN	
		dbo.Employee emp ON	ord.E_NCode=emp.E_NCode
		JOIN 
		dbo.[Service] srv ON ord.S_ID=srv.S_ID
		WHERE ord.C_Phone=@C_Phone
		ORDER BY ord.O_Date DESC;
GO

CREATE PROCEDURE GetOrderByService
	@S_ID INT
	AS
		SELECT 
			ord.O_ID,
			emp.E_FullName,
			ctm.C_FullName,
			ord.O_Name,
			ord.O_Description,
			ord.O_Cost,
			ord.O_Date,
			ord.O_DeliveryDate
		FROM dbo.[Order] ord
		JOIN	
		dbo.Employee emp ON	ord.E_NCode=emp.E_NCode
		JOIN 
		dbo.Customer ctm ON	ord.C_Phone=ctm.C_Phone
		WHERE ord.S_ID=@S_ID
		ORDER BY ord.O_Date DESC;
GO

CREATE PROCEDURE GetOrderByID
	@O_ID INT
	AS	
		SELECT 
			ord.O_ID,
			emp.E_FullName,
			emp.E_Phone,
			emp.E_EmergencyPhone,
			ctm.C_FullName,
			ctm.C_Phone,
			ctm.C_Address,
			srv.S_Name,
			srv.S_Category,
			ord.O_Name,
			ord.O_Description,
			ord.O_Cost,
			ord.O_Date,
			ord.O_DeliveryDate
		FROM dbo.[Order] ord
		JOIN	
		dbo.Employee emp ON	ord.E_NCode=emp.E_NCode
		JOIN 
		dbo.Customer ctm ON	ord.C_Phone=ctm.C_Phone
		JOIN 
		dbo.[Service] srv ON ord.S_ID=srv.S_ID
		WHERE ord.O_ID=@O_ID;
GO

CREATE PROCEDURE DeleteEmployee
	@E_NCode NVARCHAR(10)
	AS
		DELETE FROM [dbo].[Employee]
		WHERE E_NCode=@E_NCode;
GO	

CREATE PROCEDURE DeleteCustomer
	@C_Phone NVARCHAR(12)
	AS
		DELETE FROM [dbo].Customer
		WHERE C_Phone=@C_Phone;
GO	

CREATE PROCEDURE DeleteService
	@S_ID INT
	AS
		DELETE FROM [dbo].[Service]
		WHERE S_ID=@S_ID;
GO	

CREATE PROCEDURE DeleteOrder
	@O_ID INT
	AS
		DELETE FROM [dbo].[Order]
		WHERE O_ID=@O_ID;
GO	

SELECT * FROM Employee ;
GO

SELECT * FROM Customer ;
GO

SELECT * FROM [Service] ;
GO

SELECT * FROM [Order] ;
GO