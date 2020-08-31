using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HopperGame
{
    [DataContract]
    public class Prof
    {
        [DataMember]
        public Obstetrician Obstetrician { get; set; }
        [DataMember]
        public Lawyer Lawyer { get; set; }
        [DataMember]
        public Agronomist Agronomist { get; set; }
    }
}
