using F0rmDataBase;
class Entrance
    {
        public static void CheckUser()
        {
            Console.Clear();
            Console.WriteLine("|============== УКАЖИТЕ ID ================|");
            Console.WriteLine(" ");

            int id = int.Parse(Console.ReadLine());

            Console.Clear();
            
            bool isAuthorized = Database.checkId(id);

            if (isAuthorized)
            {
                EditUser(id);
            }
        }

        public static void EditUser(int id)
        {   
            while (true)
            {
            Console.WriteLine("|============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|");
            Console.WriteLine("1. посмотреть профиль");
            Console.WriteLine("2. редактировать профиль");
            Console.WriteLine("3. удалить профиль");
            Console.WriteLine("4. выход из F0rm");
            Console.WriteLine(" ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
                {
                    case "1":
                        foreach (User user in Database.allUsers)
                            {
                                if (user.ID == id)
                                {
                                    Console.WriteLine("|================= ПРОФИЛЬ =================|");
                                    Console.WriteLine($"ID : {user.ID}");
                                    Console.WriteLine($"ИМЯ ПОЛЬЗОВАТЕЛЯ : {user.USERNAME}");
                                    Console.WriteLine($"ГОД РОЖДЕНИЯ : {user.BIRTHYEAR}");
                                    Console.WriteLine($"ВОЗРАСТ : {user.AGE}");
                                    Console.WriteLine($"ПОЛ : {user.GENDER}");

                                    Console.WriteLine(" ");
                                    Console.ReadLine();

                                    Console.Clear();
                                    break;
                                }
                            }
                        break;

                    case "2":
                        
                        break;
                
                    case "3":
                        User userToDelete = null;

                        Console.WriteLine("Чтобы подтвердить текущее действие, введите - 1 :");
                        Console.WriteLine(" ");

                        string confirm = Console.ReadLine();
                        Console.Clear();

                        if (confirm == "1")
                        {
                            foreach (User user in Database.allUsers)
                            {
                                if (user.ID == id)
                                {
                                    userToDelete = user;
                                }
                            }

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
                        return;
                
                    default:
                        Console.Clear();
                        continue;
                }
            }
        }
    }
