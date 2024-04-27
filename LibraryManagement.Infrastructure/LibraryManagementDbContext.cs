using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure;

public class LibraryManagementDbContext : AuditableDbContext
{
    public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementDbContext).Assembly);
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<BorrowedBook> BorrowedBooks { get; set;}
}
