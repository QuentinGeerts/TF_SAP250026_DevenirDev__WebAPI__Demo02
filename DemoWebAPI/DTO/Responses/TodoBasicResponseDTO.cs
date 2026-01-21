using DemoWebAPI.Data.Enums;

namespace DemoWebAPI.DTO.Responses;

public class TodoBasicResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public TodoStatus Status { get; set; }
}
