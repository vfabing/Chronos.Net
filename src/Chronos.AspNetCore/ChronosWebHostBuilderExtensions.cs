using Chronos.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chronos.AspNetCore
{
    public static class ChronosWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseDateTimeProvider(this IWebHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.ConfigureServices(collection =>
                collection.AddSingleton<IDateTimeProvider, DateTimeProvider>());
            return builder;
        }

        public static IWebHostBuilder UseDateTimeOffsetProvider(this IWebHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.ConfigureServices(collection =>
                collection.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>());
            return builder;
        }
    }
}
