USE [master];
GO

-- Criar o banco de dados ShopDB
CREATE DATABASE ShopDB;
GO

USE [ShopDB];
GO

-- Criar a tabela Product
CREATE TABLE Product
(
    Id       INT IDENTITY PRIMARY KEY,
    Name     NVARCHAR(255) NOT NULL,
    Price    FLOAT,
    Category NVARCHAR(255)
);
GO

-- Criar o procedimento armazenado FilterProducts
CREATE PROCEDURE FilterProducts
    @p_name NVARCHAR(255) = NULL,
    @p_price_min FLOAT = NULL,
    @p_price_max FLOAT = NULL,
    @p_category NVARCHAR(255) = NULL
AS
BEGIN
    SELECT *
    FROM Product
    WHERE (Name LIKE '%' + @p_name + '%')
      AND (Price >= ISNULL(@p_price_min, Price))
      AND (Price <= ISNULL(@p_price_max, Price))
      AND (Category = @p_category);
END;
GO
