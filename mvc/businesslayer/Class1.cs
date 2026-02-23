using namesdll;
namespace businesslayer
{
    public class Class1
    {
        public List<string> reversednames()
        {
            names n = new names();
            List<string> t = n.getnames();
            List<string> reversed = new List<string>();
            foreach (string name in t)
            {
                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                reversed.Add(new string(arr));
            }
            return reversed;
        }
        
    }
}
