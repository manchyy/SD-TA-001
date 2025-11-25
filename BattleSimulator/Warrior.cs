namespace BattleSimulator;

public enum WarriorClass //enums to determine warrior class
{
    Heavy,
    Rogue,
    Ranged
}
public class Warrior
{
    public string Name;
    public double Health;
    public double Attack;
    public int Defense;
    public int Speed;
    public WarriorClass Type;
    
    public Warrior(string name, int health, int attack, int defense, int speed, WarriorClass type)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        Type = type;
    }
    
    public void AttackTarget(Warrior target)
    {
        double damage = Attack - (target.Defense / 4) ; //defense takes away 1/4 of damage
        if (damage < 1) //if defense too high, hit for at least 1hp
        {
            damage = 1;
        }
        
        double calculatedDamage = damage * DamageMultiplier(target);
        int damageDealt = (int)Math.Floor(calculatedDamage);
        target.Health -= damageDealt;
        
        Console.WriteLine($"{Name}({this.ClassEmoji()}) ⚔️ {target.Name}({target.ClassEmoji()})" +
                          $" for " +
                          $"{damage} 💥! " +
                          $"{target.Name} now has " +
                          $"❤️{target.Health}.");
    }

    public double DamageMultiplier(Warrior target)
    {
        //if advantge, return 1.5 damage multiplier
        if ((this.Type == WarriorClass.Heavy) && (target.Type == WarriorClass.Rogue))
        {
            return 1.5;
        }
        else if ((this.Type == WarriorClass.Rogue) && (target.Type == WarriorClass.Ranged))
        {
            return 1.5;
        }
        else if ((this.Type == WarriorClass.Ranged) && target.Type == WarriorClass.Heavy)
        {
            return 1.5;
        }
        else if((this.Type == target.Type)) //same type, return 1 (normal dmg)
        {
            return 1;
        }
        else //disadvantage (deal less dmg)
        {
            return 0.8;
        }
    }

    public string ClassEmoji()
    {
        if (this.Type == WarriorClass.Heavy)
        {
            return "🪓";
        }
        else if (this.Type == WarriorClass.Rogue)
        {
            return "🗡️";
        }
        else if (this.Type == WarriorClass.Ranged)
        {
            return "🏹";
        }

        return "";
    }
    
    public void printWarrior()
    {
        Console.WriteLine("---WARRIOR: " + this.Name+"---");
        Console.WriteLine("Health: " + this.Health);
        Console.WriteLine("Attack: " + this.Attack);
        Console.WriteLine("Defense: " + this.Defense);
        Console.WriteLine("Speed: " + this.Speed);
    }
}

public class HeavyWarrior : Warrior
{
    private static readonly Random r = new Random();
    //moderately high attack, health, and defense, but be quite slow
    public HeavyWarrior(string name) 
        : base(
            name, 
            health: r.Next(50,70),
            attack: r.Next(15,25), 
            defense: r.Next(10,30), 
            speed: r.Next(10,25),
            type: WarriorClass.Heavy
            )
    {}
}

public class RogueWarrior : Warrior
{
    private static readonly Random r = new Random();
    //very high attack and speed, but lower defense and health points
    public RogueWarrior(string name)
        : base(
            name,
            health: r.Next(20,30),
            attack: r.Next(5,15), 
            defense: r.Next(10,30), 
            speed: r.Next(40,60),
            type: WarriorClass.Rogue
        )
    {}
}
public class RangedWarrior : Warrior
{
    private static readonly Random r = new Random();
    //medium attack and speed, but virtually no defense and lower health points
    public RangedWarrior(string name)
        : base(
            name, 
            health: r.Next(15,30),
            attack: r.Next(5,12), 
            defense: r.Next(1,10), 
            speed: r.Next(20,50),
            type: WarriorClass.Ranged
        )
    {}
}