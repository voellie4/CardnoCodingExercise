USE [master]
GO
/****** Object:  Database [DbCandidate]    Script Date: 6/1/2019 4:36:19 PM ******/
CREATE DATABASE [DbCandidate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbCandidate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DbCandidate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbCandidate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DbCandidate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DbCandidate] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbCandidate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbCandidate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbCandidate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbCandidate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbCandidate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbCandidate] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbCandidate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbCandidate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbCandidate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbCandidate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbCandidate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbCandidate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbCandidate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbCandidate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbCandidate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbCandidate] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbCandidate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbCandidate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbCandidate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbCandidate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbCandidate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbCandidate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbCandidate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbCandidate] SET RECOVERY FULL 
GO
ALTER DATABASE [DbCandidate] SET  MULTI_USER 
GO
ALTER DATABASE [DbCandidate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbCandidate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbCandidate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbCandidate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbCandidate] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbCandidate', N'ON'
GO
ALTER DATABASE [DbCandidate] SET QUERY_STORE = OFF
GO
USE [DbCandidate]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DbCandidate]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/1/2019 4:36:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 6/1/2019 4:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[CandidateId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[ZipCode] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_dbo.Candidates] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 6/1/2019 4:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifications](
	[QualificationId] [int] IDENTITY(1,1) NOT NULL,
	[QualificationType] [nvarchar](30) NULL,
	[QualificationName] [nvarchar](max) NULL,
	[DateStarted] [datetime] NULL,
	[DateCompleted] [datetime] NULL,
	[CandidateId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Qualifications] PRIMARY KEY CLUSTERED 
(
	[QualificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Email]    Script Date: 6/1/2019 4:36:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Email] ON [dbo].[Candidates]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PhoneNumber]    Script Date: 6/1/2019 4:36:21 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PhoneNumber] ON [dbo].[Candidates]
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CandidateId]    Script Date: 6/1/2019 4:36:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_CandidateId] ON [dbo].[Qualifications]
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Qualifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Qualifications_dbo.Candidates_CandidateId] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidates] ([CandidateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Qualifications] CHECK CONSTRAINT [FK_dbo.Qualifications_dbo.Candidates_CandidateId]
GO
/****** Object:  StoredProcedure [dbo].[procCandidateSelect]    Script Date: 6/1/2019 4:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vo,Ellie
-- Create date: 05/31/2019
-- Description:	select candidate based on selected criteria
-- =============================================
CREATE PROCEDURE [dbo].[procCandidateSelect] 
	@FirstName varchar(25) = null,
	@LastName varchar(25) = null,
	@Email varchar(150) = null,
	@PhoneNumber varchar(20) = null,
	@ZipCode varchar(5) = null,
	@QualificationType varchar(Max) = null,
	@QualificationName varchar(Max) = null,
	@SearchDate datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Prepare multiple Qualification Type and Name
	IF ISNULL(@QualificationType,'') <> ''
		SET @QualificationType = '|' + @QualificationType

	IF ISNULL(@QualificationName,'') <> ''
		SET @QualificationName = '|' + @QualificationName

    -- select list of candidate with search criteria
	SELECT distinct c.*
	FROM Candidates c LEFT JOIN Qualifications q ON c.CandidateID = q.CandidateId
	WHERE (@FirstName IS NULL OR c.FirstName LIKE @FirstName)
		AND (@LastName IS NULL OR c.LastName LIKE @LastName)
		AND (@Email IS NULL OR c.Email LIKE @Email)
		AND (@PhoneNumber IS NULL OR c.PhoneNumber LIKE @PhoneNumber)
		AND (@ZipCode IS NULL OR c.ZipCode LIKE @ZipCode)
		AND (@QualificationType IS NULL OR @QualificationType LIKE '%|' + q.QualificationType + '|%')
		AND (@QualificationName IS NULL OR @QualificationName LIKE '%|' + q.QualificationName + '|%')
		AND (@SearchDate IS NULL OR (q.DateStarted = DATEADD(MONTH,-1,@SearchDate) OR q.DateCompleted = DATEADD(MONTH,1,@SearchDate))) 
	ORDER BY c.FirstName, c.LastName
END
GO
USE [master]
GO
ALTER DATABASE [DbCandidate] SET  READ_WRITE 
GO
