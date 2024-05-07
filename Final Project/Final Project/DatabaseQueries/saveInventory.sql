DELETE FROM Inventory;

INSERT INTO Inventory (ItemCode, ItemName, SalePrice, Category, Quantity)
VALUES (@Param1, @Param2, @Param3, @Param4, @Param5);