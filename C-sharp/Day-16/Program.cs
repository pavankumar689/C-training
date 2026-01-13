using System;
using System.Reflection;

// class Employee
// {
//     public int Id { get; set; }
//     public string Name { get; set; }

//     public void Work()
//     {
//         Console.WriteLine("Employee is working");
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         // Type type1 = typeof(Employee);

//         // Employee employeeObject = new Employee();
//         // Type type2 = employeeObject.GetType();

//         // Type type3 = Type.GetType("Employee");

//         // Console.WriteLine(type1);
//         // Console.WriteLine(type2);
//         // Console.WriteLine(type3);

//         Type type = typeof(Employee);
//         MethodInfo method = type.GetMethod("Work");
//         Console.WriteLine(method.Name);

        
//         Type type = typeof(Employee);
//         object obj = Activator.CreateInstance(type);

//         PropertyInfo prop = type.GetProperty("Name");
//         prop.SetValue(obj, "John");

//         object value = prop.GetValue(obj);
//         Console.WriteLine(value);
//     }
// }

//FIELD INFO
// class Employee
// {
//     private int _salary = 0;

//     public int GetSalary()
//     {
//         return _salary;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Type type = typeof(Employee);
//         object obj = Activator.CreateInstance(type);

//         FieldInfo field = type.GetField(
//             "_salary",
//             BindingFlags.NonPublic | BindingFlags.Instance
//         );

//         field.SetValue(obj, 50000);

//         Console.WriteLine(field.GetValue(obj));
//     }
// }


class Employee
{
    public string Name;
    public int Age;

    public Employee()
    {
        Name = "Default";
        Age = 0;
    }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    public static void method(int a, int b)
    {
    }

    static void Main()
    {
        // Type type = typeof(Employee);

        // ConstructorInfo ctor1 = type.GetConstructor(Type.EmptyTypes);
        // object obj1 = ctor1.Invoke(null);
        // Console.WriteLine(((Employee)obj1).Name + " " + ((Employee)obj1).Age);

        // ConstructorInfo ctor2 = type.GetConstructor(
        //     new Type[] { typeof(string), typeof(int) }
        // );
        // object obj2 = ctor2.Invoke(new object[] { "John", 30 });
        // Console.WriteLine(((Employee)obj2).Name + " " + ((Employee)obj2).Age);

        // Type programType = typeof(Program);
        // MethodInfo methodInfo = programType.GetMethod(
        //     "method",
        //     BindingFlags.Public | BindingFlags.Static
        // );

        // ParameterInfo[] parameters = methodInfo.GetParameters();

        // foreach (var p in parameters)
        // {
        //     Console.WriteLine(p.Name + " : " + p.ParameterType);
        // }
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            Console.WriteLine("Class: " + type.Name);

            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine("  Method: " + method.Name);
            }
        }
    }
}
