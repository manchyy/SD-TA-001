using BattleSimulator;

public class Program
{
    public static void Main(string[] args)
    {
        Utils.PrintMenu();
        Team playerTeam  = new Team();
        FillPlayerTeam(playerTeam); 
        // DebugTeam(playerTeam); //debug mock team

        int rounds = 0;
        while (playerTeam.GetTeamSize() > 0)
        {
            if (!Utils.StayInArena(playerTeam))
            {
                Console.WriteLine($"You lasted {rounds} rounds.");
                return; //exit
            }
            
            Team enemyTeam = new Team();
            FillEnemyTeam(enemyTeam, playerTeam);
            
            Battle.StartFight(playerTeam, enemyTeam);
            rounds++;
            if (playerTeam.GetTeamSize() == 0)
            {
                Console.WriteLine($"You have fallen. You lasted {rounds} rounds.");
            }
        }
    }

    public static void FillEnemyTeam(Team enemyTeam, Team playerTeam)
    {
        //generate same amount of enemies based on player team
        Dictionary<int, string> WarriorType = new Dictionary<int, string>();
        WarriorType.Add(1, "Heavy");
        WarriorType.Add(2, "Rogue");
        WarriorType.Add(3, "Ranged");
        Random r = new Random();
        for (int i = 0; i < r.Next(1,5); i++)
        {
            int choice = r.Next(1, 4);
            if (choice == 1) //heavy
            {
                enemyTeam.AddMember(new HeavyWarrior(Utils.GenerateName()));
            }
            else if (choice == 2) //rogue
            {
                enemyTeam.AddMember(new RogueWarrior(Utils.GenerateName()));
            }
            else if (choice == 3) //ranged
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