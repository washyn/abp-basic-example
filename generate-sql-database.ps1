# dotnet ef migrations script -o database_iohscrap_table_generation_script.sql
# dotnet ef migrations script --idempotent --output "database_script.sql"

dotnet ef migrations script --idempotent --output "./database_script.sql" --verbose --project "./src/Washyn.EntityFrameworkCore/Washyn.EntityFrameworkCore.csproj"