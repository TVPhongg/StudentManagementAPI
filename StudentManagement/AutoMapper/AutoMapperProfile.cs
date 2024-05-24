using AutoMapper;
using StudentManagement.Data.Entities;
using StudentManagement.DTOs.StudentDTOs;

namespace StudentManagement.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            //mapper student
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
