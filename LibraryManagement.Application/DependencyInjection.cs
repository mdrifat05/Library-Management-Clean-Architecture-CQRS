using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        var assembly = typeof(DependencyInjection).Assembly;
        //for dependency injection extenstion package deprecated
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        //for mediatR package
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });
        //for fluent validation 
        //services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
