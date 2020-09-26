using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HopperGame
{

    class Disaster
    {
        //Описание катострофы
        [DataMember]
        public string Description;
        //Дополнительное описание катастрофы
        [DataMember]
        public string SubDescription;
        //Катоклзимы
        [DataMember]
        public string Cataclysm;
        //Остаток насления
        public int RemainderPopulation;
        //Остаток воды
        public int RemainderWater;
      
    }
}
