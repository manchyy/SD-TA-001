using System.Runtime.CompilerServices;

namespace TimesheetAssignment;

public class Employee
{
    //Employee, Department, Mon, Tue, Wed, Thur, Fri
    public string Name;
    public string Department;
    public double MondayHours;
    public double TuesdayHours;
    public double WednesdayHours;
    public double ThursdayHours;
    public double FridayHours;
    public double TotalHours;

    public Employee(string name, string department, double monday, double tuesday, double wednesday,
        double thursday, double friday)
    {
        this.Name = name;
        this.Department = department;
        this.MondayHours = monday;
        this.TuesdayHours = tuesday;
        this.WednesdayHours = wednesday;
        this.ThursdayHours = thursday;
        this.FridayHours = friday;
        CalculateHours();
    }

    private void CalculateHours()
    {
        this.TotalHours = (this.MondayHours + this.TuesdayHours + this.WednesdayHours + this.ThursdayHours + this.FridayHours);
    }
}