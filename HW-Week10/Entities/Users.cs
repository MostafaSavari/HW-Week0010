using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Contracts;
using HW_Week10.Data;
using HW_Week10.Enums;
using HW_Week10.Repositorys;
using HW_Week10.Repositorys.Dapper;

namespace HW_Week10.Entities
{
    public class Users
    {
        public int  Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string StatusEnum { get; set; }

        public Users(string username,string password)
        {
            UserName = username;
            Password = password;
        }
        public Users(string username, string password,string statusEnum)
        {
            UserName = username;
            Password = password;
            StatusEnum = statusEnum;
        }


        public Users()
        {
            
        }

    }

}
