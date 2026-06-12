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

    public void RemoveSGRItem(Guid id)
    {
        var session = CurrentSet.FirstOrDefault(s => s.SGRItems.Any(i => i.Id == id));
        if (session != null)
        {
            var itemToRemove = session.SGRItems.FirstOrDefault(i => i.Id == id);
            if (itemToRemove != null)
            {
                session.SGRItems.Remove(itemToRemove);
                SaveChanges();
            }
        }
    }
}