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
        /// mã lớp
        /// </summary>
        public int classId { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng điểm
        /// </summary>
        /// ICollection(pthuc thao tác vs tập hợp): định nghĩa các mối quan hệ giữa các thực thể. 
        /// IEnumerable(chỉ duyệt ptu), IList(truy cập theo chỉ số), IDictionary(cặp khóa-giá trị), ISet, List, Dictionary, Stack. 
        public virtual ICollection<Score> Scores { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng lớp học
        /// </summary>
        public virtual Class Class { get; set; }    
    }
}
