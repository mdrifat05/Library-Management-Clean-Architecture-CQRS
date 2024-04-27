namespace LibraryManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken);
    Task<bool> Exists(int id, CancellationToken cancellationToken);
    Task<T> Add(T entity, CancellationToken cancellationToken);
    Task Update(T entity, CancellationToken cancellationToken);
    Task Delete(T entity, CancellationToken cancellationToken);

}
