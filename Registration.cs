namespace F0rmDataBase
{
    class Registration
    {
        public static void Greetings(string username) => Console.WriteLine($"Здравствуйте, {username}!\n");

        public static void CreateUser()
        {
            Console.Clear();

            string username = InputHelper.RequestUsername();
            
            Console.Clear();
            Greetings(username);

            int birthYear = InputHelper.RequestBirthYear();
            int age = DateTime.Now.Year - birthYear;
            
            string gender = InputHelper.RequestGender();
            string encryptedPassword = InputHelper.RequestPassword();

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
                PASSWORD = encryptedPassword
            };

            Database.allUsers.Add(newUser);
            Database.saveUsers();

            Console.WriteLine($"Ваш уникальный ID: {id}");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("""

            |============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|
            1. изменить данные
            2. выход из программы
             
            """);

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Entrance.Profile(id);
                    break;

                case "2":
                    Console.Clear();
                    return;
            }
        }
    }
}