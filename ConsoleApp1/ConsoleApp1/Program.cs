using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using NetTelegramBotApi.Util;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        private static DateTime Date = new DateTime();
        private static string Token = "648939177:AAH-wxagSRhCIySBg2dPCZ0VJCsNGzWJXOM";
        private static ReplyKeyboardMarkup GameMenu = new ReplyKeyboardMarkup();
        private static ReplyKeyboardMarkup MainMenu = new ReplyKeyboardMarkup();
        static void Main(string[] args)
        {
            Console.Title = "GameAlon";
            MainMenu.ResizeKeyboard = true;
            MainMenu.Keyboard =
               new KeyboardButton[][]
                {
               new KeyboardButton[]
                    {
                   new KeyboardButton("🕹شروع بازی🕹")
                }
                ,
               new KeyboardButton[]
               {
                   new KeyboardButton("📋درباره ی ما📋") , new KeyboardButton("📋درباره ی ربات📋")
               }

            };
            GameMenu.ResizeKeyboard = true;
            GameMenu.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("👾حدس عدد👾")

                }
                ,
                new KeyboardButton []
                {
                    new KeyboardButton("🔙بازگشت به منوی اصلی🔙")
                }
            };

            Task.Run(() => RunBot());
            Console.ReadKey();
        }
        public static async Task RunBot()
        {
            TelegramBot bot = new TelegramBot(Token);
            User me = await bot.MakeRequestAsync(new GetMe());
            Console.WriteLine("UserName Is: {0} And My Name Is {1}", me.Username, me.FirstName);
            long offset = 0;
            int whilecount = 0;
            while (true)
            {
                Console.WriteLine("WhileCount is:{0} ", whilecount);
                whilecount++;
                Update[] Updates = await bot.MakeRequestAsync(new GetUpdates() { Offset = offset });
                Console.WriteLine("Update Count Is:{0}", Updates.Count());
                Console.WriteLine("--------------------------------------------");
                try
                {
                    foreach (Update Update in Updates)
                    {
                        offset = Update.UpdateId + 1;
                        string text = Update.Message.Text;
                        if (text == "/start")
                        {
                            User User = new User();
                            Console.WriteLine(User.Id);
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "لطفا یک گزینه انتخاب کنید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;

                        }
                        else if (text != null && text.Contains("/aboutus")|| text.Contains("📋درباره ی ما📋")) 
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "ربات درحال توسعه میباشد شکیبا باشید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        else if (text != null && text.Contains("👥امتیاز شما👥") || text.Contains("/myscore"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "ربات درحال توسعه میباشد شکیبا باشید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        else if (text != null && text.Contains("📋درباره ی ربات📋") || text.Contains("/aboutbot"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "\n🌐 ربات Gamealon 🌐\nما در این ربات از بروزترین ابزار برنامه نویسی بهره گرفته ایم تا بتوانیم لحظات خوشی رو برای شما به ارمغان بیاریم امیدواریم از بازی های این ربات لذت ببرید. \nهمچنین این ربات هر روز درحال ارتقا هست و تیم ما سخت در تلاش هست هر روز بخش جدیدی به این ربات اضافه کند.\nبه امید روزی که از نظر شما کاربران عزیز بهترین باشیم.")
                            { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        else if (text != null && text.Contains("🕹شروع بازی🕹") || text.Contains("/startnewgame"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "لطفا یک گزینه انتخاب کنید.") { ReplyMarkup = GameMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        else if (text != null && text.Contains("👥برترین کاربران👥") || text.Contains("/rank"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "ربات درحال توسعه میباشد شکیبا باشید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        if (text != null && text.Contains("👾حدس عدد👾"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "ربات درحال توسعه میباشد شکیبا باشید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        if (text != null && text.Contains("🔙بازگشت به منوی اصلی🔙") ||text.Contains("/mainmenu"))
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "شما  در منوی اصلی هستید.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                        else
                        {
                            SendMessage Message01 = new SendMessage(Update.Message.Chat.Id, "قابل مفهوم نبود.") { ReplyMarkup = MainMenu };
                            await bot.MakeRequestAsync(Message01);
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    SendMessage MessageErrorForAhmad = new SendMessage(107091211, "AhmadReza Robot " + me.Username + "  Error dde Matn Error ine " + e.Message + "Date : " + Date.Date + "Time : " + Date.Hour + ":" + Date.Minute + ":" + Date.Millisecond);
                    SendMessage MessageErrorForErfan = new SendMessage(562445249, "Erfan Robot " + me.Username + "  Error dde Matn Error ine " + e.Message + "Date : " + Date.Date + "Time : " + Date.Hour + ":" + Date.Minute + ":" + Date.Millisecond);
                    Console.WriteLine(e.Message + "Date : " + Date.Date + "Time : " + Date.Hour + ":" + Date.Minute + ":" + Date.Millisecond);
                    throw;
                }
            }
        }
    }
}
