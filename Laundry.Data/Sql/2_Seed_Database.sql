USE Laundry;
GO

INSERT INTO Employee (E_FirstName, E_LastName, E_Phone, E_NCode, E_Email, E_Salary, E_EmergencyPhone, E_Gender, E_State, E_City, E_Street, E_Other)
VALUES
(N'حمیدرضا',N'همت یار','091210000000', '0021265984','hamidrez77@gmail.com',1000000,'02666789876',N'مرد',N'البرز',N'کردان',N'شهید فلانی',N'کوچه ی فلان ساختمان فلان پلاک فلان'),
(N'تست',N'تستی','09126785467', '2334569518','testtesti@gmail.com',1200000,'02156786798',N'مرد',N'تهران',N'تهران',N'ولیعصر',N'کوچه تست پلاک ۳') ;
GO

INSERT INTO Customer (C_FirstName, C_LastName, C_Phone, C_State, C_City, C_Street, C_Other)
VALUES
(N'علی',N'محمدی','09121234567', N'تهران',N'تهران',N'آزادی',N'کوچه تست پلاک ۳'),
(N'سعید',N'سعیدی','09121243567', N'تهران',N'تهران',N'شریعتی',N'کوچه تست پلاک ۴'),
(N'جواد',N'جوادی','09121234457', N'البرز',N'هشتگرد',N'مصلی',N'میدان تست پلاک ۱'),
(N'محمد',N'محمدی','09127654321', N'البرز',N'کرج',N'مطهری',N'جنب فروشگاه بزرگ فلان') ;
GO

INSERT INTO [Service] (S_Name, S_Cost, S_Category)
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

INSERT INTO [Order] (E_NCode, C_Phone, S_ID, O_Name, O_Description, O_Cost, O_Date, O_DeliveryDate)
VALUES
('0021265984','09121234567',1,N'کت آبی', '',  5000, '2018/05/16 14:00:00', '2018/05/19 14:00:00'),
('2334569518','09127654321',1,N'پیراهن صورتی', '',  5000, '2018/05/15 18:32:30', '2018/05/18 18:32:30');
GO

SELECT * FROM Employee ;
GO

SELECT * FROM Customer ;
GO

SELECT * FROM [Service] ;
GO

SELECT * FROM [Order] ;
GO
