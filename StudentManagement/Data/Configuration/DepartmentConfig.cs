using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng department
    /// </summary>
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("department");
            builder.HasKey(x => x.departmentId);
            builder.Property(x => x.departmentName).HasMaxLength(200).IsRequired();
        }
    }
}
