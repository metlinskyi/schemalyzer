USE [master]
--#DEBUG
DECLARE @objname nvarchar(776) = ''
--#END
DECLARE @lines TABLE ([Text] NVARCHAR(MAX));
INSERT @lines EXEC sp_helptext @objname;
SELECT TRIM([Text]) FROM @lines