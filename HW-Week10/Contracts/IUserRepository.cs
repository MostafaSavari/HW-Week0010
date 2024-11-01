﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Entities;

namespace HW_Week10.Contracts
{
    public interface IUserRepository
    {
        public void Add(Users model);
        public Users Get(int id);
        public List<Users> GetAll();
        public void Update(int id,Users model);
    }
}
