using HW_Week10.Entities;
using HW_Week10.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week10.Contracts
{
    public interface IAuthentication
    {
        Result Login(string username, string password);
        Result Register(Users user);
    }
}
