namespace ConfidenceFactorAssessment.API.Repository.Abstractions;

public interface IConfidenceFactorRepository
{
    Task<IEnumerable<ConfidenceFactor>> FetchConfidenceFactor(Guid assessmentId, IEnumerable<Guid> criteriaId, bool trackChanges);
    Task<ConfidenceFactor?> GetConfidenceFactor(Guid assessmentId, Guid criteriaId, bool trackChanges);
    void CreateConfidenceFactor(Guid assessmentId, Guid criteriaId, ConfidenceFactor confidenceFactor);
    void DeleteConfidenceFactor(ConfidenceFactor confidenceFactor);
}
