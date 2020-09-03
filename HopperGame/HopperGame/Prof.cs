
using System.Runtime.Serialization;


namespace HopperGame
{
    [DataContract]
    public class Prof
    {
        [DataMember]
        public string NameProf { get; set; }
        [DataMember]
        public string Skill { get; set; }
    }
}
