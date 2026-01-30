using System.Text;

class Inventory_Name_Cleanup
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the string: ");
        string s=Console.ReadLine().Trim();
        StringBuilder sb=new StringBuilder(s);
        for(int i = 1; i < sb.Length; i++)
        {
            if (sb[i - 1] == sb[i])
            {
                sb.Remove(i,1);
                i--;
            }
        }
        StringBuilder finalstring=new StringBuilder();
        bool isspace=true;
        for(int i = 0; i < sb.Length; i++)
        {
            if (char.IsWhiteSpace(sb[i]))
            {
                finalstring.Append(' ');
                isspace=true;
            }
            else
            {
                finalstring.Append(isspace?char.ToUpper(sb[i]):char.ToLower(sb[i]));
                isspace=false;
            }
        }
        Console.WriteLine(finalstring.ToString());
        
    }
}