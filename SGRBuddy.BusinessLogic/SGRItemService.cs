using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRItemService(ISGRItemRepository sgrItemRepository, ISGRSessionRepository sgrSessionRepository)
{
    public Guid CreateItem(SGRItemDto sgrItemDto)
    {
        var sgrItem = new SGRItem
        {
            Id = new Guid(),
            Barcode = sgrItemDto.Barcode,
            SessionId = sgrItemDto.SessionId,
            Brand = sgrItemDto.Brand,
            Type = sgrItemDto.Type,
            Capacity = sgrItemDto.Capacity,
            IsAlcohol = sgrItemDto.IsAlcohol

        };
        
        sgrItemRepository.Add(sgrItem);
        sgrItemRepository.SaveChanges();
        AddItemToSession(sgrItem.SessionId, sgrItem.Id);
        return sgrItem.Id;
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
            
            SessionId = s.SessionId,
            Barcode = s.Barcode,
            Brand = s.Brand,
            Capacity = s.Capacity,
            IsAlcohol = s.IsAlcohol,
        }).ToList();
    }
    
    public void AddItemToSession(Guid sessionId, Guid itemId)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session == null)
        {
            throw new Exception("Session not found");
        }
        
        var sgrItem = sgrItemRepository.Get(itemId);

        sgrItem.SessionId = session.Id;
        session.TotalItems++;
        session.TotalPrice = (decimal)(session.TotalItems * 0.5);
        
        sgrSessionRepository.SaveChanges();
    }
    
}