//class program
//{
//    public static void Main(string[] args)
//    {
//        List<int>Numbers_Divisible_by_2=new List<int>();
//        List<int>Numbers_Divisible_by_3=new List<int>();
//        List<int>Numbers_That_do_not_divisible=new List<int>();
//        for(int i = 1; i < 100; i++)
//        {
//            if (i % 2 == 0)
//            {
//                Numbers_Divisible_by_2.Add(i);
//            }
//            if (i % 3 == 0)
//            {
//                Numbers_Divisible_by_3.Add(i);
//            }
//            int count=0;
//            for(int j = 2; j < i; j++)
//            {
//                if (i % j == 0)
//                {
//                    count++;
//                }
//            }
//            if (count == 0)
//            {
//                Numbers_That_do_not_divisible.Add(i);
//            }
//        }

//        Console.WriteLine("Prime Numbers");
//        foreach(int i in Numbers_That_do_not_divisible)
//        {
//            Console.WriteLine(i);
//        }

//        Console.WriteLine("Numbers Divisible by 2");
//        foreach(int i in Numbers_Divisible_by_2)
//        {
//            Console.WriteLine(i);
//        }

//        Console.WriteLine("Numbers Divisible by 3");
//        foreach(int i in Numbers_Divisible_by_3)
//        {
//            Console.WriteLine(i);
//        }
//        Console.ReadKey();
//    }
//}

//interface Igear
//{
//    public void gear1();
//    public void gear2();
//    public void gear3();
//    public void gear4();
//    public void gear5();
//    public void reversegear();
//}
//class car : Igear
//{
//    public void gear1()
//    {
//        Console.WriteLine("Grear 1 tested");
//    }
//    public void gear2()
//    {
//        Console.WriteLine("Grear 2 tested");
//    }
//    public void gear3()
//    {
//        Console.WriteLine("Grear 3 tested");
//    }
//    public void gear4()
//    {
//        Console.WriteLine("Grear 4 tested");
//    }
//    public void gear5()
//    {
//        Console.WriteLine("Grear 5 tested");
//    }
//    public void reversegear()
//    {
//        Console.WriteLine("Reverse gear");
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        //Igear car1 = new car();
//        //car1.gear1();
//        //car1.gear2();
//        //car1.gear3();
//        //car1.gear4();
//        //car1.gear5();
//        //car1.reversegear();
//        nano car1 = new car();
//        car1.gear1();
//        car1.gear2();
//    }
//}

//abstract class nano
//{
//    public abstract void gear1();
//    public abstract void gear2();
//    public virtual void airbag()
//    {
//        Console.WriteLine("Air break implemented");
//    }
//    public virtual void Audio()
//    {
//        Console.WriteLine("Audio implemented");
//    }
//}

//class car : nano
//{
//    public override void gear1()
//    {
//        Console.WriteLine("gear 1 mandetory");
//    }
//    public override void gear2()
//    {
//        Console.WriteLine("gear 2 mandetory");
//    }
//}

//delegate int Addition(int a, int b);
//delegate int findlen(string c);

class program
{
    //public static int add(int a, int b)
    //{
    //    return a + b;
    //}
    //public static int Sub(int a, int b)
    //{
    //    return a - b;
    //}
    //public static int len(string c)
    //{
    //    return c.Length;
    //}
    public static void Main(string[] args)
    {
        //Addition a = add;
        //Console.WriteLine(a(5, 2));
        //a = Sub;
        //Console.WriteLine(a(7, 2));
        //findlen f = len;
        //Console.WriteLine(f("pavan")); 
        //int[] arr = { 23, 252, 35, 2, 6, 4, 3, 7, 45, 7, 34, 23, 64 };
        //var temp = from i in arr where i > 40 orderby i descending select i ;
        //foreach(int i in temp)
        //{
        //    Console.WriteLine(i);
        //}
    }
}

