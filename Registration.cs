class Registration
    {
        public static void CreateUser()
        {
            int birthYear, age;

            string username = "";
            string gender = "";

            Console.Clear();

            while (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("|======== ВВЕДИТЕ ИМЯ ПОЛЬЗОВАТЕЛЯ =========|");
                Console.WriteLine(" ");
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.Clear();
                    Console.WriteLine("Имя пользователя не должно состоять из пробела!");
                    Console.ReadLine();
                }
            }

            Console.Clear();

            Console.WriteLine($"Здравствуйте, {username}!");
            Console.WriteLine(" ");

        while (true)
        {
            Console.Clear();

            Console.WriteLine("|========= УКАЖИТЕ ВАШ ГОД РОЖДЕНИЯ =========|");
            Console.WriteLine(" ");

            try
            {
                birthYear = int.Parse(Console.ReadLine());
                age = DateTime.Now.Year - birthYear;

                if (age < 0)
                    {
                        Console.WriteLine("Ошибка! Кажется Вы еще не родились!");
                        Console.ReadLine();
                        continue;
                    }          

                break;
            }

            catch
            {
                Console.WriteLine("Ошибка! Введите число.");
                Console.ReadLine();
            }
        }
            

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|============== ВЫБЕРИТЕ ПОЛ ==============|");
                Console.WriteLine("1. мужчина");
                Console.WriteLine("2. женщина");
                Console.WriteLine(" ");

                gender = Console.ReadLine();

                switch (gender)
                {
                    case "1":
                    case "2":
                        Console.Clear();
                        break;
                
                    default:
                        {   
                            Console.WriteLine("Только М или Ж!");
                            Console.ReadLine();
                            continue;
                        }
                
                }

                break;
            }

            Console.WriteLine("|============ ПРИДУМАЙТЕ ПАРОЛЬ ============|");
            Console.WriteLine(" ");

            string password = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Отлично, {username}! Вы успешно зарегистрировались в F0rm!");
            Console.ReadLine();

            Console.Clear();

            int id = Database.getNextId();
 
            User newUser = new User
            {
                ID = id,
                USERNAME = username,
                BIRTHYEAR = birthYear,
                AGE = age,
                GENDER = gender,
                PASSWORD = password
            };

            Database.allUsers.Add(newUser);
            Database.saveUsers();

            Console.WriteLine($"Ваш уникальный ID: {id}");
            Console.ReadLine();

            Console.Clear();
            
            Console.WriteLine("|============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|");
            Console.WriteLine("1. изменить данные");
            Console.WriteLine("2. выход из программы");
            Console.WriteLine(" ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entrance.EditUser(id);
                    break;

                case "2":
                    Console.Clear();
                    return;
            }
        }
    }
