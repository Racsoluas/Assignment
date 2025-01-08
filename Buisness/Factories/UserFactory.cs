using Buisness.Dtos;
using Buisness.Helpers;
using Buisness.Models;

namespace Buisness.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create() => new UserRegistrationForm();
    public static User Create(UserRegistrationForm form) => new()
    {
        Id = IdGenerator.Generate(),
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
            
    };
}