using System.Diagnostics;
using System.Linq;
//class Program
//{
//    static void Main()
//    {
//        //Trace.Listeners.Add(new ConsoleTraceListener());
//        Trace.WriteLine("Application started");

//        int a = 10;
//        int b = 0;

//        try
//        {
//            int result = a / b;
//            Console.WriteLine(result);
//        }
//        catch (Exception ex)
//        {
//            Trace.WriteLine("Exception occurred: " + ex.Message);
//        }

//        Trace.WriteLine("Application ended");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//Trace.Listeners.Add(new ConsoleTraceListener());

//Trace.WriteLine("Program started");

//PerformCalculation(10, 5);
//PerformCalculation(10, 0);   // Error case

//int total = 0;


//for (int i = 1; i <= 5; i++)
//{
//    total += i; // Breakpoint here
//}
//Trace.WriteLine("Program ended");
//    List<User> users = new List<User>();

//    users.Add(new User { Name = "Aryan", Age = 22 });
//    users.Add(new User { Name = "Mohit", Age = 32 });
//    users.Add(new User { Name = "Sushant", Age = 68 });
//    users.Add(new User { Name = "Ritik", Age = 63 });
//    users.Add(new User { Name = "Sahil", Age = 52 });

//    foreach (var user in users)
//    {
//        Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
//    }

//    Queue<int> queue = new Queue<int>();
//    queue.Enqueue(45);
//    queue.Enqueue(55);
//    queue.Enqueue(65);
//    queue.Enqueue(75);
//    queue.Enqueue(25);

//    while (queue.Count > 0)
//    {
//        Console.Write(queue.Dequeue() + " ");
//    }

//}

//    static void PerformCalculation(int a, int b)
//    {
//        Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

//        if (b == 0)
//        {
//            Trace.WriteLine("Error: Division by zero detected");
//            return;
//        }

//        int result = Divide(a, b);

//        Trace.WriteLine($"Calculation successful | Result={result}");
//        Trace.WriteLine("Exiting PerformCalculation");
//    }

//    static int Divide(int x, int y)
//    {
//        Trace.WriteLine($"Dividing values | x={x}, y={y}");
//        return x / y;
//    }
//}

//class User
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}
//}
using System;
using System.Collections.Generic;

class Program
{
    public static int Add(int a,int b)
    {
        return a+b;
    }
    static void Main(string[] args)
    {
        // List<User> users = new List<User>
        // {
        //     new User { Name = "Aryan", Age = 22 },
        //     new User { Name = "Mohit", Age = 32 },
        //     new User { Name = "Sushant", Age = 68 },
        //     new User { Name = "Ritik", Age = 63 },
        //     new User { Name = "Sahil", Age = 52 }
        // };


        // foreach (var user in users)
        // {
        //     Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");

        // }

        // Console.WriteLine("------ Queue ------");


        // Queue<int> queue = new Queue<int>();
        // queue.Enqueue(45);
        // queue.Enqueue(55);
        // queue.Enqueue(65);
        // queue.Enqueue(75);
        // queue.Enqueue(25);

        // while (queue.Count > 0)
        // {
        //     Console.Write(queue.Dequeue() + " ");

        // }
        // int a=5;
        // int b=10;
        // int c=Add(a,b);
        // Console.WriteLine(c);

        // Students s1= new Students("Raju",70);
        // Students s2= new Students("Raki",40);
        // Students s3= new Students("Ravi",50);
        // Students s4= new Students("saju",70);

        // List<Students>students=new List<Students>{s1,s2,s3,s4};
        // var result = students.Select(
        //     s => new
        //     {
        //         s.Name,
        //         Grade=s.Marks>40?"pass":"fail"
        //     }
        // );
        // foreach(var item in result)
        // {
        //     Console.WriteLine($"Name:{item.Name}\nGrade:{item.Grade}");
        // }
        // Console.WriteLine(result.ToList().GetType());

        // var result2=students.OrderBy(s=>s.Marks).ThenBy(s=>s.Name);
        // foreach(var i in result2)
        // {
        //     Console.WriteLine($"Name:{i.Name}\nGrade:{i.Marks}");
        // }

        // Console.WriteLine(result2.GetType());
        // Console.WriteLine();
        // var result3=students.OrderByDescending(s=>s.Marks);
        // foreach(var i in result3)
        // {
        //     Console.WriteLine($"Name:{i.Name}\nGrade:{i.Marks}");
        // }
        // List<int> numbers = new List<int> { 5,10, 20, 30 };
        // int first = numbers.First();
        // Console.WriteLine(first);
        // int result=numbers.First(n=>n>15);
        // Console.WriteLine(result);
        // int last=numbers.Last();
        // Console.WriteLine(last);
        // int last2=numbers.Last(n=>n<15);
        // Console.WriteLine(last2);

        // List<int> numbers = new List<int> {3};
        // int value = numbers. Single();
        // Console.WriteLine(value);
        // List<int> numbers2 = new List<int> {1, 2,3};
        // int result = numbers2. Single(n => n == 3);
        // Console.WriteLine(result);

        var students = new List<Student>
        {
            new Student("Raju", "A"),
            new Student("Ravi", "B"),
            new Student("Raki", "A"),
            new Student("Sahil", "C")
        };

        var groupedStudents = students.GroupBy(s => s.Grade);

        foreach (var group in groupedStudents)
        {
            Console.WriteLine($"Grade: {group.Key}");

            foreach (var student in group)
            {
                Console.WriteLine($"  {student.Name}");
            }
        }

        var lookup = students.ToLookup(s => s.Grade);
        foreach (var student in lookup["A"])
        {
            Console.WriteLine(student.Name);
        }
    
    }
}

// class User
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }

// class Students
// {
//     public string? Name;
//     public string? Grade;
//     public int Marks;
//     public Students(string name,int marks)
//     {
//         Name=name;
//         Marks=marks;
//     }
// }


class Student
{
    public string Name;
    public string Grade;

    public Student(string name, string grade)
    {
        Name = name;
        Grade = grade;
    }
}
