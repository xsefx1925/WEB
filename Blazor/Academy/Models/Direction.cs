using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Academy.Models
{
	public class Direction
	{
		[Key]
		public int direction_id { get; set; }
		[Required]
		public string direction_name { get; set; }

		// Коллекция групп
		public ICollection<Group> Groups { get; set; } = new List<Group>();
	}
}