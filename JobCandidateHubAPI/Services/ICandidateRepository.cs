using JobCandidateHubAPI.Entities;

namespace JobCandidateHubAPI.Services;

public interface ICandidateRepository : IRepository<Candidate>
{
    Task<Candidate?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}