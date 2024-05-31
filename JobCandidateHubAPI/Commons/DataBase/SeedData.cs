using JobCandidateHubAPI.DataContext;
using JobCandidateHubAPI.Entities;

namespace JobCandidateHubAPI.Commons.DataBase;

public class SeedData
{
    public static void PrepareSeedData(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        var logger = serviceScope.ServiceProvider.GetService<Serilog.ILogger>();
        logger?.Debug("SeedData.PrepareSeedData called.");
        if (context is null)
        {
            logger?.Error("AppDbContext is null");
            throw new NullReferenceException("AppDbContext is null");
        }

        if (context.Candidates.Any() is false)
        {
            context.Candidates.AddRange(
                new Candidate
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "JohnDoe@gmail.com",
                    PhoneNumber = "+1234567890",
                    CallTimeInterval = "10:00 AM - 12:00 PM",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/johndoe",
                    GitHubProfileUrl = "https://www.Github.com/in/johndoe",
                    Comment = "John is a great candidate"
                },
                new Candidate
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "JaneSmith@example.com",
                    PhoneNumber = "+1987654321",
                    CallTimeInterval = "1:00 PM - 3:00 PM",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/janesmith",
                    GitHubProfileUrl = "https://www.github.com/janesmith",
                    Comment = "Jane has strong technical skills."
                },
                new Candidate
                {
                    FirstName = "Robert",
                    LastName = "Johnson",
                    Email = "RobertJohnson@example.com",
                    PhoneNumber = "+11234567890",
                    CallTimeInterval = "2:00 PM - 4:00 PM",
                    LinkedInProfileUrl = "https://www.linkedin.com/in/robertjohnson",
                    GitHubProfileUrl = "https://www.github.com/robertjohnson",
                    Comment = "Robert has extensive experience in project management."
                });
        }
       
        logger?.Information("Seeding data.");
        context.SaveChanges();
    }
}