namespace JobCandidateHubAPI.Services;

public interface IRepository<T> where T : class
{
    
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity,CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity,CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity,CancellationToken cancellationToken = default);
    
    
}