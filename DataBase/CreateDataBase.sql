﻿USE master
GO

CREATE DATABASE SellingComponentsDB
GO

USE SellingComponentsDB
GO

---Quyền
CREATE TABLE Role(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Role NVARCHAR(100) NOT NULL,
	DateCreated DATE DEFAULT GETDATE()
)
GO

---Người dùng
CREATE TABLE UserInformation(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(100) NOT NULL,
	Password VARCHAR(100) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Sex NVARCHAR(100),
	PhoneNumber VARCHAR(11) NOT NULL,
	Email VARCHAR(100),
	Brithday DATE,
	Address NVARCHAR(200) NOT NULL,
	JoinDate DATE DEFAULT GETDATE(),
	IdRole INT NOT NULL,
	CONSTRAINT UserInformation_Role
	FOREIGN KEY(IdRole)
	REFERENCES Role(Id)
	ON DELETE CASCADE
)
GO

---Đơn hàng
CREATE TABLE Orders(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdUser INT NOT NULL,
	OrderDate DATE DEFAULT GETDATE(),
	TotalCost DECIMAL(14,1) NOT NULL,
	DeliveryAddress NVARCHAR(200) NOT NULL,
	DeliveryDate DATE NOT NULL,
	CONSTRAINT Orders_UserInformation
	FOREIGN KEY(IdUser)
	REFERENCES UserInformation(Id)
	ON DELETE CASCADE
)
GO

---Loại hàng hóa
CREATE TABLE Classify(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ClassifyName NVARCHAR(100) NOT NULL,
	ClassifyDetail NVARCHAR(1000) NOT NULL,
	DateCreated DATE DEFAULT GETDATE()
)
GO

---Hàng hóa
CREATE TABLE Product(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ProductName NVARCHAR(100) NOT NULL,
	Amount INT DEFAULT 0,
	Price DECIMAL(13,1) NOT NULL,
	Detail NVARCHAR(1000) NOT NULL,
	IdClassify INT NOT NULL,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT Product_Classify
	FOREIGN KEY(IdClassify)
	REFERENCES Classify(Id)
	ON DELETE CASCADE
)
GO

---Kho
CREATE TABLE Warehouse(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdProduct INT NOT NULL,
	Amount INT NOT NULL,
	InputDate DATE DEFAULT GETDATE(),
	CONSTRAINT Warehouse_Product
	FOREIGN KEY(IdProduct)
	REFERENCES Product(Id)
	ON DELETE CASCADE
)
GO

---Catalog
CREATE TABLE Catalog(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CatalogName NVARCHAR(100) NOT NULL,
	CatalogDetails NVARCHAR(1000) NOT NULL,
	DateCreated DATE DEFAULT GETDATE()
)
GO

---Combo
CREATE TABLE Combo(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ComboName NVARCHAR(100) NOT NULL,
	ComboDetails NVARCHAR(1000) NOT NULL,
	TotalCost DECIMAL(14,1) NOT NULL,
	Price DECIMAL(14,1) NOT NULL,
	IdCatalog INT NOT NULL,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT Combo_Catalog
	FOREIGN KEY(IdCatalog)
	REFERENCES Catalog(Id)
	ON DELETE CASCADE
)
GO

---Chi tiết combo
CREATE TABLE ComboDetails(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdCombo INT NOT NULL,
	IdProduct INT NOT NULL,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT ComboDetails_Combo
	FOREIGN KEY(IdCombo)
	REFERENCES Combo(Id)
	ON DELETE CASCADE,
	CONSTRAINT ComboDetails_Product
	FOREIGN KEY(IdProduct)
	REFERENCES Product(Id)
	ON DELETE CASCADE
)
GO

---Chi tiết đơn hàng
CREATE TABLE OrdersDetails(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdOrders INT NOT NULL,
	IdCombo INT,
	IdProduct INT,
	IdUser INT,
	Amount INT NOT NULL,
	Price DECIMAL(13,1) NOT NULL,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT OrdersDetails_Product
	FOREIGN KEY(IdProduct)
	REFERENCES Product(Id)
	ON DELETE CASCADE,
	CONSTRAINT OrdersDetails_Orders
	FOREIGN KEY(IdOrders)
	REFERENCES Orders(Id)
	ON DELETE CASCADE,
	CONSTRAINT OrdersDetails_Combo
	FOREIGN KEY(IdCombo)
	REFERENCES Combo(Id)
	ON DELETE CASCADE,
)
GO