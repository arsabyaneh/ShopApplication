CREATE DATABASE Shop
GO

USE Shop
GO

CREATE TABLE Customer(
	ID			BIGINT IDENTITY NOT NULL PRIMARY KEY,
	Code		CHAR(5) NOT NULL UNIQUE,
	FirstName	NVARCHAR(50) NOT NULL,
	LastName	NVARCHAR(50) NOT NULL,
	Gender		BIT NOT NULL,
	BirthDate	DATE NOT NULL,
	Country		NVARCHAR(50) NOT NULL,
	Telephone	NVARCHAR(20) NOT NULL,
	Address		NVARCHAR(200) NULL,
	CONSTRAINT CK_Customer CHECK (Code LIKE '[0-9][0-9][0-9][0-9][0-9]')
)
GO

INSERT INTO Customer (Code, FirstName, LastName, Gender, BirthDate, Country, Telephone, Address)
VALUES 
	('00001', N'John', N'James', 1, '1980-09-01', N'Canada', N'(123) 123-1231', Null),
	('00002', N'James', N'John', 1, '1992-02-01', N'Austria', N'(123) 123-4561', Null);
GO

CREATE PROCEDURE CustomerCollection
AS
	SELECT * 
		FROM Customer
GO

CREATE PROCEDURE SelectCustomer
@ID BIGINT 
AS 
	SELECT *
		FROM Customer
		WHERE ID = @ID
GO

CREATE PROCEDURE DeleteCustomer
@ID BIGINT 
AS 
	DELETE Customer
		WHERE ID = @ID
GO

CREATE PROCEDURE SaveCustomer
@ID 		BIGINT,
@Code		CHAR(5),
@FirstName	NVARCHAR(50),
@LastName	NVARCHAR(50),
@Gender		BIT,
@BirthDate	DATE,
@Country	NVARCHAR(50),
@Telephone	NVARCHAR(20),
@Address	NVARCHAR(200)
AS 
	IF EXISTS (
		SELECT * 
			FROM Customer
			WHERE ID != @ID AND Code = @Code
	)
	RETURN -1

	UPDATE Customer
		SET
			Code        = @Code,
			FirstName   = @FirstName,         
			LastName    = @LastName,
			Gender      = @Gender,
			BirthDate   = @BirthDate,
			Country     = @Country,
			Telephone   = @Telephone,
			Address     = @Address
		WHERE
			ID = @ID
	
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Customer (Code, FirstName, LastName, Gender, BirthDate, Country, Telephone, Address)
		VALUES (@Code, @FirstName, @LastName, @Gender, @BirthDate, @Country, @Telephone, @Address)
		SELECT @ID = SCOPE_IDENTITY()
	END

	SELECT @ID
	RETURN 0
GO