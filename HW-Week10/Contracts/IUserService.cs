using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Entities;
using HW_Week10.Enums;

namespace HW_Week10.Contracts
{
    public interface IUserService
    {
         Result Login(string username, string password);
         Result Register(Users user);
         public List<Users> SearchUsers(string username);
    }
}
