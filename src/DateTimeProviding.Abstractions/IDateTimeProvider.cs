using System;

namespace DateTimeProviding.Abstractions
{
    public class IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
