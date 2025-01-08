using System.Text.Json;
using Buisness.Dtos;
using Buisness.Factories;
using Buisness.Interfaces;
using Buisness.Models;

namespace Buisness.Services;

public class UserService : IUserService
{
    private readonly IFileService _fileService;
    private List<User> _users = [];

    public UserService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public bool Save(UserRegistrationForm form)
    {
        var user = UserFactory.Create(form);
        _users.Add(user);
        
        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveContentToFile(json);
        return result;
    }

    public IEnumerable<User> GetAll()
    {
        var content = _fileService.GetContentFromFile();
        try
        {
            _users = JsonSerializer.Deserialize<List<User>>(content)!;
            
        }
        catch
        {
            _users = [];
        }
        return _users;
    }
}