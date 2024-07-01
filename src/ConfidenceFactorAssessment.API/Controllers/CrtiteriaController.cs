using Microsoft.AspNetCore.Mvc;

namespace ConfidenceFactorAssessment.API.Controllers;

[ApiController]
[Route("api/criteria")]
public class CrtiteriaController
{
    private readonly AssessmentServices _assessmentServices;
    private readonly AssessmentServiceManager _assessmentServiceManager;

    public CrtiteriaController(AssessmentServices assessmentServices)
    {
        _assessmentServices = assessmentServices;
        _assessmentServiceManager = assessmentServices.assessmentServiceManager;
    }

    [HttpGet("{criteriaId:guid}", Name = "GetCriteriaById")]
    public async Task<IResult> GetCriteriaById(Guid criteriaId)
    {
        var criteriaDto = await _assessmentServiceManager.Criteria.GetCriteriaById(criteriaId, false);

        return TypedResults.Ok(criteriaDto);
    }

    [HttpGet("list")]
    public async Task<IResult> FetchAllCriteriaCollection()
    {
        var criteriaCollectionDto = await _assessmentServiceManager.Criteria.FetchFullCriteriaCollection(false);

        return TypedResults.Ok(criteriaCollectionDto);
    }
}
