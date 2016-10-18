cd %srcFolder%\nuget
nuget pack ..\source\equalidator\equalidator\equalidator.csproj
nuget setApiKey %nugetApiKey%
nuget push %srcFolder%\nuget\equalidator.%APPVEYOR_BUILD_VERSION%.0.nupkg