SELECT Towns.Name, dbo.STRCONCAT(FirstName + ' ' + LastName) 
FROM Employees inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID
group by Towns.Name