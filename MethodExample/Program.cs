class MethodExample
{
    public static void Main(string [] args)
    {
        PrintHello();
        Console.WriteLine("TwoSum: "+TwoSum(2, 2));
        Console.WriteLine(StringMethod("12345", "12345"));
    }

    private static void PrintHello()
    {
        Console.WriteLine("Hello, World!");
    }

    private static int TwoSum(int a, int b)
    {
        return a + b;
    }

    public static string? StringMethod(string a, string b)
    {
        //return the longer of two
        //if equal return two joined together
        if (a.Length > b.Length)
        {
            return a;
        }
        else if (b.Length > a.Length)
        {
            return b;
        }
        else if (a.Length == b.Length)
        {
            return a + b;
        }
        else
        {
            return "error";
        }
    }
}