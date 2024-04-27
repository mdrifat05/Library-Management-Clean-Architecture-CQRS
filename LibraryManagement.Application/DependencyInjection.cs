﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
