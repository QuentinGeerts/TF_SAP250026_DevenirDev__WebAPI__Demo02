using DemoWebAPI.DTO.Requests;
using DemoWebAPI.DTO.Responses;

namespace DemoWebAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserAddResponseDTO> AddUserAsync(UserAddRequestDTO dto);
    Task<bool> EmailExists(string email);
}
