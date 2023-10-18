using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VB.Models
{
    public class Specialist
    {
		[Key]
		public int SpecialistID { get; set; }
		[Required]
		[DisplayName("Specialist Name")]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

		public string Status { get; set; }
	}
}
