namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRItemDto
{
    public Guid Id { get; set; }
    public string Barcode  { get; set; }
    public string Brand { get; set; }
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}