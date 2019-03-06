using System;

namespace DateTimeProviding.Abstractions
{
    public class IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
