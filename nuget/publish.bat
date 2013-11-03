%srcFolder%\nuget\nuget pack %srcFolder%\source\equalidator\equalidator\equalidator.csproj
%srcFolder%\nuget\nuget setApiKey %nugetApiKey%
tree .. /f /a
%srcFolder%\nuget\nuget push %srcFolder%\nuget\equalidator.%projectVersion%.nupkg