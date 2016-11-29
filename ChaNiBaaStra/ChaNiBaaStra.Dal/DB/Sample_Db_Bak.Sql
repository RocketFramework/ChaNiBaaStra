USE [master]
GO

/****** Object:  Database [School_N]    Script Date: 10/13/2014 2:50:29 PM ******/
CREATE DATABASE [School_N]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School_N', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\School_N.mdf' , SIZE = 5072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'School_N_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\School_N_log.ldf' , SIZE = 2024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [School_N] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School_N].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [School_N] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [School_N] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [School_N] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [School_N] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [School_N] SET ARITHABORT OFF 
GO

ALTER DATABASE [School_N] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [School_N] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [School_N] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [School_N] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [School_N] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [School_N] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [School_N] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [School_N] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [School_N] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [School_N] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [School_N] SET  DISABLE_BROKER 
GO

ALTER DATABASE [School_N] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [School_N] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [School_N] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [School_N] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [School_N] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [School_N] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [School_N] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [School_N] SET RECOVERY FULL 
GO

ALTER DATABASE [School_N] SET  MULTI_USER 
GO

ALTER DATABASE [School_N] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [School_N] SET DB_CHAINING OFF 
GO

ALTER DATABASE [School_N] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [School_N] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [School_N] SET  READ_WRITE 
GO

USE [School_N]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditTrail]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditTrail](
	[AuditTrailId] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [varchar](50) NULL,
	[RevisionStamp] [datetime] NULL,
	[TableName] [varchar](50) NULL,
	[TablePrimaryId] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Actions] [varchar](50) NULL,
	[OldData] [xml] NULL,
	[NewData] [xml] NULL,
	[ChangedColumns] [varchar](1000) NULL,
 CONSTRAINT [PK_DBAudit] PRIMARY KEY CLUSTERED 
(
	[AuditTrailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Period] [int] NOT NULL,
	[IsWeekEnd] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Data]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Data](
	[DataId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[DataString] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Data] PRIMARY KEY CLUSTERED 
(
	[DataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[OfficeAddressId] [int] NOT NULL,
	[HomeAddressId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[RegisteredDate] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
	[Description] [varchar](250) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 10/13/2014 2:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentCourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Data]  WITH CHECK ADD  CONSTRAINT [FK_Data_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Data] CHECK CONSTRAINT [FK_Data_Course]
GO
ALTER TABLE [dbo].[Data]  WITH CHECK ADD  CONSTRAINT [FK_Data_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Data] CHECK CONSTRAINT [FK_Data_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Address] FOREIGN KEY([OfficeAddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Address]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Address1] FOREIGN KEY([HomeAddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Address1]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO

USE [School_N];
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

