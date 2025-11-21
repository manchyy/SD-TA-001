public class Program
{
    static void Main(string[] args)
    {
        string[] jokes = ReadFile("Resources/Jokes.txt");
        string[] compliments = ReadFile("Resources/Compliments.txt");
        string[] facts = ReadFile("Resources/Facts.txt");

        while (true)
        {
            Console.WriteLine("1) Hear a Joke");
            Console.WriteLine("2) Hear a Compliment");
            Console.WriteLine("3) Hear a Random Fact");
            Console.WriteLine("4) Exit the Program");
            Random random = new Random();
            int input = int.Parse(Console.ReadLine());
            int randomIndex = random.Next(0, 9); //all 3 arrays are 10 long
            if (input == 1) //joke
            {
                Console.Clear();
                Console.WriteLine(jokes[randomIndex]);
            }
            else if (input == 2) //compliment
            {
                Console.Clear();
                Console.WriteLine(compliments[randomIndex]);
            }
            else if (input == 3) //random fact
            {
                Console.Clear();
                Console.WriteLine(facts[randomIndex]);
            }
            else if (input == 4) //exit
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }
        }
    }

    public static string[] ReadFile(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
    
    public static void PrintJokes(string[] contents)
    {
        for (int i = 0; i < contents.Length; i++)
        {
            Console.WriteLine(contents[i]);
        }
    }
}