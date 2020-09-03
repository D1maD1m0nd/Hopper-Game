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
