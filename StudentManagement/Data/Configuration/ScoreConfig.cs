using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng score
    /// </summary>
    public class ScoreConfig : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("score");
            builder.HasKey(x => new { x.studentId, x.subjectId });
            builder.Property(x => x.examTimes).IsRequired();
            builder.Property(x => x.testScore).IsRequired();

            builder.HasOne<Subject>(x => x.Subject).WithMany(x => x.Scores).HasForeignKey(x => x.subjectId)
                .IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Student>(x => x.Student).WithMany(x => x.Scores).HasForeignKey(x => x.studentId)
                .IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

