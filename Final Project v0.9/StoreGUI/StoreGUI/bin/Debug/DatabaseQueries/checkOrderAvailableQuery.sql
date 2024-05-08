SELECT I.ItemName, I.Quantity AS Inventory, O.Customer, O.TotalAmount, D.Quantity, D.UnitPrice
FROM Inventory I
INNER JOIN OrderDetail D ON I.ItemCode = D.ItemId
INNER JOIN Orders O ON D.OrderNo = O.OrderNo;