using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRItemService(ISGRItemRepository sgrItemRepository)
{
    public string CreateItem(SGRItemDto sgrItemDto)
    {
        var sgrItem = new SGRItem
        {
            Barcode = sgrItemDto.Barcode,
            SessionId = sgrItemDto.SessionId,
            Brand = sgrItemDto.Brand,
            Type = sgrItemDto.Type,
            Capacity = sgrItemDto.Capacity,
            IsAlcohol = sgrItemDto.IsAlcohol

        };
        sgrItemRepository.Add(sgrItem);
        sgrItemRepository.SaveChanges();
        return sgrItem.Barcode;
    }
    
    public SGRItemDto UpdateSGRItem(Guid Id, SGRItemDto sgrItemDto)
    {
        var sgrItem = sgrItemRepository.Get(Id);

        sgrItem.Brand = sgrItemDto.Brand;
        sgrItem.Type = sgrItemDto.Type;
        sgrItem.Capacity = sgrItemDto.Capacity;
        sgrItem.IsAlcohol = sgrItemDto.IsAlcohol;
        sgrItemRepository.SaveChanges();

        return new SGRItemDto()
        {
            Barcode = sgrItem.Barcode,
            Brand = sgrItem.Brand,
            Capacity = sgrItem.Capacity,
            IsAlcohol = sgrItem.IsAlcohol,
            Type = sgrItem.Type
        };
    }
    
    public void DeleteSGRItem(Guid  Id)
    {
        var sgrItem = sgrItemRepository.Get(Id);

        sgrItemRepository.Delete(sgrItem);
        sgrItemRepository.SaveChanges();
    }

    public SGRItemDto Get(Guid Id)
    {
        var sgrItem = sgrItemRepository.Get(Id);
        return new SGRItemDto
        {
            SessionId = sgrItem.SessionId,
            Barcode = sgrItem.Barcode,
            Brand = sgrItem.Brand,
            Type = sgrItem.Type,
            Capacity = sgrItem.Capacity,
            IsAlcohol = sgrItem.IsAlcohol
        };
    }
    
    public IEnumerable<SGRItemDto> GetAll()
    {
        var sgrItems = sgrItemRepository.GetAll();

        return sgrItems.Select(s => new SGRItemDto()
        {
            Barcode = s.Barcode,
            Brand = s.Brand,
            Capacity = s.Capacity,
            IsAlcohol = s.IsAlcohol,
        }).ToList();
    }
}