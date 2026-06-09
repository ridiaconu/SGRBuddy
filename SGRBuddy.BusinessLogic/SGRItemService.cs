using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;

namespace SGRBuddy.BusinessLogic;

public class SGRItemService(ISGRItemRepository sgrItemRepository)
{
    public Guid CreateItem(SGRItemBaseDto sgrItemDto)
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
    
    public SGRItemDto UpdateSGRItem(Guid id, SGRItemDto sgrItemDto)
    {
        var sgrItem = sgrItemRepository.Get(id);

        sgrItem.Brand = sgrItemDto.Brand;
        sgrItem.Count = sgrItemDto.Count;

        sgrItemRepository.SaveChanges();

        return new SGRItemDto()
        {
            Id = sgrItem.Id,
            Brand = sgrItem.Brand,
            Count = sgrItem.Count
        };
    }
    
    public void DeleteSGRItem(Guid id)
    {
        var sgrItem = sgrItemRepository.Get(id);

        sgrItemRepository.Delete(sgrItem);
        sgrItemRepository.SaveChanges();
    }
    
    public SGRItemDto GetSGRItems(Guid id)
    {
        var sgrItem = sgrItemRepository.Get(id);

        return new SGRItemDto()
        {
            Id = sgrItem.Id,
            Brand = sgrItem.Brand,
            Count = sgrItem.Count,
            Capacity = sgrItem.Capacity,
            IsAlcohol = sgrItem.IsAlcohol,
            Price = sgrItem.Price
        };
    }
    
    public IEnumerable<SGRItemDto> GetAll()
    {
        var sgrItems = sgrItemRepository.GetAll();

        return sgrItems.Select(s => new SGRItemDto()
        {
            Id = s.Id,
            Brand = s.Brand,
            Count = s.Count,
            Capacity = s.Capacity,
            IsAlcohol = s.IsAlcohol,
            Price = s.Price
        }).ToList();
    }

    public SGRItemDto UpdateCount(Guid id)
    {
        var sgrItem = sgrItemRepository.Get(id);

        sgrItem.Count += 1;
        sgrItemRepository.SaveChanges();
        return new SGRItemDto()
        {
            Id = sgrItem.Id,
            Brand = sgrItem.Brand,
            Count = sgrItem.Count,
            Capacity = sgrItem.Capacity,
            IsAlcohol = sgrItem.IsAlcohol,
            Price = sgrItem.Price
        };
    }
}