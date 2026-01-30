using System;

class MultiplicationTable
{
    static int[] GetTableRow(int n, int upto)
    {
        int[] result = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            result[i - 1] = n * i;
        }

        return result;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int upto = Convert.ToInt32(Console.ReadLine());

        int[] row = GetTableRow(n, upto);

        for (int i = 0; i < row.Length; i++)
        {
            Console.Write(row[i]);
            if (i < row.Length - 1)
                Console.Write(" ");
        }
    }
}
