using AutoMapper;
using StudentManagement.Data.DBcontext;
using StudentManagement.Data.Entities;
using StudentManagement.DTOs.StudentDTOs;
using StudentManagement.Services.BaseServices;

namespace StudentManagement.Services.StudentServices
{
    public class StudentServices: BaseService<Student, StudentDTO>, IStudentServices
    {
        private readonly StudentManagementContext _context;
        private readonly IMapper _mapper;

        public StudentServices(StudentManagementContext context, IMapper mapper)
            :base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Thêm mới sinh viên
        /// </summary>
        /// <param name="request"> Đối tượng cần thêm mới</param>
        /// <returns> true: thêm mới thành công / false: thêm mới thất bại</returns> 
        public Task<Student> CreateStudent(StudentDTO request)
        {
            return base.Create(request);
        }


        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        /// <param name="Id"> Id sinh viên</param>
        /// <returns>true: xóa thành công / false: xóa thất bại</returns>
        public Task<int> DeleteStudent(int Id)
        {
            return base.Delete(Id);
        }


        /// <summary>
        /// Lấy sinh viên theo id
        /// </summary>
        /// <param name="Id">Id sinh viên</param>
        /// <returns> true: lấy danh sách thành công / false: lấy danh sách thất bại </returns>
        public Task<StudentDTO> GetStudentId(int Id)
        {
            return base.GetById(Id);
        }


        /// <summary>
        /// Cập nhật sinh viên
        /// </summary>
        /// <param name="Id">Id của sinh viên cần cập nhật</param>
        /// <param name="request"> Cập nhật đối tượng sinh viên </param>
        /// <returns> true: cập nhật thành công, false: cập nhật thất bại</returns>
        public Task<Student> UpdateStudent(int Id, StudentDTO request)
        {
            return base.Update(Id, request);
        }
    }
}
