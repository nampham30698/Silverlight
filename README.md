# Silverlight

# Add migrations

#step1
-- run: cd src/silverlight.web

#step2 
	# appidentitydbcontext
	-- add migrations

	dotnet ef migrations add "nampv_update_user_12112022_10h44" -c appidentitydbcontext -o ../silverlight.infrastructure/identity/migrations -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj

	-- update db
	dotnet ef database update -c appidentitydbcontext -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj


	# SilverlightDbContext

	-- add migrations
	dotnet ef migrations add nampv_insert_table_category_06112022_21h44 -c SilverlightDbContext -o ../silverlight.infrastructure/data/migrations -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj

	-- update db
	dotnet ef database update -c SilverlightDbContext -p ../silverlight.infrastructure/silverlight.infrastructure.csproj -s silverlight.web.csproj



# remove migrations

step1: dotnet ef migrations remove -c SilverlightDbContext
step2: delete file migrations
