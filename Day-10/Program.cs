
// class Gc
// {
//     public static void Main(string[] args)
//     {
//         // Console.WriteLine("Creating objects....");
//         // for(int i = 0; i < 5; i++)
//         // {
//         //     MyClass obj=new MyClass();
//         // }
//         // for(int i = 0; i < 5; i++)
//         // {
//         //     Newclass r=new Newclass();
//         // }
//         // Console.WriteLine("Forcing garbage collection...");
//         // GC.Collect();
//         // GC.WaitForPendingFinalizers();
//         // Console.WriteLine("Garbage collection completed.");

//         // var student1=(ID:101,Name:"Amit");
//         // Console.WriteLine(student1.GetType());

//         // (int ,string)student2=(101,"ravi");
//         // Console.WriteLine(student2.GetType());

//         // var a=new{x=20,y=20};
//         // Console.WriteLine(a.GetType());
//         // var result=Calculate(10,2);
//         // Console.WriteLine(result);
//         // Console.WriteLine(result.GetType());

//         // var response = ValidateUser("Admin");
//         // Console.WriteLine(response.Message);
//         // Console.WriteLine(response);

//         // var person = (Id: 1, Name: "Neha"); // creating a tuple
//         // Console.WriteLine (person. Id); // print 1
//         // var (id, name) = person;
//         // Console.WriteLine(id);
//         // Console.WriteLine(id.GetType());
//         // var (_,username)=person;
//         // Console.WriteLine();

//         // var s = new Student2 { Id = 1, Name = "Amit" };
//         // Console.WriteLine(s.GetType());
//         // var (sid, sname) = s;

//         // Console.WriteLine(sid);
//         // Console.WriteLine(sname);

//         // int[] numbers = { 4,5,2,2,7,2,32,6,45,3 };
//         // var evenNumbers = numbers. Where (n => n % 2 == 0); // LINQ
//         // var ascendingorder=numbers.OrderBy(n=>n);
//         // var descendingorder=numbers.OrderByDescending(n=>n);
//         // var result=numbers. Where (n=> n > 3 ) . Select(n => n * 2);
//         // Console.WriteLine(evenNumbers.GetType());
//         // Console.WriteLine("Even numbers are:");
//         // foreach (var n in evenNumbers)
//         // {
//         //     Console.WriteLine(n);
//         // }
//         // foreach (var n in result)
//         // {
//         //     Console.WriteLine(n);
//         // }
//         // foreach (var n in ascendingorder)
//         // {
//         //     Console.WriteLine(n);
//         // }
//         // foreach (var n in descendingorder)
//         // {
//         //     Console.WriteLine(n);
//         // }

//         // List<Student3> students = new List<Student3>
//         // {
//         //     new Student3 { Name = "Amit", Marks = 75 },
//         //     new Student3 { Name = "Ravi", Marks = 45 },
//         //     new Student3 { Name = "Sita", Marks = 60 },
//         //     new Student3 { Name = "Rahul", Marks = 90 }
//         // };

    
//         // var result = students.Select(s => new
//         // {
//         //     s.Name,
//         //     Grade = s.Marks > 60 ? "Pass" : "Fail"
//         // });


//         // foreach (var item in result)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }

//         using (ResourceHandler2 handler = new ResourceHandler2())
//         {
//         Console.WriteLine("Using resource...");
//         } // Dispose() called automatically
//         Console.WriteLine("End of program.");

//     }
//     // static (int Sum, int Average,int diff) Calculate(int a, int b)
//     // {
//     //     return (a + b, (a + b) / 2,a-b);
//     // }
//     // static (bool IsValid, string Message) ValidateUser (string username)
//     // {
//     //     if (string.IsNullOrEmpty (username))
//     //         return (false, "Username is required");
//     //     return (true, "Valid user");
//     // }

   
// }
// // class MyClass
// // {
// //     public int age;
// //     ~MyClass()
// //     {
// //         Console.WriteLine("Finalizer called, object collected.");
// //     }
// // }
// // class Newclass
// // {
// //     ~Newclass()
// //     {
// //         Console.WriteLine("hello deleted");
// //     }
// // }

// // class Student2
// // {
// //     public int Id { get; set; }
// //     public string Name { get; set; }

// //     public void Deconstruct(out int id, out string name)
// //     {
// //         id = Id;
// //         name = Name;
// //     }
// // }

// // class Student3
// // {
// //     public string Name { get; set; }
// //     public int Marks { get; set; }
// // }


// class ResourceHandler2: IDisposable
// {
//     public ResourceHandler2()
//     {
//     Console.WriteLine("Resource acquired.");
//     }
//     public void Dispose(){
//     Console.WriteLine("Resource released.");
//     }
// }

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
    }
}
// class Student
// {
//     public string Name { get; set; }
//     public int Age { get; set; }

//     public void DisplayInfo()
//     {
//         Console.WriteLine($"Name: {Name}");
//         Console.WriteLine($"Age: {Age}");
//     }
// }

