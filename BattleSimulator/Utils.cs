namespace BattleSimulator;

public class Utils
{
    public static void PrintMenu()
    {
        Console.Clear();
        string[] asciiArt =
        {
            "▗▄▄▄▖▗▄▄▄▖ ▗▄▄▖▗▖ ▗▖▗▄▄▄▖     ▗▄▖ ▗▄▄▖ ▗▄▄▄▖▗▖  ▗▖ ▗▄▖",
            "▐▌     █  ▐▌   ▐▌ ▐▌  █      ▐▌ ▐▌▐▌ ▐▌▐▌   ▐▛▚▖▐▌▐▌ ▐▌",
            "▐▛▀▀▘  █  ▐▌▝▜▌▐▛▀▜▌  █      ▐▛▀▜▌▐▛▀▚▖▐▛▀▀▘▐▌ ▝▜▌▐▛▀▜▌",
            "▐▌   ▗▄█▄▖▝▚▄▞▘▐▌ ▐▌  █      ▐▌ ▐▌▐▌ ▐▌▐▙▄▄▖▐▌  ▐▌▐▌ ▐▌"
        };

        ConsoleColor[] colors =
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

    public static bool StayInArena(Team team)
    {
        while (true)
        {
            Console.WriteLine("Do you want to enter the arena?");
            Console.WriteLine("1) Enter the arena");
            Console.WriteLine("2) Display team status");
            Console.WriteLine("3) Leave");
            
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                return true;
            }
            else if (choice == 2)
            {
                //print team info here with PrintWarrior()
                foreach (Warrior w in team.warriors)
                {
                    w.PrintWarrior(w);
                }
            }
            else if (choice == 3)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
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
