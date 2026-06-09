namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRItemBaseDto
{
    //public Guid Id { get; set; }
    public string Barcode  { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Capacity { get; set; }
    public bool IsAlcohol { get; set; }
}