using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VB.Models
{
    public class Admin
    {
		[Key]
		public int AdminID { get; set; }
		[Required]
		[DisplayName("Name of Admin")]
		public string AdminName { get; set; }
		[Required]
		public string Email { get; set; }

		public string Status { get; set; }
	}
}
