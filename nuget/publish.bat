cd %srcFolder%\nuget
nuget pack ..\source\equalidator\equalidator\equalidator.csproj
nuget setApiKey %nugetApiKey%
tree .. /f /a
tree %buildFolder%\out /f /a
nuget push %srcFolder%\nuget\equalidator.%projectVersion%.nupkg