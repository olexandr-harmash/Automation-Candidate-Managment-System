namespace ConfidenceFactorAssessment.API.Dto;

public record ConfidenceFactorDto(Guid Id, Guid AssessmentId, Guid CriteriaId, double Value);
