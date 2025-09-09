using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeePortal.Core.Abstractions;
using EmployeePortal.Core.Abstractions.Repositories;
using EmployeePortal.Infrastructure.Persistence;
using EmployeePortal.Infrastructure.Repositories;

namespace EmployeePortal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(connectionString));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
