using System.Text.Json;
using F0rmDataBase;
class Database
{
    public static List<User> allUsers = new List<User>();
    public static void saveUsers()
    {
        string json = JsonSerializer.Serialize(allUsers);
        File.WriteAllText("usersData.json", json);
    }

    public static int getNextId()
    {
        int maxID = 999;
        
        string json = File.ReadAllText("usersData.json");
        if (string.IsNullOrWhiteSpace(json))
        {
            return maxID = 999;
        }
        else
        {
            Database.allUsers = JsonSerializer.Deserialize<List<User>>(json);
        }
        

        foreach (User newUser in allUsers)
        {
            if (newUser.ID > maxID)
            {
                maxID = newUser.ID;
            }
        }

        ++maxID;
        return maxID;
    }
    public static bool checkId(int inputID)
    {
        string json = File.ReadAllText("usersData.json");

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("Ошибка со стороны F0rm! Просим извинения за предоставленные неудобства!");
            Console.WriteLine("Повторите попытку позже, предварительно обновив версию F0rm.");
            Console.ReadLine();

            return false;
        }

        Database.allUsers = JsonSerializer.Deserialize<List<User>>(json);

        foreach (User user in Database.allUsers)
        {
            if (user.ID == inputID)
            {
                Console.Clear();
                Console.WriteLine("|============== УКАЖИТЕ ПАРОЛЬ ==============|");
                Console.WriteLine(" ");

                string inputPassword = Console.ReadLine();

                Console.Clear();

                if (inputPassword == user.PASSWORD)
                {   
                    Console.Clear();

                    Console.WriteLine($"Приветствуем, {user.USERNAME}!");
                    Console.WriteLine("Вы успешно вошли в свой аккаунт.");
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
        Console.Clear();

        Console.WriteLine("Ошибка. Неверный или несуществующий ID!");
        Console.ReadLine();

        Console.Clear();

        Begin.Main();
        return false;
    }
}