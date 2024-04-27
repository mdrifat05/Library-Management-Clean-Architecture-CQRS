using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly LibraryManagementDbContext _dbContext;
    public GenericRepository(LibraryManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<T> Table
    {
        get
        {
            return _dbContext.Set<T>();
        }
    }
    public async Task<T> Add(T entity, CancellationToken cancellationToken)
    {
        await Table.AddAsync(entity);
        //await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task Delete(T entity, CancellationToken cancellationToken)
    {
        Table.Remove(entity);
        //await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Exists(int id, CancellationToken cancellationToken)
    {
        var entity = await Get(id, cancellationToken);
        return entity != null;
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await Table.FindAsync(id, cancellationToken);
        if (entity != null)
        {
            return entity;
        }
        throw new NotFoundException(nameof(T), id);
    }

    public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Table.ToListAsync(cancellationToken);
    }

    public async Task Update(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        //await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
