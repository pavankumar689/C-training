using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float? Height { get; set; }
    public float AttendancePercentage { get; set; }
}

class Program
{
    static void Main()
    {
       
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ravi",   Height = null,   AttendancePercentage = 80f },
            new Student { Id = 2, Name = "Ramu",   Height = 165.5f, AttendancePercentage = 82.3f },
            new Student { Id = 3, Name = "Barath", Height = 172.75f,AttendancePercentage = 72f },
            new Student { Id = 4, Name = "Rakesh", Height = null,   AttendancePercentage = 74.5f },
            new Student { Id = 5, Name = "Sam",    Height = 168.32f,AttendancePercentage = 86f }
        };

        
        ArrayList legacyData = new ArrayList(students);

        int attendanceCount = 0;

        
        foreach (var item in legacyData)
        {
            if (item is Student student)
            {
                Console.WriteLine($"Student: {student.Name}");

                
                if (student.Height.HasValue)
                    Console.WriteLine($"Height: {student.Height.Value:F1}");
                else
                    Console.WriteLine("Height: Height Not Available");

               
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < student.Name.Length; i += 2)
                {
                    sb.Append(student.Name[i]);
                }
                Console.WriteLine($"Alternate Name: {sb}");

               
                if (student.AttendancePercentage > 75.5f)
                {
                    Console.WriteLine($"Attendance: {student.AttendancePercentage}");
                    attendanceCount++;
                }

                Console.WriteLine("-------------------------");
            }
        }

       
        Console.WriteLine($"Total Students with Attendance > 75.5: {attendanceCount}");
    }
}
