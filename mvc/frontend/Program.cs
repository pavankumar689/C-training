using businesslayer;
class program
{
    public static void Main(string[] args)
    {
        Class1 c = new Class1();
        List<string> names=c.reversednames();
        foreach(var i in names)
        {
            Console.WriteLine(i);
        }
    }
}