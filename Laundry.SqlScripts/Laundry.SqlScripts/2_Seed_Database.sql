USE Laundry;
GO

INSERT INTO Employee (FirstName, LastName, Phone, Email, Salary, EmergencyPhone, Gender, [State], City, Street, Other)
VALUES
(N'حمیدرضا',N'همت یار','091210000000','hamidrez77@gmail.com',1000000,'02666789876',N'مرد',N'البرز',N'ولیان',N'شهید فلانی',N'کوچه ی فلان ساختمان فلان پلاک فلان'),
(N'تست',N'تستی','09126785467','testtesti@gmail.com',1200000,'02156786798',N'مرد',N'تهران',N'تهران',N'ولیعصر',N'کوچه تست پلاک ۳') ;
GO

INSERT INTO Customer (FirstName, LastName, Phone, Email, [State], City, Street, Other)
VALUES
(N'علی',N'محمدی','09121234567','alimohammditest@gmail.com',N'تهران',N'تهران',N'آزادی',N'کوچه تست پلاک ۳'),
(N'سعید',N'سعیدی','09121234567','saeedsaeedi@gmail.com',N'تهران',N'تهران',N'شریعتی',N'کوچه تست پلاک ۴'),
(N'جواد',N'جوادی','09121234567','alimohammditest@gmail.com',N'البرز',N'هشتگرد',N'مصلی',N'میدان تست پلاک ۱'),
(N'محمد',N'محمدی','09127654321','mohammadmohammadi@gmail.com',N'البرز',N'کرج',N'مطهری',N'جنب فروشگاه بزرگ فلان') ;
GO

INSERT INTO [Service] ([Name], [Cost], [Category])
VALUES
(N'کت ساده', 7800, N'خشکشویی'),
(N'شلوار ساده', 4800, N'خشکشویی'),
(N'اورکت ساده', 8400, N'خشکشویی'),
(N'پیراهن مردانه', 4800, N'خشکشویی'),
(N'کت ساده', 4200, N'اتوکشی'),
(N'شلوار ساده', 3000, N'اتوکشی'),
(N'اورکت ساده', 4200, N'اتوکشی'),
(N'پیراهن مردانه', 3000, N'اتوکشی');
Go

INSERT INTO [Order] (Employee_ID, Customer_ID, Service_ID, [Name], [Description], Cost, [Date], [DeliveryDate])
VALUES
(1,1,1,N'کت آبی', '',  5000, '2016/02/02 12:00:00', '2016/02/05 12:00:00'),
(1,2,1,N'پیراهن صورتی', '',  5000, '2016/02/03 12:02:00', '2016/02/06 12:00:00');
GO

SELECT * FROM Employee ;
GO

SELECT * FROM Customer ;
GO

SELECT * FROM [Service] ;
GO

SELECT * FROM [Order] ;
GO