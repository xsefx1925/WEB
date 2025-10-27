

using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 

namespace ContosoUniversity.Data
{
	public class UniversityContext : DbContext
	{
		public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

		public DbSet<Course> Courses { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Enrollment> Enrollments { get; set; }

		public DbSet<Instructor> Instructors { get; set; } 
		public DbSet<CourseAssignment> CourseAssignments { get; set; } 
																	   // DbSet<OfficeAssignment> OfficeAssignments { get; set; } // Если добавляли

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<Course>().ToTable("Course");
			modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
			modelBuilder.Entity<Student>().ToTable("Student");
			modelBuilder.Entity<Instructor>().ToTable("Instructor");
			modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment"); 

			
			modelBuilder.Entity<CourseAssignment>()
				.HasKey(c => new { c.CourseID, c.InstructorID });
		}
	}
}
