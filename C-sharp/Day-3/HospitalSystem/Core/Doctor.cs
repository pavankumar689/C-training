class Doctor
{
    public static int TotalDoctors;

    public readonly int LicenseNumber;

    static Doctor()
    {
        TotalDoctors = 0;  
    }
    public Doctor(int licenseNumber)
    {
        LicenseNumber = licenseNumber;
        TotalDoctors++;               
    }
    public string? Name { get; set; }

    public Doctor(string name)
    {
        Name = name;
    }
}
