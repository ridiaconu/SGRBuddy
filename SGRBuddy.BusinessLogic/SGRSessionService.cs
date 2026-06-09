using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.DataAccess.Repositories.Abstractions;
using SGRBuddy.Domain;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic;

public class SGRSessionService (ISGRSessionRepository sgrSessionRepository)
{
    public SGRSessionDto CreateSession(SGRSessionBaseDto sgrSessionBaseDto)
    {
        var sgrSession = new SGRSession
        {
            StartDate = sgrSessionBaseDto.StartDate,
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
}