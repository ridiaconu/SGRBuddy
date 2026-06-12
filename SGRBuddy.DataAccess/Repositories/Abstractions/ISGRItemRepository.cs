using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess.Repositories.Abstractions;

public interface ISGRItemRepository : IRepository<SGRItem>
{
    public IEnumerable<SGRItem> GetAlcohol();

    public SGRItem GetSGRItemByBarcode(string barcode);
}