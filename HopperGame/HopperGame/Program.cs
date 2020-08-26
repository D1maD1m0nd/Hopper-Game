using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HopperGame
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Player
    {
        public string[] gender { get; set; }
        public string[] stage_dev { get; set; }
        public string[] Body { get; set; }
    }


    class Program
    {
        static async Task Main(string[] args)
        {
            // чтение данных
            FileStream fs = new FileStream("D:/Рабочий стол/Git_proj/HopperGame/HopperGame/player.json", FileMode.OpenOrCreate);
            Player restoredPlayer = await JsonSerializer.DeserializeAsync<Player>(fs);
            Console.WriteLine("Все ОК");

            string gender_player = PropertyRandStr(restoredPlayer.gender);
            string stage_dev_player = PropertyRandStr(restoredPlayer.stage_dev);
            string body_player = PropertyRandStr(restoredPlayer.Body);



            
            
            
        }

        //Генерация свойства gender
        static string PropertyRandStr(string[] obj)
        {
            Random rand = new Random();
            return obj[rand.Next(obj.Length)];
        }

        
    }
}
