

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
	public class CourseAssignment
	{
		public int InstructorID { get; set; }
		public int CourseID { get; set; }

		// Навигационные свойства
		public Instructor Instructor { get; set; }
		public Course Course { get; set; }
	}
}