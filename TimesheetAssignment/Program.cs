using TimesheetAssignment;
public class Program
{
    static void Main(string[] args)
    {
        string filePath = "Resources/SD-TA-001-A_OrganisationWeeklyTimesheet.csv";
        var employees = LoadEmployeesFromCsv(filePath); //load csv into list
        var employeeListArray = GroupEmployeesByDept(employees); //group employees by their department
        SortAllDepts(employeeListArray); //sort by total hours (desc)
        WriteToFile("DepartmentResults.txt", employeeListArray); //write to file
    }
    public static void SortAllDepts(List<Employee>[] employeeListArray)
    {
        for (int i = 0; i < employeeListArray.Length; i++)
        {
            employeeListArray[i] = SortListDesc(employeeListArray[i]);
        }
    }
    public static List<Employee> LoadEmployeesFromCsv(string filePath)
    {
        string[] data = File.ReadAllLines(filePath);
        List<Employee> employees = new List<Employee>();
        for (int i = 1; i < data.Length; i++) //fill employees list from csv
        {
            employees.Add(Employee.FromCsv(data[i]));
        }

        return employees;
    }
    public static List<Employee>[] GroupEmployeesByDept(List<Employee> employees)
    { 
        //pass entire list of employees, return a sorted array of lists (departments)
        List<Employee>[] employeeListArray = new List<Employee>[5] //hardcoded amount for 5 departments
        {
            new List<Employee>(), //0 - finance
            new List<Employee>(), //1 - marketing
            new List<Employee>(), //2 - hr
            new List<Employee>(), //3 - engineering
            new List<Employee>()  //4 - management
        };
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].Department == "Finance")
            {
                employeeListArray[0].Add(employees[i]);
            }
            else if (employees[i].Department == "Marketing")
            {
                employeeListArray[1].Add(employees[i]);
            }
            else if (employees[i].Department == "Human Resources")
            {
                employeeListArray[2].Add(employees[i]);
            }
            else if (employees[i].Department == "Engineering")
            {
                employeeListArray[3].Add(employees[i]);
            }
            else if (employees[i].Department == "Management")
            {
                employeeListArray[4].Add(employees[i]);
            }
        }
        return employeeListArray;
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
    public static void WriteToFile(string fileName, List<Employee>[] inputArray)
    {
        string[] summaryCollection = new string [5];
        for (int i = 0; i < inputArray.Length; i++)
        {
            summaryCollection[i] = DeptSummary(inputArray[i]);
        }
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
    public static List<Employee> SortListDesc(List<Employee> employees)
    {
        return employees = employees.OrderByDescending(employee => employee.TotalHours).ToList();
    }
}