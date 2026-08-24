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

                    Created by sh3/axy3nno
            GitHub - https://github.com/axy3nno/F0rm
";

        Console.WriteLine(logo);
        Console.ResetColor();
        Console.ReadLine();
    }
}
