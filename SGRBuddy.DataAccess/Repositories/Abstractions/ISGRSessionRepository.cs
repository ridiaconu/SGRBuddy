using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess.Repositories.Abstractions;

public interface ISGRSessionRepository : IRepository<SGRSession>
{
    public IEnumerable<SGRSession> GetOngoingSessions();
    
    public void RemoveSGRItem(Guid id);
}