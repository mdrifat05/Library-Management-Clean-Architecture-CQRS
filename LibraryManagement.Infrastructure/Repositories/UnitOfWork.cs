using LibraryManagement.Application.Constants;
using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Infrastructure;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace HR.LeaveManagement.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly LibraryManagementDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IAuthorRepository _authorRepository;
    private IBookRepository _bookRepository;
    private IMemberRepository _memberRepository;
    private IBorrowedBookRepository _borrowedBookRepository;


    public UnitOfWork(LibraryManagementDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_context);
    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);
    public IMemberRepository MemberRepository => _memberRepository ??= new MemberRepository(_context);
    public IBorrowedBookRepository BorrowedBookRepository => _borrowedBookRepository ??= new BorrowedBookRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
        var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        await _context.SaveChangesAsync(username); //username
    }
}
