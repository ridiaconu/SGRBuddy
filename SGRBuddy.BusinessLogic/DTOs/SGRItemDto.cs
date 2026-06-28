using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRItemDto
{
    public Guid SessionId { get; set; }
    public string Barcode  { get; set; } 
    public string Brand { get; set; }
    public SGRItemType Type { get; set; }
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
}