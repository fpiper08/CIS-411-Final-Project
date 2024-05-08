UPDATE Inventory
SET 
    ItemName = @Param2,
    SalePrice = @Param3,
    Category = @Param4,
    Quantity = @Param5
WHERE 
    ItemCode = @Param1;