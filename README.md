[![NuGet Version](https://img.shields.io/nuget/v/Chronos.Net.svg)](https://www.nuget.org/packages/Chronos.Net/)

# Chronos.Net
Simple library to help abstracting time in dotnet projects, usually for testing purpose.

## Chronos.Abstractions
Contains:
- An `IDateTimeProvider` interface

## Chronos.Net
Contains:
- An `IDateTimeProvider` interface simple implementation named `DateTimeProvider`

## Chronos.AspNetCore
Contains:
- A `WebHostBuilder` extension to enable to provide the default implementation `DateTimeProvider` for the `IDateTimeProvider` interface, by using `UseDateTimeProvider()`  

A sample web project can be found in the [samples folder](https://github.com/vfabing/Chronos.Net/tree/master/samples/SimpleWebSample)
