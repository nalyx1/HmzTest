#!/bin/bash
set -e

echo "Esperando o SQL Server iniciar..."
sleep 30s

echo "Restaurando o banco de dados a partir do backup..."
/opt/mssql-tools/bin/sqlcmd -S db -U SA -P "HmzTest@123" -i /var/opt/mssql/data/backup/restore-database.sql

exec /opt/mssql/bin/sqlservr