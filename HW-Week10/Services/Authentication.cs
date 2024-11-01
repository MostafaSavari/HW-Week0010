using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Contracts;
using HW_Week10.Data;
using HW_Week10.Entities;
using HW_Week10.Enums;
using HW_Week10.Repositorys.Dapper;

namespace HW_Week10.Services
{
    public class Authentication : DapperUserRepository, IAuthentication
    {
        private IDapperUserRepository _dapperUserRepository;

        public Authentication()
        {
            _dapperUserRepository = new DapperUserRepository();
        }
        public Result Login(string username, string password)
        {
            List<Users> users = _dapperUserRepository.GetAll();
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    Storage.CurrentUser = user;
                    return new Result(true, "Login Successfull");
                }
            }

            return new Result(false, "UserName OR Password InCorrect");
        }

        public Result Register(Users user)
        {
            List<Users> users = _dapperUserRepository.GetAll();
            foreach (var u in users)
            {
                if (u.UserName == user.UserName)
                {
                    return new Result(false, "register failed! username already exists.");
                }
            }
            //_userRepository.Add(user);
            _dapperUserRepository.Create(user);
            return new Result(true, "Register Successfull");
        }
    }
}
