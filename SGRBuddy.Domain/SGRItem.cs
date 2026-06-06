namespace SGRBuddy.Domain;

public class SGRItem
{
    public Guid Id { get; set; }
    public string Barcode  { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
}