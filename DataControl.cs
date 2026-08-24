using System.Text.Json;

namespace F0rmDataBase
{
    class Database
    {
        public static List<User> allUsers = new List<User>();
        public static void saveUsers()
        {
            string json = JsonSerializer.Serialize(allUsers);
            
            File.WriteAllText("usersData.json", json);
        }
        public static User? FindUserById(int id)
        {
            if (!File.Exists("usersData.json")) return null;

            string json = File.ReadAllText("usersData.json");

            if (string.IsNullOrWhiteSpace(json)) return null;

            allUsers = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

            foreach (User user in allUsers)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }

            return null;
        }
        public static int getNextId()
        {
            int maxID = 999;
            
            FindUserById(-1); 

            foreach (User newUser in allUsers)
            {
                if (newUser.ID > maxID)
                {
                    maxID = newUser.ID;
                }
            }

            return ++maxID;
        }
        public static bool checkId(int inputID)
        {
            User? user = FindUserById(inputID);

            if (user == null)
            {
                Console.Clear();

                Console.WriteLine("Ошибка. Неверный или несуществующий ID!");
                Console.ReadLine();

                Console.Clear();

                Begin.Main();
                return false;
            }

            string inputPasswordBase64 = InputHelper.RequestPassword("УКАЖИТЕ ПАРОЛЬ");

            Console.Clear();

            if (inputPasswordBase64 == user.PASSWORD)
            {   
                Console.Clear();

                Console.WriteLine($"""

                Приветствуем, {user.USERNAME}!
                Вы успешно вошли в свой аккаунт.
                 
                """);

                Console.ReadLine();
                return true;
            }
            else
            {   
                Console.Clear();

                Console.WriteLine("Ошибка. Неверный пароль!");
                Console.ReadLine();

                Console.Clear();

                Begin.Main();
                return false;
            }
        }
    }
}
