using DemoWebAPI.Data.Entities;
using DemoWebAPI.DTO.Responses;

namespace DemoWebAPI.Mappers;

public static class UserMapperExtensions
{
    public static UserAddResponseDTO ToUserBasicDTO (this User user)
    {
        return new UserAddResponseDTO
        {
            Id = user.Id,
            Email = user.Email,
            Lastname = user.Lastname,
            Firstname = user.Firstname
        };
    }
}
