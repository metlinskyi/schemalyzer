--#DEBUG
DECLARE @referencing_entity_name varchar(20) = 'sp_tables'
--#END
SELECT * 
FROM sys.dm_sql_referenced_entities (@referencing_entity_name, 'OBJECT');