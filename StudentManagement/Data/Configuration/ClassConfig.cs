using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data.Configuration
{
    /// <summary>
    /// cấu hình bảng class
    /// </summary>
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        /// <summary>
        /// Cấu hình bảng class
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Class> builder) // tạo ra lớp cấu hình riêng cho mỗi bảng
        {        
            builder.ToTable("class"); 
            builder.HasKey(x => x.classId);
            builder.Property(x => x.className).HasMaxLength(100).IsRequired();
            builder.HasOne<Department>(x => x.Department).WithMany(x => x.Classes).HasForeignKey(x => x.departmentId )
              .IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            /// 1 số loại OnDelete:
            /// Cascade: xóa thực thể phụ thuộc khi thực thể chính bị xóa.
            /* ClientSetNull: Đặt khóa ngoại của thực thể phụ thuộc thành null trên client.
               khi thực thể chính bị xóa, không áp dụng trên cơ sở dữ liệu nếu không có cập nhật từ client.
            */
            // Restrict: Ngăn chặn việc xóa thực thể chính nếu có thực thể phụ thuộc liên quan.
            // SetNull: Đặt khóa ngoại của thực thể phụ thuộc thành null khi thực thể chính bị xóa.
        }
    }
}
