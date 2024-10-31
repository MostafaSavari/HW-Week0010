using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Contracts;
using HW_Week10.Data;
using HW_Week10.Enums;
using HW_Week10.Repositorys;

namespace HW_Week10.Entities
{
    public class Users
    {
        private IUserRepository _userRepository;
        public int  Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public StatusEnum StatusEnum { get; set; }

        public Users(string username,string password)
        {
            Id = Storage.Users.Count + 1;
            UserName = username;
            Password = password;
            _userRepository = new UserRepository();
        }

        public Result ChangePassword(string currentpass, string newpass)
        {
            if (Password == currentpass)
            {
                Password = newpass;
                _userRepository.Update(Storage.CurrentUser.Id,Storage.CurrentUser);
                return new Result(true, "Change Password Success");
            }
            return new Result(false, "password incrorrect");
        }
        public Result ChangeStatus(string status)
        {
            switch (status.ToLower())
            {
                case "available":
                    StatusEnum = StatusEnum.Available;
                    _userRepository.Update(Storage.CurrentUser.Id, Storage.CurrentUser);
                    return new Result(false, "Status Change to available");
                    break;
                case "unavailable":
                    StatusEnum = StatusEnum.UnAvailable;
                    _userRepository.Update(Storage.CurrentUser.Id, Storage.CurrentUser);
                    return new Result(false, "Status Change to unavailable");
                    break;
                default:
                    return new Result(false, "Status Input Incorrect");
                break;
            }
            return new Result(false, "Status Input Incorrect");
        }

    }

}
