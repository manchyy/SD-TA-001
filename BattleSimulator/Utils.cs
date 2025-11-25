namespace BattleSimulator;

public class Utils
{
    public static void PrintMenu()
    {
        Console.Clear();
        string[] asciiArt = new string[]
        {
            "▗▄▄▄▖▗▄▄▄▖ ▗▄▄▖▗▖ ▗▖▗▄▄▄▖     ▗▄▖ ▗▄▄▖ ▗▄▄▄▖▗▖  ▗▖ ▗▄▖",
            "▐▌     █  ▐▌   ▐▌ ▐▌  █      ▐▌ ▐▌▐▌ ▐▌▐▌   ▐▛▚▖▐▌▐▌ ▐▌",
            "▐▛▀▀▘  █  ▐▌▝▜▌▐▛▀▜▌  █      ▐▛▀▜▌▐▛▀▚▖▐▛▀▀▘▐▌ ▝▜▌▐▛▀▜▌",
            "▐▌   ▗▄█▄▖▝▚▄▞▘▐▌ ▐▌  █      ▐▌ ▐▌▐▌ ▐▌▐▙▄▄▖▐▌  ▐▌▐▌ ▐▌"
        };

        ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan
        };
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------------------------------------------");
        for (int i = 0; i < asciiArt.Length; i++)
        {
            Console.ForegroundColor = colors[i];
            Console.WriteLine(asciiArt[i]);
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------------------------------------------");
        Console.ResetColor();
    }

    public static string GenerateName()
    {
        Random r = new Random();
        string[] orcNames =
            {
                "Grom",
                "Thrag",
                "Mogdur",
                "Urzug",
                "Kragnar",
                "Zugthak",
                "Rokmar",
                "Brukk",
                "Grashnak",
                "Urzoth",
                "Drakmar",
                "Gorblud"
            };
        return orcNames[r.Next(orcNames.Length)];
    }
}
