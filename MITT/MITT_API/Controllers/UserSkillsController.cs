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
    public class UserSkillsController : ControllerBase
    {
        private DBConnection db = new DBConnection();
        [Route("api/GetUserSkill")]
        [HttpGet]
        public ActionResult GetUserSkill(string username)
        {
            UserSkills userskill = new UserSkills
            {
                User = new User_Identity(),
                Skill = new Skills(),
                SkillLevel = new SkillLevel()
            };

            MySqlCommand comm = db.comm("SELECT userskills.username as username, " +
                "userprofile.name as name, " +
                "skill.skill_name as skill_name, " +
                "skill_level.skill_level_name as skill_level_name FROM userskills " +
                "inner join user on userskills.username = user.username " +
                "left join userprofile on userskills.username = userprofile.username " +
                "left join skill on userskills.skill_id = skill.skill_id " +
                "left join skill_level on userskills.skill_level_id = skill_level.skill_level_id " +
                "where userskills.username = " + username);
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                userskill.User.username = reader["username"].ToString();
                userskill.UserProfile.name = reader["name"].ToString();
                userskill.Skill.skill_name = reader["skill_name"].ToString();
                userskill.SkillLevel.skill_level_name = reader["skill_level_name"].ToString();
            }
            db.conn.Close();
            return Ok(userskill);
        }

        [Route("api/Create")]
        [HttpPost]
        public ActionResult Create(UserSkills userskill)
        {
            MySqlCommand comm = db.comm("INSERT INTO userskills (username, skill_id, skill_level_id) " +
                "VALUES ('" + userskill.User.username + "', '" + userskill.Skill.skill_id + "','" + userskill.SkillLevel.skill_level_id + "')");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Update")]
        [HttpPut]
        public ActionResult Update(UserSkills userskill)
        {
            MySqlCommand comm = db.comm("Update userskills " +
                "SET skill_id = " + userskill.Skill.skill_id + ", " +
                "skill_level_Id = " + userskill.SkillLevel.skill_level_id + " " +
                "where user_skill_id = " + userskill.user_skill_id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MySqlCommand comm = db.comm("Delete from userskills " +
                "where user_skill_id = " + id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }
    }
}
