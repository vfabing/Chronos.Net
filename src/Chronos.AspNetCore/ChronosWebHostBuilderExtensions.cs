using Chronos.Abstractions;
using Chronos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chronos
{
    public static class ChronosWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseDateTimeProvider(this IWebHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.ConfigureServices(collection =>
                collection.AddSingleton<IDateTimeProvider>(new DateTimeProvider()));
            return builder;
        }
    }
}
