INSERT INTO Inventory(ItemCode, ItemName, SalePrice, Category, Quantity)
VALUES (123456789012345, 'Product1', 19.99, 'Electronics', 100),
       (987654321098765, 'Product2', 29.99, 'Clothing', 50),
       (555555555555555, 'Product3', 9.99, 'Accessories', 200);

-- Insert into Items table
INSERT INTO Items (ItemCode, UnitCost, UPC, SKU, Supplier, Brand)
VALUES ('Product1', 15.00, 123456789012345, 12345, 'Supplier1', 'Brand1'),
       ('Product2', 20.00, 987654321098765, 67890, 'Supplier2', 'Brand2'),
       ('Product3', 8.00, 555555555555555, 54321, 'Supplier3', 'Brand3');

-- Insert into Supplier table
INSERT INTO Supplier (SupplierName, ID, City, StreetName, StreetNumber, ZipCode, State)
VALUES ('Supplier1', 1, 'City1', 'Street1', 123, 12345, 'CA'),
       ('Supplier2', 2, 'City2', 'Street2', 456, 67890, 'NY'),
       ('Supplier3', 3, 'City3', 'Street3', 789, 54321, 'TX');

-- Insert into Orders table
INSERT INTO Orders (OrderNo, Item, Customer, TotalAmount, Status)
VALUES (1234567890, 'Product1', 'Customer1', 199.90, 'Completed'),
       (9876543210, 'Product2', 'Customer2', 299.90, 'In Progress'),
       (5555555555, 'Product3', 'Customer3', 99.90, 'Pending');

-- Insert into OrderDetail table
INSERT INTO OrderDetail (DetailId, OrderNo, ItemId, Quantity, UnitPrice, Total)
VALUES (1, 1234567890, 123456789012345, 10, 19.99, 199.90),
       (2, 9876543210, 987654321098765, 5, 29.99, 149.95),
       (3, 5555555555, 555555555555555, 20, 9.99, 199.80);
