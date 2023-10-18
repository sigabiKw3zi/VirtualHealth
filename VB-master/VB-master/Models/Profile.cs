using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VB.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace VB.Models
{
    public class Profile
    {
		[Key]
		public int ProfileID { get; set; }
		[Required]
		[DisplayName("Full Name")]
		public string UserName { get; set; }
		[Required]
        
		public int Age { get; set; }
		[Required]
        [EmailAddress]
		public string Email { get;set; }
        
        [Phone]
		public string Phone { get; set; }
        [Required]
		public string City { get; set; }
		[Required]
		public int PostalCode { get; set; }
      
        [NotMapped]
        public Image Image { get; set; }
        public DateTime MemberSince { get; set; }
		public string Role { get; set; }
	}
}
