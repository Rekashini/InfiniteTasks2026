using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    class DBHandler
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(
                "server=ICS-LT-DPCQLB4\\SQLEXPRESS;database=TrainDB;integrated security=true");

            return con;
        }
    }
}