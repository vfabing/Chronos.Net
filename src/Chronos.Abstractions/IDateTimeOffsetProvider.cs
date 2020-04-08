using System;

namespace Chronos.Abstractions
{
    public interface IDateTimeOffsetProvider
    {
        DateTimeOffset UtcNow { get; }
        DateTimeOffset Now { get; }
    }
}
