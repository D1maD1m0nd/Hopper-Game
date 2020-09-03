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
        [DataMember]
        public List<string> StageDev { get; set; }
        [DataMember]
        public List<string> Body { get; set; }
        //[DataMember]
        //public List<string> inventory { get; set; }
        [DataMember]
        public List<string> Character { get; set; }
        [DataMember]
        public List<string> Hobby { get; set; }
    }
}
