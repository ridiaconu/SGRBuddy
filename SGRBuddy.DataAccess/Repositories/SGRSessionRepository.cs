using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.DataAccess.Repositories;

internal class SGRSessionRepository (SGRContext sgrContext) : BaseRepository<SGRSession>(sgrContext), ISGRSessionRepository
{
    public IEnumerable<SGRSession> GetOngoingSessions()
    {
        return CurrentSet.Where(item => item.Status==SGRSessionStatus.Ongoing).ToList();
    }
}