using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnDemandcarWashSystemAPI.Models
{
	public class Car
	{
		[Key]
		[DataType("int")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Model { get; set; }
		public string? Status { get; set; }
	}
}
