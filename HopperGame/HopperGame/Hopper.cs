using System;
using System.Collections.Generic;

namespace HopperGame
{
    public class Hopper
    {   
        //Площадь  бункера в метрах квадратных
        public int Area { get; set; } 
        //Количество комнат
        public int CountRoom { get; set; }
        //Расположение
        
        public string Location { get; set; }
        //Вещи расположенные в бункер
        public string[] Things { get; set; }

        public Hopper(
            string location,
            string[] things)
        {
            Area = GenerateRandomArea();
            CountRoom = GenerateCountRoom(Area);
            Location = location;
            Things = things;
        }

        private int GenerateRandomArea()
        {
            var rand = new Random();
            return rand.Next(20, 150);
        }

        private int GenerateCountRoom(int area)
        {
            if (area < 40)
            {
                return 4;
            }

            if (area < 70)
            {
                return 7;
            }

            if (area < 120)
            {
                return 10;
            }

            return 14;
        }

    }
}
