RESTORE DATABASE HmzTest_Data
FROM DISK = '/var/opt/mssql/data/backup/HmzTest.bak'
WITH MOVE 'HmzTest_Data' TO '/var/opt/mssql/data/HmzTest_Data.mdf',
     MOVE 'HmzTest_Data_Log' TO '/var/opt/mssql/data/HmzTest_Data_Log.ldf',
     REPLACE;
