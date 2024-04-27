using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories;

public class BookRepository : GenericRepository<Book> , IBookRepository
{
    private readonly LibraryManagementDbContext _dbContext;

    public BookRepository(LibraryManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
