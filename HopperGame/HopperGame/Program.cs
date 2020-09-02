using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace HopperGame
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Obstetrician
    {
        public string name_prof { get; set; }
        public string skills { get; set; }
    }

    public class Lawyer
    {
        public string name_prof { get; set; }
        public string skills { get; set; }
    }

    public class Agronomist
    {
        public string name_prof { get; set; }
        public string skills { get; set; }
    }

    public class Prof
    {
        public Obstetrician Obstetrician { get; set; }
        public Lawyer Lawyer { get; set; }
        public Agronomist Agronomist { get; set; }
    }

    public class Player
    {
        public List<Prof> prof { get; set; }
        public List<string> gender { get; set; }
        public List<string> stage_dev { get; set; }
        public List<string> Body { get; set; }
    }



    class Program
    {
        static async Task Main(string[] args)
        {

            FileStream fs = new FileStream($"D:/Рабочий стол/Git_proj/HopperGame/HopperGame/player.json", FileMode.OpenOrCreate);

                

            Player restoredPlayer = await JsonSerializer.DeserializeAsync<Player>(fs);
            string gender_player = PropertyRandStr(restoredPlayer.gender);
            string stage_dev_player = PropertyRandStr(restoredPlayer.stage_dev);
            string body_player = PropertyRandStr(restoredPlayer.Body);
            List<Prof> pfor = restoredPlayer.prof;

            Console.WriteLine($"You create player an sinse stats \n" +
                $" Gender: {gender_player}\n" +
               $"Old: {stage_dev_player}\n" +
              $"Body: {body_player}{pfor[0].Lawyer.name_prof}");
        }

        //Генерация свойства gender
        static string PropertyRandStr(List<string> obj)
        {
            Random rand = new Random();
            return obj[rand.Next(obj.Count)];
        }
    }
        

}
