using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_Front.Models
{
    public class UserSkills
    {
        public int user_skill_id { get; set; }
        public User_Identity User { get; set; }
        public UserProfile UserProfile { get; set; }
        public Skills Skill { get; set; }
        public SkillLevel SkillLevel { get; set; }
    }
}
