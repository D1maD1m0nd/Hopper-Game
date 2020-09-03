namespace HopperGame
{
    public class User
    {
        public string Username { get; set; }
        public string Prof { get; set; }
        public string Skill { get; set; }
        public string Gender { get; set; }
        public int Old { get; set; }
        public int Weight { get; set; }
        public int Growth { get; set; }
        public string[] Inventory { get; set; }
        public string Character { get; set; }
        public string Hobby { get; set; }
        public string Health { get; set; }
        public string Phobia { get; set; }

        public User
            (
                    string prof,
                    string skill,
                    string gender,
                    int old,
                    string username,
                    string character,
                    string hobby,
                    string health,
                    int weight,
                    int growth,
                    string phobia
            )
        {
            Prof = prof;
            Skill = skill;
            Gender = gender;
            Old = old;
            Username = username;
            //Inventory = inventory;
            Character = character;
            Hobby = hobby;
            Health = health;
            Weight = weight;
            Growth = growth;
            Phobia = phobia;
        }
    }
}
