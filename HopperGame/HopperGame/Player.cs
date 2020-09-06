using System.Collections.Generic;
using System.Runtime.Serialization;


namespace HopperGame
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public List<Prof> Profs { get; set; }
        [DataMember]
        public List<string> Gender { get; set; }
        public int Old { get; set; }
        [DataMember]
        public List<string> Body { get; set; }
        [DataMember]
        public List<string> Inventory { get; set; }
        [DataMember]
        public List<string> Character { get; set; }
        [DataMember]
        public List<string> Hobby { get; set; }
        [DataMember]
        public List<string> Health { get; set; }
        [DataMember]
        public List<string> Phobia { get; set; }
        public int Growth { get; set; }
        public int Weigth { get; set; }

    }
}
