CREATE DATABASE Store;
GO

USE Store;
GO

CREATE TABLE Inventory(
    ItemCode numeric(15) PRIMARY KEY ,
    ItemName varchar(255),
    SalePrice numeric(10,2),
    Category varchar(255),
    Quantity numeric(38)
);

CREATE TABLE Items(
    ItemCode numeric(15),
    UnitCost numeric(38),
    UPC numeric(38),
    SKU numeric(38),
    Supplier varchar(255) UNIQUE,
    Brand varchar(255),
    PRIMARY KEY (UPC),
    FOREIGN KEY (ItemCode) REFERENCES Inventory(ItemCode) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Supplier(
    SupplierName varchar(255),
    ID numeric(5),
    City varchar(255),
    StreetName varchar(255),
    StreetNumber numeric(10),
    ZipCode numeric(10),
    State varchar(2),
    PRIMARY KEY (ID),
    FOREIGN KEY (SupplierName) REFERENCES Items(Supplier) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Orders(
    OrderNo numeric(10) PRIMARY KEY,
    ItemCode numeric(15),
	ItemName varchar(255),
    Customer varchar(255),
    TotalAmount decimal(10,2),
    Status varchar(255)
);

CREATE TABLE OrderDetail(
    DetailId int,
    OrderNo numeric(10) REFERENCES Orders(OrderNo) ON DELETE CASCADE ON UPDATE CASCADE,
    ItemId numeric(15) REFERENCES Inventory(ItemCode) ON DELETE CASCADE ON UPDATE CASCADE,
    Quantity numeric(10),
    UnitPrice numeric(10,2),
    Total numeric(10,2)
);
GO

INSERT INTO Inventory(ItemCode, ItemName, SalePrice, Category, Quantity)
VALUES (123456789012345, 'Product1', 19.99, 'Electronics', 100),
       (987654321098765, 'Product2', 29.99, 'Clothing', 50),
       (555555555555555, 'Product3', 9.99, 'Accessories', 200);

-- Insert into Items table
INSERT INTO Items (ItemCode, UnitCost, UPC, SKU, Supplier, Brand)
VALUES (123456789012345, 15.00, 123456789012345, 12345, 'Supplier1', 'Brand1'),
       (987654321098765, 20.00, 987654321098765, 67890, 'Supplier2', 'Brand2'),
       (555555555555555, 8.00, 555555555555555, 54321, 'Supplier3', 'Brand3');

-- Insert into Supplier table
INSERT INTO Supplier (SupplierName, ID, City, StreetName, StreetNumber, ZipCode, State)
VALUES ('Supplier1', 1, 'City1', 'Street1', 123, 12345, 'CA'),
       ('Supplier2', 2, 'City2', 'Street2', 456, 67890, 'NY'),
       ('Supplier3', 3, 'City3', 'Street3', 789, 54321, 'TX');

-- Insert into Orders table
INSERT INTO Orders (OrderNo, ItemCode, ItemName, Customer, TotalAmount, Status)
VALUES (1234567890, 123456789012345, 'Product1','Customer1', 199.90, 'Completed'),
       (9876543210, 987654321098765, 'Product2', 'Customer2', 299.90, 'In Progress'),
       (5555555555, 555555555555555, 'Product3', 'Customer3', 99.90, 'Pending');

-- Insert into OrderDetail table
INSERT INTO OrderDetail (DetailId, OrderNo, ItemId, Quantity, UnitPrice, Total)
VALUES (1, 1234567890, 123456789012345, 10, 19.99, 199.90),
       (2, 9876543210, 987654321098765, 5, 29.99, 149.95),
       (3, 5555555555, 555555555555555, 20, 9.99, 199.80);
GO