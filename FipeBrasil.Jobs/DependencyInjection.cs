using Microsoft.Extensions.DependencyInjection;

namespace FipeBrasil.Jobs
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJobs(this IServiceCollection services)
        {
            services.AddScoped<UpsertDataJob>();
            return services;
        }
    }
}
