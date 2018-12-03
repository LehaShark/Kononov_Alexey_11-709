//using System;
//using System.Threading;
//using Telegram.Bot;
//using System.Collections.Generic;
//using System.Diagnostics;
//using Telegram.Bot.Args;
//using Telegram.Bot.Types.ReplyMarkups;

//namespace Awesome
//{
//    class Program
//    {

//        static ITelegramBotClient botClient;
//        static int count = 0;
//        static Dictionary<int, string> phrases = new Dictionary<int, string>();
//        static void Main()
//        {
//            botClient = new TelegramBotClient("636670621:AAE18_1_f0-FyG9kFEQNXY6T1SIIBdrtxv8");
//            var me = botClient.GetMeAsync().Result;
//            Console.WriteLine(
//            $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
//            );
//            phrases.Add(1, "Выбери свой класс");
//            phrases.Add(2, "Выбери своего первого противника");
//            phrases.Add(3, "Выбери свою награду");
//            phrases.Add(4, "Выбери свою принцессу");
//            phrases.Add(5, "Твой дальнейшее действие?");
//            botClient.OnMessage += Bot_OnMessage;
//            botClient.StartReceiving();
//            Thread.Sleep(int.MaxValue);
//        }

//        static async void Bot_OnMessage(object sender, MessageEventArgs e)
//        {
//            if (e.Message.Text == "старт") count++;
//            var rkm = new ReplyKeyboardMarkup();
//            if (count == 0)
//            {
//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: "Приветcтвую тебя, путник! Напиши \"старт\", чтобы начать игру.");
//                return;
//            }
//            else if (count == 1)
//            {
//                rkm.Keyboard =
//                new KeyboardButton[][]
//                {
//new KeyboardButton[]
//{
//new KeyboardButton("Воин."),
//new KeyboardButton("Маг."),
//new KeyboardButton("Убийца")
//},
//                };

//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: phrases[count],
//                replyMarkup: rkm);

//                //await botClient.SendTextMessageAsync( 
//                // chatId: e.Message.Chat, 
//                // text: phrases[count], 
//                // replyMarkup: new ReplyKeyboardRemove() { }); 
//                count++;
//                return;
//            }
//            else if (count == 2)
//            {
//                rkm.Keyboard =
//                new KeyboardButton[][]
//                {
//new KeyboardButton[]
//{
//new KeyboardButton("Гоблин."),
//new KeyboardButton("Скелет."),
//new KeyboardButton("Морлок")
//},
//                };
//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: phrases[count],
//                replyMarkup: rkm);
//            }
//            else if (count == 3)
//            {
//                rkm.Keyboard =
//                new KeyboardButton[][]
//                {
//new KeyboardButton[]
//{
//new KeyboardButton("Радужный плащ."),
//new KeyboardButton("Платиновая корона."),
//new KeyboardButton("Чугунная трость.")
//},
//                };
//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: phrases[count],
//                replyMarkup: rkm);
//            }
//            else if (count == 4)
//            {
//                rkm.Keyboard =
//                new KeyboardButton[][]
//                {
//new KeyboardButton[]
//{
//new KeyboardButton("Фиона."),
//new KeyboardButton("Керш."),
//new KeyboardButton("Киркоров.")
//},
//                };
//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: phrases[count],
//                replyMarkup: rkm);
//            }
//            else if (count == 5)
//            {
//                rkm.Keyboard =
//                new KeyboardButton[][]
//                {
//new KeyboardButton[]
//{
//new KeyboardButton("Спать."),
//new KeyboardButton("Чистить зубы."),
//new KeyboardButton("Писать код.")
//},
//                };
//                await botClient.SendTextMessageAsync(
//                chatId: e.Message.Chat,
//                text: phrases[count],
//replyMarkup: rkm);
//            } 