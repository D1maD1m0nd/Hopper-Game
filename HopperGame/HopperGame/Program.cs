using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using static System.IO.Path;

namespace HopperGame
{



    class Program
    {
        static void Main()
        {
            //Создание объекта для сериализации json
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Player>));
            
            //Путь к файлу с характеристиками игрока
            string filePath = GetFullPath(@"..\..\..\player.json");
           
            //Список возможных пользователей
            var users = new List<User>();

            //Поток чтения JSON
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
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
            foreach (var user in users)
            {
                Console.WriteLine($" Имя пользователя: {user.Username}" +
                                  $" \n Профессия: {user.Prof}" +
                                  $" \n Описание профессии: {user.Skill}" +
                                  $"\n Возраст: {user.Old}" +
                                  $" \n Пол: {user.Gender} " +
                                  $" \n Рост: {user.Growth}" +
                                  $" \n Вес: {user.Weight}" +
                                  $"\n Здоровье:{user.Health}" +
                                  $"\n Характер:{user.Character}" +
                                  $"\n Хобби: {user.Hobby}" +
                                  $"\n Фобия:{user.Phobia}" +
                                  $"\n Инвентарь: {user.Inventory}");
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
            int countUser = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            for (int i = 0; countUser > i; i++)
            {
                Console.Write($"Введите имя пользователя № {i+1}: ");
                string username = Console.ReadLine();
                
                int itemProf = rand.Next(player.Profs.Count);
                users.Add(new User(
                        player.Profs[itemProf].NameProf,
                        player.Profs[itemProf].Skill,
                        player.Gender[rand.Next(player.Gender.Count)],
                        player.Old = rand.Next(16,71),
                        username,
                        player.Character[rand.Next(player.Character.Count)],
                        player.Hobby[rand.Next(player.Hobby.Count)],
                        player.Health[rand.Next(player.Health.Count)],
                        player.Weigth = rand.Next(40,130),
                        player.Growth = rand.Next(140,210),
                        player.Phobia[rand.Next(player.Phobia.Count)],
                        player.Inventory[rand.Next(player.Inventory.Count)]
                    )
                 );
            }
            return users;
        }

    }
        

}
