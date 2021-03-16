using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentService_UsingConsul.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Batch { get; set; }
        public int Marks { get; set; }
    }
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }
        public DbSet<Student> Students { get; set; }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().
                HasData(new Student
                {   Id=1,
                    Name = "Ajay",
                    Batch = "B001",
                    Marks = 90
                }, new Student
                {
                    Id=2,
                    Name = "Deepak",
                    Batch = "B002",
                    Marks = 98
                }
                );

        }
    }
}
