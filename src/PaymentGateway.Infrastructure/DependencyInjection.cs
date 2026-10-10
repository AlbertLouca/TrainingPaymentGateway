using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Infrastructure.Persistence;

namespace PaymentGateway.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
