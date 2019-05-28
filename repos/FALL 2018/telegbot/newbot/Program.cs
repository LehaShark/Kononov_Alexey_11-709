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
using System.IO;
using NewBot;

namespace NewBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        public static UserService<User> UserService;
        public static User user = new User() { answer = new string[15], step = 0 };
        public static int counter = 0;


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
                "775986874:AAEgYiDvdavMI9EKr5AQqDWcZbbKUac2CeU");
                //,
            //new SocksWebProxy(
            //        new ProxyConfig(
            //            IPAddress.Parse("127.0.0.1"),
            //            GetNextFreePort(),
            //            IPAddress.Parse("185.20.184.217"),
            //            3693,
            //            ProxyConfig.SocksVersion.Five,
            //            "userid66n9",
            //            "pSnEA7M"),
            //        false));

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

            //var senderId = e.Message.From.Id;


            if (user.step == 0 && e.Message.Text != "/start")
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
                return;
            }

            if (e.Message.Text == "/start" || user.step == 0)
            {
                user.step++;
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
                var random = new Random();
                var chanse = random.Next(1, 5);

                if (chanse == 1)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Записано в Орловской губернии " +

                        "Была у одного крестьянина любимая корова.Холил он её, лелеял, " +
                        "кормил вдоволь.А она возьми да и захворай, слабеет с каждым днём, отощала. Как хозяин не бился, " +
                        "а ничего поделать не мог. «Сколько ей не задавай, всё не в коня корм, одна кожа да кости» - сетовал он соседу. " +
                        "А среди ночи услыхал стон с чердака: «Новых друзей кормит, а старых из сердца вон, не уважит...» " +
                        "Смекнул мужик, и стал оставлять для домового хлеб и соль в укромном месте. Корова поправилась, а хозяин её по сей день жив - " +
                        "здоров и такое мне сказывал: если домовой какой скотинке позавидует, то может объедать её, гонять почём зря по ночам или даже хвост оторвать.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 2)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text:
                        "Записано в Тульской губернии " +

                        "Была у одного крестьянина любимая корова.Холил он её, лелеял, кормил вдоволь.А она возьми да и захворай, слабеет с каждым днём, отощала.Как хозяин не бился, а ничего поделать не мог. " +
                        "«Сколько ей не задавай, всё не в коня корм, одна кожа да кости» -сетовал он соседу.А среди ночи услыхал стон с чердака: " +
                        "«Новых друзей кормит, а старых из сердца вон, не уважит...» Смекнул мужик, и стал оставлять для домового хлеб и соль в укромном месте.Корова поправилась, " +
                        "а хозяин её по сей день жив - здоров и такое мне сказывал: если домовой какой скотинке позавидует, то может объедать её, гонять почём зря по ночам или даже хвост оторвать.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 3)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Записано в Тобольской губернии " +

                        "Поселились старик со старухой в новой избе.Пришла ночь.Погасили лучину и стали обсуждать, явится ли сегодня домовой ? " +
                        "В новом доме обязательно должен появиться и может кого - нибудь из новых хозяев задушить. " +
                        "«Ишь чего выдумал!» — сказала старуха, — «Вот тебя пущай и душит!» Сказала, да сама своих слов и испугалась.Заснули в страхе. " +
                        "А в полночь заскрипела входная дверца, и раздался страшный хруст.Проснулись старики, слова вымолвить не могут.  " +
                        "Видят как домовой повалил незваного гостя и душит его.А тот уже мертвец мертвецом.С тех пор больше домового не боялись, и даже перед соседями хвастали.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 4)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Записано в Саратовской губернии " +

                        "Вышла девушка замуж и вместе с собой в мужнюю избу позвала своего домового. Да только там свой Хозяин имелся. " +
                        "Как ночь пришла, так домовые когтями и сцепились. Дерут друг дружку, кому главным быть. Муж говорит: " +
                        "«Два медведя в одной берлоге не уживутся. Надо гнать твоего поскорее». Взял метлу и стал ей по стенам колотить да по углам мести: " +
                        "«Уходи, гость незваный, не рады тебе здесь!» Домовой, который с женой пришел, сбежал в окно. С тех пор стало в доме тихо, спокойно. " +
                        "А однажды наткнулся муж в лесу на изгнанного домового, и тот вырвал ему горло.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 5)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Записано в Тобольской губернии " +

                        "Утонул у одной крестьянки муж.Хороший был, работящий, да только скаредный очень.Деньги прятал - на мечту копил, а жили в обрез. " +
                        "И вот стал он вдове во сне являться.Приходит весь в тине и плачет: «Прости меня, душа моя...Отрой наше богатство...» — " +
                        "а где зарыл сказать не может, исчезает. Бедная женщина поначалу пугалась, а потом свыклась, стала думать. " +
                        "Была она рачительной хозяйкой, вкусно готовила, грязной посуды не копила, по воскресеньям за шитьё не садилась, домового чтила. " +
                        "Накрыла она для него стол, попросила как следует, и легла спать. " +
                        "Наутро стол оказался пуст, всё убрано, только короб с мукой опрокинут, а по белой муке — следы. " +
                        "Пошла она по следам - то по этим, а они через сени на крыльцо, с него за дом, на заднем дворе обрываются. " +
                        "Ровно в этом месте женщина клад и откопала.С тех пор жила в достатке.Только по мужу тосковала, хороший он у неё был.",
                    replyMarkup: rkm);
                    return;
                }
                return;
            }

            if (user.step == 1 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 2 && (e.Message.Text == "..." || e.Message.Text == "Да" || e.Message.Text == "Нет"))
            {
                user.step++;
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

            if (user.step == 3 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 4 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 5 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 6 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 7 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 8 && e.Message.Text == "...")
            {
                user.step++;
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

            if (user.step == 9 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Ты слушаешь? ...будь ты на месте домового, чем бы ты подкрепил свои доводы ? " +
                    "Древней традицией ? ...или, может, религией ?",
                    replyMarkup: rkm);
                return;
            }



            // первый выбор.
            if (user.step == 10 && e.Message.Text == "Традицией")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                //UserService.Save(user);
                user.step++;
                //UserService.Save(user);
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
                    text: "Спасибо, попробуем так. " +
                    "Пока хозяин не вернулся и не взял на себя заботу об этой земле, которой начал владеть ещё его дед, " +
                    "я не могу позволить находиться в его доме всяким незваным...",
                    replyMarkup: rkm);
                return;
            }
            if (user.step == 10 && e.Message.Text == "Религией")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                user.step++;
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
                    text: "Хорошо, попробуем так. " +
                    "Пока хозяин не вернулся, чтобы поклониться святым ликам в красном углу, " +
                    "в котором я поддерживаю огонь лампады, " +
                    "я не могу позволить незваным гостям... " +
                    "я не могу позволить находиться в его доме всяким незваным...",
                    replyMarkup: rkm);
                return;
            }




            if (user.step == 11 && user.answer[counter - 1] == "Традицией")
            {
                user.step++;
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
                var random = new Random();
                var chanse = random.Next(1, 3);

                if (chanse == 1)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "К слову о наследовании! Хозяин, мы пожираем себе подобных, " +
                        "но я смогла пережить своих многочисленных братьев и сестёр. " +
                        "Я — единственное продолжение рода моей устрашающей матери, " +
                        "обитательницы церковных подвалов и отравительнице священников. " +
                        "Неужели ты прогонишь меня и моих детей в такую стужу, " +
                        "неужели ты заставишь меня забыть дела моих предков ?",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 2)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text:
                        "К слову о семье! Хозяин, я переношу всех своих деток на собственной спине. " +
                        "Я плела им колыбели в самых отвратительных заброшенных церквях, которые ты можешь себе представить. " +
                        "Когда насекомых и птиц для пропитания семьи не хватало, я переставала есть ради детей. " +
                        "Неужели ты прогонишь меня и моих крошек в такую стужу, неужели ты так жестоко оборвёшь наш долгий путь ?",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 3)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "К слову о доме! Хозяин, я пронёсла свой выводок через много полей и лесов. " +
                        "Они никогда не знали тепла домашнего очага.Ни древних стульев, ни печи, ни кровати — ничего из того богатства, " +
                        "которое ты охраняешь. Неужели ты прогонишь меня и моих крошек в такую стужу? " +
                        "Неужели ты не дашь нам прикоснуться к этим прекрасным вещам?",
                        replyMarkup: rkm);
                    return;
                }
                return;
            }
            if (user.step == 11 && user.answer[counter - 1] == "Религией")
            {
                user.step++;
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
                var random = new Random();
                var chanse = random.Next(1, 3);

                if (chanse == 1)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "О, хозяин! Разве ты не замечаешь, как от постоянного нагрева портятся эти ужасные иконы? " +
                        "Краска облупляется, а оклады покрываются копотью. Моя паутина могла бы сохранить весь этот угол. " +
                        "Ты бы мог больше не опасаться тлетворных изменений.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 2)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text:
                        "О, хозяин! Разве красный угол не для того, чтобы молиться? Кто-то же должен креститься и просить всякие глупости! " +
                        "Сейчас все эти оклады ни к чему. Мы с моими детьми могли бы время от времени шептать подобающие слова и всё такое. " +
                        "Ты бы сразу почувствал, что иконы при делах.",
                        replyMarkup: rkm);
                    return;
                }

                if (chanse == 3)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "О, xозяин! Разве свет лампады не привлекает всяких мерзких жучков, " +
                        "прогрызающих ходы в досках икон и оскверняющих лики чревоточинами? " +
                        "Мои дети могли бы ловить и поедать всю эту отвратительную братию. " +
                        "Тебе было бы не о чем беспокоиться.",
                        replyMarkup: rkm);
                    return;
                }
                return;
            }

            if (user.step == 12 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Домовой молчит. Паучиха торопливо оплетает паутиной [метлу], прислонённую к подоконнику. " +
                    "Домовой делает ещё один неуверенный шаг назад, не сводя глаз с растущей паутины.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 13 && e.Message.Text == "...")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[метлу]"),
                            new KeyboardButton("[молча слушал дальше]")
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Друг мой... прислушайся к себе. Если бы домовой [молча слушал дальше], это было бы убедительным?",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 14 && e.Message.Text == "[метлу]")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                user.step++;
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
                    text: "Кхм... метла? Ну, как скажешь. Словно пользуясь минутной слабостью домового, " +
                    "со спины паучихи сходит волна малюсеньких черных точек и начинает разбегаться по паутине. " +
                    "Домовой резко подхватывает метлу и смахивет чёрную мелюзгу вместе с их нитяным домом, словно пыль с подоконника." +
                    " Чудовище!Изверг! — паучиха собирает в охапку свой выводок и ретируется через щель между ставнями. " +
                    "Обратно в безжалостные объятья зимы. " +
                    "Домовой возвращает метлу на положенное место — точно туда, где её оставил хозяин перед своим уходом. " +
                    "Паучиху и её семейство гонит по сугробам ледяной ветер, а домовой затапливает печь, чтоб[[согреться.| 1.7]]",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 14 && e.Message.Text == "[молча слушал дальше]")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                user.step++;
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
                    text: "Пожалуй, я с тобой соглашусь. " +
                    "Словно пользуясь минутной слабостью домового, со спины паучихи сходит волна малюсеньких черных точек и устремляется к паутине. " +
                    "Паучьи детки разбиваются на пульсирующие кучки и замирают на нитях словно капли росы.После этого представления всё замирает, " +
                    "и только знакомый домовому пронзительный ветер завывает за окнами." +
                    "Домовой отворачивается от паучихи и её мелюзги, ковыляет к скамейке, когда - то собственноручно сработанной его хозяином, " +
                    "и тяжело на неё плюхается. Одну руку он устало роняет на колено, а второй задумчиво теребит свою бороду, " +
                    "напрасно ожидая от своего незамысловатого умишки ценных мыслей. " +

                    "— Не затопишь ли ты для нас печь, хозяин? Здесь холодно.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 15 && user.answer[counter - 1] == "[метлу]" && user.answer[counter - 2] == "Традицией")
            {
                user.step++;
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
                    text: "Отличный выбор! Конечно, домовой — это существо, живущее глубоко в традиции и само по себе являющееся, " +
                    "в некотором роде, традиционной ценностью. " +
                    "Метла, говоришь ? Кхм...Честно говоря, я её использовать не собиралась. " +
                    "Но это интересно, возможно кое для кого это будет сюрпризом. " +
                    "Я уверена, что эта мысль пришла домовому внезапно, в последний момент.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 15 && user.answer[counter - 1] == "[молча слушал дальше]" && user.answer[counter - 2] == "Традицией")
            {
                user.step++;
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
                    text: "Отличный выбор! Конечно, домовой близок к религии. " +
                    "Единственная, как-никак, нечисть не боящаяся креста и икон. " +
                    "Говорят, что домовые, это покаявшиеся души грешников, и за 70 лет служения хозяину им даруется спасение. " +
                    "Так ведь?",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 15 && user.answer[counter - 1] == "[метлу]" && user.answer[counter - 2] == "Религией")
            {
                user.step++;
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
                    text: "Отличный выбор! Конечно, домовой близок к религии. Единственная, как-никак, нечисть не боящаяся креста и икон. " +
                    "Говорят, что домовые, это покаявшиеся души грешников, и за 70 лет служения хозяину им даруется спасение. Так ведь? " +
                    "Метла, говоришь ? Кхм...Честно говоря, я её использовать не собиралась. Но это интересно, возможно кое для кого это будет сюрпризом. " +
                    "Я уверена, что эта мысль пришла домовому внезапно, в последний момент.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 15 && user.answer[counter - 1] == "[молча слушал дальше]" && user.answer[counter - 2] == "Религией")
            {
                user.step++;
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
                    text: "Отличный выбор! Конечно, домовой близок к религии. Единственная, как-никак, нечисть не боящаяся креста и икон. " +
                    "Говорят, что домовые, это покаявшиеся души грешников, и за 70 лет служения хозяину им даруется спасение. Так ведь?",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 16 && e.Message.Text == "...")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[Продолжим...]"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Переживаешь? Друг мой, не волнуйся!В следующий раз история может сложиться совсем по - другому. " +
                    "Мы вольны рассказывать её так или иначе, в зависимости от настроения. " +
                    "Делать раз за разом одно и то же скучно, так что давай экспериментировать. " +
                    "Наш с тобой диалог тоже будет немного меняться. Тебя это не слишком беспокоит? Кхм... прости, я слишком много отвлекаюсь. [Продолжим...]",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 17 && e.Message.Text == "[Продолжим...]")
            {
                user.step++;
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
                    text: "Немногим позже беседы домового с паучихой, даже пыль осесть как следует не успела, к дому подошел человек. " +
                    "Это боец Красной армии, продравшийся через дремучие чащобы и чёрные болота, " +
                    "бесстрашный строитель нового мира, который решил здесь поселиться. В руках у него молоток, извлеченный из глубин вещмешка. " +
                    "Красноармеец раскрывает створку неисправных ставней и всё, " +
                    "что ему теперь мешает попасть внутрь, это треснутое стекло. Он заносит руку с молотком.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 18 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "За годы печной дым покрыл стены и потолок слоями сажи. Несмотря  на периодические попытки всё оттереть, " +
                    "домовой не может тягаться с печным жерлом и полузабитым дымоходом. В тот момент когда молоток солдата " +
                    "разбивает оконное стекло разбивает оконное стекло , домовой сидит на скамейке своего хозяина и пытается подумать хоть о чём-нибудь, кроме злосчастной сажи." +
                    " Домовой чувствует, как его кожа страшно растягивается, мышцы деревенеют, а кости разделяются на тысячи кусочков. " +
                    "Его сознание самым невероятным образом раздувается, пытаясь охватить весь дом, каждый его уголок. " +
                    "Его изнутри нагревает растопленная печь, а снаружи студит ледяная корка. Словно черепаха, " +
                    "втягивающая при опасности голову в панцирь, домовой сливается со своим жилищем.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 19 && e.Message.Text == "...")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[продолжает гореть]"),
                        },
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[самовар]"),
                            new KeyboardButton("[рушник]"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Когда солдат пролезает через разбитое окно, домовой ощущает приятное чувство насыщения, будто щей навернул." +
                    " Он ни о чём не беспокоится — его физически как бы и не существует, он равномерно распределён по всему дому:" +
                    " по стенам, мебели, овчинам на кровати... Вот только огонь в печи [продолжает гореть]. " +
                    "Домовой наблюдает за тем, как насторожившийся красноармеец вынимает из кобуры воронёный наган. " +
                    "У простых существ мысли прямы и незамысловаты. В бравом бойце, " +
                    "проливавшем кровь за дело Революции, домовой видит лишь вороватую лису. " +
                    "Он с беспокойством думает о серебряном самоваре и рушнике, висящем в красном углу, " +
                    "на котором вышит портрет хозяина.Он явно не успевает спрятать от чужих глаз сразу всё. " +
                    "Скажи мне, друг...за что домовому стоило бы ухватиться в первую очередь ? Спасать [самовар] или [рушник] ? ",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 20 && e.Message.Text == "[продолжает гореть]")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                user.step++;
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
                    text: "Что? Печь? Кхм... Ну да. Хорошо. [Печь]            " +

                    "Печь взревела: «Это дом Николая Павловича Волынского!Отважного воина, который... который... Солдат вздрогнул от неожиданности и выстрелил. " +
                    "Пуля отколола кусок изразца на печи и отрикошетила куда - то в пол. В жерле печи взревело пламя  — домовой открыл свой окаменевший рот и резко выдохнул," +
                    " но солдат прикрылся от жара рукавом бушлата. Удушливый дым наполнил комнату. " +
                    "Бумажные иконы в красном углу в нескольких местах насквозь прожжены отлетевшими угольками. " +
                    "Красноармеец выпрямляется и возвращает свой наган обратно в кобуру.—  Весь дом спалишь, домовой! " +
                    "Выходи, поговорим, дело есть.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 21 && user.answer[counter - 1] == "[продолжает гореть]" && user.answer[counter - 2] == "[метлу]" && user.answer[counter - 3] == "Традицией")
            {
                user.step++;
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
                    text: "Кхм... Мне не слишком нравится развитие нашей с тобой истории. " +
                            "Конечно, домовой печётся о скарбе своего хозяина, но не до такой же степени! " +
                            "Красноармеец, безусловно, может постоять за себя, но будь внимателен, зри в корень повествования.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 21 && user.answer[counter - 1] == "[продолжает гореть]" && user.answer[counter - 2] == "[метлу]" && user.answer[counter - 3] == "Религией")
            {
                user.step++;
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
                    text: "Постой! Осторожнее с выбором. Если твой домовой с таким остервенением защищает угол с иконками, " +
                    "нападая на красноармейцев и паучат, то тут недалеко и до одобрения его отсталой идеологии. " +
                    "Не попадайся в сети архаичного мышления.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 21 && user.answer[counter - 1] == "[продолжает гореть]" && user.answer[counter - 2] == "[молча слушал дальше]" && user.answer[counter - 3] == "Традицией")
            {
                user.step++;
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
                    text: "Великолепно! " +
                            "Я впечатлена... Сначала мы подняли тему почтения домового перед свои хозяином," +
                            " а потом метко изобличили его трудноскрываемые связи с дремучими традиционными суевериями.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 21 && user.answer[counter - 1] == "[продолжает гореть]" && user.answer[counter - 2] == "[молча слушал дальше]" && user.answer[counter - 3] == "Религией")
            {
                user.step++;
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
                    text: "Я впечатлена... Сначала мы подняли тему почтения домового перед свои хозяином," +
                            " а потом метко изобличили его трудноскрываемые связи с дремучими религиозными суевериями.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 22 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Молчалив угрюмый дом, затерянный во внезапной снежной буре. " +
                    "Что-то почувствовав, солдат отворачивается от печи и обнаруживает домового, который свесив ноги сидит на скамейке своего хозяина." +
                    " Пододвинув стул и сев поближе к столу, солдат приглядывается к незнакомцу: выцветшие волосы и сероватая кожа домового выдают его почтенный возраст.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 23 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "— Каков же он, твой хозяин, домовой? " +
                    "— Святой человек.Этот дом обитель его и Бога, а ты ни тому ни другому не ровня. Уходи! — бурчит домовой солдату. " +
                    "— Я твой гость, домовой! Где твоё гостеприимство ? Или ты прогонишь меня умирать от холода, как и паучьих деток? " +
                    "Скажи мне, домовой!" +
                    "— Я поставлен охранять этот дом до возвращения хозяина, — нехотя отвечает домовой, снова теребя свою бороду. " +
                    "— Этот дом заброшен.Здесь никто не живет, и возвращаться сюда некому.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 24 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Домовой продолжает теребить бороду, отбрасывая время от времени на пол вырванные волоски. " +
                    "— С кем воюет твой хозяин ? " +
                    "— Он бьётся против османских нехристей." +
                    "Красноармеец со вздохом бросает взгляд на прожженные иконы. " +
                    "— Мне очень жаль, мой друг.Эта война окончилась 60 лет назад.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 25 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Домовой давно потерял счет времени. Он не мог сказать сколько именно прошло лет, но и сам чувствовал, что немало. " +
                    "— Твой хозяин мёртв. " +
                    "Солдат закуривает папиросу.По мере того, как его легкие заполняются дымом, он вытягивает ноги и устало облокачивается на стул. " +
                    "Огонь в печи уже окончательно потух, а изба снова наполнилась холодом, словно никогда и не была натоплена. " +
                    "Огонёк на конце папиросы то затухает, то ярко загорается, когда красноармеец затягивается. " +
                    "Домовому вспоминаются пылающие свечи, которые раньше зажигались в доме по праздникам. " +
                    "Неужели хозяин уже не вернётся ? ",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 26 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "— Ищи себе другой дом. " +
                    "Солдат тушит папиросу и выбрасывает окурок в печь. " +
                    "— Впрочем, можешь и не искать. " +
                    "Одновременно с этими словами он выкладывает на стол свой наган.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 27 && e.Message.Text == "...")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[выживет домовой]"),
                        },
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[вороненое дуло к груди]"),
                            new KeyboardButton("[себе в рот]"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Домовой уже видел подобное оружие раньше, похожей штукой его хозяин отстреливал лис, пойманных в курятнике. " +
                    "Домовой чётко и при этом болезненно ощущает окружающие его вещи. Каждая деталь обстановки, словно отделённая часть его собственного тела. " +
                    "Он практически слышит, как красный угол молит о спасении — его дальнейшее существование зависит от того, [выживет домовой] или нет. " +
                    "Впрочем, это уже наследие ушедших времён, отживший своё скарб мертвеца.Солдат терпеливо ждёт. Скажи мне...что же домовой должен сделать с наганом? " +
                    "Прижать [воронёное дуло к груди] или, может, направить его [себе в рот] ? ",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 28 && e.Message.Text == "[вороненое дуло к груди]")
            {
                user.answer[counter] = e.Message.Text;
                counter++;
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[жми]"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Домовой дрожащими руками направляет пистолет себе в грудь. Самовар беззвучно вскрикивает. " +
                    "— Всё верно. Теперь [жми] на металлический крючок.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 29 && user.answer[counter - 1] == "[вороненое дуло к груди]")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("[жми ещё]"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Домовой послушно выполняет сказанное. Пистолет издаёт мерзкий щелчок, выстрела не происходит. " +
                    "Рушник зажмуривает свои вышитые глаза. " +
                    "— Черт... прости, барабан не полный, [жми ещё].",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 30 && e.Message.Text == "[жми ещё]")
            {
                user.step++;
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
                    text: "Домовой делает ещё попытку, но в этот раз нет даже щелчка. " +
                    "Дом судорожно сжимается, в одном из окон трескается стекло. " +
                    "— Жми сильнее, идиот, или дай мне... Солдат начинает протягивать руку...",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 31 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Солдат начинает протягивать руку, но тут же вздрагивает от выстрела. " +
                    "Клок грязно-серых волос беззвучно падает на грубые доски пола.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 32 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Снежная буря больше не терзает окрестности этой глуши. Природа запоздало встречает бесстрашного победителя," +
                    " прошедшего под красным знаменем свободы сквозь дремучие чащобы и чёрные болота, и готового здесь поселиться, чтобы незамедлительно начать строить новый мир.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 33 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "— Спасибо тебе, Хозяин! Эта тварь выгнала меня с детьми на смертельный холод, больше сотни моих крошек погибли. " +
                    "— Добро пожаловать в новую жизнь, дружок.Теперь женщина сама строитель своего счастья. " +
                    "Солдат переносит паучиху с выводком в удобную коробку, в которой им предстоит помогать стране, производя шелк.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 34 && e.Message.Text == "...")
            {
                user.step++;
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
                    text: "Солдат сгребает иконки и тряпки из красного угла и заталкивает в топку печи. Через минуту ветхие останки ярко пылают, а еще минутой позже лик Богородицы осыпается седым пеплом." +
                    "Все эти игры с огнем пока только цветочки, ягодки будут потом, прогресс не остановить.",
                    replyMarkup: rkm);
                return;
            }

            if (user.step == 35 && e.Message.Text == "...")
            {
                user.step++;
                var rkm = new ReplyKeyboardMarkup
                {
                    Keyboard = new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            new KeyboardButton("Покакусики"),
                        }
                    }
                };

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Спасибо за помощь! Благодаря тебе моя история обретает форму и важные для слушателей детали. " +
                    "Как ты думаешь, похожа ли она на традиционную сказку? Будут ли ее пересказывать в народе?" +
                    " Кажется, основная линия получилась слишком неявной. Вот если нам сделать домового пьянчугой, синей нечистью, так сказать... " +
                    "Ну что ж...Боюсь, я увлеклась и совсем тебя утомила.Вот и сказке конец, а кто слушал, а особенно участвовал в ее создании, " +
                    "тот и молодец.Спасибо тебе и до следующей встречи, мой друг!",
                    replyMarkup: rkm);
                user.step = 0;
                return;
            }


        }
    }
}
//775986874:AAEgYiDvdavMI9EKr5AQqDWcZbbKUac2CeU