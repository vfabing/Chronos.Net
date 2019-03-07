using Chronos.Abstractions;
using System;

namespace Chronos.Net
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
