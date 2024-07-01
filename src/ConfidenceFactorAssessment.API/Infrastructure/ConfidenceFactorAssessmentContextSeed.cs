using Npgsql;
using AutoMapper;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ConfidenceFactorAssessment.API.Infrastructure;

public class ConfidenceFactorAssessmentContextSeed : IDbSeeder<ConfidenceFactorAssessmentContext>
{
    private string _setupFolder = "Setup";
    private string _setupFile = "criteria.json";

    private readonly IWebHostEnvironment _env;
    private readonly IMapper _assessmentMapper;
    private readonly ICriteriaService _criteriaService;
    private readonly ILogger<ConfidenceFactorAssessmentContextSeed> _logger;

    public ConfidenceFactorAssessmentContextSeed(
        IWebHostEnvironment env,
        IMapper assessmentMapper,
        ILogger<ConfidenceFactorAssessmentContextSeed> logger,
        ICriteriaService criteriaService)
    {
        _env = env;
        _logger = logger;
        _criteriaService = criteriaService;
        _assessmentMapper = assessmentMapper;
    }

    public async Task SeedAsync(ConfidenceFactorAssessmentContext context)
    {
        await context.Database.OpenConnectionAsync();
        ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypes();

        if (!context.Criterias.Any())
        {
            var contentRootPath = _env.ContentRootPath;
            var sourcePath = Path.Combine(contentRootPath, _setupFolder, _setupFile);

            var sourceJson = File.ReadAllText(sourcePath);
            var criterions = JsonSerializer.Deserialize<IEnumerable<CriteriaDtoForCreate>>(sourceJson);

            if (criterions == null)
            {
                throw new Exception($"Failed to load or validate criterions from {contentRootPath}");
            }

            await _criteriaService.CreateCriteriaCollection(criterions, false);
        }
    }
}