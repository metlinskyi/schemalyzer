USE [master]

SELECT 
    ROUTINE_SCHEMA,
    ROUTINE_NAME,
    ROUTINE_TYPE

FROM INFORMATION_SCHEMA.ROUTINES