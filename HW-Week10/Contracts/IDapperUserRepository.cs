using HW_Week10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week10.Contracts
{
    public interface IDapperUserRepository
    {
        public void Create(Users model);
        public Users Get(int id);
        public List<Users> GetAll();
        public void Update(Users model);
    }
}
