class Patient
{
    public readonly int PatientId;

    public string? Name { get; set; }
    public int Age { get; set; }

    private string? medicalHistory;

    public Patient(int patientId, string name, int age)
    {
        PatientId = patientId;
        Name = name;
        Age = age;
    }

    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }

    public string? GetMedicalHistory()
    {
        return medicalHistory;
    }
}
