namespace ConfidenceFactorAssessment.API.Dto;

public record AssessmentDto(Guid Id, Guid ProjectId, string CreatedBy, IEnumerable<ConfidenceFactorDto> ConfidenceFactors);

