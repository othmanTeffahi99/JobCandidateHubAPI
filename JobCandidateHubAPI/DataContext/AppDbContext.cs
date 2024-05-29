using JobCandidateHubAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHubAPI.DataContext;

public class AppDbContext : DbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; } = null!;


}