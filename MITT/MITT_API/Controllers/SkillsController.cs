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
    public class SkillsController : ControllerBase
    {
        private DBConnection db = new DBConnection();
        [Route("api/GetSkills")]
        [HttpGet]
        public ActionResult GetSkills()
        {
            List<Skills> skill = new List<Skills>();
            MySqlCommand comm = db.comm("SELECT * FROM skill");
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                skill.Add(new Skills 
                {
                    skill_id = Convert.ToInt32(reader["skill_id"]),
                    skill_name = reader["skill_name"].ToString()
                });
            }
            db.conn.Close();
            return Ok(skill);
        }

        [Route("api/GetSkills")]
        [HttpGet]
        public ActionResult GetSkills(int id)
        {
            Skills skill = new Skills();
            MySqlCommand comm = db.comm("SELECT * FROM skill where skill_id = " + id);
            db.conn.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                skill.skill_id = Convert.ToInt32(reader["skill_id"]);
                skill.skill_name = reader["skill_name"].ToString();
            }
            db.conn.Close();
            return Ok(skill);
        }

        [Route("api/Create")]
        [HttpPost]
        public ActionResult Create(Skills skill)
        {
            MySqlCommand comm = db.comm("INSERT INTO skill (skill_name) VALUES ('" + skill.skill_name + "')");
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Update")]
        [HttpPut]
        public ActionResult Update(Skills skill)
        {
            MySqlCommand comm = db.comm("Update skill " +
                "SET skill_name = '" + skill.skill_name + "' " +
                "where skill_id = " + skill.skill_id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }

        [Route("api/Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MySqlCommand comm = db.comm("Delete from skill " +
                "where skill_id = " + id);
            db.conn.Open();
            comm.ExecuteNonQuery();
            db.conn.Close();
            return Ok();
        }
    }
}
