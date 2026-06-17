using SGRBuddy.Domain.Enums;

namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRItemDto
{
    public Guid SessionId { get; set; }
    public string Barcode  { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public SGRItemType Type { get; set; }
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
}