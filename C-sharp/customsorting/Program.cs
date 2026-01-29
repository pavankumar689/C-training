class Student
{
    public string Name;
    public int Age;
    public int Marks;
    public Student(string name,int age,int marks)
    {
        Name=name;
        Age=age;
        Marks=marks;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Student> students_list =new List<Student>
        {
            new Student("pavan",21,500),
            new Student("Sri karan",20,450),
            new Student("shubanshu",22,475),
            new Student("rohit",20,500),
            new Student("Aditya",26,490)
        };



        students_list.Sort(new StudentComparer());

        foreach (var s in students_list)
        {
            Console.WriteLine($"{s.Name} - Marks: {s.Marks}, Age: {s.Age}");
        }

    }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
    
        int marksCompare = y.Marks.CompareTo(x.Marks);

        if (marksCompare == 0)
        {
            return x.Age.CompareTo(y.Age);
        }
        return marksCompare;
    }
}