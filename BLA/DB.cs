using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLA
{
    internal class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source = localhost; Initial Catalog = GreenZone; Integrated Security = True");
        
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection GetConnection() {  return connection; }
    }
}
