IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = '{0}')
BEGIN
   CREATE LOGIN [{0}] WITH PASSWORD=N'{1}', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
   ALTER SERVER ROLE [sysadmin] ADD MEMBER [{0}]
END