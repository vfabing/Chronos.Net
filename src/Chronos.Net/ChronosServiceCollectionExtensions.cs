using Chronos.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos
{
    public static class ChronosServiceCollectionExtensions
    {
        public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddDateTimeOffsetProvider(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IDateTimeOffsetProvider, DateTimeOffsetProvider>();

            return services;
        }
    }
}
