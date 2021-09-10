using System;
using System.Collections.Generic;
using System.Text;

namespace HopperGame
{
    public class Disaster
    {
        //Описание катострофы

        public string Description { get; set; }

        //Остаток насления
        public int RemainderPopulation { get; set; }

        public Disaster(
            string description,
            int remainderPopulation)
        {
            Description = description;
            RemainderPopulation = remainderPopulation;
        }
    }
}
