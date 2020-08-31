using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;

namespace HopperGame
{



    class Program
    {
        static void Main(string[] args)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Player>));
            string File_path = "D:/Рабочий стол/Git_proj/HopperGame/HopperGame/player.json";
            Random rand = new Random();
            string Name_user;
            string Skills_user;
            

            using (var fs = new FileStream(File_path, FileMode.OpenOrCreate))
            {
                var newPlayer = jsonFormatter.ReadObject(fs) as List<Player>;
                if (newPlayer != null)
                {
                    foreach (var player in newPlayer)
                    {

                        Name_user = player.prof[rand.Next(player.prof.Count)].name_prof.ToString();
                        Skills_user = player.prof[rand.Next(player.prof.Count)].name_prof.ToString();
                        Console.WriteLine($"{Name_user}, {Skills_user}");
                    }
                }
            }
        }

    }
        

}
