
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VB.Models
{
    public class Staff
    {
		[Key]
		public int StaffID { get; set; }
		[Required]
		[DisplayName("Name of Staff")]
		public string StaffName { get; set; }
		
		public string StaffDescription { get; set; }
		
		public string Status { get; set; }
	}
}
