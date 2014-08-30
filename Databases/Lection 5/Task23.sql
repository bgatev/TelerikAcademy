The SQL is:
update users
set users.Password = null
where users.LastLoginTime < '2010-03-10 00:00:00.000'

but there is an error message, because I DON'T ALLOW NULL values for the password:
Msg 515, Level 16, State 2, Line 1
Cannot insert the value NULL into column 'Password', table 'TelerikAcademy.dbo.Users'; column does not allow nulls. UPDATE fails.
The statement has been terminated.

If I allow nulls, then everything is ok