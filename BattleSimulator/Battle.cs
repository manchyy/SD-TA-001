namespace BattleSimulator;

public class Battle
{
    public static void StartFight(Team teamA, Team teamB)
    {
        Console.WriteLine("\u001b[38;2;153;194;216m\nPlayer Team: " + teamA.TeamMembers() + "\u001b[0m");
        Thread.Sleep(1000);
        Console.WriteLine("\u001b[38;2;255;104;104mOrc Team: " + teamB.TeamMembers() + "\n\u001b[0m");
        Thread.Sleep(1000);
        //fight until a team gets wiped and there is a winner team
        int duelNumber=1;
        while ((teamA.GetTeamSize() > 0) && (teamB.GetTeamSize() > 0))
        {
            //pick one random fighter from each team
            Warrior fighter1 = teamA.GetRandomMember();
            Warrior fighter2 = teamB.GetRandomMember();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"DUEL #{duelNumber++}: {fighter1.Name} vs {fighter2.Name}");
            Console.ResetColor();
            Thread.Sleep(800);
            
            FighterDuel(fighter1, fighter2, teamA, teamB);
            Console.WriteLine(); //newline for formatting
        }

        if (teamA.GetTeamSize() > 0)
        {
            Console.WriteLine($"Player Won!");
        }
        else if (teamB.GetTeamSize() > 0)
        {
            Console.WriteLine($"Orcs Won!");
        }
        Thread.Sleep(1000);
    }
    
    public static void FighterDuel(Warrior warriorA, Warrior warriorB, Team teamA, Team teamB)
    {
        while (warriorA.Health > 0 && warriorB.Health > 0)
        {
            Thread.Sleep(1000);
            warriorA.AttackTarget(warriorB); //a attack b
            if (warriorB.Health <= 0)
            {
                FighterDies(warriorB, teamB);
                Thread.Sleep(1000);
                break;
            }
            Thread.Sleep(1000);
            warriorB.AttackTarget(warriorA); //b attack a
            if (warriorA.Health <= 0)
            {
                FighterDies(warriorA, teamA);
                Thread.Sleep(1000);
                break;
            }
        }
    }


    public static void FighterDies(Warrior warrior, Team team)
    {
        //if fighter dies, announce death
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{warrior.Name} Has Fallen!");
        Console.ResetColor();
        //remove from team
        team.RemoveMember(warrior);
    }
}