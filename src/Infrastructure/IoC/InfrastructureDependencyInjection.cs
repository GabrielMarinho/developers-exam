using System.Reflection;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories;
using Infrastructure.Events;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class InfrastructureDependencyInjection
{
    public static void InfrastructureRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddDbContext<SqlDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("SQLConnection"), 
                b => 
                    b.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName)));

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<IDomainEventHandler, DomainEventHandler>();

        services.AddScoped<SqlDbContext>();
    }
}