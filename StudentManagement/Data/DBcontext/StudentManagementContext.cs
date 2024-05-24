using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Configuration;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.DBcontext
{
    /// <summary>
    /// DBContext: trung gian giữa CSDL và Code -> query, add, insert,.. 
    /// </summary>
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // tạo object của mỗi lớp config
            modelBuilder.ApplyConfiguration(new ClassConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new ScoreConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new SubjectConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
        }
        /// <summary>
        /// DbSet: thể hiện của các bảng trong CSDL -> giúp truy xuất dữ liệu từ CSDL
        /// </summary>
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}
