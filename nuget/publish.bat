%srcFolder%\nuget\nuget pack %srcFolder%\source\equalidator\equalidator\equalidator.csproj
%srcFolder%\nuget\nuget setApiKey %nugetApiKey%
cd %srcFolder%\nuget
tree .. /f /a
nuget push %srcFolder%\nuget\equalidator.%projectVersion%.nupkg