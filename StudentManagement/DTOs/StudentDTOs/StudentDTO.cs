namespace StudentManagement.DTOs.StudentDTOs
{
    /// <summary>
    /// Auto Mapper: map các thuộc tính -> chuyển obj data này thành obj data khác.
    /// client nhận data từ server bằng domain obj để xử lý và hiển thị DL. Khi thay đổi tên column trong table
    /// thì phải chỉnh sửa các property trong domain obj. 
    /// DTO mapping với domain obj. Chỉnh sửa domain obj sẽ chỉ cần chỉnh sửa mapping với DTO
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// id sinh viên
        /// </summary>
        public int studentId { get; set; }

        /// <summary>
        /// tên sinh viên
        /// </summary>
        public string studentName { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime DoB { get; set; }

        /// <summary>
        /// mã lớp
        /// </summary>
        public int classId { get; set; }
    }
}
