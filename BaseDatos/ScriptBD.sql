USE [master]
GO
/****** Object:  Database [Lab2]    Script Date: 2/18/2021 5:43:16 PM ******/
CREATE DATABASE [Lab2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lab2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Lab2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lab2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Lab2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Lab2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lab2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lab2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lab2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lab2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lab2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lab2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lab2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lab2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lab2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lab2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lab2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lab2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lab2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lab2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lab2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lab2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lab2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lab2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lab2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lab2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lab2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lab2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lab2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lab2] SET RECOVERY FULL 
GO
ALTER DATABASE [Lab2] SET  MULTI_USER 
GO
ALTER DATABASE [Lab2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lab2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lab2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lab2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lab2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lab2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Lab2', N'ON'
GO
ALTER DATABASE [Lab2] SET QUERY_STORE = OFF
GO
USE [Lab2]
GO
/****** Object:  Table [dbo].[TBL_Clientes]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[FechaNac] [datetime] NOT NULL,
	[Edad] [int] NOT NULL,
	[EstadoCivil] [nvarchar](50) NOT NULL,
	[Genero] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Creditos]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Creditos](
	[Id_Credito] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [float] NOT NULL,
	[Tasa] [float] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Cuota] [float] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[SaldoOperacion] [float] NOT NULL,
	[Cliente] [int] NOT NULL,
 CONSTRAINT [PK_Creditos] PRIMARY KEY CLUSTERED 
(
	[Id_Credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Cuentas]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Cuentas](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Moneda] [nvarchar](50) NOT NULL,
	[Saldo] [float] NOT NULL,
	[Cliente] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Direcciones]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Direcciones](
	[Id_Direccion] [int] IDENTITY(1,1) NOT NULL,
	[Provincia] [nvarchar](50) NOT NULL,
	[Canton] [nvarchar](50) NOT NULL,
	[Distrito] [nvarchar](50) NOT NULL,
	[Cliente] [int] NOT NULL,
 CONSTRAINT [PK_TBL_Direcciones] PRIMARY KEY CLUSTERED 
(
	[Id_Direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CRE_CLIENTE_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_CLIENTE_PR]
	@P_Cedula nvarchar(50),
	@P_Nombre nvarchar(50),
	@P_Apellido nvarchar(50),
	@P_FechaNac datetime,
	@P_Edad int,
	@P_EstadoCivil nvarchar(50),
	@P_Genero nvarchar(50)
AS
	INSERT INTO [dbo].[TBL_Clientes] VALUES(@P_Cedula,@P_Nombre,@P_Apellido,@P_FechaNac,@P_Edad,@P_EstadoCivil,@P_Genero);
GO
/****** Object:  StoredProcedure [dbo].[CRE_CREDITO_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_CREDITO_PR] 
	@P_Monto float,
	@P_Tasa float,
	@P_Nombre nvarchar(50),
	@P_Cuota float,
	@P_FechaInicio datetime,
	@P_Estado nvarchar(50),
	@P_SaldoOperacion float,
	@P_Cliente int
AS
	INSERT INTO [dbo].[TBL_Creditos](Monto,Tasa,Nombre,Cuota,FechaInicio,Estado,SaldoOperacion,Cliente) VALUES(@P_Monto,@P_Tasa,@P_Nombre,@P_Cuota,@P_FechaInicio,@P_Estado,@P_SaldoOperacion,@P_Cliente);
GO
/****** Object:  StoredProcedure [dbo].[CRE_CUENTA_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_CUENTA_PR]
	@P_Nombre nvarchar(50),
	@P_Moneda nvarchar(50),
	@P_Saldo float,
	@P_Cliente int
AS
	INSERT INTO [dbo].[TBL_Cuentas](Nombre,Moneda,Saldo,Cliente) VALUES(@P_Nombre,@P_Moneda,@P_Saldo,@P_Cliente);
GO
/****** Object:  StoredProcedure [dbo].[CRE_DIRECCION_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_DIRECCION_PR] 
	@P_Provincia nvarchar(50),
	@P_Canton nvarchar(50),
	@P_Distrito nvarchar(50),
	@P_Cliente int
AS
	INSERT INTO dbo.TBL_Direcciones VALUES(@P_Provincia,@P_Canton,@P_Distrito,@P_Cliente);
GO
/****** Object:  StoredProcedure [dbo].[DEL_CLIENTE_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_CLIENTE_PR]
	@P_Id_Cliente int
AS
	DELETE FROM TBL_Clientes WHERE Id_Cliente=@P_Id_Cliente;
GO
/****** Object:  StoredProcedure [dbo].[DEL_CREDITO_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DELETE Credito
CREATE PROCEDURE [dbo].[DEL_CREDITO_PR]
	@P_Id_Credito int
AS
	DELETE FROM TBL_Creditos WHERE Id_Credito=@P_Id_Credito;
GO
/****** Object:  StoredProcedure [dbo].[DEL_CUENTA_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_CUENTA_PR]
	@P_Id_Cuenta int
AS
	DELETE FROM TBL_Cuentas WHERE Id_Cuenta=@P_Id_Cuenta;
GO
/****** Object:  StoredProcedure [dbo].[DEL_DIRECCION_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_DIRECCION_PR]
	@P_Id_Direccion int
AS
	DELETE FROM TBL_Direcciones WHERE Id_Direccion=@P_Id_Direccion;
GO
/****** Object:  StoredProcedure [dbo].[IDENTITY_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDENTITY_PR]
AS
	SELECT @@IDENTITY as id;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_CLIENTES_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_CLIENTES_PR]
AS
	--SELECT Id_Cliente, Cedula, Nombre, Apellido, FechaNac, Edad, EstadoCivil, Genero, Direccion FROM TBL_Clientes;
	SELECT * FROM TBL_Clientes;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_CREDITOS_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_CREDITOS_PR]
AS
	--SELECT Id_Credito, Monto, Tasa, Nombre, Cuota, FechaInicio, Estado, SaldoOperacion, Cliente FROM TBL_Creditos;
	SELECT * FROM TBL_Creditos;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_CUENTAS_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_CUENTAS_PR]
AS
	SELECT * FROM TBL_Cuentas;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_DIRECCIONES_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RETRIEVE ALL Direcciones
CREATE PROCEDURE [dbo].[RET_ALL_DIRECCIONES_PR]
AS
	--SELECT Id_Direccion, Provincia, Canton, Distrito FROM TBL_Clientes;
	SELECT * FROM TBL_Direcciones;
GO
/****** Object:  StoredProcedure [dbo].[RET_CLIENTE_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_CLIENTE_PR]
	@P_Id_Cliente int
AS
	SELECT * FROM TBL_Clientes WHERE Id_Cliente=@P_Id_Cliente;
GO
/****** Object:  StoredProcedure [dbo].[RET_CREDITO_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RET Creditos BY ID
CREATE PROCEDURE [dbo].[RET_CREDITO_PR]
	@P_Id_Credito int
AS
	SELECT * FROM TBL_Creditos WHERE Id_Credito=@P_Id_Credito;
GO
/****** Object:  StoredProcedure [dbo].[RET_CUENTA_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_CUENTA_PR]
	@P_Id_Cuenta int
AS
	SELECT * FROM TBL_Cuentas WHERE Id_Cuenta=@P_Id_Cuenta;
GO
/****** Object:  StoredProcedure [dbo].[RET_DIRECCION_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RET Direccion BY ID
CREATE PROCEDURE [dbo].[RET_DIRECCION_PR]
	@P_Id_Direccion int
AS
	SELECT * FROM TBL_Direcciones WHERE Id_Direccion=@P_Id_Direccion;
GO
/****** Object:  StoredProcedure [dbo].[UPD_CLIENTE_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_CLIENTE_PR]
	@P_Id_Cliente int,
	@P_Cedula nvarchar(50),
	@P_Nombre nvarchar(50),
	@P_Apellido nvarchar(50),
	@P_FechaNac datetime,
	@P_Edad int,
	@P_EstadoCivil nvarchar(50),
	@P_Genero nvarchar(50)
AS
	UPDATE [dbo].[TBL_Clientes] SET Cedula=@P_Cedula, Nombre=@P_Nombre, Apellido=@P_Apellido, FechaNac=@P_FechaNac, Edad=@P_Edad, EstadoCivil=@P_EstadoCivil, Genero=@P_Genero WHERE Id_Cliente=@P_Id_Cliente;
GO
/****** Object:  StoredProcedure [dbo].[UPD_CREDITO_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE Creditos
CREATE PROCEDURE [dbo].[UPD_CREDITO_PR]
	@P_Id_Credito int,
	@P_Monto float,
	@P_Tasa float,
	@P_Nombre nvarchar(50),
	@P_Cuota float,
	@P_FechaInicio datetime,
	@P_Estado nvarchar(10),
	@P_SaldoOperacion float,
	@P_Cliente int
AS
	UPDATE [dbo].[TBL_Creditos] SET Monto=@P_Monto, Tasa=@P_Tasa, Nombre=@P_Nombre, Cuota=@P_Cuota, FechaInicio=@P_FechaInicio, Estado=@P_Estado, SaldoOperacion=@P_SaldoOperacion, Cliente=@P_Cliente WHERE Id_Credito=@P_Id_Credito;
GO
/****** Object:  StoredProcedure [dbo].[UPD_CUENTA_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE Cuentas
CREATE PROCEDURE [dbo].[UPD_CUENTA_PR]
	@P_Id_Cuenta int,
	@P_Nombre nvarchar(50),
	@P_Moneda nvarchar(50),
	@P_Saldo float,
	@P_Cliente int
AS
	UPDATE [dbo].[TBL_Cuentas] SET Nombre=@P_Nombre, Moneda=@P_Moneda, Saldo=@P_Saldo, Cliente=@P_Cliente WHERE Id_Cuenta=@P_Id_Cuenta;
GO
/****** Object:  StoredProcedure [dbo].[UPD_DIRECCION_PR]    Script Date: 2/18/2021 5:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_DIRECCION_PR]
	@P_Id_Direccion int,
	@P_Provincia nvarchar(15),
	@P_Canton nvarchar(50),
	@P_Distrito nvarchar(50)
AS
	UPDATE [dbo].[TBL_Direcciones] SET Provincia=@P_Provincia, Canton=@P_Canton, Distrito=@P_Distrito WHERE Id_Direccion=@P_Id_Direccion;
GO
USE [master]
GO
ALTER DATABASE [Lab2] SET  READ_WRITE 
GO
