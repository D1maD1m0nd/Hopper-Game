using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HopperGame
{
    [DataContract]
    public class Obstetrician
    {
        [DataMember]
        public string Name_prof { get; set; }
        [DataMember]
        public string Skills { get; set; }
    }
}
