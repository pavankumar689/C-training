using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            // TODO: Return sum of credits of all RegisteredCourses

            if (RegisteredCourses == null || RegisteredCourses.Count == 0)
                return 0;

            return RegisteredCourses.Sum(c => c.Credits);
        }

        public bool CanAddCourse(Course course)
        {
            // TODO:
            // 1. Course should not already be registered
            // 2. Total credits + course credits <= MaxCredits
            // 3. Course prerequisites must be satisfied
            //THE WORLD IS GOING THE END
            if (course == null)
                return false;

            // 1. Not already registered
            if (RegisteredCourses.Any(c => string.Equals(c.CourseCode, course.CourseCode, StringComparison.OrdinalIgnoreCase)))
                return false;

            // 2. Credit limit
            if (GetTotalCredits() + course.Credits > MaxCredits)
                return false;

            // 3. Prerequisites
            if (!course.HasPrerequisites(CompletedCourses))
                return false;

            return true;
        }

        public bool AddCourse(Course course)
        {
            // TODO:
            // 1. Call CanAddCourse
            // 2. Check course capacity
            // 3. Add course to RegisteredCourses
            // 4. Call course.EnrollStudent()
            if (course == null)
                return false;

            if (!CanAddCourse(course))
                return false;

            if (course.IsFull())
                return false;

            try
            {
                course.EnrollStudent();
                RegisteredCourses.Add(course);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DropCourse(string courseCode)
        {
            // TODO:
            // 1. Find course by code
            // 2. Remove from RegisteredCourses
            // 3. Call course.DropStudent()
            if (string.IsNullOrWhiteSpace(courseCode))
                return false;

            var course = RegisteredCourses.FirstOrDefault(c => string.Equals(c.CourseCode, courseCode, StringComparison.OrdinalIgnoreCase));
            if (course == null)
                return false;

            course.DropStudent();
            RegisteredCourses.Remove(course);
            return true;
        }

        public void DisplaySchedule()
        {
            // TODO:
            // Display course code, name, and credits
            // If no courses registered, display appropriate message

            Console.WriteLine($"Schedule for {Name} ({StudentId}):");
            if (RegisteredCourses == null || RegisteredCourses.Count == 0)
            {
                Console.WriteLine("No courses registered.");
                return;
                
            }

            foreach (var c in RegisteredCourses)
            {
                Console.WriteLine($"{c.CourseCode} - {c.CourseName} ({c.Credits} credits)");
            }
        }
    }
}
