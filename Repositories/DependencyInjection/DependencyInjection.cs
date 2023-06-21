using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories.DependencyInjection
{
    public static class DependencyInjection
    { 
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<CostRepository>();

            services.AddScoped<PriestRepository>();

            services.AddScoped<DioceseRepository>();

            services.AddScoped<PensionRepository>();

            services.AddScoped<ContributionRepository>();
        }
    }
}
