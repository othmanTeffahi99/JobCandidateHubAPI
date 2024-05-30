using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using JobCandidateHubAPI.Dtos;
using JobCandidateHubAPI.Entities;
using JobCandidateHubAPI.Repositories;
using JobCandidateHubAPI.Services;

namespace JobCandidateHubAPI.EndPoints;

public static class CandidateEndPoints
{
    public static void MapCandidateEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGroup("/api/Candidates").AllowAnonymous().WithOpenApi();

        app.MapGet("/",  async (ICandidateRepository repository, IMapper Mapper, Serilog.ILogger logger) =>
        {
            logger.Information("Getting all candidates.");
            var candidates = await repository.GetAllAsync();
            return Results.Ok(Mapper.Map<IEnumerable<CandidateReadDto>>(candidates));

        }).CacheOutput().WithName("GetAllCandidates");
        
        app.MapPost("/", async (CandidateReadOrUpdateDto candidateDto, IValidator<Candidate>  validator,ICandidateRepository repository, IUnitOfWork unitOfWork ,IMapper mapper, Serilog.ILogger logger) =>
        {
            
            var candidate = mapper.Map<Candidate>(candidateDto);
            
            ValidationResult validationResult = await validator.ValidateAsync(candidate);

            if (!validationResult.IsValid) 
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            
            var cdtEntity =   await repository.GetByEmailAsync(candidate.Email);
            
            if( cdtEntity is null)
            {
                logger.Warning($"this Candidate with email {candidate.Email} does not exists");
                logger.Information("Create new candidate.");
                await repository.CreateAsync(candidate);
                await unitOfWork.SaveChangesAsync();
                return Results.Created();
            }
            else
            {
                logger.Information("Email already exists.");
                logger.Information("Update candidate.");
                await repository.UpdateAsync(candidate);
                await unitOfWork.SaveChangesAsync();
                return Results.Ok(mapper.Map<CandidateReadDto>(candidate));
            }
            
        }).Produces<CandidateReadDto>().CacheOutput().WithName("CreateCandidate");
    }
}