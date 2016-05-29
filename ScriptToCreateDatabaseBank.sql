USE [master]
GO

/****** Object:  Database [Bank]    Script Date: 2016-05-12 23:43:44 ******/
CREATE DATABASE [Bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER2014\MSSQL\DATA\Bank.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bank_log', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER2014\MSSQL\DATA\Bank_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Bank] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Bank] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Bank] SET ARITHABORT OFF 
GO

ALTER DATABASE [Bank] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Bank] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Bank] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Bank] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Bank] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Bank] SET RECOVERY FULL 
GO

ALTER DATABASE [Bank] SET  MULTI_USER 
GO

ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Bank] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Bank] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Bank] SET  READ_WRITE 
GO





-- =========================================
--tables

USE [Bank]
GO

/****** Object:  Table [dbo].[AccountDetails]    Script Date: 2016-05-12 23:48:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[accountNumber] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[street] [nvarchar](70) NOT NULL,
	[buildingNumber] [nvarchar](20) NOT NULL,
	[apartmentNumber] [nvarchar](20) NOT NULL,
	[postcode] [nvarchar](15) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[accountBalance] [int] NOT NULL,
	[creationDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_AccountDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [Bank]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 2016-05-12 23:56:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[accountNumber] [uniqueidentifier] NOT NULL,
	[amount] [int] NOT NULL,
	[operationType] [nvarchar](50) NOT NULL,
	[operationDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [Bank]
GO

/****** Object:  Table [dbo].[UserCredentials]    Script Date: 2016-05-12 23:56:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCredentials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[accountNumber] [uniqueidentifier] NOT NULL,
	[clientNumber] [nvarchar](50) NOT NULL,
	[saltedPassword] [nvarchar](300) NOT NULL,
	[salt] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_UserCredentials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--=================================
--procedures

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spAddNewAccount]    Script Date: 2016-05-12 23:57:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddNewAccount]
@accountNumber uniqueidentifier,
@name nvarchar(50),
@surname nvarchar(50),
@street nvarchar(70),
@buildingNumber int,
@apartmentNumber int,
@postcode nvarchar(15),
@city nvarchar(50),
@accountBalance int,
@clientNumber nvarchar(50),
@saltedPassword nvarchar(300),
@salt nvarchar(300),
@creationDate smalldatetime
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO [Bank].[dbo].[AccountDetails] (accountNumber,name,surname,street,buildingNumber,apartmentNumber,postcode,city,accountBalance,creationDate) 
			VALUES (@accountNumber,@name,@surname,@street,@buildingNumber,@apartmentNumber,@postcode,@city,@accountBalance,@creationDate)

			INSERT INTO [Bank].[dbo].[UserCredentials] (accountNumber,clientNumber,saltedPassword,salt)
			VALUES (@accountNumber,@clientNumber,@saltedPassword,@salt)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spDepositMoney]    Script Date: 2016-05-12 23:57:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDepositMoney]
@accountNumber uniqueidentifier,
@amount int,
@operationType nvarchar(50),
@operationDate smalldatetime
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN

			INSERT INTO [Bank].[dbo].[Transactions] (accountNumber, amount, operationType, operationDate)
			VALUES (@accountNumber,@amount,@operationType,@operationDate)

			UPDATE [Bank].[dbo].[AccountDetails]
			SET accountBalance = accountBalance + @amount
			WHERE accountNumber = @accountNumber

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spReturnAccountBalance]    Script Date: 2016-05-12 23:57:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spReturnAccountBalance]
@accountNumber uniqueidentifier
AS
BEGIN
	SELECT [accountBalance]
	FROM [Bank].[dbo].[AccountDetails]
	WHERE [accountNumber] = @accountNumber 
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spReturnAccountDetails]    Script Date: 2016-05-12 23:57:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReturnAccountDetails]
@accountNumber uniqueidentifier
AS
BEGIN
	SELECT [Id], [accountNumber], [name], [surname], [street], [buildingNumber], [apartmentNumber], [postcode], [city], [accountBalance],[creationDate]
	FROM [Bank].[dbo].[AccountDetails]
	WHERE [accountNumber] = @accountNumber
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spReturnAllClientNumbers]    Script Date: 2016-05-12 23:58:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReturnAllClientNumbers]
AS
BEGIN
	SELECT [clientNumber]
	FROM [Bank].[dbo].[UserCredentials]
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spReturnAllTransactions]    Script Date: 2016-05-12 23:58:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReturnAllTransactions]
@accountNumber uniqueidentifier
AS
BEGIN
	SELECT amount, operationType, operationDate
	FROM [Bank].[dbo].[Transactions]
	WHERE [accountNumber] = @accountNumber
END
GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spReturnSaltAndSaltedPassword]    Script Date: 2016-05-12 23:58:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spReturnSaltAndSaltedPassword]
@clientNumber nvarchar(50)
AS
BEGIN
	SELECT [salt],[saltedPassword],[accountNumber]
	FROM [Bank].[dbo].[UserCredentials]
	WHERE [clientNumber] = @clientNumber
END

GO

USE [Bank]
GO

/****** Object:  StoredProcedure [dbo].[spWithdrawMoney]    Script Date: 2016-05-12 23:58:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spWithdrawMoney]
@accountNumber uniqueidentifier,
@amount int,
@operationType nvarchar(50),
@operationDate smalldatetime
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN

			INSERT INTO [Bank].[dbo].[Transactions] (accountNumber, amount, operationType, operationDate)
			VALUES (@accountNumber,@amount,@operationType,@operationDate)

			UPDATE [Bank].[dbo].[AccountDetails]
			SET accountBalance = accountBalance - @amount
			WHERE accountNumber = @accountNumber

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END

GO

