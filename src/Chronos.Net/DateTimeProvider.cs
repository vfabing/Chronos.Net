using Chronos.Abstractions;
using System;

namespace Chronos
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
