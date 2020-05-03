SELECT 
t.TABLE_CATALOG, 
t.TABLE_SCHEMA, 
t.TABLE_NAME
FROM /*DATABASE_NAME.*/INFORMATION_SCHEMA.TABLES t 
WHERE t.TABLE_TYPE = 'BASE TABLE'
ORDER BY 1, 2, 3