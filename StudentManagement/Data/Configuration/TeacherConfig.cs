using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng teacher
    /// </summary>
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("teacher");
            builder.HasKey(x => x.teacherId);
            builder.Property(x => x.teacherName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.major).HasMaxLength(100).IsRequired();

            builder.HasOne<Department>(x => x.Department).WithMany(x => x.Teachers).HasForeignKey(x => x.departmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
