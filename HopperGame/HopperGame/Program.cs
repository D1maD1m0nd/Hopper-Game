using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace HopperGame
{



    class Program
    {
        private static TelegramBotClient Bot;
        static async Task Main()
        {
            //Remote on bot
            Bot = new TelegramBotClient(Configuration.BotToken);
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.StartReceiving(Array.Empty<UpdateType>());


            Console.ReadKey();
            Bot.StopReceiving();

        }
        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text)
            {
                return;
            }

            if (Configuration.GameOn && CheckNum(message.Text))
            {
                int countUsers = Convert.ToInt32(message.Text);

                if (countUsers >= 5 && countUsers <= 20)
                {
                    List<User> users = SerializedPlayerPropertyJson(countUsers);
                    GenFilesPlayer(users);
                    await SendDocumentOnTelegramChat(message);
                    
                }
                else
                {
                    Configuration.GameOn = false;
                }
                


            }
            else{
                switch (message.Text)
                {
                    case "/start":
                        string text = @"Список команд: 
                                        /start - запуск бота;
                                        /Game - вызов клавиатуры;";
                        await Bot.SendTextMessageAsync(message.From.Id, text);

                        break;

                    case "/Game":
                        await SendReplyKeyboard(message);
                        break;
                    case "Начать игру":
                        Configuration.GameOn = true;
                        await Bot.SendTextMessageAsync(message.From.Id,"Игра началась");
                        await Bot.SendTextMessageAsync(message.From.Id, "Введите количество пользователей от 5 до 20");
                        break;
                    default:
                        text = @"Вот что я могу
                                        Список команд: 
                                        /start - запуск бота;
                                        /keyboard - вызов клавиатуры;
                                        /menu - вызов меню;"; 
                        await Bot.SendTextMessageAsync(message.From.Id, text);
                        break;
                }

            }
        }
        static async Task SendReplyKeyboard(Message message)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new []
                {
                    new KeyboardButton("Начать игру"),
                    new KeyboardButton("Правила"),
                }
            });

            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Выберите режим",
                replyMarkup: replyKeyboard

            );
        }

        static async Task SendDocumentOnTelegramChat(Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadDocument);
            //Получаем путь до папки с фалами карточек игроков
            string filePath = Configuration.PathPlayerFilesFlorder;
            //Получаем список файлов
            string[] playerAllFilesStrings = Directory.GetFiles(filePath);
            foreach (var file in playerAllFilesStrings)
            {
                
                using var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                string fileName = file.Split(Path.DirectorySeparatorChar).Last();
                await Bot.SendDocumentAsync(
                    chatId: message.Chat.Id,
                    document: new InputOnlineFile(fileStream, fileName)
                );
            }
            
        }
        // Генерация списка пользователей, входные данные объект с свойствами, которые нужно присвоить игрокам
        //количество игроков ,которые необходимо сгенерировать
        static List<User> GenUsers(Player player, int countUser)
        {
            //Список пользователей
            var users = new List<User>();
            Random rand = new Random();
            //Генерация списка пользователей
            for (int i = 0; countUser > i; i++)
            {
                string username = $"Пользователь #{i}";

                int itemProf = rand.Next(player.Profs.Count);
                users.Add(new User(
                        player.Profs[itemProf].NameProf,
                        player.Profs[itemProf].Skill,
                        player.Gender[rand.Next(player.Gender.Count)],
                        player.Old = rand.Next(16, 71),
                        username,
                        player.Character[rand.Next(player.Character.Count)],
                        player.Hobby[rand.Next(player.Hobby.Count)],
                        player.Health[rand.Next(player.Health.Count)],
                        player.Weigth = rand.Next(40, 130),
                        player.Growth = rand.Next(140, 210),
                        player.Phobia[rand.Next(player.Phobia.Count)],
                        player.Inventory[rand.Next(player.Inventory.Count)],
                        rand.Next(player.Old - 18)
                    )
                );
            }

            return users;
        }
        static List<User> SerializedPlayerPropertyJson(int countUser)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Player>));

            //Путь к файлу с характеристиками игрока
            string filePath = Configuration.PathJsonProperty;

            //Список возможных пользователей
            var users = new List<User>();

            //Поток чтения и сериализации JSON
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var newPlayer = jsonFormatter.ReadObject(fs) as List<Player>;
                if (newPlayer != null)
                {
                    foreach (var player in newPlayer)
                    {
                        
                        users = GenUsers(player, countUser);
                    }
                }
            }

            return users;
        }
        static void GenFilesPlayer(List<User> users)
        {
            int i = 1;
            string filepath = $"{Configuration.PathPlayerFilesFlorder}player{i}.txt";
            foreach (var user in users)
            {
                using (StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"Имя пользователя: {user.Username}");
                    sw.WriteLine($"Профессия: {user.Prof}");
                    sw.WriteLine($"Стаж: {user.ExperienceProf}");
                    sw.WriteLine($"Возраст/Пол: {user.Old} лет {user.Gender} ");
                    sw.WriteLine($"Рост/Вес: {user.Growth} см {user.Weight} кг");
                    sw.WriteLine($"Здоровье:{user.Health}");
                    sw.WriteLine($"Характер:{user.Character}");
                    sw.WriteLine($"Хобби: {user.Hobby}");
                    sw.WriteLine($"Фобия:{user.Phobia}");
                    sw.WriteLine($"Инвентарь: {user.Inventory}");
                }
                filepath = $"../../../ListPlayer/player{++i}.txt";
            }
        }

        static bool CheckNum(string s)
        {
            //Проверяем, что строка число
            return int.TryParse(s, out _);
        }
    }
        

}
