namespace StudentManagement.Data.Entities
{

    /// <summary>
    /// bảng sinh viên
    /// </summary>
    public class Student
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
        /// điều hướng tập hợp đến bảng điểm
        /// </summary>
        public virtual ICollection<Score> Scores { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng lớp học
        /// </summary>
        public virtual Class Class { get; set; }    
    }
}
