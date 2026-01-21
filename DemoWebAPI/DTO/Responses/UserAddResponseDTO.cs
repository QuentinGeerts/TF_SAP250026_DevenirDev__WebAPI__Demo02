using DemoWebAPI.Data.Entities;

namespace DemoWebAPI.DTO.Responses;

public class UserAddResponseDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Lastname { get; set; }
    public string? Firstname { get; set; }
}
