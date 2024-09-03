using BookStream.Application.Commands.AuthorCommands.InsertAuthor;
using BookStream.Application.Commands.BookCommands.InsertBook;
using BookStream.Application.Models.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookStream.Application;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValitation();

        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertBookCommand>()
        );
        services.AddMediatR(config =>
           config.RegisterServicesFromAssemblyContaining<InsertAuthorCommand>()
       );

        services.AddTransient<IPipelineBehavior<InsertBookCommand,
                                                ResultViewModel<int>>,
                                                ValidateInsertBookCommandBehavior>();

        return services;
    }

    private static IServiceCollection AddValitation(this IServiceCollection services)
    {

        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<InsertBookCommand>();

        return services;
    }
}
