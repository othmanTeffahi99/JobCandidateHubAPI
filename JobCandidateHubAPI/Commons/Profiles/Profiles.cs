using AutoMapper;
using JobCandidateHubAPI.Dtos;
using JobCandidateHubAPI.Entities;

namespace JobCandidateHubAPI.Commons.Profiles;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Candidate, CandidateReadDto>();
        CreateMap<CandidateReadOrUpdateDto, Candidate>();
    }
}