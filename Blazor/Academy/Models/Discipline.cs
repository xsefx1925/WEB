using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Academy.Models
{
	public class Discipline
	{
		[Key]
		public short discipline_id { get; set; }
		[Required]
		public string discipline_name { get; set; }
		[Required]
		[Column(TypeName = "tinyint")]
		public short number_of_lessons { get; set; }

	}
}
