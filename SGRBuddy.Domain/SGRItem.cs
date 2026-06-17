using System.ComponentModel.DataAnnotations.Schema;
using SGRBuddy.Domain.Enums;

namespace SGRBuddy.Domain;

public class SGRItem
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public required string Barcode  { get; set; }
    
    [Column("SGRSessionId")]
    public required Guid SessionId { get; set; }
    public string Brand { get; set; }
    
    public SGRItemType Type { get; set; }
    public decimal Capacity { get; set; }
    
    public DateTime ScannedAt { get; set; } = DateTime.Now;
    public bool IsAlcohol { get; set; }
    
    // Navigation property
    public SGRSession SGRSession { get; set; }

}