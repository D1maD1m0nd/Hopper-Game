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
            using (var fs = new FileStream("D:/Рабочий стол/Git_proj/HopperGame/HopperGame/player.json", FileMode.OpenOrCreate))
            {
                var newPlayer = jsonFormatter.ReadObject(fs) as List<Player>;
                if (newPlayer != null)
                {
                    foreach (var player in newPlayer)
                    {
                        Console.WriteLine(player.prof.Lawyer.skills);
                    }
                }
            }
        }

        //Генерация свойства gender
        static string PropertyRandStr(List<string> obj)
        {
            Random rand = new Random();
            return obj[rand.Next(obj.Count)];
        }
    }
        

}
