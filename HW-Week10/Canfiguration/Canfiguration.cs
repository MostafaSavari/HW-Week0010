using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week10.Canfiguration
{
    public static class Canfiguration
    {
        public static string ConnectionString { get; set; }

        static Canfiguration()
        {
            ConnectionString =
                "Data Source=DESKTOP-CMB0AK2\\SQL_2017;Initial Catalog=CommandDb;User ID=sa;Password=Aa@123456; TrustServerCertificate=true";

        }
    }
}
