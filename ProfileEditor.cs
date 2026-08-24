namespace F0rmDataBase
{
    class ProfileEditor
    {
        public static void Edit(int id)
        {
            User? targetUser = Database.FindUserById(id);

            if (targetUser == null) return;

            while (true)
            {
                Console.Clear();

                Console.WriteLine($"""

                |======= ЧТО ВЫ ХОТИТЕ ИЗМЕНИТЬ? =======|
                1. Имя пользователя (Текущее: {targetUser.USERNAME})
                2. Год рождения     (Текущий: {targetUser.BIRTHYEAR})
                3. Пол              (Текущий: {targetUser.GENDER})
                4. Пароль           (Скрыт)
                5. Сохранить изменения и выйти
                 
                """);

                string? choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        targetUser.USERNAME = InputHelper.RequestUsername($"НОВОЕ ИМЯ (Текущее: {targetUser.USERNAME})");
                        break;

                    case "2":
                        targetUser.BIRTHYEAR = InputHelper.RequestBirthYear($"НОВЫЙ ГОД РОЖДЕНИЯ (Текущий: {targetUser.BIRTHYEAR})");
                        targetUser.AGE = DateTime.Now.Year - targetUser.BIRTHYEAR; 
                        break;

                    case "3":
                        targetUser.GENDER = InputHelper.RequestGender($"ИЗМЕНЕНИЕ ПОЛА (Текущий: {targetUser.GENDER})");
                        break;

                    case "4":
                        targetUser.PASSWORD = InputHelper.RequestPassword("ВВЕДИТЕ НОВЫЙ ПАРОЛЬ");
                        break;

                    case "5":
                        Database.saveUsers();
                        
                        Console.WriteLine("Все изменения успешно сохранены в базу!");
                        Console.ReadLine();

                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Неверный выбор! Пожалуйста, выберите пункт от 1 до 5.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}