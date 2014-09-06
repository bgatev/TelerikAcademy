USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[Suppliers Income for Period]    Script Date: 31.8.2014 ã. 14:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Suppliers Income for Period] 
	@SupplierName nvarchar(100), @StartDate DateTime, @EndDate DateTime
AS
	Begin
		Select Products.ProductName, Sum([Order Details].Quantity * [Order Details].UnitPrice * (1-[Order Details].Discount)) as 'Product Income'
		From Suppliers Inner Join Products On Suppliers.SupplierID = Products.SupplierID
					   Inner Join [Order Details] On Products.ProductID = [Order Details].ProductID
					   Inner Join Orders On [Order Details].OrderID = Orders.OrderID
		WHERE Suppliers.CompanyName = @SupplierName And (Orders.OrderDate Between @StartDate And @EndDate)
		Group By Products.ProductName
	End
