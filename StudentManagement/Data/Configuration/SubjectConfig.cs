using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng subject
    /// </summary>
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subject");
            builder.HasKey(x => x.subjectId);
            builder.Property(x => x.subjectName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.hour).IsRequired();
        }
    }
}
