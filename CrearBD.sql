-- Crear la base de datos
CREATE DATABASE CrudWinForm;
GO

-- Usar la base de datos
USE CrudWinForm;
GO

-- Crear la tabla 'people'
CREATE TABLE people (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    age INT NOT NULL
);
GO

