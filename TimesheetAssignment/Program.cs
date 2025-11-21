using TimesheetAssignment;
public class Program
{
    static void Main(string[] args)
    {
        string filePath = "Resources/SD-TA-001-A_OrganisationWeeklyTimesheet.csv";
        string[] data = File.ReadAllLines(filePath);
        List<Employee> employees = new List<Employee>();
        for (int i = 1; i < data.Length; i++) 
        {
            employees.Add(Employee.FromCsv(data[i]));
        }
        
        //probably not the best solution, maybe should use a dictionary ;)
        List<Employee> financeEmployees = new List<Employee>();
        List<Employee> marketingEmployees = new List<Employee>();
        List<Employee> hrEmployees = new List<Employee>();
        List<Employee> engineeringEmployees = new List<Employee>();
        List<Employee> managementEmployees = new List<Employee>();
        //group employees by their department
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].Department == "Finance")
            {
                financeEmployees.Add(employees[i]);
            }
            else if (employees[i].Department == "Marketing")
            {
                marketingEmployees.Add(employees[i]);
            }
            else if (employees[i].Department == "Human Resources")
            {
                hrEmployees.Add(employees[i]);
            }
            else if (employees[i].Department == "Engineering")
            {
                engineeringEmployees.Add(employees[i]);
            }
            else if (employees[i].Department == "Management")
            {
                managementEmployees.Add(employees[i]);
            }
        }
        //sort employees by the total hours (desc)
        financeEmployees = SortListDesc(financeEmployees);
        marketingEmployees = SortListDesc(marketingEmployees);
        hrEmployees = SortListDesc(hrEmployees);
        engineeringEmployees = SortListDesc(engineeringEmployees);
        managementEmployees = SortListDesc(managementEmployees);
        
        // Console.WriteLine(DeptSummary(financeEmployees));
        // Console.WriteLine(DeptSummary(marketingEmployees));
        // Console.WriteLine(DeptSummary(hrEmployees));
        // Console.WriteLine(DeptSummary(engineeringEmployees));
        // Console.WriteLine(DeptSummary(managementEmployees));
        
        WriteToFile("DepartmentResults.txt", financeEmployees, marketingEmployees, hrEmployees, engineeringEmployees, managementEmployees);
    }

    public static string DeptSummary(List<Employee> employees)
    {
        string result = $"Department - {employees[0].Department}\n" +
                        $"Employees assigned: {employees.Count}\n" +
                        $"Total Hours Worked: {CalculateTotalHours(employees)}\n" +
                        $"Average Hours Worked: {CalculateAverageHours(employees)}\n" +
                        $"Top Employee: {employees[0].Name} with {employees[0].TotalHours}hrs worked\n";
        return result;
    }

    public static void WriteToFile(string fileName, List<Employee> finance, List<Employee> marketing, List<Employee> hr,
        List<Employee> engineering, List<Employee> management)
    {
        string[] summaryCollection = new string [5];
        summaryCollection[0] = DeptSummary(finance);
        summaryCollection[1] = DeptSummary(marketing);
        summaryCollection[2] = DeptSummary(hr);
        summaryCollection[3] = DeptSummary(engineering);
        summaryCollection[4] = DeptSummary(management);
        
        File.WriteAllLines(fileName, summaryCollection);
    }

    public static double CalculateTotalHours(List<Employee> employees)
    {
        double totalHours = 0;
        for (int i = 0; i < employees.Count; i++)
        {
            totalHours += employees[i].TotalHours;
        }
        return totalHours;
    }
    
    public static double CalculateAverageHours(List<Employee> employees)
    {
        double totalHours = 0;
        for (int i = 0; i < employees.Count; i++)
        {
            totalHours += employees[i].TotalHours;
        }
        return (totalHours /  employees.Count);
    }
    
    public static void PrintEmployees(string[] contents)
    {
        for (int i = 1; i < contents.Length; i++)
        {
            Console.WriteLine(contents[i]);
        }
    }

    public static List<Employee> SortListDesc(List<Employee> employees)
    {
        return employees =  employees.OrderByDescending(employee => employee.TotalHours).ToList();
    }
    
}