SELECT [name] FROM sys.databases 
WHERE [name] NOT IN ('master','tempdb','model','msdb')
ORDER BY [name]