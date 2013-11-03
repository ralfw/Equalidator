cd %srcFolder%\nuget
nuget pack ..\source\equalidator\equalidator\equalidator.csproj
nuget setApiKey %nugetApiKey%
tree .. /f /a
nuget push %srcFolder%\nuget\equalidator.%projectVersion%.0.nupkg