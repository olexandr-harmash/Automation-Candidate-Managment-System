using System.ComponentModel.DataAnnotations;

namespace ConfidenceFactorAssessment.API.Dto;

public record AssessmentDtoForUpdate
{
    public Guid ProjectId { get; init; }

    [Required(ErrorMessage = "CreatedBy is required")]
    public string CreatedBy { get; init; }
}
