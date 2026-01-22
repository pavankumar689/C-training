namespace dllfile
{
    interface Interface1
    {
        public void method1();
        public void method2();
    }
    interface Interface2
    {
        public void method3();
    }
    interface Interface3
    {
        public void method4();
    }
    public class Class1:Interface1,Interface2,Interface3
    {
        public void method1()
        {
            Console.WriteLine("Method 1");
        }
        public void method2()
        {
            Console.WriteLine("Method 2");
        }
        public void method3()
        {
            Console.WriteLine("Method 3");
        }
        public void method4()
        {
            Console.WriteLine("Method 4");
        }

    }
    public class Class2 : Class1
    {
        public void method5()
        {
            Console.WriteLine("Method 5");
        }
    }
}
