<<<<<<< HEAD
﻿using System;
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
            //Создание объекта для сериализации json
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Player>));
            
            //Путь к файлу с характеристиками игрока
            string File_path = Path.GetFullPath(@"..\..\..\player.json");
           
            //Список возможных пользователей
            var users = new List<User>();

            Random rand = new Random();

            //Поток чтения JSON
            using (var fs = new FileStream(File_path, FileMode.OpenOrCreate))
            {
                var newPlayer = jsonFormatter.ReadObject(fs) as List<Player>;
                if (newPlayer != null)
                {
                    foreach (var player in newPlayer)
                    {
                        users = GenUsers(player);
                    }
                }
            }
            foreach(var user in users)
            {
                Console.WriteLine(  $" Имя пользователя: {user.Username}"+
                                    $" \n Профессия: {user.Prof}" +
                                    $" \n Описание профессии: {user.Skill}" +
                                    $" \n Пол: {user.Gender} \n Возраст: {user.StageDev}" +
                                    $" \n Телосложение: {user.Body}");
                Console.WriteLine("\n");
            }
           
        }
        // Генерация списка пользователей, входные данные объект с свойствами, которые нужно присвоить игрокам
        //количество игроков ,которые необходимо сгенерировать
        static List<User> GenUsers(Player player)
        {
            //Список пользователей
            var users = new List<User>();
            //Количество пользователей
            Console.Write("Ввведите количество пользователей: ");
            int count_user = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            for (int i = 0; count_user > i; i++)
            {
                Console.Write($"Введите имя пользователя № {i+1}: ");
                string username = Console.ReadLine();
                int item_prof = rand.Next(player.prof.Count);
                users.Add(new User(
                        player.prof[item_prof].name_prof.ToString(),
                        player.prof[item_prof].skill.ToString(),
                        player.gender[rand.Next(player.gender.Count)].ToString(),
                        player.stage_dev[rand.Next(player.stage_dev.Count)].ToString(),
                        player.body[rand.Next(player.body.Count)].ToString(),
                        username
                    )
                 );
            }
            return users;
        }

    }
        

}
=======
﻿using System;
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
>>>>>>> 1e3838990f26c05c380f98105f25d6ca00802833
