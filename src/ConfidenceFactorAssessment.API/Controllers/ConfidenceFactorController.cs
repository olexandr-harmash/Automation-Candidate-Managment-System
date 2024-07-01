using Microsoft.AspNetCore.Mvc;

namespace ConfidenceFactorAssessment.API.Controllers;

[ApiController]
[Route("api/assessment/{assessmentId:guid}")]
public class ConfidenceFactorController
{
    private readonly AssessmentServices _assessmentServices;
    private readonly AssessmentServiceManager _assessmentServiceManager;

    public ConfidenceFactorController(AssessmentServices assessmentServices)
    {
        _assessmentServices = assessmentServices;
        _assessmentServiceManager = assessmentServices.assessmentServiceManager;
    }

    [HttpGet("criteria/{criteriaId}", Name = "GetConfidenceFactor")]
    public async Task<IResult> GetConfidenceFactor(Guid assessmentId, Guid criteriaId)
    {
        var assessmentDto = await _assessmentServiceManager.ConfidenceFactor.GetConfidenceFactor(assessmentId, criteriaId, false);

        return TypedResults.Ok(assessmentDto);
    }

    [HttpPost("criteria/{criteriaId:guid}")]
    [ServiceFilter(typeof(ValidationAttributeFilter))]
    public async Task<IResult> CreateConfidenceFactor(Guid assessmentId, Guid criteriaId, [FromBody] ConfidenceFactorDtoForCreate assessmentForCreate)
    {
        var confidenceFactorDto = await _assessmentServiceManager.ConfidenceFactor.CreateConfidenceFactor(assessmentId, criteriaId, assessmentForCreate, false);

        return Results.CreatedAtRoute(
            "GetConfidenceFactor",
            new
            {
                assessmentId = confidenceFactorDto.AssessmentId,
                criteriaId = confidenceFactorDto.CriteriaId,
            },
            confidenceFactorDto);
    }

    [HttpPut("criteria/{criteriaId:guid}")]
    [ServiceFilter(typeof(ValidationAttributeFilter))]
    public async Task<IResult> UpdateConfidenceFactor(Guid assessmentId, Guid criteriaId, [FromBody] ConfidenceFactorDtoForUpdate assessmentForUpdate)
    {
        await _assessmentServiceManager.ConfidenceFactor.UpdateConfidenceFactor(assessmentId, criteriaId, assessmentForUpdate, true);

        return TypedResults.NoContent();
    }

    [HttpDelete("criteria/{criteriaId:guid}")]
    public async Task<IResult> DeleteConfidenceFactor(Guid assessmentId, Guid criteriaId)
    {
        await _assessmentServiceManager.ConfidenceFactor.DeleteConfidenceFactor(assessmentId, criteriaId, false);

        return TypedResults.NoContent();
    }
}
