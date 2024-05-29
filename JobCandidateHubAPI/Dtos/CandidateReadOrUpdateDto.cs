namespace JobCandidateHubAPI.Dtos;

public record CandidateReadOrUpdateDto
(
    string Email,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? CallTimeInterval,
    string? LinkedInProfileUrl,
    string? GitHubProfileUrl,
    string Comment
);