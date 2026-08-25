using System.Text.Json;

namespace F0rmDataBase
{
    class Database
    {
        private const string FileName = "usersData.json";
        public static List<User> allUsers = new List<User>();
        public static bool FileExists()
        {
            return File.Exists(FileName);
        }
        public static bool LoadUsers()
        {
            if (!FileExists())
                return false;

            string json = File.ReadAllText(FileName);

            if (string.IsNullOrWhiteSpace(json))
            {
                allUsers = new List<User>();
                return true;
            }

            allUsers = JsonSerializer.Deserialize<List<User>>(json)
                       ?? new List<User>();

            return true;
        }
        public static void SaveUsers()
        {
            string json = JsonSerializer.Serialize(allUsers,new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(FileName, json);
        }
        public static User? FindUserById(int id)
        {
            LoadUsers();

            foreach (User user in allUsers)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }

            return null;
        }
        public static void DeleteUser()
        {
            Console.Clear();
            int id = InputHelper.RequestId();

            if (!LoadUsers()) return;
            var user = allUsers.FirstOrDefault(u => u.ID == id);

            if (user == null) { Console.WriteLine("\nНе найден."); Console.ReadLine(); return; }

            Console.WriteLine($"""

            Удалить пользователя {user.USERNAME}?
            1. да
            2. нет

            """);

            Console.Write("\nВыберите действие: ");

            if (Console.ReadLine() == "1")
            {
                allUsers.Remove(user);
                SaveUsers();
                Console.WriteLine("\nУспешно удалён.");
                Console.ReadLine();
                ListUsers();
            }
            else
            {
                Console.WriteLine("\nУдаление отменено.");
                Admin.Panel();
            }
        }

        public static int GetNextId()
        {
            LoadUsers();

            int maxID = 999;

            foreach (User user in allUsers)
            {
                if (user.ID > maxID)
                {
                    maxID = user.ID;
                }
            }

            return maxID + 1;
        }
        public static bool CheckId(int inputID)
        {
            User? user = FindUserById(inputID);

            if (user == null)
            {
                Console.Clear();

                Console.WriteLine("Ошибка. Неверный или несуществующий ID!");
                Console.ReadLine();

                return false;
            }

            string inputPassword = InputHelper.RequestPassword("УКАЖИТЕ ПАРОЛЬ");

            Console.Clear();

            if (inputPassword == user.PASSWORD)
            {
                Console.WriteLine($"""

                Приветствуем, {user.USERNAME}!
                Вы успешно вошли в свой аккаунт.

                """);

                Console.ReadLine();

                return true;
            }

            Console.WriteLine("Ошибка. Неверный пароль!");
            Console.ReadLine();

            return false;
        }
        public static void ListUsers()
        {
            if (!LoadUsers())
            {
                Console.WriteLine("Файл базы данных не найден.");
                Console.ReadLine();
                return;
            }

            if (allUsers.Count == 0)
            {
                Console.WriteLine("В базе данных нет пользователей.");
                Console.ReadLine();
                return;
            }

            while (true)
            {
                Console.Clear();

                Console.WriteLine("""
                
                |================ СПИСОК ПОЛЬЗОВАТЕЛЕЙ ================|

                """);

                foreach (User user in allUsers)
                {
                    Console.WriteLine($"ID: {user.ID} | ИМЯ ПОЛьЗОВАТЕЛЯ: {user.USERNAME} ");
                }

                Console.WriteLine("""

                 
                Введите ID пользователя для просмотра.
                Для выхода введите - 1.
                 
                """);

                int id = InputHelper.RequestId();

                if (id == 1)
                {
                    Console.Clear();
                    Admin.Panel();
                    return;
                }

                User? selectedUser = FindUserById(id);

                if (selectedUser == null)
                {
                    Console.WriteLine("Пользователь с таким ID не найден.");
                    Console.ReadLine();
                    continue;
                }

                Console.Clear();

                Console.WriteLine($"""

                |================ ПРОФИЛЬ ПОЛЬЗОВАТЕЛЯ ================|

                ID : {selectedUser.ID}
                ИМЯ ПОЛЬЗОВАТЕЛЯ : {selectedUser.USERNAME}
                ГОД РОЖДЕНИЯ : {selectedUser.BIRTHYEAR}
                ВОЗРАСТ : {selectedUser.AGE}
                ПОЛ : {selectedUser.GENDER}

                """);

                Console.ReadLine();
            }
        }
    }
}