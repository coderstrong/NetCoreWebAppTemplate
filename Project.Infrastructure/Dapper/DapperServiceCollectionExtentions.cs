using Microsoft.Extensions.DependencyInjection;
using System;

namespace Project.Infrastructure.Dapper
{
    public static class DapperServiceCollectionExtentions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, Action<DapperOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if(setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddOptions();
            services.Configure(setupAction);
            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));

            return services;
        }
    }
}