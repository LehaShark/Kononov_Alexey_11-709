using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Npgsql;

namespace TgBot
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
    }


    public class UserService<User> : IDataService<User>
    {
        private string ConnectionString { get; }
        public UserService(string connStr)
        {
            ConnectionString = connStr;
        }

        public void Save(User user)
        {
            //тут пишем сохранение и т.д. с каждым методом
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public Human Human { get; set; }
        public int Step { get; set; }
    }

    public interface IDataService<T>
    {
        void Save(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        IEnumerable<T> GetAll();
    }

    public class Program
    {
        static ITelegramBotClient botClient;
        public static Dictionary<int, User> UserInfos;
        public static string[] person = new string[3];
        static string connectString = "Host=localhost;Port=5432;Username=postgres;Password=Z1478963z;Database=TelegramBot";

        public static void Main()
        {
            botClient = new TelegramBotClient("561845330:AAHVScX_i2LHn32w2RMtTsC8ST99c08ucvc");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            UserInfos = new Dictionary<int, User>();

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static void BDInteraction (string[] values)
        {
            using ( var connect = new NpgsqlConnection(connectString))
            {
                connect.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connect;
                    cmd.CommandText = "INSERT INTO telega (name, age, groupe) " +
                        "VALUES (@name, @age, @groupe)";
                    cmd.Parameters.AddWithValue("name", values[0]);
                    cmd.Parameters.AddWithValue("age", int.Parse(values[1]));
                    cmd.Parameters.AddWithValue("languages", values[2]);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var senderId = e.Message.From.Id;
            UserInfos.TryGetValue(senderId, out var user);
            if (user == null)
            {
                user = new User
                {
                    Human = new Human(),
                    Step = 0
                };

                UserInfos.Add(senderId, user);
            }

            if (user.Step == 0)
            {
                user.Step++;
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "What is your name?",
                    replyMarkup: new ReplyKeyboardMarkup
                    {
                        Keyboard = new[]
                        {
                            new []
                            {
                                new KeyboardButton("start")
                            }
                        }
                    }
                );
                return;
            }

            if (user.Step == 1)
            {
                user.Step++;
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "How old are u?"
                );
                person[0] = e.Message.Text;
                return;
            }

            if (user.Step == 2)
            {
                if (int.TryParse(e.Message.Text, out int age))
                {
                    user.Step++;
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "What language do u study?",
                        replyMarkup: new ReplyKeyboardMarkup
                        {
                            Keyboard = new[]
                            {
                                new []
                                {
                                    new KeyboardButton("C#")
                                },

                                //new[]
                                //{
                                //    new ReplyKeyBoardMarkup("c2")
                                //},

                                new []
                                {
                                    new KeyboardButton("Java")
                                }
                            }
                        }
                    );
                    return;
                }
                person[1] = e.Message.Text;
            }
            if (user.Step == 4)
            {
                user.Step++;
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Good, I too",
                    replyMarkup: new ReplyKeyboardRemove()
                );
                person[2] = e.Message.Text;
                BDInteraction(person);
            }

        }
    }
}