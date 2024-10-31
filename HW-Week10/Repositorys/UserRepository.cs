using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Contracts;
using HW_Week10.Entities;
using Newtonsoft.Json;

namespace HW_Week10.Repositorys
{
    public class UserRepository: IUserRepository
    {
        private string _path = "";

        public UserRepository(string path= null)
        {
            if (string.IsNullOrEmpty(path))
            {
                if (!Directory.Exists("Database"))
                    Directory.CreateDirectory("Database");
                //_path = $"Database/{typeof(Users)}.json";
                _path = $"Database/Users.json";
                if (!File.Exists(_path))
                {
                    var myFile = File.Create(_path);
                    myFile.Close();
                }


            }
            else
            {
                _path = path;
                if (!File.Exists(_path))
                {
                    var myFile = File.Create(_path);
                    myFile.Close();
                }
            }
        }
        public void Add(Users model)
        {
            var data = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<Users>>(data);
            if (users == null)
                users = new List<Users>();
            users.Add(model);
            var result = JsonConvert.SerializeObject(users);

            File.WriteAllText(_path, result);
        }

        public void AddList(List<Users> model)
        {
            var result = JsonConvert.SerializeObject(model);
            File.WriteAllText(_path, result);
        }
        public Users Get(int id)
        {
            var data = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<Users>>(data);
            if (users == null)
                users = new List<Users>();
            return users.FirstOrDefault(x => x.Id == id);
        }

        public List<Users> GetAll()
        {
            var data = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<Users>>(data);
            if (users == null)
                users = new List<Users>();
            return users;
        }

        public void Delete(int id)
        {
            var data = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<Users>>(data);
            if (users == null)
                users = new List<Users>();
            var user = users.FirstOrDefault(x => x.Id == id);
            users.Remove(user);
            var result = JsonConvert.SerializeObject(users);
            File.WriteAllText(_path, result);
        }

        public void Update(int id, Users model)
        {
            var data = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<Users>>(data);
            if (users == null)
                users = new List<Users>();
            var user = users.FirstOrDefault(x => x.Id == id);
            users.Remove(user);
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.StatusEnum = model.StatusEnum;
            users.Add(user);
            var result = JsonConvert.SerializeObject(users);
            File.WriteAllText(_path, result);
        }
    }
}
