using System.ComponentModel;

class Bank_account
{
    public int AccNumber;
    private double Balance=0;
    public void Deposit(double amount)
    {
        Balance+=amount;
        Console.WriteLine($"Deposit was successful.Your current balance is {Balance}");
    }
}

class Program1
{
    // public static void Main(String[] args)
    // {
        // Employee e1=new Employee();
        // e1.Name="Raju";
        // e1.Salary=40000;
        // e1.DisplayDetails();

        // Bank_account B1=new Bank_account();
        // B1.Deposit(50000);
        // B1.Deposit(30000);

        // Wallet w1=new Wallet();
        // w1.AddMoney(40000);
        // w1.AddMoney(20000);
        // Console.WriteLine(w1.GetBalance());

        // Mathops m=new Mathops();
        // // // Console.WriteLine(Mathops.add(1,2));
        // // // Console.WriteLine(m.add(1.1,2));
        // // // Console.WriteLine(m.add(1.1,2.2));
        // m.namedparameters(name:"raju",age:21,gender:'f',arr:[1,2,4,3]);
        


        // String? name=Console.ReadLine();
        // foreach(Char n in name)
        // {
        //     Console.WriteLine(n);
        // }

        // Console.WriteLine(Sum(1,3,5,2));
        // Console.WriteLine(Sum(3,5,6));
        // int[] arr={2,4,2,6,23,3};
        // Console.WriteLine(Sum(arr));

        // int x=10;
        // Increaseby10(ref x);
        // Console.WriteLine(x);

        // int q, r;   // no initialization required

        // Divide(10, 3, out q, out r);

        // Console.WriteLine("Quotient = " + q);
        // Console.WriteLine("Remainder = " + r);

        // string result;
        // GetResult(75, out result);
        // Console.WriteLine(result);

        //calculate(2,4);
        // Example();
    //     Level.Calculate();

    // }

    //params
    public static int Sum(params int[] arr)
    {
        int total=0;
        foreach(int n in arr)
        {
            total+=n;
        }
        return total;
    }

    //pass by reference
    public static void Increaseby10(ref int a)
    {
        a+=10;
    }

    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }

     public static void GetResult(int marks, out string grade)
    {
        if (marks >= 60)
            grade = "Pass";
        else
            grade = "Fail";
    }

    public static void infunction(in int x){
        Console.WriteLine(x);
        //x=x+10 in wont allow this modification
    }
    // public static void calculate(int a,int b)
    // {
    //     void add()
    //     {
    //         Console.WriteLine(a+b);
    //     }
    //     void subtract()
    //     {
    //         Console.WriteLine(a-b);
    //     }
    // }
    static void Example()
    {
    static int Square(int x)
    {
        return x * x;
    }
    Func<int, int> squareLambda = x => x * x;

    Console.WriteLine(Square(4));
    Console.WriteLine(squareLambda(4));
    }   

}