using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Entities;
using HW_Week10.Repositorys;

namespace HW_Week10.Data
{
    public static class Storage
    {
        private static UserRepository _userRepository;
        public static List<Users> Users { get; set; } = new List<Users>();
        public static Users CurrentUser { get; set; }

        static Storage()
        {
            _userRepository = new UserRepository();
        }
        public static void LoadUser()
        {
            try
            {
                Users = _userRepository.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static void SaveUser()
        {
            _userRepository.AddList(Users);
        }
    }
}
