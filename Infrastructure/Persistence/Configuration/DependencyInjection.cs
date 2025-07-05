using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationOptions = new AppConfiguration();
            configuration.GetSection(AppConfiguration.Section).Bind(applicationOptions);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(applicationOptions.ConnectionString));

            services.AddScoped<IEspecialidadInterface, EspecialidadesService>();
            return services;

        }
    }
}
