public class Program
{
    public static void Main(string[] args)
    {
        List<Person> personsList = new List<Person>();
        personsList.Add(new Person("James", 40, "james@bond.com"));
        personsList.Add(new Person("Tony", 45, "tony@soprano.com"));
        personsList.Add(new Person("Hunter", 20, "h@t.com"));
        // PrintPersons(personsList);
        
        List<Car> carsList = new List<Car>();
        carsList.Add(new Car("Toyota", "GT86", 2014, "Silver", 2.0));

        //Task1
        Desktop myComputer = new Desktop("9800X3D","B650E-E","32GB","5070Ti");
        //Task2
        Desktop[] computers = new Desktop[2];
        computers[0] = myComputer;
        computers[1] = new Desktop("i9-9900k", "Z390", "16GB", "1080Ti");
        computers[1].GraphicsCard = "5090"; //GPU Replacement
        
        //Task3
        //PrintArray(computers);
        
        //Task4
        Desktop customComputer = CreateComputer();
        Console.WriteLine($"Custom computer built: {customComputer.Processor}, {customComputer.Motherboard}," +
                          $" {customComputer.Memory}, {customComputer.GraphicsCard}");
        
         //Practice adding to and viewing elements of the original array
         //Task5
         computers[0] = customComputer;
         Console.WriteLine("Spec update: ");
         computers[0].Print();

    }

    private static Desktop CreateComputer()
    {
        Console.WriteLine("Welcome to the PC Shop.");
        Console.Write("Please select your Processor: ");
        string processor =  Console.ReadLine();
        Console.Write("Please select your Motherboard: ");
        string motherboard =  Console.ReadLine();
        Console.Write("Please select your Memory: ");
        string memory =  Console.ReadLine();
        Console.Write("Please select your Graphics Card: ");
        string graphicscard =  Console.ReadLine();

        return new Desktop(processor, motherboard, memory, graphicscard);
    }
    private static void PrintArray(Desktop[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("PC #"+i+" Specifications:");
            Console.WriteLine(array[i].Processor);
            Console.WriteLine(array[i].Motherboard);
            Console.WriteLine(array[i].Memory);
            Console.WriteLine(array[i].GraphicsCard);
        }
    }

    private static void PrintPersons(List<Person> personsList)
    {
        foreach (var p in personsList)
        {
            Console.WriteLine("----");
            Console.WriteLine(p.Name+"'s info:");
            Console.WriteLine("Age: "+p.Age);
            Console.WriteLine("Email: "+p.Email);
        } 
    }
}

class Desktop
{
    public string Processor;
    public string Motherboard;
    public string Memory;
    public string GraphicsCard;
    public Desktop(string processor, string motherboard, string memory, string graphicsCard)
    {
        this.Processor = processor;
        this.Motherboard = motherboard;
        this.Memory = memory;
        this.GraphicsCard = graphicsCard;
    }

    public void Print()
    {
        Console.WriteLine("CPU: "+ Processor);
        Console.WriteLine("MOBO: "+ Motherboard);
        Console.WriteLine("RAM: "+ Memory);
        Console.WriteLine("GPU: "+ GraphicsCard);
    }
}

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public double EngineSize { get; set; }

    public Car(string make, string model, int year, string color, double engineSize)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
        this.Color = color;
        this.EngineSize = engineSize;
    }

    public void Start()
    {
        Console.WriteLine("BR-P-P-P-P");
        Thread.Sleep(2000);
        Console.WriteLine("WHMMMMRRRMMR");
    }
}

class Person
{
    
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }
    public Person()
    {
        this.Name = "N/A";
        this.Age = 0;
        this.Email = "N/A";
    }
}