using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Infrastructure.Repositories;

public class AuthorRepository : GenericRepository<Author> , IAuthorRepository
{
    private readonly LibraryManagementDbContext _dbContext;

    public AuthorRepository(LibraryManagementDbContext dbContext) : base(dbContext) 
    {
        _dbContext = dbContext;
    }


}
