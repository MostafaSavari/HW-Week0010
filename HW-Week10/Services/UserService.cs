using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Contracts;
using HW_Week10.Data;
using HW_Week10.Entities;
using HW_Week10.Enums;
using HW_Week10.Repositorys;

namespace HW_Week10.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public Result Login(string username, string password)
        {
            foreach (var user in Storage.Users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    Storage.CurrentUser =user;
                    return new Result(true, "Login Successfull");
                }
            }
            
            return new Result(false, "UserName OR Password InCorrect");
        }

        public Result Register(Users user)
        {
            foreach (var u in Storage.Users)
            {
                if (u.UserName == user.UserName)
                {
                    return new Result(false, "register failed! username already exists.");
                }
            }
            _userRepository.Add(user);
            Storage.Users.Add(user);
            return new Result(true, "Register Successfull");
        }

        public List<Users> SearchUsers(string username)
        {
            List<Users> users = new List<Users>();
            foreach (var user in Storage.Users)
            {
                username = username.ToLower().Replace(" ", "");
                if (user.UserName.ToLower().StartsWith(username))
                {
                    users.Add(user);
                }
            }
            return users;
        }


    }
}
