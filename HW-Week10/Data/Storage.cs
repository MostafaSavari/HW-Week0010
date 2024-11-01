using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Entities;
using HW_Week10.Repositorys;
using HW_Week10.Repositorys.Dapper;

namespace HW_Week10.Data
{
    public static class Storage
    {
        public static Users CurrentUser { get; set; }
    }
}
