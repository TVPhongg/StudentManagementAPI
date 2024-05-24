using StudentManagement.Data.Entities;
using StudentManagement.DTOs.StudentDTOs;
using StudentManagement.Services.BaseServices;

namespace StudentManagement.Services.StudentServices
{
    public interface IStudentServices : IBaseService<Student, StudentDTO>
    {
        Task<StudentDTO> GetStudentId(int Id);
        Task<Student> CreateStudent(StudentDTO request);
        Task<Student> UpdateStudent(int Id, StudentDTO request);
        Task<int> DeleteStudent(int Id);
    }
}
