using DemoWebAPI.Data.Entities;
using DemoWebAPI.DTO.Requests;
using DemoWebAPI.DTO.Responses;
using DemoWebAPI.Mappers;
using DemoWebAPI.Repositories.Interfaces;
using DemoWebAPI.Services.Interfaces;

namespace DemoWebAPI.Services;

public class UserService (IUserRepository _repository) : IUserService
{
    public async Task<UserAddResponseDTO> AddUserAsync(UserAddRequestDTO dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            Password = dto.Password,
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
        };

        await _repository.CreateAsync(user);

        return user.ToUserBasicDTO();
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _repository.ExistingByEmail(email);
    }
}
