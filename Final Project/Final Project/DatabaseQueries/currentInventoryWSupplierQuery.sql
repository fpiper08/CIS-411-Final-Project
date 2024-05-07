SELECT I.ItemName, I.Quantity, T.UnitCost, T.Supplier, S.City, S.State
FROM Inventory I
INNER JOIN Items T ON I.ItemCode = T.ItemCode
INNER JOIN Supplier S ON T.Supplier = S.SupplierName;