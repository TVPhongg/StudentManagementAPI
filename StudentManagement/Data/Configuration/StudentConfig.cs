using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng student
    /// </summary>
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// cấu hình bảng sinh viên
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student");
            builder.HasKey(std => std.studentId);
            builder.Property(std => std.studentName).HasMaxLength(200).IsRequired();
            builder.Property(std => std.sex).HasMaxLength(10);
            builder.Property(std => std.DoB).HasMaxLength(50);

            builder.HasOne<Class>(x => x.Class).WithMany(x => x.Students).HasForeignKey(x => x.classId)
                .IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
