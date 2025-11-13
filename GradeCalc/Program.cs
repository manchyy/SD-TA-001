class GradeCalc
{
    public static bool running = true;
    public static void Main(string [] args)
    {
        /*
         * write a mini program that will ask the user to type in a number
         * whatever number they type in, output the corresponding letter to the grade
         * if they output a number outside 0-100, output an error message
         */
        while (running)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Grade");
            Console.ResetColor();
            int input = Convert.ToInt32(Console.ReadLine());
            // string s = Console.ReadLine().ToUpper();
            GradeExample(input);
        }
    }

    public static void GradeExample(int input)
    {
        if ((input >= 85) && (input <= 100)) //85+
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A");
            Console.ResetColor();
        }
        else if ( (input <= 84) && (input >= 75)) //75-84
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("B");
            Console.ResetColor();
        }
        else if ((input <= 74) && (input >= 65)) //65-74
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("C"); 
            Console.ResetColor();
        }
        else if ((input <= 64) && (input >= 40)) // 40-64
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("D");
            Console.ResetColor();
        }
        else if ((input < 40) && (input >= 0)) // <40
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("F"); 
            Console.ResetColor();
        }
        // else if ((input < 0) && (input > 100)) //invalid
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Invalid input");
            Console.ResetColor();
        }
    }
}