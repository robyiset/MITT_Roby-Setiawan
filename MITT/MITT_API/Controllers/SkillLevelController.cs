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
    public class SkillLevelController : ControllerBase
    {
        private DBConnection db = new DBConnection();
        [Route("api/GetSkillLevels")]
        [HttpGet]
        public ActionResult GetSkillLevels()
        {
            List<SkillLevel> skill = new List<SkillLevel>();
            MySqlCommand comm = db.comm("SELECT * FROM skill_level");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                skill.Add(new SkillLevel
                {
                    skill_level_id = Convert.ToInt32(reader["skill_level_id"]),
                    skill_level_name = reader["skill_level_name"].ToString()
                });
            }
            db.conn.Close();
            return Ok(skill);
        }

        [Route("api/GetSkillLevels")]
        [HttpGet]
        public ActionResult GetSkillLevels(int id)
        {
            SkillLevel skill = new SkillLevel();
            MySqlCommand comm = db.comm("SELECT * FROM skill_level where skill_level_id = " + id);
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                skill.skill_level_id = Convert.ToInt32(reader["skill_level_id"]);
                skill.skill_level_name = reader["skill_level_name"].ToString();
            }
            db.conn.Close();
            return Ok(skill);
        }

        [Route("api/Create")]
        [HttpPost]
        public ActionResult Create(SkillLevel skill)
        {
            MySqlCommand comm = db.comm("INSERT INTO skill_level (skill_level_name) VALUES ('" + skill.skill_level_name + "')");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Update")]
        [HttpPut]
        public ActionResult Update(SkillLevel skill)
        {
            MySqlCommand comm = db.comm("Update skill_level " +
                "SET skill_level_name = '" + skill.skill_level_name + "' " +
                "where skill_level_id = " + skill.skill_level_id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MySqlCommand comm = db.comm("Delete from skill_level " +
                "where skill_level_id = " + id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }
    }
}
