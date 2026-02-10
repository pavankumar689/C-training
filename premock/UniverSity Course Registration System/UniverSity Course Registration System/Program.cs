using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch ((choice ?? "").Trim())
                    {
                        case "1":
                            Console.Write("Enter Course Code: ");
                            var courseCode = Console.ReadLine();
                            Console.Write("Enter Course Name: ");
                            var courseName = Console.ReadLine();
                            Console.Write("Enter Credits: ");
                            int credits = 0;
                            int.TryParse(Console.ReadLine(), out credits);
                            Console.Write("Enter Max Capacity (default 50): ");
                            var capLine = Console.ReadLine();
                            int maxCap = 50;
                            if (!string.IsNullOrWhiteSpace(capLine))
                                int.TryParse(capLine, out maxCap);
                            Console.Write("Enter Prerequisites (comma-separated, or Enter for none): ");
                            var preLine = Console.ReadLine();
                            List<string> prereqs = new List<string>();
                            if (!string.IsNullOrWhiteSpace(preLine))
                                prereqs = preLine.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();

                            try
                            {
                                system.AddCourse(courseCode ?? string.Empty, courseName ?? string.Empty, credits, maxCap, prereqs);
                                Console.WriteLine($"Course {courseCode} added successfully.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case "2":
                            Console.Write("Enter Student ID: ");
                            var studentId = Console.ReadLine();
                            Console.Write("Enter Name: ");
                            var studentName = Console.ReadLine();
                            Console.Write("Enter Major: ");
                            var major = Console.ReadLine();
                            Console.Write("Enter Max Credits (default 18): ");
                            int maxCredits = 18;
                            var maxLine = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(maxLine))
                                int.TryParse(maxLine, out maxCredits);
                            Console.Write("Enter Completed Courses (comma-separated, or Enter for none): ");
                            var compLine = Console.ReadLine();
                            List<string> completed = new List<string>();
                            if (!string.IsNullOrWhiteSpace(compLine))
                                completed = compLine.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();

                            try
                            {
                                system.AddStudent(studentId ?? string.Empty, studentName ?? string.Empty, major ?? string.Empty, maxCredits, completed ?? new List<string>());
                                Console.WriteLine($"Student {studentId} added successfully.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case "3":
                            Console.Write("Enter Student ID: ");
                            var regStudent = Console.ReadLine();
                            Console.Write("Enter Course Code: ");
                            var regCourse = Console.ReadLine();
                            system.RegisterStudentForCourse(regStudent ?? string.Empty, regCourse ?? string.Empty);
                            break;

                        case "4":
                            Console.Write("Enter Student ID: ");
                            var dropStudent = Console.ReadLine();
                            Console.Write("Enter Course Code: ");
                            var dropCourse = Console.ReadLine();
                            system.DropStudentFromCourse(dropStudent ?? string.Empty, dropCourse ?? string.Empty);
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Enter Student ID: ");
                            var schedId = Console.ReadLine();
                            system.DisplayStudentSchedule(schedId ?? string.Empty);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

