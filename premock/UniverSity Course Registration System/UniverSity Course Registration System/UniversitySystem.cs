using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
         
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Course code cannot be empty");

            var key = code.Trim().ToUpperInvariant();
            if (AvailableCourses.ContainsKey(key))
                throw new ArgumentException($"Course {code} already exists.");

            var course = new Course(key, name, credits, maxCapacity, prerequisites);
            AvailableCourses[key] = course;
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Student ID cannot be empty");

            var key = id.Trim().ToUpperInvariant();
            if (Students.ContainsKey(key))
                throw new ArgumentException($"Student {id} already exists.");

            var student = new Student(key, name, major, maxCredits, completedCourses ?? new List<string>());
            Students[key] = student;
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(courseCode))
                return false;

            var sKey = studentId.Trim().ToUpperInvariant();
            var cKey = courseCode.Trim().ToUpperInvariant();

            if (!Students.ContainsKey(sKey))
            {
                Console.WriteLine($"Student {studentId} does not exist.");
                return false;
            }

            if (!AvailableCourses.ContainsKey(cKey))
            {
                Console.WriteLine($"Course {courseCode} does not exist.");
                return false;
            }

            var student = Students[sKey];
            var course = AvailableCourses[cKey];

            if (student.RegisteredCourses.Any(c => string.Equals(c.CourseCode, course.CourseCode, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Student already registered for this course.");
                return false;
            }

            if (!course.HasPrerequisites(student.CompletedCourses))
            {
                Console.WriteLine("Prerequisites not satisfied.");
                return false;
            }

            if (student.GetTotalCredits() + course.Credits > student.MaxCredits)
            {
                Console.WriteLine("Cannot register: exceeds student's max credits.");
                return false;
            }

            if (course.IsFull())
            {
                Console.WriteLine("Course is full.");
                return false;
            }

            var success = student.AddCourse(course);
            if (success)
            {
                Console.WriteLine($"Registration successful! Total credits: {student.GetTotalCredits()}/{student.MaxCredits}.");
                return true;
            }

            Console.WriteLine("Registration failed.");
            return false;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(courseCode))
                return false;

            var sKey = studentId.Trim().ToUpperInvariant();
            var cKey = courseCode.Trim().ToUpperInvariant();

            if (!Students.ContainsKey(sKey))
            {
                Console.WriteLine($"Student {studentId} does not exist.");
                return false;
            }

            var student = Students[sKey];
            var success = student.DropCourse(cKey);
            if (success)
            {
                Console.WriteLine("Course dropped successfully.");
                return true;
            }

            Console.WriteLine("Drop failed: student not registered in that course.");
            return false;
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if (AvailableCourses == null || AvailableCourses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            Console.WriteLine("Available Courses:");
            foreach (var course in AvailableCourses.Values)
            {
                Console.WriteLine($"{course.CourseCode} - {course.CourseName} ({course.Credits} credits) [{course.GetEnrollmentInfo()}]");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if (string.IsNullOrWhiteSpace(studentId))
                return;

            var sKey = studentId.Trim().ToUpperInvariant();
            if (!Students.ContainsKey(sKey))
            {
                Console.WriteLine($"Student {studentId} does not exist.");
                return;
            }

            Students[sKey].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            int totalStudents = Students?.Count ?? 0;
            int totalCourses = AvailableCourses?.Count ?? 0;

            int totalEnrollment = 0;
            if (AvailableCourses != null && AvailableCourses.Count > 0)
            {
                foreach (var c in AvailableCourses.Values)
                {
                    var info = c.GetEnrollmentInfo();
                    var parts = info.Split('/');
                    if (parts.Length > 0 && int.TryParse(parts[0], out int enrolled))
                        totalEnrollment += enrolled;
                }
            }

            double average = 0.0;
            if (totalCourses > 0)
                average = Math.Round((double)totalEnrollment / totalCourses, 1);

            Console.WriteLine("System Summary:");
            Console.WriteLine($"- Total Students: {totalStudents}");
            Console.WriteLine($"- Total Courses: {totalCourses}");
            Console.WriteLine($"- Average Enrollment: {average}");
        }
    }
}
