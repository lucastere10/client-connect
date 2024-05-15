using ClientConnect.Infrastructure.Data;
using ClientConnect.Infrastructure.Services;
using ClientConnect.UseCases.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ClientConnect.Infrastructure;

public static class InfrastructureServiceExtensions
{

    public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config)
    {
        string? connectionString = config.GetConnectionString("ClientConnectConnection");
        services.AddDbContext<ClientConnectContext>(opts => opts
            .UseLazyLoadingProxies()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddAutoMapper(typeof(CustomerProfile).Assembly);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<CustomerService>();
        services.AddScoped<EmployeeService>();
        services.AddScoped<InteractionService>();

        return services;
    }
}
