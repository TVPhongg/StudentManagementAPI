namespace StudentManagement.Data.Entities
{

    /// <summary>
    /// bảng giảng viên
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// mã giảng viên
        /// </summary>
        public int teacherId { get; set; }

        /// <summary>
        /// tên giảng viên
        /// </summary>
        public string teacherName { get; set; }

        /// <summary>
        /// chuyên ngành
        /// </summary>
        public string major { get; set; }

        /// <summary>
        ///  mã khoa
        /// </summary>
        public int departmentId { get; set; }

        /// <summary>
        /// điều hướng tham chiếu đến bảng khoa
        /// </summary>
        public virtual Department Department { get; set; }

    }
}
