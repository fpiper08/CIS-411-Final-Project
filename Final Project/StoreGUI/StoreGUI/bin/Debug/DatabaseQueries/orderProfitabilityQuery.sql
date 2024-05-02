SELECT T.ItemCode, T.UnitCost, T.Supplier, O.Customer, O.TotalAmount, S.City, S.State
FROM Items T
INNER JOIN Orders O ON T.ItemCode = O.ItemCode
INNER JOIN Supplier S ON T.Supplier = S.SupplierName;
