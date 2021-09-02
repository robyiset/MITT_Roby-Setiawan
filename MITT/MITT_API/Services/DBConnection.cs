using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MITT_API.Services
{
    public class DBConnection
    {
        public static string connString { get; set; }
        public MySqlConnection conn = new MySqlConnection(connString);
        public MySqlCommand comm(string command)
        {
            return new MySqlCommand
            {
                Connection = conn,
                CommandType = System.Data.CommandType.Text,
                CommandText = command
            };
        }
    }
}
