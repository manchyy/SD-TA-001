using BattleSimulator;

public class Program
{
    public static void Main(string[] args)
    {
        Utils.PrintMenu();
        Team playerTeam  = new Team();
        // FillPlayerTeam(playerTeam); 
        DebugTeam(playerTeam); //debug mock team
        Team enemyTeam = new Team();
        FillEnemyTeam(enemyTeam, playerTeam);
        
        //debug team size and members print
        // playerTeam.PrintTeam();
        // enemyTeam.PrintTeam();
        
        
        Battle.StartFight(playerTeam, enemyTeam);
    }

    public static void FillEnemyTeam(Team enemyTeam, Team playerTeam)
    {
        //generate same amount of enemies based on player team
        Dictionary<int, string> WarriorType = new Dictionary<int, string>();
        WarriorType.Add(0, "Heavy");
        WarriorType.Add(1, "Rogue");
        WarriorType.Add(2, "Ranged");
        for (int i = 0; i < playerTeam.GetTeamSize(); i++)
        {
            Random r = new Random();
            if (r.Next(0,2) == 0) //heavy
            {
                enemyTeam.AddMember(new HeavyWarrior(Utils.GenerateName()));
            }
            else if (r.Next(2) == 1) //rogue
            {
                enemyTeam.AddMember(new RogueWarrior(Utils.GenerateName()));
            }
            else if (r.Next(2) == 2) //ranged
            {
                enemyTeam.AddMember(new RangedWarrior(Utils.GenerateName()));
            }
        }
        
    }
    public static void FillPlayerTeam(Team team)
    {
        Console.Write("How many characters would you want? (max 5): ");
        int warriorCount = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < warriorCount; i++)
        {
            Console.Write("Enter Character name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Select Type. \n" +
                              "1) Heavy \n" +
                              "2) Rogue \n" +
                              "3) Ranged");
            int type = Int32.Parse(Console.ReadLine());
            if (type == 1) //heavy
            {
                team.AddMember(new HeavyWarrior(name));
            }
            else if (type == 2) //rogue
            {
                team.AddMember(new RogueWarrior(name));
            }
            else if (type == 3) //ranged
            {
                team.AddMember(new RangedWarrior(name));
            }
            Console.Clear();
        }
    }

    public static void DebugTeam(Team team)
    {
        Warrior warrior1 = new HeavyWarrior("Tony");
        Warrior warrior2 = new RogueWarrior("Paulie");
        Warrior warrior3 = new RangedWarrior("Christopher");
        team.AddMember(warrior1);
        team.AddMember(warrior2);
        team.AddMember(warrior3);
    }
}