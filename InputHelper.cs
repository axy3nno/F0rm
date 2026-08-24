namespace F0rmDataBase
{
    class InputHelper
    {
        public static string RequestUsername(string contextTitle = "ВВЕДИТЕ ИМЯ ПОЛЬЗОВАТЕЛЯ")
        {
            string? username = "";
            while (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine($"""

                |======== {contextTitle} =========|
                 
                """);
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.Clear();
                    Console.WriteLine("Имя пользователя не должно состоять из пробела!");
                    Console.ReadLine();
                }
            }
            return username;
        }

        public static int RequestBirthYear(string contextTitle = "УКАЖИТЕ ВАШ ГОД РОЖДЕНИЯ")
        {
            int? birthYear = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"""

                |========= {contextTitle} =========|

                """);
        
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка! Вы ничего не ввели.");
                    Console.ReadLine();
                    continue;
                }

                if (int.TryParse(input, out int parsedYear))
                {
                    birthYear = parsedYear;
                }
                else
                {
                    birthYear = null; 
                }

                if (birthYear is null)
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                    Console.ReadLine();
                    continue;
                }

                if (birthYear == 0)
                {
                    Console.WriteLine("Ошибка! Год рождения не может быть равен 0.");
                    Console.ReadLine();
                    continue;
                }

                int age = DateTime.Now.Year - birthYear.Value;

                if (age < 0)
                {
                    Console.WriteLine("Ошибка! Кажется Вы еще не родились!");
                    Console.ReadLine();
                    continue;
                }

                return birthYear.Value;
            }
        }

        public static string RequestGender(string contextTitle = "ВЫБЕРИТЕ ПОЛ")
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"""

                |============== {contextTitle} ==============|
                1. мужчина
                2. женщина
                 
                """);

                string? inputGender = Console.ReadLine();

                if (inputGender == "1") return "мужчина";
                if (inputGender == "2") return "женщина";

                Console.WriteLine("Только 1 или 2!");
                Console.ReadLine();
            }
        }

        public static string RequestPassword(string contextTitle = "ПРИДУМАЙТЕ ПАРОЛЬ")
        {
            Console.Clear();
            Console.WriteLine($"""

            |============ {contextTitle} ============|
             
            """);

            string password = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        Console.WriteLine("\nОшибка! Пароль не должен быть пустым.");
                        Console.ReadLine();
                        
                        Console.Clear();
                        Console.WriteLine($"""

                        |============ {contextTitle} ============|
                         
                        """);
                        password = "";
                        continue;
                    }
                    Console.WriteLine(); 
                    break;
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (keyInfo.KeyChar != '\u0000')
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }

            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}