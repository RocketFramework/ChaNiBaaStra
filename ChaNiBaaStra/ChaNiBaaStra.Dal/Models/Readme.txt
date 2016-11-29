How to develop the database tables?

There are few Database guidelines that you need to adhere if you are to easily use Nido.

1. Give meaningful names for tables 
2. Use a primary key for all the tables. The primary key should have the table name followed by the suffix 'Id' (e.g. primary key = TableNameId). This is applicable for composite tables as well.
3. 'Name' column would come handy if you are to display table records in a drop-down box.
4. Foreign key name of a table also may use table name followed by the suffix 'Id' 
5. Use as many as Views for yourself to simplify the SQL statement, model classes for views needed to be created manually. They can be created just like you create them in EF.
6. Use Stored Procedures as much as possible to avoid unwanted database round trips.