using TimesheetAssignment;

/*
          create a programme which calculates the total workforce effort for the week by department

           Employee, Department, Mon, Tue, Wed, Thur, Fri
           John Doe, Management, 8, 7.5, 8, 6, 5

            flow:
            1) Create an Employee object with fields - Name,Department,MonH,TueH,WedH,ThuH,FriH,TotalH
            2) Read the .csv file and fill a list of Employee objects
            3) Split Employees by their department into separate arrays (or lists)
            4) Sort employees by their total hours (highest - lowest)
            5) Calculate avg hours worked, total hours worked, and pick list[0] for total time worked
*/

public class Program
{
    static void Main(string[] args)
    {
        string filePath = "Resources/SD-TA-001-A_OrganisationWeeklyTimesheet.csv";
        Employee[] employees = new Employee[GetLineCount(filePath)];
        
        // PrintEmployees(data);
    }
    public static string[] ReadFile(string filePath)
    {
        //maybe return an array of instantiated Employee objects?
        return File.ReadAllLines(filePath);
    }
    
    public static void PrintEmployees(string[] contents)
    {
        for (int i = 1; i < contents.Length; i++)
        {
            Console.WriteLine(contents[i]);
        }
    }

    public static int GetLineCount(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines.Length-1;
    }
}