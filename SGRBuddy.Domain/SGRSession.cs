using SGRBuddy.Domain.Enums;

namespace SGRBuddy.Domain;

public class SGRSession
{
    public Guid Id { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }

    public int TotalItems { get; set; }
    
    public SGRSessionStatus Status { get; set; }

    public decimal TotalPrice { get; set; }
    
    // Navigation property for one-to-many relationship
    public ICollection<SGRItem> SGRItems { get; set; } = new List<SGRItem>();
}