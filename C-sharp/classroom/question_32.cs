using System.Globalization;
using System.Text;

class Mahirl_and_Alphabets
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the first string: ");
        string s1=Console.ReadLine().ToLower();
        Console.Write("Enter the second string: ");
        string s2=Console.ReadLine().ToLower();
        StringBuilder sb=new StringBuilder(s1);
        for(int i = 0; i < s2.Length; i++)
        {
            if (s2[i] != 'a' && s2[i] != 'e' && s2[i] != 'i' && s2[i] != 'o' && s2[i] != 'u')
            {
                for(int j = 0; j < sb.Length; j++)
                {
                    if (sb[j] == s2[i])
                    {
                        sb.Remove(j,1);
                        j--;
                    }
                }
            }
        }
        for(int i = 1; i < sb.Length; i++)
        {
            if (sb[i] == sb[i - 1])
            {
                sb.Remove(i,1);
                i--;
            }
        }
        Console.WriteLine(sb);
    }
}