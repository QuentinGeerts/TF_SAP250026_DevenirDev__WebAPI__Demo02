using DemoWebAPI.Data.Entities;

namespace DemoWebAPI.Repositories.Interfaces;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<bool> ExistingByEmail(string email);
}
