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

    public SGRItem GetSGRItemByBarcode(string barcode)
    {
        return CurrentSet.FirstOrDefault(item => item.Barcode == barcode);
    }
    

}