# EmployeePortal
Manage Employee details

# EF
cd src/EmployeePortal.Api
dotnet ef migrations add InitialCreate -p ../EmployeePortal.Infrastructure -s . -o Persistence/Migrations
dotnet ef database update -p ../EmployeePortal.Infrastructure -s .