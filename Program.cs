namespace F0rmDataBase
{
    class Begin
    {
        public static void Main()
        {
            Logo.Print();

            Console.Clear();

            Console.WriteLine("""

            |============ ВЫБЕРИТЕ ДЕЙСТВИЕ ============|
            1. регистрация
            2. вход
            3. выход из F0rm
             
            """);

            while (true)
            {
                string? choice = Console.ReadLine();
                
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