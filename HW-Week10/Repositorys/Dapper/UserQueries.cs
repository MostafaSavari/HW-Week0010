using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week10.Repositorys.Dapper
{
    public static class UserQueries
    {
        public static string Careate = "INSERT INTO Users (UserName, Password ,StatusEnum ) VALUES (@UserName, @Password, @StatusEnum );";
        public static string GetById = "SELECT * FROM dbo.Users WHERE Id = @Id;";
        public static string GetAll = "SELECT * FROM dbo.Users;";
        //public static string Delete = "Delete dbo.Users WHERE Id = @Id;";
        public static string Update = "UPDATE dbo.Users SET UserName = @UserName, [Password] = @Password, StatusEnum = @StatusEnum WHERE Id = @id";
    }
}
