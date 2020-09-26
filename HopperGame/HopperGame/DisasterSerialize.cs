using System.Collections.Generic;
using System.Runtime.Serialization;


namespace HopperGame
{
    [DataContract]
    public class DisasterSerialize
    {
        //Описание катострофы
        [DataMember]
        public List<string> Description;

    }
}
