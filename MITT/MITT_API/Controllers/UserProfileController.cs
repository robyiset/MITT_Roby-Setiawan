using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MITT_API.Models;
using MITT_API.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_API.Controllers
{
    
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private DBConnection db = new DBConnection();

        [Route("api/Register")]
        [HttpPost]
        public ActionResult Register(UserProfile user)
        {
            int found = 0;
            MySqlCommand comm = db.comm("SELECT COUNT(username) as found FROM user WHERE username = '" + user.user_identity.username + "'");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                found = Convert.ToInt32(reader["found"]);
            }
            if (found > 1)
            {
                return Ok();
            }
            db.conn.Close();
            comm = db.comm("INSERT INTO user (username, password) VALUES ('" + user.user_identity.username + "', '" + user.user_identity.password + "')");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close(); 
            comm = db.comm("INSERT INTO userprofile (name, address, bod, email) VALUES ('" + user.name + "', '" + user.address + "', '" + user.bod.ToString("yyyy-MM-dd") + "', '" + user.email + "')");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Update")]
        [HttpPut]
        public ActionResult Update(UserProfile user)
        {
            MySqlCommand comm = db.comm("Update userprofile " +
                "SET name = '" + user.name + "', " +
                "address = '" + user.address + "'," +
                "bod = '" + user.bod.ToString("yyyy-MM-dd") + "'," +
                "email = '" + user.email + "' " +
                "where username = '" + user.user_identity.username + "'");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }
    }
}
