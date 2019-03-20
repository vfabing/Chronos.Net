[![NuGet Version](https://img.shields.io/nuget/v/Chronos.Net.svg)](https://www.nuget.org/packages/Chronos.Net/)
[![Build Status](https://vivien.visualstudio.com/Chronos.Net/_apis/build/status/Chronos.Net?branchName=master)](https://vivien.visualstudio.com/Chronos.Net/_build/latest?definitionId=43&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=chronos.net&metric=alert_status)](https://sonarcloud.io/dashboard?id=chronos.net)
    
# Chronos.Net
Simple library to help abstracting time in dotnet projects, usually for testing purpose.

## Chronos.Abstractions
[![NuGet Version](https://img.shields.io/nuget/v/Chronos.Abstractions.svg)](https://www.nuget.org/packages/Chronos.Abstractions/)
[![Chronos.Abstractions package in Vivien_NuGet feed in Azure Artifacts](https://vivien.feeds.visualstudio.com/_apis/public/Packaging/Feeds/c65668a1-d42d-4549-8bba-74d16d3af39e/Packages/ea8d171a-34a0-4e2c-a1ab-de0d30c9a1b1/Badge)](https://vivien.visualstudio.com/Chronos.Net/_packaging?_a=package&feed=c65668a1-d42d-4549-8bba-74d16d3af39e&package=ea8d171a-34a0-4e2c-a1ab-de0d30c9a1b1&preferRelease=true)

Contains:
- An `IDateTimeProvider` interface which exposes `Now` or `UtcNow` properties.

## Chronos.Net
[![NuGet Version](https://img.shields.io/nuget/v/Chronos.Net.svg)](https://www.nuget.org/packages/Chronos.Net/)
[![Chronos.Net package in Vivien_NuGet feed in Azure Artifacts](https://vivien.feeds.visualstudio.com/_apis/public/Packaging/Feeds/c65668a1-d42d-4549-8bba-74d16d3af39e/Packages/2f9eae02-0cdd-46a3-a8c4-8e8f21cd6d92/Badge)](https://vivien.visualstudio.com/Chronos.Net/_packaging?_a=package&feed=c65668a1-d42d-4549-8bba-74d16d3af39e&package=2f9eae02-0cdd-46a3-a8c4-8e8f21cd6d92&preferRelease=true)

Contains:
- A simple implementation `DateTimeProvider` of the `IDateTimeProvider` interface.

## Chronos.AspNetCore
[![NuGet Version](https://img.shields.io/nuget/v/Chronos.AspNetCore.svg)](https://www.nuget.org/packages/Chronos.AspNetCore/)
[![Chronos.AspNetCore package in Vivien_NuGet feed in Azure Artifacts](https://vivien.feeds.visualstudio.com/_apis/public/Packaging/Feeds/c65668a1-d42d-4549-8bba-74d16d3af39e/Packages/17a4a36e-bc01-48ca-98ac-ceb9d1c55e1f/Badge)](https://vivien.visualstudio.com/Chronos.Net/_packaging?_a=package&feed=c65668a1-d42d-4549-8bba-74d16d3af39e&package=17a4a36e-bc01-48ca-98ac-ceb9d1c55e1f&preferRelease=true)

Contains:
- A `WebHostBuilder` extension to provide the default implementation `DateTimeProvider` for the `IDateTimeProvider` interface, by simply using `UseDateTimeProvider()`  

```csharp
public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .UseDateTimeProvider()
    .UseStartup<Startup>();
```

Then instead of using `DateTime.Now` or `DateTime.UtcNow`, you should use `IDateTimeProvider.Now` or `IDateTimeProvider.UtcNow`, which would enable you to fake/mock the time in your tests.  
Example with [FakeItEasy](https://fakeiteasy.github.io/):

```csharp
var dateTimeProvider = A.Fake<IDateTimeProvider>();
A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(2019, 3, 6, 9, 0, 0));
```

A sample web project can be found in the [samples folder](https://github.com/vfabing/Chronos.Net/tree/master/samples/SimpleWebSample)
