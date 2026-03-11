using StudentAndHostelMangement.Models;
using StudentAndHostelMangement.DTO;

namespace StudentAndHostelMangement.Services
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(CreateStudent dto);

        Task AssignRoom(AssignRoom dto);

        Task ChangeRoom(ChangeRoom dto);

        Task<Student> UpdateStudent(UpdateStudent dto);

        Task<bool> DeleteStudent(int id);

        Task<Student> GetStudent(int id);

        Task<List<Student>> GetAllStudents();
    }
}
