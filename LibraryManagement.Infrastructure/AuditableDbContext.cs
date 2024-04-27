using LibraryManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure;

public abstract class AuditableDbContext : DbContext
{
    public AuditableDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = username;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.Now;
                entry.Entity.CreatedBy = username;
            }
        }

        var result = await base.SaveChangesAsync();

        return result;
    }
}