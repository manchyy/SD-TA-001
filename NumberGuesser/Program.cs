class NumberGuesser
{
    public static void Main()
    {
        Guesser();
    }
    
    private static void Guesser()
    {
        int guessCount = 3;
        int lives = 3;
        int randomNumber = new Random().Next(1, 10);
        
        for (int i = 0; i < guessCount; i++)
        {
            Console.WriteLine("Guess a number 1-10");
            int guess =  int.Parse(Console.ReadLine());
            if (guess == randomNumber)
            {
                Console.WriteLine("You guessed the number!");
                break;
            }
            else if (guess > randomNumber)
            {
                lives--;
                Console.WriteLine("Wrong Number, It is lower. You have "+lives+" lives left.");
            }
            else if (guess < randomNumber)
            {
                lives--;
                Console.WriteLine("Wrong Number, It is higher. You have "+lives+" lives left.");
            }
        }
        Console.WriteLine("Correct number was: "+randomNumber);
    }
}