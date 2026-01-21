namespace DemoWebAPI.DTO.Requests;

public class UserAddRequestDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Lastname { get; set; }
    public string? Firstname { get; set; }
}
