using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
	public class Teacher
	{
		[Key]
		public int teacher_id { get; set; }
		[Required]
		public string first_name { get; set; }
		[Required]
		public string last_name { get; set; }
		public string? email { get; set; }
	}
}