using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;

namespace SGRBuddy.BusinessLogic;

public class SGRItemService(ISGRItemRepository sgrItemRepository)
{
    public Guid CreateItem(SGRItemDto sgrItemDto)
    {
        var sgrItem = new SGRItem
        {
            Barcode = sgrItemDto.Barcode,
            Brand = sgrItemDto.Brand,
            IsAlcohol = sgrItemDto.IsAlcohol,
            Price = 0.5,
            Count = 1,
            Capacity = sgrItemDto.Capacity
        };
        sgrItemRepository.Add(sgrItem);
        sgrItemRepository.SaveChanges();
        return sgrItem.Id;
    }
    
    
}