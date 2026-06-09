namespace SGRBuddy.BusinessLogic.DTOs;

public class SGRSessionDto : SGRSessionBaseDto
{
    public Guid Id { get; set; }
    public IEnumerable<SGRItemDto> SGRItems { get; set; } = [];
}