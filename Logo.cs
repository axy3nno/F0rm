class Logo
{
    public static void Print()
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.White;

        string logo = @"
██████████       ██████████       ██████████    ████      ████
██████████     ██████████████     ████████████  ██████  ██████
██            █████        █████  ████    ████  ██████████████
██████████    ████   ████   ████  ████████████  ████  ██  ████
██████████    ████   ████   ████  ██████████    ████      ████
██            █████        █████  ████  ████    ████      ████
██              ██████████████    ████    ████  ████      ████

                        Created by sh3
";

        Console.WriteLine(logo);
        Console.ResetColor();
        Console.ReadLine();
    }
}
