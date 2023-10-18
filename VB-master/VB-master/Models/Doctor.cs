using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VB.Models
{
    public class Doctor
    {
		[Key]
		public int DoctorID { get; set; }
		[Required]
		[DisplayName("Doctor Name")]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

		public string Status { get; set; }
	}
}
