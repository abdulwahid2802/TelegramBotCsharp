using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotNew
{
    class Program
    {
        static string[] surahNamesUz = new[] {
        "Fotiha",
        "Baqara",
        "Oli Imron",
        "Niso",
        "Moida",
        "An\'om",
        "A\'rof",
        "Anfol",
        "Tavba",
        "Yunus",
        "Hud",
        "Yusuf",
        "Ra\'d",
        "Ibdohim",
        "Xijr",
        "Nahl",
        "Isro",
        "Kahf",
        "Maryam",
        "Toxo",
        "Anbiyo",
        "Haj",
        "Mo\'minun",
        "Nur",
        "Furqon",
        "Shuaro",
        "Naml",
        "Qasos",
        "Ankabut",
        "Rum",
        "Luqmon",
        "Sajda",
        "Ahzob",
        "Saba\'",
        "Fotir",
        "Yosin",
        "As-Saffot",
        "Sod",
        "Zumar",
        "Gʻofir",
        "Fussilat",
        "Shuro",
        "Zuhruf",
        "Duxon",
        "Josiya",
        "Ahqof",
        "Muhammad",
        "Fath",
        "Hujurot",
        "Qof",
        "Zariyat",
        "Tur",
        "Najm",
        "Qamar",
        "Rahmon",
        "Voqea",
        "Hadid",
        "Mujodala",
        "Xashr",
        "Mumtahana",
        "Saf",
        "Juma",
        "Munofiqun",
        "Tagʻobun",
        "Taloq",
        "Tahrim",
        "Mulk",
        "Qalam",
        "Haaqqah",
        "Ma\'orij",
        "Nuh",
        "Jin",
        "Muzzammil",
        "Muddassir",
        "Qiyomat",
        "Inson",
        "Mursalat",
        "Naba",
        "Naziyat",
        "Abasa",
        "Takvir",
        "Infitor",
        "Mutaffifun",
        "Inshiqoq",
        "Buruj",
        "Toriq",
        "A\'lo",
        "Gʻoshiya",
        "Fajr",
        "Balad",
        "Shams",
        "Layl",
        "Zuho",
        "Sharh",
        "Tiyn",
        "Alaq",
        "Qadr",
        "Bayyina",
        "Zalzala",
        "Odiyot",
        "Qori\'a",
        "Takasur",
        "Asr",
        "Humaza",
        "Fil",
        "Quraysh",
        "Mo\'un",
        "Kavsar",
        "Kofirun",
        "Nasr",
        "Masad",
        "Ixlos",
        "Falaq",
        "Nos"
        };
        static string[] surahNamesRu = new[]
        {
            "Аль-Фатиха",
    "Аль-Бакара",
    "Аль \'Имран",
    "Ан-Ниса\'",
    "Аль-Ма\'ида",
    "Аль-Ан\'ам",
    "Аль-А\'раф",
    "Аль-Анфаль",
    "Ат-Тауба",
    "Йунус",
    "Худ",
    "Йусуф",
    "Ар-Ра\'д",
    "Ибрахим",
    "Аль-Хиджр",
    "Ан-Нахль",
    "Аль-Исра\'",
    "Аль-Кахф",
    "Марйам",
    "Та Ха",
    "Аль-Анбийа\'",
    "Аль-Хаджж",
    "Аль-Му\'МИНУН",
    "Ан-Нур",
    "Аль-Фуркан",
    "Аш-Шу\'ара\'",
    "Ан-Намль",
    "Аль-Касас",
    "Аль-\'Нкабут",
    "Ар-Рум",
    "Лукман",
    "Ас-Саджда",
    "Аль-Ахзаб",
    "Саба\'",
    "Фатыр",
    "Йа Син",
    "Ас-Саффат",
    "Сад",
    "Аз-Зумар",
    "Гафер",
    "Фуссилат",
    "Аш-Шура",
    "Аз-Зухруф",
    "Ад-Духан",
    "Аль-Джасийа",
    "Аль-Ахкаф",
    "Мухаммад",
    "Аль-Фатх",
    "Аль-Худжурат",
    "Каф",
    "Аз-Зарийат",
    "Ат-Тур",
    "Ан-Наджм",
    "Аль-Камар",
    "Ар-Рахман",
    "Аль-Ваки\'а",
    "Аль-Хадид",
    "Аль-Муджадала",
    "Аль-Хашр",
    "Аль-Мумтахана",
    "Ас-Сафф",
    "Аль-Джуму\'а",
    "Аль-Мунафикун",
    "Ат-Тагабун",
    "Ат-Талак",
    "Ат-Тахрим",
    "Аль-Мульк",
    "Аль-Калам",
    "Аль-Хакка",
    "Аль-Ма\'аридж",
    "Нух",
    "Аль-Джинн",
    "Аль-Муззаммиль",
    "Аль-Мудассир",
    "Аль-Кийама",
    "Аль-Инсан",
    "Аль-Мурсалят",
    "Ан-Наба\'",
    "Ан-Нази\'ат",
    "\'Абаса",
    "Ат-Таквир",
    "Аль-Инфитар",
    "Аль-Мутаффифин",
    "Аль-Иншикак",
    "Аль-Бурудж",
    "Ат-Тарик",
    "Аль-А\'ла",
    "Аль-Гашийа",
    "Аль-Фаджр",
    "Аль-Балад",
    "Аш-Шамс",
    "Аль-Лайл",
    "Ад-Духа",
    "Аш-Шарх",
    "Ат-Тин",
    "Аль-Алак",
    "Аль-Кадр",
    "Аль-Баййина",
    "Аз-Залзала",
    "Аль-Адийат",
    "Аль-Кари\'а",
    "Ат-Такасур",
    "Аль-\'Аср",
    "Аль-Хумаза",
    "Аль-Филь",
    "Курайш",
    "Аль-Ма\'ун",
    "Аль-Каусар",
    "Аль-Кафирун",
    "Ан-Наср",
    "Аль-Масад",
    "Аль-Ихлас",
    "Аль-Фалак",
    "Ан-Нас",
        };
        static string[] surahNamesEn = new[]
        {
            "Al-Fatihah",
    "Al-Baqarah",
    "Aal-E-Imran",
    "An-Nisa\'",
    "Al-Ma\'idah",
    "Al-An\'am",
    "Al-A\'raf",
    "Al-Anfal",
    "At-Tawbah",
    "Yunus",
    "Hud",
    "Yusuf",
    "Ar-Ra\'d",
    "Ibrahim",
    "Al-Hijr",
    "An-Nahl",
    "Al-Isra\'",
    "Al-Kahf",
    "Maryam",
    "Ta-Ha",
    "Al-Anbiya\'",
    "Al-Hajj",
    "Al-Mu\'minun",
    "An-Nur",
    "Al-Furqan",
    "Ash-Shu\'ara",
    "An-Naml",
    "Al-Qasas",
    "Al-Ankabut",
    "Ar-Rum",
    "Luqman",
    "As-Sajdah",
    "Al-Ahzab",
    "Saba\'",
    "Fatir",
    "Ya-Seen",
    "As-Saaffat",
    "Sad",
    "Az-Zumar",
    "Ghafir",
    "Fussilat",
    "Ash-Shura",
    "Az-Zukhruf",
    "Ad-Dukhan",
    "Al-Jathiya",
    "Al-Ahqaf",
    "Muhammad",
    "Al-Fath",
    "Al-Hujurat",
    "Qaf",
    "Adh-Dhariyat",
    "At-Tur",
    "An-Najm",
    "Al-Qamar",
    "Ar-Rahman",
    "Al-Waqi\'ah",
    "Al-Hadid",
    "Al-Mujadila",
    "Al-Hashr",
    "Al-Mumtahana",
    "As-Saf",
    "Al-Jumu\'ah",
    "Al-Munafiqun",
    "At-Taghabun",
    "At-Talaq",
    "At-Tahrim",
    "Al-Mulk",
    "Al-Qalam",
    "Al-Haqqah",
    "Al-Ma\'arij",
    "Nuh",
    "Al-Jinn",
    "Al-Muzzammil",
    "Al-Muddaththir",
    "Al-Qiyamah",
    "Al-Insan",
    "Al-Mursalat",
    "An-Naba\'",
    "An-Nazi\'at",
    "\'Abasa",
    "At-Takwir",
    "Al-Infitar",
    "Al-Mutaffifin",
    "Al-Inshiqaq",
    "Al-Buruj",
    "At-Tariq",
    "Al-A\'la",
    "Al-Ghashiyah",
    "Al-Fajr",
    "Al-Balad",
    "Ash-Shams",
    "Al-Layl",
    "Ad-Dhuhaa",
    "Al-Sharh",
    "At-Tin",
    "Al-Alaq",
    "Al-Qadr",
    "Al-Bayyinah",
    "Az-Zalzalah",
    "Al-Adiyat",
    "Al-Qari\'ah",
    "At-Takathur",
    "Al-Asr",
    "Al-Humazah",
    "Al-Fil",
    "Quraysh",
    "Al-Ma\'un",
    "Al-Kawthar",
    "Al-Kafirun",
    "An-Nasr",
    "Al-Masad",
    "Al-Ikhlas",
    "Al-Falaq",
    "An-Nas"
        };
        static string[] surahNamesAr = new[]
        {
            "الفاتحة",
        "البقرة",
        "آل عمران",
        "النساء",
        "المائدة",
        "اﻷنعام",
        "اﻷعراف",
        "اﻷنفال",
        "التوبة",
        "يونس",
        "هود",
        "يوسف",
        "الرعد",
        "إبراهيم",
        "الحجر",
        "النحل",
        "اﻹسراء",
        "الكهف",
        "مريم",
        "طه",
        "اﻷنبياء",
        "الحج",
        "المؤمنون",
        "النور",
        "الفرقان",
        "الشعراء",
        "النمل",
        "القصص",
        "العنكبوت",
        "الروم",
        "لقمان",
        "السجدة",
        "اﻷحزاب",
        "سبأ",
        "فاطر",
        "يس",
        "الصافات",
        "ص",
        "الزمر",
        "غافر",
        "فصلت",
        "الشورى",
        "الزخرف",
        "الدخان",
        "الجاثية",
        "اﻷحقاف",
        "محمد",
        "الفتح",
        "الحجرات",
        "ق",
        "الذاريات",
        "الطور",
        "النجم",
        "القمر",
        "الرحمن",
        "الواقعة",
        "الحديد",
        "المجادلة",
        "الحشر",
        "الممتحنة",
        "الصف",
        "الجمعة",
        "المنافقون",
        "التغابن",
        "الطلاق",
        "التحريم",
        "الملك",
        "القلم",
        "الحاقة",
        "المعارج",
        "نوح",
        "الجن",
        "المزمل",
        "المدثر",
        "القيامة",
        "اﻹنسان",
        "المرسلات",
        "النبأ",
        "النازعات",
        "عبس",
        "التكوير",
        "الانفطار",
        "المطففين",
        "الانشقاق",
        "البروج",
        "الطارق",
        "اﻷعلى",
        "الغاشية",
        "الفجر",
        "البلد",
        "الشمس",
        "الليل",
        "الضحى",
        "الشرح",
        "التين",
        "العلق",
        "القدر",
        "البينة",
        "الزلزلة",
        "العاديات",
        "القارعة",
        "التكاثر",
        "العصر",
        "الهمزة",
        "الفيل",
        "قريش",
        "الماعون",
        "الكوثر",
        "الكافرون",
        "النصر",
        "المسد",
        "اﻹخلاص",
        "الفلق",
        "الناس",
        };


        static string pathToJsonUz = "c:\\users\\shrew\\source\\repos\\TelegramBotNew\\TelegramBotNew\\AlQuran_uz.json";
        static string pathToJsonAr = "c:\\users\\shrew\\source\\repos\\TelegramBotNew\\TelegramBotNew\\AlQuran_Ar.json";

        static JsonValue jsonUz;
        static JsonValue jsonAr;

        static TelegramBotClient bot = new TelegramBotClient("365015286:AAED8kb8oncNHdruQcDpTk_WaRNFjeHm8Lo");

        static ReplyKeyboardMarkup kb = new ReplyKeyboardMarkup();

        static void Main(string[] args)
        {


            InitJson();
            Console.WriteLine("Json is loaded...");

            bot.StartReceiving();
            bot.OnMessage += Bot_OnMessage;
            bot.OnCallbackQuery += Bot_OnCallbackQuery;
            bot.OnInlineQuery += Bot_OnInlineQuery;
            Console.ReadLine();

        }

        private static async void InitJson()
        {
            jsonUz = await FetchWeatherAsync(pathToJsonUz);
            jsonAr = await FetchWeatherAsync(pathToJsonAr);
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var cid = e.Message.Chat.Id;
            var txt = e.Message.Text;

            switch (txt)
            {
                case "/start":
                    StartBot(e);
                    break;
                case "English":
                    SendInlineKeyBoard(e);
                    break;
                case "O'zbek tili":
                    SendInlineKeyBoard(e);
                    break;
                case "русский":
                    SendInlineKeyBoard(e);
                    break;
                case "Arabic":
                    SendInlineKeyBoard(e);
                    break;
                default:
                    break;
            }



            Console.WriteLine(cid.ToString());
            Console.WriteLine(txt);
        }

        private async static void StartBot(MessageEventArgs e)
        {
            kb.ResizeKeyboard = true;
            kb.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("O'zbek tili"),
                    new KeyboardButton("English"),
                    new KeyboardButton("русский"),
                    new KeyboardButton("Arabic")

                }
            };

            string msg = "************************************\n";
                  msg += "This BOT provides Quran in the   \n" +
                        "form of text and audio. Audio    \n" +
                        "and Text files come from         \n" +
                        "AlAdhan.com.                      \n" +
                        "ALL PRAISES DUE TO ALLAH ALONE.   \n" +
                        "************************************";
            msg += "\n\nPlease write to this BOT what new features you want in the future." +
                " Thank you for your cooperation!";



            await bot.SendTextMessageAsync(e.Message.Chat.Id, msg, Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, kb);
        }
        private async static void SendInlineKeyBoard(MessageEventArgs e)
        {
            string[] surahNames1;
            string[] surahNames2;

            if (e.Message.Text == "O'zbek tili")
            {
                surahNames1 = surahNamesUz.Take<string>(surahNamesUz.Length / 2).ToArray<string>();
                surahNames2 = surahNamesUz.Skip<string>(surahNamesUz.Length / 2).ToArray<string>();
            }
            else if(e.Message.Text == "Arabic")
            {
                surahNames1 = surahNamesAr.Take<string>(surahNamesAr.Length / 2).ToArray<string>();
                surahNames2 = surahNamesAr.Skip<string>(surahNamesAr.Length / 2).ToArray<string>();
            }
            else if(e.Message.Text == "English")
            {
                surahNames1 = surahNamesEn.Take<string>(surahNamesEn.Length / 2).ToArray<string>();
                surahNames2 = surahNamesEn.Skip<string>(surahNamesEn.Length / 2).ToArray<string>();
            }
            else
            {
                surahNames1 = surahNamesRu.Take<string>(surahNamesRu.Length / 2).ToArray<string>();
                surahNames2 = surahNamesRu.Skip<string>(surahNamesRu.Length / 2).ToArray<string>();
            }





            var keyboardMarkup = new InlineKeyboardMarkup(GetInlineKeyboard(surahNames1));

            await bot.SendTextMessageAsync(e.Message.Chat.Id, "Surani tanlang", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.Message.MessageId, keyboardMarkup);

            keyboardMarkup = new InlineKeyboardMarkup(GetInlineKeyboard(surahNames2));

            await bot.SendTextMessageAsync(e.Message.Chat.Id, "Davomi", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.Message.MessageId, keyboardMarkup);
        }
        private static async void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CallbackQuery.Data))
            {
                var data = e.CallbackQuery.Data;
                var cid = e.CallbackQuery.Message.Chat.Id;
                var cbid = e.CallbackQuery.Id;

                int index = FindIndex(e.CallbackQuery.Data);
                SendQuran(e, FindLang(e.CallbackQuery.Data), index);


                await bot.AnswerCallbackQueryAsync(cbid, data);

                if(surahNamesUz.Contains(data))
                {
                    int index1 = Array.IndexOf(surahNamesUz, data);

                    


                }

                








                await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, data.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.CallbackQuery.Message.MessageId, null);

            }
        }

        private static int FindIndex(string data)
        {
            if (surahNamesUz.Contains(data.ToString()))
            {
                return Array.IndexOf(surahNamesUz, data);
            }
            else if (surahNamesAr.Contains(data))
                return Array.IndexOf(surahNamesAr, data);
            else
                return 1;
        }

        private static async void SendQuran(CallbackQueryEventArgs e, JsonValue json, int index)
        {
            string msg = ParseAndDisplay(json, index);
            await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, msg);

            JsonValue data = json["data"];
            JsonValue surahs = data["surahs"];

                string temp = "";
                JsonValue ayahs = surahs[index]["ayahs"];
                JsonValue edition = data["edition"];

                temp += "\n\n" + "Language: " + edition["language"];
                temp += "\n" + "Name: " + edition["englishName"] + "\n\n";

                await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, temp);

                foreach (JsonValue item in ayahs)
                {
                    int num = item["number"];

                    await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, item["text"]);

                    await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "http://cdn.alquran.cloud/media/audio/ayah/ar.alafasy/" + num.ToString());
            }
            


        }

        private static string ParseAndDisplay(JsonValue json, int index)
        {

            string msg = "";

            JsonValue data = json["data"];
            JsonValue surahs = data["surahs"];
            JsonValue number = surahs[index]["number"];
            msg += ("Number: " + number.ToString() + "\n");
            JsonValue name = surahs[index]["name"];
            msg += ("Name: " + name + "\n");
            JsonValue englishName = surahs[index]["englishName"];
            msg += ("English Name: " + englishName + "\n");
            JsonValue englishNameTranslation = surahs[index]["englishNameTranslation"];
            msg += ("English Name Translation: " + englishNameTranslation + "\n");
            JsonValue revelationType = surahs[index]["revelationType"];
            msg += ("Revelation Type: " + revelationType + "\n\n\n");

            return msg;

        }

        private static JsonValue FindLang(string data)
        {
            if (surahNamesUz.Contains(data.ToString()))
            {
                return jsonUz;
            }
            else if (surahNamesAr.Contains(data))
                return jsonAr;
            else
                return null;
        }

        private static void Bot_OnInlineQuery(object sender, Telegram.Bot.Args.InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }




        private static InlineKeyboardButton[][] GetInlineKeyboard(string[] buttonItem)
        {
            var keyboardInline = new InlineKeyboardButton[19][];
            

            int k = 0;
            for(var j=0;j<19;j++)
            {
                var keyboardButtons = new InlineKeyboardButton[3];
                for (var i = 0; i < 3; i++)
                {
                    keyboardButtons[i] = new InlineKeyboardButton
                    {
                        Text = buttonItem[k],
                        CallbackData = buttonItem[k++],
                    };
                }
                keyboardInline[j] = keyboardButtons;
            }
            
            return keyboardInline;
        }
        private static async Task<JsonValue> FetchWeatherAsync(string path)
        {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = File.OpenRead(path))
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                    // Return the JSON document:
                    return jsonDoc;
                }
            
        }

    }
}
