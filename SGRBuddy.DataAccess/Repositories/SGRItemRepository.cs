using Microsoft.EntityFrameworkCore;

using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess.Repositories;

internal class SGRItemRepository(SGRContext sgrContext) : BaseRepository<SGRItem>(sgrContext), ISGRItemRepository
{
    public IEnumerable<SGRItem> GetAlcohol()
    {
        return CurrentSet.Where(item => item.IsAlcohol == true).ToList();
    }

    public IEnumerable<SGRItem> GetBySession(Guid sessionId)
    {
        return CurrentSet.Where(item => item.SessionId == sessionId).ToList();
    }

    public IEnumerable<SGRItem> GetByBarcode(string barcode)
    {
       return  CurrentSet.Where(item => item.Barcode == barcode).ToList();
    }
}