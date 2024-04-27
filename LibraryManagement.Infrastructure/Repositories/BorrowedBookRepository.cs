using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Infrastructure.Repositories;

public class BorrowedBookRepository : GenericRepository<BorrowedBook>, IBorrowedBookRepository
{
    private readonly LibraryManagementDbContext _dbContext;
    public BorrowedBookRepository(LibraryManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
