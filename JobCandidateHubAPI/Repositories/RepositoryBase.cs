using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Repositories;

public class RepositoryBase<T>(AppDbContext appDbContext) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await appDbContext.Set<T>().ToListAsync(cancellationToken);


    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await appDbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);


    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    { 
        await appDbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            appDbContext.Set<T>().Update(entity);
        }, cancellationToken);
        
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            appDbContext.Set<T>().Update(entity);
        }, cancellationToken);
    }
}