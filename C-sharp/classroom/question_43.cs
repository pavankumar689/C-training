using System;

class SumOfPositiveIntegers
{
    static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int n in nums)
        {
            if (n == 0)
                break;

            if (n < 0)
                continue;

            sum += n;
        }

        return sum;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
            nums[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(SumPositiveUntilZero(nums));
    }
}
