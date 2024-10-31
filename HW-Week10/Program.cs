using System.Collections.Generic;
using System;
using System.Data.SqlTypes;
using HW_Week10.Data;
using HW_Week10.Entities;
using HW_Week10.Repositorys;
using HW_Week10.Services;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using HW_Week10.Enums;

Storage.LoadUser();
UserRepository userRepository = new UserRepository();
UserService userService = new UserService();

//var user = new Users("msavari","Aa@12345")
//{
//};
//userRepository.Add(user);

//string input = "  login --username sara --password 12@34";
//var comma = input.Split(" ");
//var result = Command(input);
//Console.ReadKey();

Main();
void Main()
{
    Console.Clear();
    Console.WriteLine("Plase enter login\\register --username user --password pass");
    var input = Console.ReadLine();
    if (input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Count == 5 )
    {
        var dictonary = Command(input);
        var typeCommand = GetTypeCommand(dictonary);
        if (typeCommand.ToLower() == "login")
        {
            if (dictonary.ContainsKey("username") && dictonary.ContainsKey("password"))
            {
                var result = userService.Login(dictonary["username"].ToLower(), dictonary["password"]);
                Console.WriteLine("Login Succesfully");
                Console.ReadKey();
                LoginMenu();
            }
            else
            {
                Console.WriteLine("Username or password is invlaid");
                Console.ReadKey();
                Main();
            }
            
        }
        else if (typeCommand.ToLower() == "register")
        {
            if (dictonary.ContainsKey("username") && dictonary.ContainsKey("password"))
            {
                Users user = new Users(dictonary["username"], dictonary["password"]);
                var result = userService.Register(user);
                Console.WriteLine(result.Message);
                Console.WriteLine("Plase login");
                Console.ReadKey();
                Main();
            }
            else
            {
                Console.WriteLine("Username or password is invlaid");
                Console.ReadKey();
                Main();
            }

        }
    }
    else
    {
        Console.WriteLine("The input is invalid");
        Console.ReadKey();
        Main();
    }

}

void LoginMenu()
{
    Console.Clear();
    Console.WriteLine("Change --status available\\unavailable \n " +
                      "ChangePassword --old [OldPassword] --new [NewPassword] \n " +
                      "Search --username [username] \n" +
                      "Logout");

    var input = Console.ReadLine();
    var dictonary = Command(input);
    var typeCommand = GetTypeCommand(dictonary);
    if (typeCommand.ToLower() == "change")
    {
        if (dictonary.ContainsKey("status"))
        {
            var result = Storage.CurrentUser.ChangeStatus(dictonary["status"]);
            Console.WriteLine(result.Message);
        }
        else
        {
            Console.WriteLine("Input InCorrect!");
        }
        Console.ReadKey();
        LoginMenu();
    }
    if (typeCommand.ToLower() == "changepassword")
    {
        if (dictonary.ContainsKey("old") && dictonary.ContainsKey("new"))
        {
            var result = Storage.CurrentUser.ChangePassword(dictonary["old"], dictonary["new"]);
            Console.WriteLine(result.Message);
            
        }
        else
        {
            Console.WriteLine("Input InCorrect!");
        }
        Console.ReadKey();
        LoginMenu();

    }
    if (typeCommand.ToLower() == "search")
    {
        if (dictonary.ContainsKey("username"))
        {
            var users = userService.SearchUsers(dictonary["username"].ToLower());
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    if (user.StatusEnum != null)
                    {
                        Console.WriteLine($"{user.UserName} || {user.StatusEnum}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Input InCorrect!");
        }
        Console.ReadKey();
        LoginMenu();
    }
    if (typeCommand.ToLower() == "logout")
    {
        //Call Main Methode
        Storage.CurrentUser = null;
        Main();
    }


}
string GetTypeCommand(Dictionary<string, string> dic)
{
    var reuslt = string.Empty;
    reuslt = dic.ElementAt(0).Key;
    return reuslt;
}
Dictionary<string, string> Command(string input)
{
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    string[] values = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < values.Length; i++)
    {
        if (values[i].StartsWith("--"))
        {
            if (i < values.Length - 1)
            {
                dictionary.Add(values[i].Substring(2).ToLower(), values[i + 1]);
                i++;
            }
            else
            {
                dictionary.Add(values[i].Substring(2).ToLower(), values[i]);
            }

        }
        else
        {
            if (i != values.Length -1)
            {
                dictionary.Add(values[i].ToLower(), values[i].ToLower());
            }
        }
    }
    return dictionary;
}
Storage.SaveUser();