﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MVCApp1._01.Models
{
    public class FirstMvcAppEntities : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Data Source=.;Initial Catalog=MVC_DB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<CourseResult>(
                 l => l.HasOne<Course>().WithMany(e => e.CoursesResults),
                 r => r.HasOne<Student>().WithMany(e => e.CoursesResults));
        }

    }
}
