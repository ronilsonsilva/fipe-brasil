using FipeBrasil.Domain.Contracts;
using FipeBrasil.Infrastructure.Data.Context;
using FipeBrasil.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FipeBrasil.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Get connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContext
            services.AddDbContext<FipeDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Unit of Work
            services.AddScoped<IUnitOfWork, Infrastructure.Data.UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
