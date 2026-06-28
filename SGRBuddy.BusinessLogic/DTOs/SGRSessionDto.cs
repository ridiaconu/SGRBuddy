using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRSessionDto : SGRSessionBaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public SGRSessionStatus Status { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }
}