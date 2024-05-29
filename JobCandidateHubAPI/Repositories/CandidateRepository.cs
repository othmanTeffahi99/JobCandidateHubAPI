using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.Entities;
using JobCandidateHubAPI.Services;

namespace JobCandidateHubAPI.Repositories;

public class CandidateRepository(AppDbContext appDbContext) : RepositoryBase<Candidate>(appDbContext), ICandidateRepository
{
    
}