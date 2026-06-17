using System.Text;
using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRSessionService (ISGRSessionRepository sgrSessionRepository, ISGRItemRepository sgrItemRepository)
{
    public SGRSessionDto CreateSession(SGRSessionDto sgrSessionDto)
    {
        var sgrSession = new SGRSession
        {
            StartDate = DateTime.Now,
            EndDate = null,
            Status = SGRSessionStatus.Ongoing,
            TotalItems = 0,
            TotalPrice = 0
        };
        sgrSessionRepository.Add(sgrSession);
        sgrSessionRepository.SaveChanges();
        
        return new SGRSessionDto()
        {
            StartDate = sgrSession.StartDate,
            EndDate = sgrSession.EndDate,
            Status = sgrSession.Status, 
            TotalItems = sgrSession.TotalItems,
            TotalPrice = sgrSession.TotalPrice
        };
    }

    public void EndSession(Guid sessionId)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session!=null)
        {
            session.EndDate = DateTime.Now;
            session.Status = SGRSessionStatus.Finished;
            sgrSessionRepository.SaveChanges();
        }
        else
        {
            throw new Exception("Session not found");
        }

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

    public void RemoveItemFromSession(Guid sessionId, Guid itemId)
    {
        var session = sgrSessionRepository.Get(sessionId);
        if (session == null)
        {
            throw new Exception("Session not found");
        }

        var sgrItem = sgrItemRepository.Get(itemId);

        if (sgrItem == null)
        {
            throw new Exception("Item not found");
        }

        if (sgrItem.SessionId != session.Id)
        {
            throw new Exception("Item not found in session");
        }

        sgrItemRepository.Delete(sgrItem);
        session.TotalItems--;
        session.TotalPrice = (decimal)(session.TotalItems * 0.5);

    sgrSessionRepository.SaveChanges();
        
    }
}