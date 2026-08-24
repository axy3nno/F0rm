namespace F0rmDataBase
{
    class Entrance
    {
        public static void CheckUser()
        {
            Console.Clear();
            Console.WriteLine("""

            |============== УКАЖИТЕ ID ================|
             
            """);

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Clear();
                Console.WriteLine("Ошибка! ID должен быть числом.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            
            bool isAuthorized = Database.checkId(id);

            if (isAuthorized)
            {
                Profile(id);
            }
        }

        public static void Profile(int id)
        {   
            while (true)
            {
                Console.WriteLine("""

                |============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|
                1. посмотреть профиль
                2. редактировать профиль
                3. удалить профиль
                4. выход из F0rm
                 
                """);

                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        foreach (User user in Database.allUsers)
                        {
                            if (user.ID == id)
                            {
                                Console.WriteLine($"""

                                |================= ПРОФИЛЬ =================|
                                ID : {user.ID}
                                ИМЯ ПОЛЬЗОВАТЕЛЯ : {user.USERNAME}
                                ГОД РОЖДЕНИЯ : {user.BIRTHYEAR}
                                ВОЗРАСТ : {user.AGE}
                                ПОЛ : {user.GENDER}
                                 
                                """);
                                
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        }
                        break;

                        case "2":
                            ProfileEditor.Edit(id);
                            break;

                
                    case "3":
                        User? userToDelete = null;

                        Console.WriteLine("""

                        Чтобы подтвердить текущее действие, введите - 1 :
                         
                        """);

                        string? confirm = Console.ReadLine();
                        Console.Clear();

                        if (confirm == "1")
                        {
                            if (userToDelete != null) Database.allUsers.Remove(userToDelete);

                            if (userToDelete != null)
                            {
                                Database.allUsers.Remove(userToDelete);
                                Database.saveUsers();

                                Console.WriteLine("Профиль был удален.");
                                Console.ReadLine();
                                
                                Console.Clear();
                                Begin.Main();
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }
                        break;
                    
                    case "4":
                        Console.Clear();

                        Console.WriteLine("Выходя из F0rm, Вы выходите из профиля!");
                        Console.ReadLine();
                        
                        Console.Clear();
                        return;
                
                    default:
                        Console.Clear();
                        continue;
                }
            }
        }
    }
}
