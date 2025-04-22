using BookStream.Core.Repositories;
using BookStream.Infrastructure.Persistence;
using BookStream.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStream.Infrastructure;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);


        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BookStreamCs");

        services
            .AddDbContext<BookStreamDbContext>(o =>
            o.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

        return services;

    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        return services;
    }
}
