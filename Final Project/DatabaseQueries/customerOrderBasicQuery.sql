SELECT O.OrderNo, O.Customer, O.TotalAmount, D.Quantity, D.UnitPrice
FROM Orders O
INNER JOIN OrderDetail D ON O.OrderNo = D.OrderNo;