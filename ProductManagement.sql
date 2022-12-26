CREATE DATABASE dbProductManagement;

USE dbProductManagement;

CREATE TABLE tblCategory
(
	CategoryId INT IDENTITY(1,1) PRIMARY KEY,
	Category NVARCHAR(10) NOT NULL UNIQUE
);

INSERT INTO tblCategory VALUES('Category A')
INSERT INTO tblCategory VALUES('Category B')
INSERT INTO tblCategory VALUES('Category C')
INSERT INTO tblCategory VALUES('Category D')

CREATE TABLE tblProducts
(
	ProductId INT IDENTITY(1,1) PRIMARY KEY,
	ProductCode NVARCHAR(25) UNIQUE NOT NULL,
	ProductName NVARCHAR(250) NOT NULL,
	ProductDescription NVARCHAR(4000) NOT NULL,
	ExpiryDate DATE CHECK (ExpiryDate >	GETDATE()) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES tblCategory(CategoryId) ON DELETE NO ACTION NOT NULL,
	ProductImage NVARCHAR(200),
	IsActive BIT DEFAULT(1),
	CreationDate DATE NOT NULL,
);

CREATE PROCEDURE spAddProduct
@code NVARCHAR(25), @name NVARCHAR(250), @description NVARCHAR(4000), @expiry DATE, @category INT, @image NVARCHAR(100), @status BIT, @date DATE
AS
BEGIN
	INSERT INTO tblProducts 
	VALUES(@code, @name, @description, @expiry, @category, @image, @status, @date)
END

CREATE PROCEDURE spViewProducts
AS
BEGIN
	SET NOCOUNT ON;
	SELECT P.*, C.Category FROM tblProducts AS P JOIN tblCategory AS C ON P.CategoryId = C.CategoryId ORDER BY ProductId DESC
END

