namespace JobCandidateHubAPI.Dtos;

public sealed record CandidateReadDto
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