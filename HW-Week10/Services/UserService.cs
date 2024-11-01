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
using HW_Week10.Repositorys.Dapper;

namespace HW_Week10.Services
{
    public class UserService : DapperUserRepository /*IUserService*/
    {
        //private IUserRepository _userRepository;
        private IDapperUserRepository _dapperUserRepository;

        public UserService()
        {
            //_userRepository = new UserRepository();
            _dapperUserRepository = new DapperUserRepository();
        }

        public List<Users> SearchUsers(string username)
        {
            List<Users> users = new List<Users>();
            List<Users> allusers = _dapperUserRepository.GetAll();
            foreach (var user in allusers)
            {
                username = username.ToLower().Replace(" ", "");
                if (user.UserName.ToLower().StartsWith(username))
                {
                    users.Add(user);
                }
            }
            return users;
        }
        public Result ValidatePassword(string pass)
        {
            Users user = _dapperUserRepository.Get(Storage.CurrentUser.Id);
            if (user.Password == pass)
            {
                return new Result(true, "Pass");
            }
            return new Result(false, "Failed");
        }
        public Result ChangePassword(string currentpass, string newpass)
        {

            if (ValidatePassword(currentpass).IsSuccess)
            {
                Storage.CurrentUser.Password = newpass;
                _dapperUserRepository.Update(Storage.CurrentUser);
                return new Result(true, "Change Password Success");
            }
            return new Result(false, "password incrorrect");
        }

        public Result ChangeStatus(string status)
        {
            switch (status.ToLower())
            {
                case "available":
                    Storage.CurrentUser.StatusEnum = StatusEnum.Available.ToString();
                    _dapperUserRepository.Update(Storage.CurrentUser);
                    return new Result(false, "Status Change to available");
                    break;
                case "unavailable":
                    Storage.CurrentUser.StatusEnum = StatusEnum.UnAvailable.ToString();
                    _dapperUserRepository.Update(Storage.CurrentUser);
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
