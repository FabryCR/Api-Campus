USE [master]
GO
/****** Object:  Database [CampusMatricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
CREATE DATABASE [CampusMatricula]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CampusMatricula', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CampusMatricula.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CampusMatricula_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CampusMatricula_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CampusMatricula] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CampusMatricula].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CampusMatricula] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CampusMatricula] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CampusMatricula] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CampusMatricula] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CampusMatricula] SET ARITHABORT OFF 
GO
ALTER DATABASE [CampusMatricula] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CampusMatricula] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CampusMatricula] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CampusMatricula] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CampusMatricula] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CampusMatricula] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CampusMatricula] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CampusMatricula] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CampusMatricula] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CampusMatricula] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CampusMatricula] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CampusMatricula] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CampusMatricula] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CampusMatricula] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CampusMatricula] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CampusMatricula] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CampusMatricula] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CampusMatricula] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CampusMatricula] SET  MULTI_USER 
GO
ALTER DATABASE [CampusMatricula] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CampusMatricula] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CampusMatricula] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CampusMatricula] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CampusMatricula] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CampusMatricula] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CampusMatricula', N'ON'
GO
ALTER DATABASE [CampusMatricula] SET QUERY_STORE = OFF
GO
USE [CampusMatricula]
GO
/****** Object:  User [UsuarioWarehouse]    Script Date: 16 ago. 2022 09:46:11 PM ******/
CREATE USER [UsuarioWarehouse] FOR LOGIN [UsuarioWarehouse] WITH DEFAULT_SCHEMA=[UsuarioWarehouse]
GO
/****** Object:  User [UserWarehouse]    Script Date: 16 ago. 2022 09:46:11 PM ******/
CREATE USER [UserWarehouse] FOR LOGIN [UserWarehouse] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [UsuarioWarehouse]    Script Date: 16 ago. 2022 09:46:11 PM ******/
CREATE SCHEMA [UsuarioWarehouse]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](25) NOT NULL,
	[Fecha] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Creditos] [int] NOT NULL,
	[Carrera] [varchar](25) NOT NULL,
	[CuposDisponibles] [int] NOT NULL,
	[Horario] [varchar](25) NOT NULL,
	[IdProfesor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](25) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido1] [varchar](25) NOT NULL,
	[Apellido2] [varchar](25) NOT NULL,
	[Contraseña] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[IDMatricula] [int] IDENTITY(1,1) NOT NULL,
	[MontoMatricula] [money] NOT NULL,
	[IdEstudiante] [int] NULL,
	[IdCurso] [int] NULL,
	[FechaMatricula] [datetime] NOT NULL,
 CONSTRAINT [PK__Matricul__3604C97DF2F9A0B2] PRIMARY KEY CLUSTERED 
(
	[IDMatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[IdProfesor] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](25) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[Apellido2] [varchar](25) NOT NULL,
	[Contraseña] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesor] ([IdProfesor])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK__Matricula__IdCur__2D27B809] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK__Matricula__IdCur__2D27B809]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK__Matricula__IdEst__2E1BDC42] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiantes] ([IdEstudiante])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK__Matricula__IdEst__2E1BDC42]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCurso]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[ActualizarCurso]
@idCurso INT,
@nombre VARCHAR(20),
@creditos INT,
@carrera VARCHAR(20),
@idProfesor INT,
@cuposDisponibles INT,
@horario VARCHAR(20)
AS
BEGIN
    UPDATE CURSO set 
    Nombre= @nombre, Creditos = @creditos, Carrera = @carrera, CuposDisponibles = @cuposDisponibles, Horario = @horario, IDProfesor = @idProfesor
    WHERE IDCurso = @idCurso
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstudiante]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ActualizarEstudiante]
@idEstudiante int,
@cedula VARCHAR(20),
@nombre VARCHAR(20),
@apellido1 VARCHAR(20),
@apellido2 VARCHAR(20),
@contraseña VARCHAR(20)
AS
BEGIN
    UPDATE Estudiantes set 
	Cedula = @cedula, Nombre =@nombre,Apellido1=@apellido1,Apellido2=@apellido2,Contraseña=@contraseña
    WHERE IdEstudiante = @idEstudiante
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMatricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ActualizarMatricula]
@idMatricula int,
@montoMatricula money,
@idEstudiante int,
@idCurso int

AS
BEGIN
    UPDATE Matricula set 
	MontoMatricula = @montoMatricula, IdEstudiante =@idEstudiante,IdCurso=@idCurso
    WHERE IDMatricula = @idMatricula
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarProfesor]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ActualizarProfesor]
@idProfesor int,
@cedula VARCHAR(20),
@nombre VARCHAR(20),
@apellido VARCHAR(20),
@apellido2 VARCHAR(20),
@contraseña VARCHAR(20)
AS
BEGIN
    UPDATE Profesor set 
	Cedula = @cedula, Nombre =@nombre,Apellido=@apellido,Apellido2=@apellido2,Contraseña=@contraseña
    WHERE IdProfesor = @idProfesor
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCurso]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultarCurso]
@idCurso int
AS 
BEGIN
--SELECT * FROM Curso where IdCurso=@idCurso
SELECT Curso.IdCurso, Curso.Nombre, Curso.Creditos, Curso.Carrera, Curso.CuposDisponibles, Curso.Horario, 
Profesor.Nombre + ' ' + Profesor.Apellido + ' ' + Profesor.Apellido2 AS nombreProfesor 
FROM Curso
INNER JOIN Profesor ON Curso.IdProfesor = Profesor.IdProfesor
WHERE IdCurso=@idCurso
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCursos]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultarCursos]
AS 
BEGIN
--SELECT * FROM Curso
SELECT Curso.IdCurso, Curso.Nombre, Curso.Creditos, Curso.Carrera, Curso.CuposDisponibles, Curso.Horario, Profesor.Nombre + ' ' + Profesor.Apellido AS nombreProfesor 
FROM Curso
INNER JOIN Profesor ON Curso.IdProfesor = Profesor.IdProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstudiante]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ConsultarEstudiante]
@idEstudiante int
AS 
BEGIN
SELECT * FROM Estudiantes where IdEstudiante=@idEstudiante
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstudiantes]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarEstudiantes]
AS 
BEGIN
SELECT IdEstudiante,Cedula,Nombre,Apellido1,Apellido2,Contraseña FROM Estudiantes
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarLogin]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultarLogin]
@cedula varchar(25),
@isAdmin bit
AS 
BEGIN

IF @isAdmin = 1  
	SELECT * FROM Profesor where Cedula=@cedula
ELSE   
	SELECT * FROM Estudiantes where Cedula=@cedula
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarMatricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultarMatricula]
@idMatricula int
AS 
BEGIN
--SELECT * FROM Matricula where IDMatricula=@idMatricula
SELECT Matricula.IDMatricula, Matricula.MontoMatricula, Matricula.FechaMatricula, 
Estudiantes.Nombre + ' ' + Estudiantes.Apellido1 + ' ' + Estudiantes.Apellido2 AS nombreEstudiante,
Estudiantes.Cedula AS cedulaEstudiante,
Curso.Nombre + ' [ ' + Curso.Horario + ']' AS nombreCurso 
FROM Matricula
INNER JOIN Estudiantes ON Matricula.IdEstudiante = Estudiantes.IdEstudiante
INNER JOIN Curso ON Curso.IdCurso = Matricula.IdCurso
WHERE IDMatricula = @idMatricula
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarMatriculas]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarMatriculas]
AS 
BEGIN
--SELECT * FROM Matricula
SELECT Matricula.IDMatricula, Matricula.MontoMatricula, Matricula.FechaMatricula, 
Estudiantes.Nombre + ' ' + Estudiantes.Apellido1 + ' ' + Estudiantes.Apellido2 AS nombreEstudiante,
Estudiantes.Cedula AS cedulaEstudiante,
Curso.Nombre + ' [ ' + Curso.Horario + ' ]' AS nombreCurso 
FROM Matricula
INNER JOIN Estudiantes ON Matricula.IdEstudiante = Estudiantes.IdEstudiante
INNER JOIN Curso ON Curso.IdCurso = Matricula.IdCurso
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarMatriculasEstudiante]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultarMatriculasEstudiante]
@cedula varchar(25)
AS 
BEGIN
SELECT Matricula.IDMatricula, Matricula.MontoMatricula, Matricula.FechaMatricula, 
Curso.Nombre + ' [ ' + Curso.Horario + ' ]' AS nombreCurso 
FROM Matricula
INNER JOIN Estudiantes ON Matricula.IdEstudiante = Estudiantes.IdEstudiante
INNER JOIN Curso ON Curso.IdCurso = Matricula.IdCurso
WHERE Estudiantes.Cedula = @cedula
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProfesor]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ConsultarProfesor]
@idProfesor int
AS 
BEGIN
SELECT * FROM Profesor where IdProfesor=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProfesores]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarProfesores]
AS 
BEGIN
SELECT * FROM Profesor
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCurso]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarCurso]
@idCurso INT
AS
BEGIN
DELETE FROM CURSO WHERE IDCurso= @idCurso
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEstudiante]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarEstudiante]
@idEstudiante INT
AS
BEGIN
DELETE FROM Estudiantes WHERE IdEstudiante= @idEstudiante
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarMatricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarMatricula]
@idMatricula int
AS
BEGIN
DELETE FROM Matricula WHERE IDMatricula= @idMatricula
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProfesor]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[EliminarProfesor]
@idProfesor int
AS
BEGIN
DELETE FROM Profesor WHERE IdProfesor= @idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCurso]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[RegistrarCurso]
@nombre VARCHAR(20),
@creditos INT,
@carrera VARCHAR(20),
@idProfesor INT,
@cuposDisponibles INT,
@horario VARCHAR(20)
AS
BEGIN
    INSERT INTO CURSO (Nombre, Creditos, Carrera, CuposDisponibles, Horario,IDProfesor) 
	VALUES (@nombre, @creditos, @carrera, @cuposDisponibles, @horario,@idProfesor)
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarEstudiante]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RegistrarEstudiante]
@cedula VARCHAR(20),
@nombre VARCHAR(20),
@apellido1 VARCHAR(20),
@apellido2 VARCHAR(20),
@contraseña VARCHAR(20)
AS
BEGIN
    INSERT INTO Estudiantes(Cedula,Nombre,Apellido1,Apellido2,Contraseña)
	VALUES (@cedula,@nombre,@apellido1,@apellido2,@contraseña)
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarMatricula]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[RegistrarMatricula]
@montoMatricula money,
@idEstudiante int,
@idCurso int,
@fechaMatricula datetime
AS
BEGIN
    INSERT INTO Matricula(MontoMatricula,IdEstudiante,IdCurso,FechaMatricula)
	VALUES (@montoMatricula,@idEstudiante,@idCurso,@fechaMatricula)
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProfesor]    Script Date: 16 ago. 2022 09:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RegistrarProfesor]
@cedula VARCHAR(20),
@nombre VARCHAR(20),
@apellido VARCHAR(20),
@apellido2 VARCHAR(20),
@contraseña VARCHAR(20)
AS
BEGIN
    INSERT INTO Profesor(Cedula,Nombre,Apellido,Apellido2,Contraseña)
	VALUES (@cedula,@nombre,@apellido,@apellido2,@contraseña)
END;
GO
USE [master]
GO
ALTER DATABASE [CampusMatricula] SET  READ_WRITE 
GO
