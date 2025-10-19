using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Academy.Models
{
	public class Student
	{
		[Key]
		public int student_id { get; set; }
		[Required]
		public string first_name { get; set; }
		[Required]
		public string last_name { get; set; }
		public int group_id { get; set; }
		// Навигационное свойство для связи с таблицей Group
		public Group? Group { get; set; }
	}
}