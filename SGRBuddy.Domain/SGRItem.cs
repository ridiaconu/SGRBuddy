namespace SGRBuddy.Domain;

public class SGRItem
{
    public Guid Id { get; set; }
    public string Barcode  { get; set; }
    public string Brand { get; set; }
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}