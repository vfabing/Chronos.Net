using Chronos.Abstractions;
using System;

namespace Chronos
{
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
