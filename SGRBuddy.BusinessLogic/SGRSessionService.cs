using System.Text;
using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRSessionService (ISGRSessionRepository sgrSessionRepository, ISGRItemRepository sgrItemRepository)
{
    public Guid CreateSession()
    {
        var sgrSession = new SGRSession
        {
            Id = new Guid(),
            StartDate = DateTime.Now,
            Status = SGRSessionStatus.Ongoing,
            TotalItems = 0,
            TotalPrice = 0
        };
        sgrSessionRepository.Add(sgrSession);
        sgrSessionRepository.SaveChanges();

        return sgrSession.Id;
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



    public SGRSessionDto Get(Guid sessionId)
    {
        var session = sgrSessionRepository.Get(sessionId);
        return new SGRSessionDto
        {
            Id = session.Id,
            StartDate = session.StartDate,
            EndDate = session.EndDate,
            Status = session.Status,
            TotalItems = session.TotalItems,
            TotalPrice = session.TotalPrice
        };
    }
    
    public IEnumerable<SGRSessionDto> GetAll()
    {
        var sgrSessions = sgrSessionRepository.GetAll();

        return sgrSessions.Select(s => new SGRSessionDto()
        {
            Id = s.Id,
            StartDate = s.StartDate,
            EndDate = s.EndDate,
            Status = s.Status,
            TotalItems = s.TotalItems,
            TotalPrice = s.TotalPrice
        }).ToList();
    }
}