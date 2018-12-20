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
                "753674851:AAEJF2_jpSE8-t0Y8dgYyl_uHb_YnZuaprQ"
                //);
                ,
                new SocksWebProxy(
                        new ProxyConfig(
                            IPAddress.Parse("127.0.0.1"),
                            GetNextFreePort(),
                            IPAddress.Parse("103.194.250.110"),
                            9999,
                            ProxyConfig.SocksVersion.Five
                        ,
                        "userid66n9",
                        "pSnEA7M"),
                        false
                        )
                        //)
                        );

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
            int count = 0;
            if (count == 0)
            {
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
                count++;
                return;
            }

            else if (e.Message.Text == "/start" && count == 1)
            {
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("Поиграем"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Что будем делать?",
                    replyMarkup: rkm);
                return;
            }
        }
    }
}
//753674851:AAEJF2_jpSE8-t0Y8dgYyl_uHb_YnZuaprQ