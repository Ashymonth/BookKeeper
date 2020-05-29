IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = '[{0}\{1}]')
BEGIN
    CREATE LOGIN [{0}\{1}] from windows WITH DEFAULT_DATABASE=[master]
END