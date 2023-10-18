using Microsoft.AspNetCore.Identity.UI.Services;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;//i removed it


namespace VB.Models
{
    public class Bookings
    {
		[Key]
        public int Id { get; set; }
		[Required(ErrorMessage = "Please enter your name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter your surname")]
		public string Surname { get; set; }
        
        //IEmailSender EmailSender { get; set; }
		
        [Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Required]
		[DataType(DataType.Time)]
		public TimeSpan Time { get; set; }

		public string Vanue { get; set; }

		[Required]
		public int Duration { get; set; }

		[Required]
		public string Type { get; set; }

		//public List<SelectListItem> DurationOptions { get; set; }

	}
  
}

