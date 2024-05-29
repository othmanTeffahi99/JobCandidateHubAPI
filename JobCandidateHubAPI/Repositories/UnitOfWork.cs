using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.Services;

namespace JobCandidateHubAPI.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private bool _disposed = false;


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return appDbContext.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected  void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                appDbContext.Dispose();
            }

            _disposed = true;
        }
    }
}