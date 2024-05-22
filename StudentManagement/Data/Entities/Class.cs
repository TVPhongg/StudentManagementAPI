namespace StudentManagement.Data.Entities
{
    /// <summary>
    /// bảng lớp
    /// </summary>
    public class Class
    {
        /// <summary>
        /// Id lớp
        /// </summary>
        public int classId { get; set; }

        /// <summary>
        /// tên lớp
        /// </summary>
        public string className { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng sinh viên
        /// </summary>
        public virtual ICollection<Student> Students { get; set;}

        /// <summary>
        /// điều hướng tham chiếu đến bảng khoa
        /// </summary>
        public virtual Department Department { get; set; }
    }
}
