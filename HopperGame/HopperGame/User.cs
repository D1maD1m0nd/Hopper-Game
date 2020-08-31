using System;
using System.Collections.Generic;
using System.Text;

namespace HopperGame
{
    public class User
    {

        public string Prof { get; set; }
        public string Skill { get; set; }
        public string Gender { get; set; }
        public string StageDev { get; set; }
        public string Body { get; set; }

        public User(string prof, string skill, string gender, string stagedev, string body)
        {
            Prof = prof;
            Skill = skill;
            Gender = gender;
            StageDev = stagedev;
            Body = body;
        }
    }
}
