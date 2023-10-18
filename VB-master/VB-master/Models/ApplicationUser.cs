using Microsoft.AspNetCore.Identity;
namespace VB.Models
{
    public class ApplicationUser:IdentityUser
    {
        //public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
