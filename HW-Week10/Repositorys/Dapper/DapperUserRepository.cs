using HW_Week10.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Week10.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using HW_Week10.Enums;

namespace HW_Week10.Repositorys.Dapper
{
    public class DapperUserRepository : IDapperUserRepository
    {
        public void Create(Users model)
        {
            using (IDbConnection db = new SqlConnection(Canfiguration.Canfiguration.ConnectionString))
            {
                db.Execute(UserQueries.Careate, new { model.UserName,model.Password,model.StatusEnum });
            }
        }

        public Users Get(int id)
        {
            using (IDbConnection db = new SqlConnection(Canfiguration.Canfiguration.ConnectionString))
            {
                return db.QueryFirstOrDefault<Entities.Users>(UserQueries.GetById, new { Id =id   });
            }
        }

        public List<Users> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Canfiguration.Canfiguration.ConnectionString))
            {
                return  db.Query<Entities.Users>(UserQueries.GetAll).ToList();
            }
        }


        public void Update(Users model)
        {
            using (IDbConnection db = new SqlConnection(Canfiguration.Canfiguration.ConnectionString))
            {
                db.Execute(UserQueries.Update, new { id = model.Id ,Username = model.UserName,Password = model.Password , StatusEnum = model.StatusEnum });
            }
        }
    }
}
