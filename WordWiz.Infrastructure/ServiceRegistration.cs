using Microsoft.Extensions.DependencyInjection;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Infrastructure.Repositories;

namespace WordWiz.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
} 