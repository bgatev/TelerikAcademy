select top 1 Towns.Name, count(Towns.Name) as Employeers
from Employees inner join Addresses on Employees.AddressID = Addresses.AddressID
			   inner join Towns on Addresses.TownID = Towns.TownID
group by Towns.Name
order by Employeers DESC