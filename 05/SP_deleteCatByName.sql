create PROCEDURE deleteCatByName  
@name varchar(max)
AS
delete from cats where name = @name;




