namespace F0rmDataBase
{
    class Begin
    {
        public static void Main()
        {
            Logo.Print();

            Console.Clear();

            Console.WriteLine("|============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|");
            Console.WriteLine("1. регистрация");
            Console.WriteLine("2. вход");
            Console.WriteLine("3. выход из F0rm");
            Console.WriteLine(" ");

            while (true)
            {
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Registration.CreateUser();
                        break;

                    case "2":
                        Entrance.CheckUser();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Выбрано некорректное действие!");
                        continue;
                }
                break;
            }
        }
    }
}