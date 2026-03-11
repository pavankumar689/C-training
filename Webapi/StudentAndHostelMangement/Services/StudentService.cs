using StudentAndHostelMangement.Models;
using StudentAndHostelMangement.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentAndHostelMangement.Services
{
    public class StudentService:IStudentService
    {
        private readonly CollegeDb1Context _context;

        public StudentService(CollegeDb1Context context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(CreateStudent dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task AssignRoom(AssignRoom dto)
        {
            var hostel = new Hostel
            {
                StudentId = dto.StudentId,
                RoomNo = dto.RoomNo,
                CollegeId = dto.CollegeId
            };

            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeRoom(ChangeRoom dto)
        {
            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(x => x.StudentId == dto.StudentId);

            if (hostel == null)
                throw new Exception("Room not assigned");

            hostel.RoomNo = dto.NewRoomNo;

            await _context.SaveChangesAsync();
        }
        public async Task<Student> UpdateStudent(UpdateStudent dto)
        {
            var student = await _context.Students.FindAsync(dto.Id);

            if (student == null)
                throw new Exception("Student not found");

            student.Name = dto.Name;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return student;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students
                .Include(s => s.Hostel)
                .ToListAsync();
        }
        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.Hostel)
                .FirstOrDefaultAsync(x => x.Id == id);

            return student;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return false;

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
