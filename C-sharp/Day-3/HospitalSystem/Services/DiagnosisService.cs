class Diagnosis
{
    public void Evaluate(in int age, ref string condition,out string riskLevel,params int[] testScores)
    {
        int total = 0;
        foreach (int score in testScores)
        {
            total += score;
        }

        static bool IsCritical(int sum, int patientAge)
        {
            return sum > 250 || patientAge > 60;
        }

        if (IsCritical(total, age))
        {
            condition = "Serious";
            riskLevel = "High";
        }
        else
        {
            riskLevel = "Moderate";
        }
    }
}
