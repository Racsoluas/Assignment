using Xunit;
using Buisness.Dtos;
using Buisness.Factories;

namespace Tests.Factories;

public class UserFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnUserRegistrationForm()
    {
        //Act
        var result = UserFactory.Create();
        
        //Assert
        Assert.NotNull(result);
        Assert.IsType<UserRegistrationForm>(result);
    }
    
    [Fact]
    public void Create_ShouldReturnUser_WhenUserRegistrationFormIsProvided()
    {
        //Arrenge
        var userRegistrationForm = new UserRegistrationForm()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@mail.com",
        };
        
        //Act
        var result = UserFactory.Create(userRegistrationForm);
        
        //Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.Equal(userRegistrationForm.Email, result.Email);
    }
    
}