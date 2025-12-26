public abstract class EmployeeRecord
{
    public string EmployeeName { get; set; }
    public double[] WeeklyHours { get; set; }

    public abstract double GetMonthlyPay();
}

public class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public double MonthlyBonus { get; set; }

    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach (double h in WeeklyHours)
        {
            totalHours += h;
        }
        return (totalHours * HourlyRate) + MonthlyBonus;
    }
}

public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }

    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach (double h in WeeklyHours)
        {
            totalHours += h;
        }
        return totalHours * HourlyRate;
    }
}

public class PayrollManager
{
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

    public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }

    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (EmployeeRecord emp in records)
        {
            double count = 0;
            foreach (double h in emp.WeeklyHours)
            {
                if (h >= hoursThreshold)
                {
                    count+=h-hoursThreshold;
                }
            }

            if (count > 0)
            {
                result.Add(emp.EmployeeName, (int)count);
            }
        }

        return result;
    }

    public double CalculateAverageMonthlyPay()
    {
        if (PayrollBoard.Count == 0)
            return 0;

        double totalPay = 0;
        foreach (EmployeeRecord emp in PayrollBoard)
        {
            totalPay += emp.GetMonthlyPay(); 
        }

        return totalPay / PayrollBoard.Count;
    }
}