﻿using System.ComponentModel.DataAnnotations;

namespace ConfidenceFactorAssessment.API.Dto;

public record ConfidenceFactorDtoForCreate
{
    [Range(-1, 1, ErrorMessage = "Value must be in a range")]
    public double Value { get; init; }
}
