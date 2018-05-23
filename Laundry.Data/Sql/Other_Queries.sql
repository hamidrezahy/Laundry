
-- ************************************
-- *                                  *
-- * Testing some database PROCEDURES *
-- *                                  *
-- ************************************

USE Laundry
GO

-- --------------------------------------------------

EXECUTE dbo.GetEmployeeByState N'البرز';
GO	

EXECUTE dbo.GetEmployeeByCity N'کردان';
GO	

EXECUTE dbo.GetEmployeeByGender N'مرد';
GO	

EXECUTE dbo.GetEmployeeByID 1;
GO	
 
-- --------------------------------------------------

EXECUTE dbo.GetCustomerByState N'البرز';
GO	

EXECUTE dbo.GetCustomerByCity N'هشتگرد';
GO	

EXECUTE dbo.GetCustomerByID 1;
GO	

-- --------------------------------------------------

EXECUTE dbo.GetEmployeeList;
GO

EXECUTE dbo.GetCustomerList;
GO

EXECUTE dbo.GetServiceList;
GO

EXECUTE dbo.GetOrderList;
GO


EXECUTE dbo.DeleteOrder 4;