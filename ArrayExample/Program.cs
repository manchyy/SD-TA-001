class ArrayExample
{
    public static void Main(string [] args)
    {
        string[] names = new string[] {"Bob", "Alice"};
        int[] scores = new int[] {83, 42};
        double[] prices = new double[] {4.99, 9.99};
        
        // PrintArray(names);
        // PrintArray(scores);
        // PrintArray(prices);
        FillUp();
    }

    private static void FillUp()
    {
        Console.Write("How many names do you want to input?: ");
        int nameAmount = Int32.Parse(Console.ReadLine());
        string[] names = new string[nameAmount];
        
        for (int i = 0; i < nameAmount; i++)
        {
            Console.Write("Enter name "+(i+1)+": ");
            names[i] = Console.ReadLine();
        }
        Array.Sort(names); //sort alphabetically
        PrintArray(names);
    }
    private static void PrintArray<T>(T[] array)
    {
        Console.WriteLine("Printing Array:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Index["+i+"]: " + array[i]);
        }
    }
}