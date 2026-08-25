namespace F0rmDataBase
{
    class Admin
    {
        public static void Login()
        {
            Console.Clear();
            string login = InputHelper.RequestUsername("ВВЕДИТЕ ЛОГИН");
            string password = InputHelper.RequestPassword("ВВЕДИТЕ ПАРОЛЬ");

            if (login == AdminData.Login && password == AdminData.Password)
            {
                Console.Clear();
                Panel();
            }
            else
            {
                Console.Clear();
                Begin.Main();
            }

        }
        public static void AdminMenu()
        {
            Console.WriteLine("""
            |============ АДМИН-ПАНЕЛЬ ============|

            1. cписок пользователей
            2. удалить пользователя
            3. выход в главное меню
             
            """);
        }
        public static void Panel()
        {
            AdminLogo.Print();

            Console.Clear();

            AdminMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Database.ListUsers();
                    break;

                case "2":
                    Database.DeleteUser();
                    break;

                case "3":
                    Console.Clear();
                    Begin.Main();
                    return;
            }
        }
    }

}