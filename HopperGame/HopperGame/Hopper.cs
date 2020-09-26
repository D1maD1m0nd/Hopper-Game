using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HopperGame
{
    class Hopper
    {
        //Площадь  бункера в метрах квадратных
        public int Area;
        //Количество комнат
        public int CountRoom;
        //Расположение
        [DataMember]
        public string Location;
        //Вещи расположенные в бункере
        [DataMember]
        public string Things;

    }
}
