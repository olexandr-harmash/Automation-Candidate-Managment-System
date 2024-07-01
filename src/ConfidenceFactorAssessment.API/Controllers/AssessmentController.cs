using Microsoft.AspNetCore.Mvc;

namespace ConfidenceFactorAssessment.API.Controllers;

[ApiController]
[Route("/api/assessment")]
public class AssessmentController : ControllerBase
{
    private readonly AssessmentServices _assessmentServices;
    private readonly AssessmentServiceManager _assessmentServiceManager;

    public AssessmentController(AssessmentServices assessmentServices)
    {
        _assessmentServices = assessmentServices;
        _assessmentServiceManager = assessmentServices.assessmentServiceManager;
    }

    [HttpGet("{assessmentId:guid}", Name = "GetAssessmentById")]
    public async Task<IResult> GetAssessmentById(Guid assessmentId)
    {
        var assessmentDto = await _assessmentServiceManager.Assessment.GetAssessmentById(assessmentId, false);

        return TypedResults.Ok(assessmentDto);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationAttributeFilter))]
    public async Task<IResult> CreateAssessment([FromBody] AssessmentDtoForCreate assessmentForCreate)
    {
        var assessmentDto = await _assessmentServiceManager.Assessment.CreateAssessment(assessmentForCreate);

        return Results.CreatedAtRoute("GetAssessmentById", new { assessmentId = assessmentDto.Id }, assessmentDto);
    }

    [HttpPut]
    [ServiceFilter(typeof(ValidationAttributeFilter))]
    public async Task<IResult> UpdateAssessment(Guid assessmentId, [FromBody] AssessmentDtoForUpdate assessmentForUpdate)
    {
        await _assessmentServiceManager.Assessment.UpdateAssessment(assessmentId, assessmentForUpdate, false);

        return TypedResults.NoContent();
    }

    [HttpDelete("{assessmentId:guid}")]
    public async Task<IResult> DeleteAssessment(Guid assessmentId)
    {
        await _assessmentServiceManager.Assessment.DeleteAssessment(assessmentId, false);

        return TypedResults.NoContent();
    }
}
