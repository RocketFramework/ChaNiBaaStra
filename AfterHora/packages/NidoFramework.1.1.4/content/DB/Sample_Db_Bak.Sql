USE [School];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[Address]([AddressId], [Name], [Description])
SELECT 1, N'Gampaha', N'test description'
COMMIT;
RAISERROR (N'[dbo].[Address]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[AuditTrail] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[AuditTrail]([AuditTrailId], [SystemName], [RevisionStamp], [TableName], [TablePrimaryId], [UserName], [Actions], [OldData], [NewData], [ChangedColumns])
SELECT 1, N'DemoApplication', '20140905 15:11:06.600', N'StudentsSystem.Data.Entity.Core.EntityKey', N'1', N'Nirosh', N'U', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">Gayani</Name></Students>', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">8vA6/ZclVTbzna++FRmz7g==</Name></Students>', NULL UNION ALL
SELECT 2, N'DemoApplication', '20140905 15:11:31.820', N'StudentsSystem.Data.Entity.Core.EntityKey', N'1', N'Nirosh', N'U', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">8vA6/ZclVTbzna++FRmz7g==</Name></Students>', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">AOoz7UdZsx7Pre5H6U5BCmc6MKoP/ICrWt5Bs+miDD8=</Name></Students>', NULL UNION ALL
SELECT 3, N'DemoApplication', '20140905 15:29:38.373', N'StudentsSystem.Data.Entity.Core.EntityKey', N'1', N'Nirosh', N'U', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">AOoz7UdZsx7Pre5H6U5BCmc6MKoP/ICrWt5Bs+miDD8=</Name></Students>', N'<Students xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><OfficeAddressId type="System.Int32">1</OfficeAddressId><Name type="System.String">AOoz7UdZsx7Pre5H6U5BCmc6MKoP/ICrWt5Bs+miDD8=</Name></Students>', NULL
COMMIT;
RAISERROR (N'[dbo].[AuditTrail]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[AuditTrail] OFF;

SET IDENTITY_INSERT [dbo].[Course] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Course]([CourseId], [Name], [StartDate], [EndDate], [Period], [IsWeekEnd], [IsActive])
SELECT 1, N'my first course', '20140101 00:00:00.000', '20140101 00:00:00.000', 6, 1, 1 UNION ALL
SELECT 2, N'Newly added course on 9/5/2014 3:11:03 PM', '20140905 00:00:00.000', '20140905 00:00:00.000', 10, 1, 0 UNION ALL
SELECT 3, N'Newly added course on 9/5/2014 3:11:29 PM', '20140905 00:00:00.000', '20140905 00:00:00.000', 10, 1, 0 UNION ALL
SELECT 4, N'Newly added course on 9/5/2014 3:29:31 PM', '20140905 00:00:00.000', '20140905 00:00:00.000', 10, 1, 0
COMMIT;
RAISERROR (N'[dbo].[Course]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Course] OFF;

SET IDENTITY_INSERT [dbo].[Data] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Data]([DataId], [StudentId], [CourseId], [DataString])
SELECT 1, 1, 1, N'None string'
COMMIT;
RAISERROR (N'[dbo].[Data]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Data] OFF;

SET IDENTITY_INSERT [dbo].[Student] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Student]([StudentId], [OfficeAddressId], [HomeAddressId], [Name], [Age], [Address], [RegisteredDate], [IsActive], [Description])
SELECT 1, 1, 1, N'AOoz7UdZsx7Pre5H6U5BCmc6MKoP/ICrWt5Bs+miDD8=', 308, N'YTI9HV0bw/WdDE3z9qcdgg==', '20140101 00:00:00.000', 1, N'Editted on 9/5/2014 3:29:31 PM'
COMMIT;
RAISERROR (N'[dbo].[Student]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Student] OFF;

SET IDENTITY_INSERT [dbo].[StudentCourse] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[StudentCourse]([StudentCourseId], [CourseId], [StudentId])
SELECT 4, 4, 1
COMMIT;
RAISERROR (N'[dbo].[StudentCourse]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[StudentCourse] OFF;

