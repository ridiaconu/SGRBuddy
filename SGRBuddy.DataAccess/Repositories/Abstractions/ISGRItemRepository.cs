using SGRBuddy.Domain;

namespace SGRBuddy.DataAccess.Repositories.Abstractions;

public interface ISGRItemRepository : IRepository<SGRItem>
{
    public IEnumerable<SGRItem> GetAlcohol();
    public IEnumerable<SGRItem> GetBySession(Guid sessionId);
    
    public IEnumerable<SGRItem> GetByBarcode(string  barcode);
}