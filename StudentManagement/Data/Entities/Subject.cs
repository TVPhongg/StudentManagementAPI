namespace StudentManagement.Data.Entities
{

    /// <summary>
    /// bảng môn học
    /// </summary>
    public class Subject
    {

        /// <summary>
        /// mã môn học
        /// </summary>
        public int subjectId { get; set; }

        /// <summary>
        /// tên môn học
        /// </summary>
        public string subjectName { get; set; }

        /// <summary>
        /// số giờ/ số tiết
        /// </summary>
        public int hour { get; set; }


        /// <summary>
        /// điều hướng tập hợp đến bảng điểm
        /// </summary>
        public virtual ICollection<Score> Scores { get; set; }

    }
}
