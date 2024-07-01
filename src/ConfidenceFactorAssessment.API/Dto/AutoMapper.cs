using AutoMapper;

namespace ConfidenceFactorAssessment.API.Dto;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Criteria, CriteriaDto>();
        CreateMap<CriteriaDtoForCreate, Criteria>();
        CreateMap<CriteriaDtoForCreate, Criteria>();

        CreateMap<Assessment, AssessmentDto>();
        CreateMap<AssessmentDtoForCreate, Assessment>();
        CreateMap<AssessmentDtoForUpdate, Assessment>();

        CreateMap<ConfidenceFactor, ConfidenceFactorDto>();
        CreateMap<ConfidenceFactorDtoForCreate, ConfidenceFactor>();
        CreateMap<ConfidenceFactorDtoForUpdate, ConfidenceFactor>();
    }
}
