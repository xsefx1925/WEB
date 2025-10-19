using Mono.TextTemplating;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
	public class Group
	{
		[Key]
		public int group_id { get; set; }
		[Required]
		public string group_name { get; set; }
		public int direction_id { get; set; }
		
		public Direction? Direction { get; set; }
	
		public ICollection<Student> Students { get; set; } = new List<Student>();
	}
}