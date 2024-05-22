﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Data.DBcontext;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(StudentManagementContext))]
    [Migration("20240522070740_V1.0")]
    partial class V10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentManagement.Data.Entities.Class", b =>
                {
                    b.Property<int>("classId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("classId"), 1L, 1);

                    b.Property<string>("className")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.HasKey("classId");

                    b.HasIndex("departmentId");

                    b.ToTable("class", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Department", b =>
                {
                    b.Property<int>("departmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("departmentId"), 1L, 1);

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("departmentId");

                    b.ToTable("department", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Score", b =>
                {
                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<int>("examTimes")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<double>("testScore")
                        .HasColumnType("float");

                    b.HasKey("subjectId");

                    b.HasIndex("studentId");

                    b.ToTable("score", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentId"), 1L, 1);

                    b.Property<DateTime>("DoB")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("classId")
                        .HasColumnType("int");

                    b.Property<string>("sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("studentId");

                    b.HasIndex("classId");

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subjectId"), 1L, 1);

                    b.Property<int>("hour")
                        .HasColumnType("int");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("subjectId");

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("teacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("teacherId"), 1L, 1);

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("major")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("teacherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("teacherId");

                    b.HasIndex("departmentId");

                    b.ToTable("teacher", (string)null);
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Class", b =>
                {
                    b.HasOne("StudentManagement.Data.Entities.Department", "Department")
                        .WithMany("Classes")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Score", b =>
                {
                    b.HasOne("StudentManagement.Data.Entities.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Data.Entities.Subject", "Subject")
                        .WithMany("Scores")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Student", b =>
                {
                    b.HasOne("StudentManagement.Data.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("classId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Teacher", b =>
                {
                    b.HasOne("StudentManagement.Data.Entities.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Department", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Student", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("StudentManagement.Data.Entities.Subject", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}