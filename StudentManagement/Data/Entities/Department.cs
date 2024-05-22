namespace StudentManagement.Data.Entities
{
    /// <summary>
    /// bảng khoa
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id khoa
        /// </summary>
        public int departmentId { get; set; }

        /// <summary>
        /// tên khoa
        /// </summary>
        public string departmentName { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng lớp
        /// </summary>
        public virtual ICollection<Class> Classes { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng giảng viên
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }  
    }
}
