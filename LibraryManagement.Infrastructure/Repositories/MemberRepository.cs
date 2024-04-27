using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories;

public class MemberRepository : GenericRepository<Member> , IMemberRepository
{
    private readonly LibraryManagementDbContext _dbContext;
    public MemberRepository(LibraryManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
