

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
	public class Course
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Display(Name = "Номер")] 
		public int CourseID { get; set; }

		public string Title { get; set; }

		public int Credits { get; set; }

		// Navigation properties:
		public ICollection<Enrollment> Enrollments { get; set; }
		public ICollection<CourseAssignment> CourseAssignments { get; set; } 
	}
}