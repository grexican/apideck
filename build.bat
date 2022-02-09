dotnet build src/Apideck.sln  --configuration Release
dotnet pack -c Release ./src/Apideck -o ./dist -p:NuspecFile=apideck.nuspec
