# Silverlight


-- add migrations

dotnet ef migrations add initialcreate -c appidentitydbcontext -o ../silverlight.infrastructure/identity/migrations -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj

-- update db
dotnet ef database update -c appidentitydbcontext -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj