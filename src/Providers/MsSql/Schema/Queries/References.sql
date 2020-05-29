USE [master]
--#DEBUG
DECLARE @referencing_entity_name varchar(20) = 'sp_helptext'
--#END
SELECT 

        r.referenced_schema_name, 
        r.referenced_entity_name,
        r.referenced_minor_name,
        r.referenced_class_desc,
        o.type_desc

FROM sys.dm_sql_referenced_entities(@referencing_entity_name, 'OBJECT') AS r

INNER JOIN sys.objects AS o 
ON 
        r.referenced_id = o.object_id  

WHERE 
        r.referenced_minor_name IS NOT NULL AND
        o.type_desc = 'USER_TABLE'
        


