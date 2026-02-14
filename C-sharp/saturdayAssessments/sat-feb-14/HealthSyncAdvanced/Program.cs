using System;

namespace HealthSyncAdvancedBilling
{
    
    public abstract class Consultant
    {
        public string ConsultantId { get; set; }

        protected Consultant(string consultantId)
        {
            if (!ValidateConsultantId(consultantId))
            {
                Console.WriteLine("Invalid doctor id");
                Environment.Exit(0);   
            }

            ConsultantId = consultantId;
        }

       
        public abstract double CalculateGrossPayout();

        
        public virtual double CalculateTDS(double grossAmount)
        {
            if (grossAmount <= 5000)
                return 0.05; 
            else
                return 0.15;  
        }

        
        public void DisplayPayout()
        {
            double gross = CalculateGrossPayout();
            double tdsRate = CalculateTDS(gross);
            double taxAmount = gross * tdsRate;
            double net = gross - taxAmount;

            Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {tdsRate * 100}% | Net Payout: {net:F2}");
        }

        
        private bool ValidateConsultantId(string id)
        {
            if (id.Length != 6)
                return false;

            if (!id.StartsWith("DR"))
                return false;

            string numericPart = id.Substring(2);

            return int.TryParse(numericPart, out _);
        }
    }


    public class InHouseConsultant : Consultant
    {
        public double MonthlyStipend { get; set; }

        public InHouseConsultant(string id, double stipend)
            : base(id)
        {
            MonthlyStipend = stipend;
        }

        public override double CalculateGrossPayout()
        {
            double allowance = 2000;
            double bonus = 1000;
            return MonthlyStipend + allowance + bonus;
        }
    }

 
    public class VisitingConsultant : Consultant
    {
        public int ConsultationsCount { get; set; }
        public double RatePerVisit { get; set; }

        public VisitingConsultant(string id, int count, double rate)
            : base(id)
        {
            ConsultationsCount = count;
            RatePerVisit = rate;
        }

        public override double CalculateGrossPayout()
        {
            return ConsultationsCount * RatePerVisit;
        }

        public override double CalculateTDS(double grossAmount)
        {
            return 0.10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HealthSync Advanced Billing System");
            Console.WriteLine("-----------------------------------");

          
            Consultant inHouse = new InHouseConsultant("DR2001", 10000);
            inHouse.DisplayPayout();

           
            Consultant visiting = new VisitingConsultant("DR8005", 10, 600);
            visiting.DisplayPayout();

            
            Consultant invalid = new InHouseConsultant("MD1001", 8000);

            Console.ReadLine();
        }
    }
}
