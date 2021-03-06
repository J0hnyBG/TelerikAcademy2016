USE [master]
GO
/****** Object:  Database [Computers]    Script Date: 08.11.2016 17:24:11 ******/
CREATE DATABASE [Computers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Computers', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Computers.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Computers_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Computers_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Computers] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Computers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Computers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Computers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Computers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Computers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Computers] SET ARITHABORT OFF 
GO
ALTER DATABASE [Computers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Computers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Computers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Computers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Computers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Computers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Computers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Computers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Computers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Computers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Computers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Computers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Computers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Computers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Computers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Computers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Computers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Computers] SET RECOVERY FULL 
GO
ALTER DATABASE [Computers] SET  MULTI_USER 
GO
ALTER DATABASE [Computers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Computers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Computers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Computers] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Computers] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Computers', N'ON'
GO
USE [Computers]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Memory] [float] NOT NULL,
	[CpuId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Model] [nvarchar](50) NULL,
	[VendorId] [int] NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersGpus]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersGpus](
	[ComputerId] [int] NOT NULL,
	[GpuId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersGpus] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[GpuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersStorages]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersStorages](
	[ComputerId] [int] NOT NULL,
	[StorageId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersStorages] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[StorageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputerTypes]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ComputerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cpus]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cores] [int] NOT NULL,
	[ClockCycles] [float] NOT NULL,
	[Model] [nvarchar](50) NULL,
	[VendorId] [int] NOT NULL,
 CONSTRAINT [PK_Cpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gpus]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gpus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Memory] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Model] [nvarchar](50) NULL,
	[VendorId] [int] NULL,
 CONSTRAINT [PK_Gpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GpuTypes]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GpuTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GpuTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Storages]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageTypes]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StorageType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 08.11.2016 17:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_ComputerTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ComputerTypes] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_ComputerTypes]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_Cpus] FOREIGN KEY([CpuId])
REFERENCES [dbo].[Cpus] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_Cpus]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_Vendors]
GO
ALTER TABLE [dbo].[ComputersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGpus_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersGpus] CHECK CONSTRAINT [FK_ComputersGpus_Computers]
GO
ALTER TABLE [dbo].[ComputersGpus]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGpus_Gpus] FOREIGN KEY([GpuId])
REFERENCES [dbo].[Gpus] ([Id])
GO
ALTER TABLE [dbo].[ComputersGpus] CHECK CONSTRAINT [FK_ComputersGpus_Gpus]
GO
ALTER TABLE [dbo].[ComputersStorages]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorages_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorages] CHECK CONSTRAINT [FK_ComputersStorages_Computers]
GO
ALTER TABLE [dbo].[ComputersStorages]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorages_Storages] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storages] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorages] CHECK CONSTRAINT [FK_ComputersStorages_Storages]
GO
ALTER TABLE [dbo].[Cpus]  WITH CHECK ADD  CONSTRAINT [FK_Cpus_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Cpus] CHECK CONSTRAINT [FK_Cpus_Vendors]
GO
ALTER TABLE [dbo].[Gpus]  WITH CHECK ADD  CONSTRAINT [FK_Gpus_GpuTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[GpuTypes] ([Id])
GO
ALTER TABLE [dbo].[Gpus] CHECK CONSTRAINT [FK_Gpus_GpuTypes]
GO
ALTER TABLE [dbo].[Gpus]  WITH CHECK ADD  CONSTRAINT [FK_Gpus_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Gpus] CHECK CONSTRAINT [FK_Gpus_Vendors]
GO
ALTER TABLE [dbo].[Storages]  WITH CHECK ADD  CONSTRAINT [FK_Storages_StorageTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[StorageTypes] ([Id])
GO
ALTER TABLE [dbo].[Storages] CHECK CONSTRAINT [FK_Storages_StorageTypes]
GO
USE [master]
GO
ALTER DATABASE [Computers] SET  READ_WRITE 
GO
