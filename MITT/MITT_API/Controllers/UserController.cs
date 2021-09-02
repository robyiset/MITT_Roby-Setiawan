using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MITT_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MITT_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DBConnection db = new DBConnection();
        [Route("api/login/")]
        [HttpGet]
        public ActionResult Login(string username, string password)
        {
            string user = string.Empty;
            MySqlCommand comm = db.comm("SELECT COUNT(username) AS found, username FROM user WHERE username = '" + username + "' and password = '"+ password + "'");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                user = reader["username"].ToString();
            }
            return Ok(user);
        }
    }
}
