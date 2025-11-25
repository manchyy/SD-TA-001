namespace BattleSimulator;

public class Team
{
    public List<Warrior> warriors = new List<Warrior>();

    public string TeamMembers()
    {
        return string.Join(", ", warriors.Select(w => w.Name+("("+w.ClassEmoji()+")")));
    }
    public void AddMember(Warrior warrior)
    {
        warriors.Add(warrior);
    }

    public void RemoveMember(Warrior warrior)
    {
        warriors.Remove(warrior);
    }
    
 
    public Warrior GetRandomMember()
    {
        int random =  new Random().Next(0, warriors.Count);
        return warriors[random];
    }
    
    public int GetTeamSize()
    {
        return warriors.Count;
    }

    public void PrintTeam()
    {
        Console.WriteLine($"Team Size: {GetTeamSize()}");
        foreach (var warrior in warriors)
        {
            Console.WriteLine($"Name: {warrior.Name}");
        }
    }
}