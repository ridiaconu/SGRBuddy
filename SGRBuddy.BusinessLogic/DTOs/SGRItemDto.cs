namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRItemDto : SGRItemBaseDto
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
}