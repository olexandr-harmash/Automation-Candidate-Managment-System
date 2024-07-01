using System.ComponentModel.DataAnnotations;

namespace ConfidenceFactorAssessment.API.Dto;

public record CriteriaDtoForCreate
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; init; }
}
