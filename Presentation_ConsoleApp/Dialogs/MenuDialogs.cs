using Buisness.Factories;
using Buisness.Interfaces;

namespace Presentation_ConsoleApp.Dialogs;

public class MenuDialogs(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void MAinMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----Menu Options---");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine();
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddUserOption();
                    break;
                case "2":
                    ViewAllUsersOptions();
                    break;
            }
        }
    }

    public void AddUserOption()
    {
        var form = UserFactory.Create();
        
        Console.Clear();
        Console.WriteLine("----New User---");
        Console.Write("First name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;
        Console.WriteLine();
        
        var result = _userService.Save(form);
        if (result)
            Console.Write("User was created successfully!");
        else
            Console.Write("User was not created!");

        Console.ReadKey();
    }

    public void ViewAllUsersOptions()
    {
        Console.Clear();
        Console.WriteLine("----View All Users----");
        
        var users = _userService.GetAll();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} < {user.Email}>");
        }
        
        Console.ReadKey();
    }
}
