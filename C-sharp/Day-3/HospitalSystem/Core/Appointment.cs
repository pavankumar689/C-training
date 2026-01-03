class Appointment
{
    public void Schedule(Patient p, Doctor d)
    {
        Console.WriteLine(
            $"Appointment scheduled for patient {p.Name} with doctor {d.Name}");
    }

    public void Schedule(
        Patient p,
        Doctor d,
        DateTime date,
        string mode = "Offline")
    {
        Console.WriteLine(
            $"Appointment scheduled for patient {p.Name} with doctor {d.Name}");
        Console.WriteLine(
            $"Date: {date:dd MMM yyyy}, Mode: {mode}");
    }
}
