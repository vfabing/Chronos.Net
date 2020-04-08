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
- An `IDateTimeOffsetProvider` interface which exposes `Now` or `UtcNow` properties.

## Chronos.Net
[![NuGet Version](https://img.shields.io/nuget/v/Chronos.Net.svg)](https://www.nuget.org/packages/Chronos.Net/)
[![Chronos.Net package in Vivien_NuGet feed in Azure Artifacts](https://vivien.feeds.visualstudio.com/_apis/public/Packaging/Feeds/c65668a1-d42d-4549-8bba-74d16d3af39e/Packages/2f9eae02-0cdd-46a3-a8c4-8e8f21cd6d92/Badge)](https://vivien.visualstudio.com/Chronos.Net/_packaging?_a=package&feed=c65668a1-d42d-4549-8bba-74d16d3af39e&package=2f9eae02-0cdd-46a3-a8c4-8e8f21cd6d92&preferRelease=true)

Contains:
- A simple implementation `DateTimeProvider` of the `IDateTimeProvider` interface.
- A simple implementation `DateTimeOffsetProvider` of the `IDateTimeOffsetProvider` interface.
- And 2 `IServiceCollection` extensions method to provide default implementations:
  - `AddDateTimeProvider()` to provide a singleton of `DateTimeProvider` when an `IDateTimeProvider` is required
  - `AddDateTimeOffsetProvider() `to provide a singleton of `DateTimeOffsetProvider` when an `IDateTimeOffsetProvider` is required
  
```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddDateTimeProvider();
    services.AddDateTimeOffsetProvider();
    ...
}
```
## Chronos.AspNetCore [Deprecated]
[![NuGet Version](https://img.shields.io/nuget/v/Chronos.AspNetCore.svg)](https://www.nuget.org/packages/Chronos.AspNetCore/)
[![Chronos.AspNetCore package in Vivien_NuGet feed in Azure Artifacts](https://vivien.feeds.visualstudio.com/_apis/public/Packaging/Feeds/c65668a1-d42d-4549-8bba-74d16d3af39e/Packages/17a4a36e-bc01-48ca-98ac-ceb9d1c55e1f/Badge)](https://vivien.visualstudio.com/Chronos.Net/_packaging?_a=package&feed=c65668a1-d42d-4549-8bba-74d16d3af39e&package=17a4a36e-bc01-48ca-98ac-ceb9d1c55e1f&preferRelease=true)

> *`Chronos.AspNetCore` was kept for compatibility reasons, but should be removed in further releases. Please use the `IServiceCollection` extensions from `Chronos.Net` instead which requires less dependencies.*

Contains:
- And 2 `WebHostBuilder` extensions method to provide default implementations:
  - `UseDateTimeProvider()` to provide a singleton of `DateTimeProvider` when an `IDateTimeProvider` is required
  - `UseDateTimeOffsetProvider() `to provide a singleton of `DateTimeOffsetProvider` when an `IDateTimeOffsetProvider` is required

```csharp
public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .UseDateTimeProvider()
    .UseDateTimeOffsetProvider()
    .UseStartup<Startup>();
```

## Usage
Then instead of using `DateTime.Now`, `DateTime.UtcNow`, `DateTimeOffset.Now` or `DateTimeOffset.UtcNow`, you should use `IDateTimeProvider.Now`, `IDateTimeProvider.UtcNow`, `IDateTimeOffsetProvider.Now` or `IDateTimeOffsetProvider.UtcNow` which would enable you to fake/mock the time in your tests.  
Example with [FakeItEasy](https://fakeiteasy.github.io/):

```csharp
var dateTimeProvider = A.Fake<IDateTimeProvider>();
A.CallTo(() => dateTimeProvider.Now).Returns(new DateTime(2019, 3, 6, 9, 0, 0));
```

```csharp
var franceOffset = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time").BaseUtcOffset;
var dateTimeOffsetProvider = A.Fake<IDateTimeOffsetProvider>();
A.CallTo(() => dateTimeOffsetProvider.Now).Returns(new DateTime(2019, 3, 6, 9, 0, 0, franceOffset));
```

A sample web project can be found in the [samples folder](https://github.com/vfabing/Chronos.Net/tree/master/samples/SimpleWebSample)
