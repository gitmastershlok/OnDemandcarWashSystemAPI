using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnDemandcarWashSystemAPI.Models
{
	public class WashPackage
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }

		[JsonIgnore]
		public IEnumerable<AddOn>? AddOn { set; get; }
	}
}
