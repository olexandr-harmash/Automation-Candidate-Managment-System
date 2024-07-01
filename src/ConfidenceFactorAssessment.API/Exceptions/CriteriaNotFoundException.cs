namespace ConfidenceFactorAssessment.API.Exceptions;

public class CriteriaNotFoundException : NotFoundException
{
    public CriteriaNotFoundException(Guid id)
        : base($"The criteria with id: {id} doesn't exist in the database.") { }

    public CriteriaNotFoundException(IEnumerable<Guid> ids)
        : base($"The criterias with ids: {ids} doesn't exist in the database.") { }
}
