namespace ConfidenceFactorAssessment.API.Services.Abstractions;

public interface IConfidenceFactorService
{
    Task<IEnumerable<ConfidenceFactorDto>> FetchConfidenceFactor(Guid assessmentId, IEnumerable<Guid> criteriaIds, bool trackChanges);
    Task<ConfidenceFactorDto> GetConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges);
    Task<ConfidenceFactorDto> CreateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactorDtoForCreate assessment, bool trackChanges);
    Task DeleteConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges);
    Task UpdateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactorDtoForUpdate confidenceFactor, bool trackChanges);
}
