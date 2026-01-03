class Mathops
{
    public static int add(int a,int b)
    {
        return a+b;
    }
    public double add(double a,double b,double c=0)
    {
        return a+b;
    }

    public void namedparameters(int age,String name,char gender='M',params int[] arr)
    {
        Console.WriteLine($"{name}: {age}");
        foreach(int i in arr)
        {
            Console.WriteLine(i);
        }
    }
}