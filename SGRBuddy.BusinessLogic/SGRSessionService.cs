using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRSessionService (ISGRSessionRepository sgrSessionRepository, ISGRItemRepository sgrItemRepository)
{
    public SGRSessionDto CreateSession(SGRSessionBaseDto sgrSessionBaseDto)
    {
        var sgrSession = new SGRSession
        {
            StartDate = DateTime.Now,
            EndDate = null,
            Status = SGRSessionStatus.Ongoing,
            TotalPrice = 0
        };
        sgrSessionRepository.Add(sgrSession);
        sgrSessionRepository.SaveChanges();
        
        return new SGRSessionDto()
        {
            Id = sgrSession.Id,
            StartDate = sgrSession.StartDate,
            EndDate = sgrSession.EndDate,
            Status = sgrSession.Status,
            TotalPrice = sgrSession.TotalPrice
        };
    }

    public void EndSession(Guid sessionId)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session!=null)
        {
            session.EndDate = DateTime.Now;
            sgrSessionRepository.SaveChanges();
        }
        else
        {
            throw new Exception("Session not found");
        }

    }
    
    public void AddItemToSession(Guid sessionId, string barcode)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session == null)
        {
            throw new Exception("Session not found");
        }
        
        var sgrItem = sgrItemRepository.GetSGRItemByBarcode(barcode);
        
        session.SGRItems.Add(sgrItem);
        session.TotalPrice += (decimal)(sgrItem.Price * sgrItem.Count);
        
        sgrSessionRepository.SaveChanges();
    }

    public void RemoveItemFromSession(Guid sessionId, string barcode)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session == null)
        {
            throw new Exception("Session not found");
        }
        var sgrItem = sgrItemRepository.GetSGRItemByBarcode(barcode);
        session.SGRItems.Remove(sgrItem);
        sgrSessionRepository.SaveChanges();
        
    }
}