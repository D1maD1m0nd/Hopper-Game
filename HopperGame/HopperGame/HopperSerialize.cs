using System.Collections.Generic;
using System.Runtime.Serialization;


namespace HopperGame
{
    [DataContract]
    public class HopperSerialize
    {

        //Расположение
        [DataMember]
        public List<string> Location { get; set; }
        //Вещи расположенные в бункере
        [DataMember]
        public List<string> Things { get; set; }

        

    }
}
