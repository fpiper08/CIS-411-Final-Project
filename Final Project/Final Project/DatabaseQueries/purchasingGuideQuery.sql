SELECT T.ItemCode, T.UnitCost, T.Supplier, S.City, S.State
FROM Items T
INNER JOIN Supplier S on T.Supplier = S.SupplierName;