using Buisness.Dtos;
using Buisness.Models;

namespace Buisness.Interfaces;

public interface IUserService
{
    bool Save(UserRegistrationForm form);
    IEnumerable<User> GetAll();
}