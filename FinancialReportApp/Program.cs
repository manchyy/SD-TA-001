//global vars
bool running = true; //main loop var
double salary = 0;
double tax = 0;
double taxCredits = 0;
Dictionary<string, double> expensesList = new Dictionary<string, double>();
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Welcome to the Personal Income Calculator.");
Console.ResetColor();
while (running)
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Please select one from the following: ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1) Input Salary");
    Console.WriteLine("2) Extra Expenses");
    Console.WriteLine("3) Display Final Report");
    Console.WriteLine("4) Save Final Report");
    Console.WriteLine("5) Quit");
    Console.ResetColor();
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please select the following: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Before Tax\n" +
                              "2. After Tax\n");
            Console.ResetColor();
            int salaryChoice = Convert.ToInt32(Console.ReadLine());
            switch (salaryChoice)
            {
                case 1: //before tax
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter how much you're getting paid: ");
                    Console.ResetColor();
                    salary = Convert.ToDouble(Console.ReadLine());
                    salary = YearlyAdjust(salary);
                    
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter your tax credits: ");
                    Console.ResetColor();
                    taxCredits = Convert.ToDouble(Console.ReadLine());
                    
                    tax = CalculateTax(salary, taxCredits);
                    Console.Clear();
                    break;
                case 2: //after tax
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter your salary: ");
                    Console.ResetColor();
                    salary = Convert.ToDouble(Console.ReadLine());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter your Tax: ");
                    Console.ResetColor();
                    tax = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                    break;
            }
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Please specify the name of expense: ");
            string? expenseName = Console.ReadLine();
            Console.WriteLine("Please specify the cost of expense: ");
            double expenseCost = Convert.ToDouble(Console.ReadLine());
            if (!string.IsNullOrEmpty(expenseName))
            {
                expensesList.Add(expenseName, expenseCost);
            }
            Console.Clear();
            break;
        case 3:
            Console.Clear();
            DisplayReport(salary, tax, taxCredits, expensesList);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press ENTER to continue..");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Please specify file's name");
            string? fileName = Console.ReadLine();
            fileName += ".txt";
            string? textToSave = ($"Gross Income: €{salary}\n" +
                                  $"Tax Credits: €{taxCredits}\n" +
                                  $"Tax Payable: €{tax}\n" +
                                  $"Net Income: €{salary-tax}\n" +
                                  $"Total Expenses: €{CalculateExpenses(expensesList)}\n" +
                                  $"Final Balance: €{salary-tax-CalculateExpenses(expensesList)}\n" );
            
            Console.WriteLine("FILENAME IS: " + fileName);
            if (fileName == ".txt") //if filename is blank, default to something
            {
                fileName = "finalReport.txt";
            }
            SaveFile(fileName, textToSave);
            Console.WriteLine("Report "+fileName+" saved!");
            break;
        case 5:
            running = false;
            //Environment.Exit(0);
            break;
        default:
            Console.Clear();
            break;

    }
}
static void SaveFile(string? fileName, string? textToSave)
{
    if (!string.IsNullOrEmpty(fileName))
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.Write(textToSave);
        }
    }
    else
    {
        Console.WriteLine("Invalid filename.");
    }
}

static double CalculateTax(double income, double taxcredit)
{
    double standardTaxRate= 0.2;
    double higherTaxRate = 0.4;
    double taxBand = 44000; //taxed at 20%, if above this, tax remainder on 40%
    double totalTax;
    //apply the standard rate of 20% in your rate band
    //apply higher rate of 40% to any income above the band
    //add the two amounts above together
    //deduct the amount of tax credits from this total

    if (income <= taxBand)
    {
        totalTax = income * standardTaxRate;
    }
    else
    {
        double higherBand = income - 44000;
        double standardTax = taxBand * standardTaxRate;
        double higherTax = higherBand * higherTaxRate;
        totalTax = standardTax + higherTax;
    }

    totalTax = totalTax - taxcredit;
    
    //Console.WriteLine("TAX FROM: "+income+" IS: "+totalTax);
    return totalTax;
}

static void DisplayReport(double salary, double tax, double taxCredits, Dictionary<string, double> expenseList)
{
    double totalExpenses = CalculateExpenses(expenseList);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("=FINAL REPORT=");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Gross Income: €"+salary);
    Console.WriteLine("Tax Credits: €"+taxCredits);
    Console.WriteLine("Tax Payable: €"+tax);
    Console.WriteLine("Net Income: €"+(salary-tax));
    Console.WriteLine("Total Expenses: €"+totalExpenses);
    Console.WriteLine("Final Balance: €"+(salary-tax-totalExpenses));
    Console.ResetColor();
}

static double CalculateExpenses(Dictionary<string, double> expenseList)
{
    double totalExpenses = 0;
    foreach (var expense in expenseList)
    {
        totalExpenses += expense.Value;
    }

    return totalExpenses;
}

static double YearlyAdjust(double income)
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Is your salary paid: ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1. Weekly\n" +
                      "2. Monthly\n" +
                      "3. Yearly");
    Console.ResetColor();
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            //weekly pay; 54 weeks per year
            income = (income * 54);
            break;
        case 2:
            //monthly pay
            income = (income * 12);
            break;
        case 3:
            //yearly pay - do nothing
            break;
        default:
            Console.WriteLine("N/A, assuming yearly");
            break;
    }

    return income;
}