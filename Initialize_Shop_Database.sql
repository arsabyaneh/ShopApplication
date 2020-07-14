CREATE DATABASE Shop
GO

USE Shop
GO

CREATE TABLE Customer(
	ID			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Code		CHAR(5) NOT NULL UNIQUE,
	FirstName	NVARCHAR(50) NOT NULL,
	LastName	NVARCHAR(50) NOT NULL,
	Gender		BIT NOT NULL,
	BirthDate	DATE NOT NULL,
	Country		NVARCHAR(50) NOT NULL,
	Telephone	NVARCHAR(20) NOT NULL,
	Email		NVARCHAR(50) NOT NULL,
	Address		NVARCHAR(500) NULL,
	CONSTRAINT CK_Customer CHECK (Code LIKE '[0-9][0-9][0-9][0-9][0-9]')
);
GO

CREATE TABLE Invoice(
	ID 			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Code		CHAR(5) NOT NULL,
	InvoiceDate DATE NOT NULL,
	Discount 	DECIMAL NOT NULL DEFAULT 0,
	CustomerID 	BIGINT,
	FOREIGN KEY (CustomerID) REFERENCES Customer(ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE Brand(
	ID 			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Title 		NVARCHAR(100) NOT NULL,
	Address 	NVARCHAR(500) NOT NULL
);
GO

CREATE TABLE Product(
	ID 			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Title 		NVARCHAR(100) NOT NULL,
	Code 		NVARCHAR(10) NOT NULL UNIQUE,
	BrandID 	BIGINT,
	FOREIGN KEY (BrandID) REFERENCES Brand(ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE InvoiceItem(
	ID 			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Quantity 	INT NOT NULL,
	InvoiceID 	BIGINT,
	ProductID 	BIGINT,
	FOREIGN KEY (InvoiceID) REFERENCES Invoice(ID) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ProductID) REFERENCES Product(ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

CREATE TABLE Price(
	ID 			BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	PriceDate 	Date NOT NULL,
	Buy 		DECIMAL NOT NULL,
	Sell 		DECIMAL NOT NULL,
	ProductID 	BIGINT,
	FOREIGN KEY (ProductID) REFERENCES Product(ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- --------------------------------------------------
-- Init
-- --------------------------------------------------

INSERT INTO Customer (Code, FirstName, LastName, Gender, BirthDate, Country, Telephone, Email, Address)
VALUES 
	('00001', N'John', N'James', 1, '1980-09-01', N'Canada', N'(123) 123-1231', N'John@email.com', Null),
	('00002', N'James', N'John', 1, '1992-02-01', N'Austria', N'(123) 123-4561', N'James@email.com', Null);
GO

INSERT INTO Brand (Title, Address)
VALUES 
	(N'Company_1', N'Country_1'),
	(N'Company_2', N'Country_2'),
	(N'Company_3', N'Country_3');
GO

INSERT INTO Product (Title, Code, BrandID)
VALUES 
	(N'Product_1', N'00100', 1),
	(N'Product_2', N'00101', 3);
GO

INSERT INTO Price (PriceDate, Buy, Sell, ProductID)
VALUES 
	(GETDATE(), 60.00, 99.99, 1),
	(GETDATE(), 70.00, 109.99, 2);
GO

-- --------------------------------------------------
-- Creating Procedures
-- --------------------------------------------------

-- Customers

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
@Email		NVARCHAR(50),
@Address	NVARCHAR(500)
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
			Email 		= @Email,
			Address     = @Address
		WHERE
			ID = @ID
	
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Customer (Code, FirstName, LastName, Gender, BirthDate, Country, Telephone, Email, Address)
		VALUES (@Code, @FirstName, @LastName, @Gender, @BirthDate, @Country, @Telephone, @Email, @Address)
		SELECT @ID = SCOPE_IDENTITY()
	END

	SELECT @ID
	RETURN 0
GO

-- Invoices

CREATE PROCEDURE InvoiceCollection
AS
	SELECT * FROM Invoice ORDER BY InvoiceDate, Code DESC
GO

CREATE PROCEDURE SelectInvoice
@ID BIGINT 
AS 
	SELECT *
		FROM Invoice
		WHERE ID = @ID
GO

CREATE PROCEDURE DeleteInvoice
@ID BIGINT 
AS 
	DELETE Invoice
		WHERE ID = @ID
GO

CREATE PROCEDURE SaveInvoice
@ID				BIGINT,
@Code 			CHAR(5),
@InvoiceDate 	DATE,
@Discount 		DECIMAL,
@CustomerID 	BIGINT
AS 
	IF EXISTS (
		SELECT * 
			FROM Invoice
			WHERE ID != @ID AND Code = @Code
	)
	RETURN -1

	UPDATE Invoice
		SET
			Code        = @Code,
			InvoiceDate = @InvoiceDate,
			Discount    = @Discount,
			CustomerID  = @CustomerID
		WHERE
			ID = @ID
	
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Invoice (Code, InvoiceDate, Discount, CustomerID)
		VALUES (@Code, @InvoiceDate, @Discount, @CustomerID)
		SELECT @ID = SCOPE_IDENTITY()
	END

	SELECT @ID
	RETURN 0
GO

-- InvoiceItems

CREATE PROCEDURE SelectProductByCode
@Code			NVARCHAR(10),
@InvoiceDate	DATE
AS
	SELECT TOP 1 Product.ID ID, Product.Title Title, Product.Code Code, Product.BrandID BrandID, Price.Sell Sell
	FROM Product INNER JOIN Price ON Product.ID = Price.ProductID
	WHERE Code = @Code AND Price.PriceDate <= @InvoiceDate
	ORDER BY Price.PriceDate DESC
GO

CREATE PROCEDURE InvoiceItemsOfAnInvoice
@InvoiceID BIGINT
AS
	SELECT InvoiceItem.ID InvoiceItemID, InvoiceItem.Quantity Quantity, InvoiceItem.InvoiceID InvoiceID, InvoiceItem.ProductID ProductID, Product.Title Title, Product.Code Code, Product.BrandID BrandID
	FROM Product INNER JOIN InvoiceItem ON Product.ID = InvoiceItem.ProductID
	WHERE InvoiceID = @InvoiceID
GO

CREATE PROCEDURE SaveInvoiceItem
@ID 		BIGINT,
@Quantity	INT,
@InvoiceID 	BIGINT,
@ProductID 	BIGINT
AS
	UPDATE InvoiceItem
		SET
			Quantity	= @Quantity,
			InvoiceID   = @InvoiceID,
			ProductID   = @ProductID
		WHERE
			ID = @ID
	
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO InvoiceItem (Quantity, InvoiceID, ProductID)
		VALUES (@Quantity, @InvoiceID, @ProductID)
		SELECT @ID = SCOPE_IDENTITY()
	END

	SELECT @ID
	RETURN 0
GO

CREATE PROCEDURE DeleteInvoiceItem
@ID BIGINT
AS 
	DELETE InvoiceItem
		WHERE ID = @ID
GO