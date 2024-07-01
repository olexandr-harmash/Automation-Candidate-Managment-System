using System.ComponentModel.DataAnnotations;

namespace ConfidenceFactorAssessment.API.Dto;

public record AssessmentDtoForCreate
{
    public Guid ProjectId { get; init; }

    [Required(ErrorMessage = "CreatedBy is required")]
    public string CreatedBy { get; init; }
}
