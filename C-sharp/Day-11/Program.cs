using System.Text;
class StringBuilder1
{
    public static void Main(string[] args)
    {
        // string s="Hello";
        // string result=char.ToLower(s[0])+s.Substring(1);
        // Console.WriteLine(result);

        //StringBuilder sb=new StringBuilder();

        // sb.Append("Hello");
        // sb.Append(" ");
        // sb.Append("World");
        // Console.WriteLine(sb.ToString());

        // sb.Append("Text");
        // sb.AppendLine();
        // sb.Insert(0,"Start");
        // sb.Remove(0,5);
        // sb.Replace("Text"," End");
        // sb.Clear();
        // Console.WriteLine(sb.GetType());
        // Console.WriteLine(sb.ToString().GetType());

        // Console.WriteLine(GC.GetTotalMemory(false));
        // StringBuilder sb=new StringBuilder();
        // for(int i = 0; i < 10000; i++)
        // {
        //     sb.Append(i);
        // }
        // string result=sb.ToString();
        //  Console.WriteLine(GC.GetTotalMemory(false));
        // string a="Hello";
        // string b="Hello";
        // Console.WriteLine(a==b);
        // Console.WriteLine(a.Equals(b));
        // Console.WriteLine(Object.ReferenceEquals(a, b));
        // Console.WriteLine(a.GetHashCode());   
        // Console.WriteLine(b.GetHashCode()); 

        // ---------- StringBuilder comparisons ----------

        // StringBuilder sb1 = new StringBuilder("Hello");
        // StringBuilder sb2 = new StringBuilder("Hello");

        // // Equals() in StringBuilder is NOT overridden
        // // So this compares REFERENCES (addresses), not values
        // Console.WriteLine(sb1.Equals(sb2));         
        // // False (different objects in memory)

        // // ReferenceEquals() explicitly checks memory address
        // Console.WriteLine(Object.ReferenceEquals(sb1, sb2));
        // // False (different objects)

        // // sb3 points to the SAME object as sb2
        // StringBuilder sb3 = sb2;

        // // Equals(): still reference comparison
        // Console.WriteLine(sb3.Equals(sb2));         
        // // True (same reference)

        // // ReferenceEquals(): same memory location
        // Console.WriteLine(Object.ReferenceEquals(sb3, sb2));
        // // True

        // // == operator is NOT overloaded for StringBuilder
        // // So it checks reference equality
        // Console.WriteLine(sb1 == sb2);
        // // False (different objects)


        // // ---------- string comparisons ----------

        // string str1 = "Hello";
        // string str2 = "Hello";

        // // == IS overloaded for string
        // // It compares VALUES (contents), not addresses
        // Console.WriteLine(str1 == str2);
        // //  True (same text)

        // DateTime now =DateTime.Now;
        // DateTime today=DateTime.Today;
        // DateTime utcNow=DateTime.UtcNow;
        // Console.WriteLine(now);
        // Console.WriteLine(today);
        // Console.WriteLine(utcNow);
    }
}
