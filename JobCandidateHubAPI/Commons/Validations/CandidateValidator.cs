using FluentValidation;
using JobCandidateHubAPI.Entities;

namespace JobCandidateHubAPI.Commons.Validations;

public class CandidateValidator : AbstractValidator<Candidate>
{
    public CandidateValidator()
    {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^\+\d{10}$").When(x => x.PhoneNumber != null);
            RuleFor(x =>  x.LinkedInProfileUrl).Matches(@"^https://www.linkedin.com/.*$").When(x => x.LinkedInProfileUrl != null);
            RuleFor(x => x.GitHubProfileUrl).Matches(@"^https://www.Github.com/.*$").When(x => x.GitHubProfileUrl != null);
    }
}