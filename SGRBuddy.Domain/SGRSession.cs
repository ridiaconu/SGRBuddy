using SGRBuddy.Domain.Enums;

namespace SGRBuddy.Domain;

public class SGRSession
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    
    public DateTime StartDate { get; set; } = DateTime.Now;
    
    public DateTime? EndDate { get; set; }

    public int TotalItems { get; set; } = 0;
    
    public SGRSessionStatus Status { get; set; }

    public decimal TotalPrice { get; set; } = 0;
    
    // Navigation property for one-to-many relationship
    public ICollection<SGRItem> SGRItems { get; set; } = new List<SGRItem>();
}