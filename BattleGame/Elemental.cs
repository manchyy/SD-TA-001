namespace BattleGame;

public class Elemental
{
    public string Nickname;
    public int HP; //health
    public int AP; //attack
    public int DP; //defence
    public string Type;
    public string Weakness;

    public Elemental(string name, int hp, int ap, int dp, string type)
    {
        Nickname = name;
        HP = hp; //health
        AP = ap; //attack
        DP = dp; //defence
        Type = type; //element type
        InitWeakness();
    }

    private void InitWeakness()
    {
        if (this.Type == "Fire")
        {
            this.Weakness = "Water";
        }
        else if (this.Type == "Water")
        {
            this.Weakness = "Grass";
        }
        else if (this.Type == "Grass")
        {
            this.Weakness = "Fire";
        }
    }

    private bool IsWeak(string type)
    {
        if (this.Weakness == type)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeAttack(Elemental attacker)
    {
        Thread.Sleep(2000);
        if (this.HP > 0)
        {
            if (this.IsWeak(attacker.Type))
            {
                if (this.DP > 0) //go through defence first
                {
                    Console.WriteLine();
                    this.DP -= (attacker.AP * 2);
                    Console.WriteLine($"{attacker.Nickname} 👊 {this.Nickname} for {attacker.AP * 2}🛡️.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Critical Hit because {this.Type} is weak to {attacker.Type}.");
                    Console.ResetColor();
                    Console.WriteLine($"{this.Nickname} now has {this.HP}❤️ {this.DP}🛡️ left.");
                }
                else //if defence 0, go through health
                {
                    this.DP = 0;
                    this.HP -= (attacker.AP * 2);
                    Console.WriteLine();
                    Console.WriteLine($"{attacker.Nickname} 👊 {this.Nickname} for {attacker.AP * 2}❤️.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Critical Hit because {this.Type} is weak to {attacker.Type}.");
                    Console.ResetColor();
                    Console.WriteLine($"{this.Nickname} now has {this.HP}❤️ {this.DP}🛡️ left.");
                }
            }
            else
            {
                if (this.DP > 0)
                {
                    this.DP -= (attacker.AP);
                    Console.WriteLine();
                    Console.WriteLine($"{attacker.Nickname} 👊 {this.Nickname} for {attacker.AP}🛡️️.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    Console.WriteLine($"{this.Nickname} now has {this.HP}❤️ {this.DP}🛡️ left.");
                }
                else // if dp 0
                {
                    this.HP -= (attacker.AP);
                    Console.WriteLine();   
                    Console.WriteLine($"{attacker.Nickname} 👊 {this.Nickname} for {attacker.AP}❤️.");
                    Console.WriteLine($"{this.Nickname} now has {this.HP}❤️ {this.DP}🛡️ left.");
                }
            }
        }
        if ((this.HP <= 0) || (attacker.AP <= 0))
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----");
            Console.WriteLine($"RIP {this.Nickname} ⚰️");
            Console.WriteLine("-----");
            Console.ResetColor();
        }
    }
}