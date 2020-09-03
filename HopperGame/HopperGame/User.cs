namespace HopperGame
{
    public class User
    {
        public string Username { get; set; }
        public string Prof { get; set; }
        public string Skill { get; set; }
        public string Gender { get; set; }
        public string StageDev { get; set; }
        public string Body { get; set; }
        public string[] Inventory { get; set; }
        public string Character { get; set; }
        public string Hobby { get; set; }
        public string Health { get; set; }

        public User
            (
                    string prof,
                    string skill,
                    string gender,
                    string stagedev,
                    string body,
                    string username,
                    string character,
                    string hobby,
                    string health
            )
        {
            Prof = prof;
            Skill = skill;
            Gender = gender;
            StageDev = stagedev;
            Body = body;
            Username = username;
            //Inventory = inventory;
            Character = character;
            Hobby = hobby;
            Health = health;
        }
    }
}
