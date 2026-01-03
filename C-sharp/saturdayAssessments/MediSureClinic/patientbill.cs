class PatientBill
{
    public string? BillId { get; set; }
    public string? PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalPayable { get; set; }

    static PatientBill LastBill;
    static bool HasLastBill = false;

    public static void CreateBill()
    {
        Console.Write("Enter Bill Id: ");
        string billId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(billId))
        {
            Console.WriteLine("BillId cannot be empty.\n");
            return;
        }

        Console.Write("Enter Patient Name: ");
        string patientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string insuranceInput = Console.ReadLine();
        bool hasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

        Console.Write("Enter Consultation Fee: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
        {
            Console.WriteLine("Consultation fee must be greater than zero.\n");
            return;
        }

        Console.Write("Enter Lab Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
        {
            Console.WriteLine("Lab charges must be zero or positive.\n");
            return;
        }

        Console.Write("Enter Medicine Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
        {
            Console.WriteLine("Medicine charges must be zero or positive.\n");
            return;
        }

        PatientBill bill = new PatientBill
        {
            BillId = billId,
            PatientName = patientName,
            HasInsurance = hasInsurance,
            ConsultationFee = consultationFee,
            LabCharges = labCharges,
            MedicineCharges = medicineCharges
        };

        bill.GrossAmount = bill.ConsultationFee + bill.LabCharges + bill.MedicineCharges;
        bill.DiscountAmount = bill.HasInsurance ? bill.GrossAmount * 0.10m : 0;
        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
        Console.WriteLine("------------------------------------------------------------\n");
    }

    public static void ViewLastBill()
    {
        if (!HasLastBill)
        {
            Console.WriteLine("No bill available. Please create a new bill first.\n");
            return;
        }

        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine($"BillId: {LastBill.BillId}");
        Console.WriteLine($"Patient: {LastBill.PatientName}");
        Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
        Console.WriteLine("--------------------------------\n");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.\n");
    }
}
