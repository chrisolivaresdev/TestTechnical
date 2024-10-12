USE [master]
GO
/****** Object:  Database [DbTechnicalTest]    Script Date: 12/10/2024 8:31:20 a. m. ******/
CREATE DATABASE [DbTechnicalTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbTechnicalTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DbTechnicalTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbTechnicalTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DbTechnicalTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DbTechnicalTest] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbTechnicalTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbTechnicalTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbTechnicalTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbTechnicalTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbTechnicalTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbTechnicalTest] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DbTechnicalTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET RECOVERY FULL 
GO
ALTER DATABASE [DbTechnicalTest] SET  MULTI_USER 
GO
ALTER DATABASE [DbTechnicalTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbTechnicalTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbTechnicalTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbTechnicalTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbTechnicalTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbTechnicalTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbTechnicalTest', N'ON'
GO
ALTER DATABASE [DbTechnicalTest] SET QUERY_STORE = ON
GO
ALTER DATABASE [DbTechnicalTest] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DbTechnicalTest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/10/2024 8:31:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/10/2024 8:31:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TypeElaboration] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/10/2024 8:31:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DbTechnicalTest] SET  READ_WRITE 
GO
