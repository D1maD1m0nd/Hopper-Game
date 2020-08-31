using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Reflection.Metadata;

namespace HopperGame
{



    class Program
    {
        static void Main(string[] args)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Player>));
            //string File_path = "D:/Рабочий стол/Git_proj/HopperGame/HopperGame/player.json";
            string File_path = System.IO.Path.GetFullPath(@"..\..\..\player.json");
            var users = new List<User>();
            Random rand = new Random();

            using (var fs = new FileStream(File_path, FileMode.OpenOrCreate))
            {
                var newPlayer = jsonFormatter.ReadObject(fs) as List<Player>;
                if (newPlayer != null)
                {
                    foreach (var player in newPlayer)
                    {
                        for (int i = 0; 10 > i; i++)
                        {
                            int item = rand.Next(player.prof.Count);
                            users.Add(new User(
                                    player.prof[item].name_prof.ToString(),
                                    player.prof[item].skill.ToString(),
                                    player.gender[rand.Next(player.gender.Count)].ToString(),
                                    player.stage_dev[rand.Next(player.stage_dev.Count)].ToString(),
                                    player.body[rand.Next(player.body.Count)].ToString()
                                )
                             );
                        }
                    }
                }
            }
            foreach(var user in users)
            {
                Console.WriteLine($"Профессия {user.Prof} \n Описание профессии {user.Skill} \n Пол {user.Gender} \n Возраст {user.StageDev} \n Телосложение {user.Body}");
                Console.WriteLine("\n");
            }
           
        }

    }
        

}
