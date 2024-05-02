SELECT I.ItemName, I.Quantity AS Inventory,
       T.UnitCost, T.Supplier,
       S.City, S.State,
       O.Customer, O.TotalAmount,
       D.Quantity, D.UnitPrice
FROM Inventory I
INNER JOIN Items T ON I.ItemCode = T.ItemCode
INNER JOIN Supplier S ON T.Supplier = S.SupplierName
INNER JOIN Orders O ON I.ItemName = O.ItemName
INNER JOIN OrderDetail D ON O.OrderNo = D.OrderNo;
