using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; 

namespace EasyType.Models
{
    public class TextProvider
    {
        private readonly Dictionary<string, List<string>> _hardcodedSeparateWordsByLanguage = new()
        {
            {"Українська", new List<string> { "слово", "тест", "програма", "швидкість", "набір", "мова", "комп'ютер", "клавіатура", "практика", "результат", "аналіз", "система", "додаток", "кодування", "розробка", "алгоритм", "логіка", "технологія", "інформація", "дані", "мережі", "сервер", "клієнт", "інтерфейс", "користувач", "функція", "змінна", "цикл", "масив", "об'єкт", "клас", "успіх", "прогрес", "збільшення", "зниження", "точний", "коректний", "відповідь", "питання", "знання", "вміння", "досвід", "навчання", "рішення", "проблема", "допомога", "підтримка", "керівництво", "інструкція", "посібник", "документ", "звіт", "дані", "файл", "папка", "диск", "пам'ять", "процесор", "екран", "мишка", "принтер", "сканер", "динамік", "мікрофон", "камера", "програмне", "забезпечення", "апаратне", "безпека", "захист", "шифрування", "аутентифікація", "авторизація", "визначення", "ідентифікація", "мережевий", "протокол", "швидкісний", "доступ", "бездротовий", "бездротове", "з'єднання", "маршрутизатор", "комутатор", "фаєрвол", "вірус", "антивірус", "фішинг", "спам", "троян", "ботнет", "руткіт", "шпигунське", "програмне", "забезпечення", "рекламне", "операційна", "система", "ядро", "оболонка", "файлова", "система", "директорія", "команда", "термінал", "консоль", "скрипт", "бібліотека", "фреймворк", "API", "сервіс", "процес", "потік", "сесія", "кеш", "буфер", "черга", "стек", "дерево", "граф", "хеш", "таблиця", "пошук", "сортування", "шифрування", "дешифрування", "компресія", "декомпресія", "резервне", "копіювання", "відновлення", "журнал", "подій", "трасування", "налагодження", "тестування", "розгортання", "конфігурація", "параметр", "опція", "значення", "типовий", "додатковий", "налаштування", "модифікація", "оновлення", "версія", "реліз", "виправлення", "помилка", "збій", "відмова", "продуктивність", "оптимізація", "масштабованість", "надійність", "доступність", "безпечність", "розширення", "інтеграція", "взаємодія", "комунікація", "транзакція", "реплікація", "синхронізація", "асинхронний", "паралельний", "розподілений", "хмарний", "віртуалізація", "контейнер", "мікросервіси", "моноліт", "рефакторинг", "реліз-менеджмент", "контроль", "версій", "розгортання", "CI/CD", "DevOps", "Agile", "Scrum", "Kanban", "Waterfall", "методологія", "планування", "аналіз", "дизайн", "реалізація", "тестування", "впровадження", "підтримка", "моніторинг" } },
            {"English", new List<string> { "the", "be", "to", "of", "and", "a", "in", "that", "have", "I", "it", "for", "not", "on", "with", "he", "as", "you", "do", "at", "this", "but", "his", "by", "from", "we", "say", "her", "she", "or", "will", "my", "one", "all", "would", "there", "their", "what", "so", "up", "out", "if", "about", "who", "get", "which", "go", "me", "when", "make", "can", "like", "time", "no", "just", "him", "know", "take", "people", "into", "year", "your", "good", "some", "could", "them", "see", "other", "than", "then", "now", "look", "only", "come", "its", "over", "think", "also", "back", "after", "use", "two", "how", "our", "work", "first", "well", "way", "even", "new", "want", "because", "any", "these", "give", "day", "most", "us" } },
            {"Code", new List<string>() } 
        };

        private readonly Dictionary<string, List<string>> _hardcodedFullTextsByLanguage = new()
        {
            {"Українська", new List<string>
            {
                "Рідна мова - це скарб, який потрібно берегти і шанувати. У ній мудрість віків і краса слова, що відображає душу народу. Не забуваймо своє коріння, адже воно живить нашу ідентичність. Природа України вражає своєю красою та різноманітністю ландшафтів. Карпати, Чорне море, безмежні степи - у нас є все для натхнення. Бережімо нашу планету, щоб зберегти цю красу для майбутніх поколінь. Київ - серце України, місто з багатою історією та культурою, що сягає глибини століть. Золоті ворота, Софійський собор, Андріївський узвіз - це лише деякі з його архітектурних та духовних перлин. Леся Українка - видатна українська поетеса і письменниця, чия творчість є невичерпним джерелом мудрості та патріотизму. Її поезія надихає та вражає своєю глибиною та силою духу. Тарас Шевченко - великий український поет і художник, чий \"Кобзар\" став символом національного відродження та боротьби за свободу. Українська кухня славиться своїми смачними та різноманітними стравами, які відображають багату історію та традиції нашого народу.",
                "Програмування - це мистецтво, яке потребує практики та творчості. Алгоритми є основою будь-якої складної програми, визначаючи її ефективність та логіку. Вивчення нових технологій ніколи не зупиняється, постійно відкриваючи нові горизонти. Чистий код завжди виглядає так, ніби його написав хтось, хто дбає про нього. Спочатку розв'яжи проблему, потім напиши код. Простота - запорука надійності. Будь-який дурень може написати код, який зрозуміє комп'ютер. Хороші програмісти пишуть код, який зрозуміють люди. Кращий спосіб передбачати майбутнє - це створити його. Технологія - це все, що не було, коли ти народився. Найважливіше в спілкуванні - це почути те, що не було сказано. Говорити легко, покажи мені код. Майбутнє належить тим, хто вірить у красу своєї мрії. Не бійтеся робити помилки, адже на них вчаться. Програмуйте так, ніби людина, яка буде підтримувати ваш код, - це озброєний психопат, який знає, де ви живете. Тестуйте свій код, інакше це зроблять ваші користувачі."
            }},
            {"English", new List<string>
            {
                "Programming is an art that requires practice and creativity. Algorithms are the foundation of any complex program, determining its efficiency and logic. Learning new technologies never stops, constantly opening new horizons. Clean code always looks like someone who cares about it wrote it. First solve the problem, then write the code. Simplicity is the key to reliability. Any fool can write code that a computer understands. Good programmers write code that people understand. The best way to predict the future is to create it. Technology is everything that didn't exist when you were born. The most important thing in communication is to hear what was not said. It's easy to talk, show me the code. The future belongs to those who believe in the beauty of their dreams. Don't be afraid to make mistakes, because you learn from them. Program as if the person who will maintain your code is an armed psychopath who knows where you live. Test your code, otherwise your users will.",
                "The quick brown fox jumps over the lazy dog. This sentence is famous for containing all the letters of the English alphabet. It is often used to test typewriters, keyboards, and fonts. The phrase is a pangram. Another common pangram is \"Pack my box with five dozen liquor jugs.\" These short sentences are useful for quick checks of text rendering and input devices."
            }},
            {"Code", new List<string> 
            {
                TextProvider.FormatCodeAsSingleLine("public static void Main(string[] args)\n{\n    Console.WriteLine(\"Hello, World!\");\n    for (int i = 0; i < 10; i++)\n    {\n        Console.WriteLine($\"Count: {i}\");\n    }\n}"),
                TextProvider.FormatCodeAsSingleLine("function factorial(n) {\n    if (n === 0) {\n        return 1;\n    }\n    return n * factorial(n - 1);\n}\nconsole.log(factorial(5)); // Output: 120")
            }}
        };

        private Random _random = new Random();

        public List<string> GetAvailableLanguages()
        {
            return _hardcodedFullTextsByLanguage.Keys.ToList();
        }

        public string GetRandomText(string language, string textMode)
        {

            if (string.IsNullOrEmpty(language) || string.IsNullOrEmpty(textMode))
            {
                return "Не вдалося завантажити текст: невідома мова або режим.";
            }


            if (language == "Code" && textMode == "Окремі слова")
            {
                return "Для мови \"Code\" немає можливості вибирати режим тексту \"Окремі слова\".";
            }


            if (textMode == "Окремі слова")
            {
                if (_hardcodedSeparateWordsByLanguage.TryGetValue(language, out var words) && words.Count > 0)
                {
                    int startIndex = _random.Next(0, words.Count - Math.Min(50, words.Count));
                    int count = Math.Min(50, words.Count - startIndex);
                    return string.Join(" ", words.Skip(startIndex).Take(count));
                }
                else
                {

                    return "Немає достатньо слів для режиму 'Окремі слова' для обраної мови.";
                }
            }
            else 
            {
                if (_hardcodedFullTextsByLanguage.TryGetValue(language, out var fullTexts) && fullTexts.Count > 0)
                {
                    return fullTexts[_random.Next(fullTexts.Count)];
                }
                else
                {
                    return "Не вдалося завантажити текст для обраної мови та режиму.";
                }
            }
        }


        private static string FormatCodeAsSingleLine(string code)
        {
            string result = code.Replace("\n", " ");

            result = Regex.Replace(result, @"\s+", " ").Trim();
            return result;
        }
    }
}