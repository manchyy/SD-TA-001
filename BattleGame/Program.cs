using BattleGame;

public class Program
{
    public static void Main(string[] args)
    {
        Elemental[] fighters = new Elemental[2];
        Console.WriteLine("");
        ShowSplash();
        Console.Write("Enter first fighter's name: ");
        string name1 = Console.ReadLine();
        Console.Write("Enter first fighter's ❤️(int): ");
        int hp1 = Int32.Parse(Console.ReadLine());
        Console.Write("Enter first fighter's 👊(int): ");
        int ap1 = Int32.Parse(Console.ReadLine());
        Console.Write("Enter first fighter's 🛡(int): ");
        int dp1= Int32.Parse(Console.ReadLine());
        Console.Write("Enter first fighter's Type (Fire, Water, Grass): ");
        string type1 = Console.ReadLine();
        fighters[0] = new Elemental(name1,hp1,ap1,dp1,type1);
        // fighters[0] = new Elemental("Tony", 10, 2, 10, "Fire");
        
        Console.Write("Enter second fighter's name: ");
        string name2 = Console.ReadLine();
        Console.Write("Enter second fighter's ❤️(int): ");
        int hp2 = Int32.Parse(Console.ReadLine());
        Console.Write("Enter second fighter's 👊(int): ");
        int ap2 = Int32.Parse(Console.ReadLine());
        Console.Write("Enter second fighter's 🛡️(int): ");
        int dp2= Int32.Parse(Console.ReadLine());
        Console.Write("Enter second fighter's Type (Fire, Water, Grass): ");
        string type2 = Console.ReadLine();
        fighters[1] = new Elemental(name2,hp2,ap2,dp2,type2);
        // fighters[1] = new Elemental("Paulie", 10, 2, 10, "Water");
        
        while ((fighters[0].HP > 0) && (fighters[1].HP > 0))
        {
            InitiateAttack(fighters);
        }
    }

    public static void ShowSplash()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        // Set text color to #F2AA00 (242,170,0)
        Console.Write("\u001b[38;2;242;170;0m");
        // Console.ForegroundColor = ConsoleColor.White;
        string art = @"
███████ ██    ██ ██████   ██████  
██      ██    ██ ██   ██ ██       
█████   ██    ██ ██████  ██   ███ 
██      ██    ██ ██   ██ ██    ██ 
███████  ██████  ██████   ██████  
ELEMENTALUNKNOWN's Battlegrounds";
        Console.WriteLine(art);
        Console.ResetColor();
    }
    public static void InitiateAttack(Elemental[] fighters)
    {
        Random random = new Random();
        int attacker = random.Next(fighters.Length);
        if (attacker == 0)
        {
            SimulateAttack(fighters[0], fighters[1]);
        }
        else
        {
            SimulateAttack(fighters[1], fighters[0]);
        }
    }
    
    public static void SimulateAttack(Elemental attacker, Elemental defender)
    {
        defender.TakeAttack(attacker);
    }
}