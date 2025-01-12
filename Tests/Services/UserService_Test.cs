using Buisness.Dtos;
using Buisness.Interfaces;
using Buisness.Services;
using Moq;

namespace Tests_.Services;

public class UserServiceTest
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IUserService _userService;

    public UserServiceTest()
    {
        _fileServiceMock = new Mock<IFileService>();
        _userService = new UserService(_fileServiceMock.Object);
    }

    [Fact]
    public void Save_ShouldReturnTrue_AddUserToListAndSaveToFile()
    {
        //arrange
        var userRegistrationForm = new UserRegistrationForm()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
        };
        
        _fileServiceMock.Setup(x => x.SaveContentToFile(It.IsAny<string())).Returns(true);
        
        //act
        var result = _userService.Save(userRegistrationForm);



        //assert
        Assert.True(result);
        _fileServiceMock.Verify(x => x.SaveContentToFile(It.IsAny<string>()), Times.Once);
        
    }
}