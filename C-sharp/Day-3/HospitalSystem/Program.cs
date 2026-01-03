using System;

class Program2
{
    // static void Main()
    // {
    //     Console.WriteLine("Welcome to " + HospitalSystem.HospitalName);

    //     Console.Write("Enter Patient ID: ");
    //     int patientId = int.Parse(Console.ReadLine());

    //     Console.Write("Enter Patient Name: ");
    //     string patientName = Console.ReadLine();

    //     Console.Write("Enter Patient Age: ");
    //     int patientAge = int.Parse(Console.ReadLine());

    //     Patient patient = new Patient(patientId, patientName, patientAge);

    //     Console.Write("Enter Medical History: ");
    //     string history = Console.ReadLine();
    //     patient.SetMedicalHistory(history);

    //     Console.Write("Enter Doctor License Number: ");
    //     int license = int.Parse(Console.ReadLine());

    //     Console.Write("Enter Doctor Name: ");
    //     string doctorName = Console.ReadLine();

    //     Doctor doctor = new Doctor(license)
    //     {
    //         Name = doctorName
    //     };

    //     Appointment appointment = new Appointment();
    //     appointment.Schedule(patient, doctor, DateTime.Now);

    //     Diagnosis diagnosis = new Diagnosis();
    //     string condition = "Normal";
    //     string riskLevel;

    //     diagnosis.Evaluate(
    //         patientAge,
    //         ref condition,
    //         out riskLevel,
    //         90, 85, 95
    //     );

    //     Console.WriteLine($"Diagnosis Condition: {condition}");
    //     Console.WriteLine($"Risk Level: {riskLevel}");

    //     HospitalBill bill = new HospitalBill
    //     {
    //         ConsultationFee = 500,
    //         TestCharges = 1500,
    //         RoomCharges = 3000
    //     };

    //     double totalBill = bill.Total();
    //     Console.WriteLine("Total Bill Amount: " + totalBill);

    //     Console.Write("Enter Insurance Coverage Percentage: ");
    //     int coverage = int.Parse(Console.ReadLine());

    //     double finalAmount = InsuranceService.ApplyCoverage(totalBill, coverage);

    //     Console.WriteLine("Final Payable Amount: " + finalAmount);
    // }
    static void Main(string[] args)
    {
        Console.WriteLine(Cardiology.TotalDoctors);
        Cardiology c=new Cardiology(532957230);
        c.DisplayTotalDoctors();
        c.NonStaticMembers();
    }
}
