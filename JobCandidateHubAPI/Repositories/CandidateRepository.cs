using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.Entities;
using JobCandidateHubAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.Repositories;

public class CandidateRepository(AppDbContext appDbContext) : RepositoryBase<Candidate>(appDbContext), ICandidateRepository
{
    public Task<Candidate?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return appDbContext.Candidates.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }
}