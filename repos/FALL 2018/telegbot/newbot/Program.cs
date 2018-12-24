using com.LandonKey.SocksWebProxy;
using com.LandonKey.SocksWebProxy.Proxy;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using Telegram.Bot.Types;
using Npgsql;

namespace Awesome
{
    class Program
    {
        static ITelegramBotClient botClient;
        static int counter = 0;

        private static int GetNextFreePort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();

            return port;
        }

        static void Main()
        {
            botClient = new TelegramBotClient(
                "753674851:AAEJF2_jpSE8-t0Y8dgYyl_uHb_YnZuaprQ",
                new SocksWebProxy(
                        new ProxyConfig(
                            IPAddress.Parse("127.0.0.1"),
                            GetNextFreePort(),
                            IPAddress.Parse("185.20.184.217"),
                            3693,
                            ProxyConfig.SocksVersion.Five,
                            "userid66n9",
                            "pSnEA7M"),
                        false));

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (counter == 0 && e.Message.Text != "/start")
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("/start"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Если хотите начать напишите /start",
                    replyMarkup: rkm);
                return;
            }

            if (e.Message.Text == "/start" || counter == 1)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("Да"),
                            new KeyboardButton("Нет"),
                        },
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Хочешь, я расскажу тебе сказку?",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 2)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Кхм... Нет, никаких «не любо — не слушай, а врать не мешай!» Забудь про бабушкины сказки. " +
                    "Это новая история с реальными героями, которую мы придумаем с тобой вместе. Ты же не против?",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 3)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Я рада. Кхм... В заброшенном краю, лежащем вдали от железных дорог, " +
                    "где скудную почву не тревожат ни плугом, ни трактором, " +
                    "заключенный в февральские ледяные оковы стоит дом. Угрюмая бревенчатая изба, " +
                    "все окна которой плотно запечатаны обледенелыми ставнями. Кроме одного. " +
                    "У него одна из створок ставней короче, чем нужно — плотницкая халтура, " +
                    "которая позволила чёрной паучихе пробраться внутрь покинутого жилища. " +
                    "Теперь ей приходится объясняться с домовым.",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 4)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Домовой отходит на пару шагов назад, чтобы оглядеть словно из ниоткуда взявшуюся паутину. " +
                    "Каждая нить соединена с сетью, протянутой от рамы окна к его центру. " +
                    "Паучиха успела основательно закрепиться на этом месте, " +
                    "и домовой небезосновательно полагает, что это начало кампании по захвату красного угла, " +
                    "в котором лик Богородицы темнеет под напором времени.",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 5)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Ты вторглась в дом Николая Павловича Волынского, отважного воина! Офицера, который прямо сейчас проливает кровь в боях против...",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 6)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "У меня три сотни детишек, хозяин! — перебивает его паучиха.",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 7)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "...османских нехристей, которые нападают на наши сёла и города. " +
                    "Он один из самых влиятельных людей при Великом князе Михаиле Павловиче, а я хранитель его жилища...",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 8)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("..."),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Сейчас зима, хозяин. Ты покрыт шерстью, а мои детки мягкие и голые. —  продолжает жалиться чёрная паучиха." +
                          "Домовой замолкает.Паучиха сползает с подоконника и начинает оплетать паутиной стоящий у окна деревянный стул. " +
                          "Домовой делает ещё один шаг назад, пытаясь оглядеть паутину целиком.",
                    replyMarkup: rkm);
                return;
            }

            if (counter == 9)
            {
                counter++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("Традицией"),
                        },
                        new KeyboardButton[]
                        {
                            new KeyboardButton("Религией"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Ты слушаешь? ...будь ты на месте домового, чем бы ты подкрепил свои доводы ? Древней традицией ? ...или, может, религией ?",
                    replyMarkup: rkm);
                return;
            }
        }
    }
}
//753674851:AAEJF2_jpSE8-t0Y8dgYyl_uHb_YnZuaprQ