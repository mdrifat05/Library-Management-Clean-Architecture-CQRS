using HR.LeaveManagement.Persistence.Repositories;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<LibraryManagementDbContext>(options =>
                options.UseSqlServer(
                configuration.GetConnectionString("SQLConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
        return services;
    }
}
