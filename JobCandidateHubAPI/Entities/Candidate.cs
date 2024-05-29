namespace JobCandidateHubAPI.Entities;

public class Candidate
{
 
        public required string Email { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
        
        public string? PhoneNumber { get; set; }

        public string? CallTimeInterval { get; set; }

        public string? LinkedInProfileUrl { get; set; }

        public string? GitHubProfileUrl { get; set; }

        public required string Comment { get; set; }
    
}