using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HopperGame
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public List<Prof> prof { get; set; }
        [DataMember]
        public List<string> gender { get; set; }
        [DataMember]
        public List<string> stage_dev { get; set; }
        [DataMember]
        public List<string> body { get; set; }
    }
}
