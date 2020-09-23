using System.ComponentModel.DataAnnotations;

namespace HealthcareMember360.Core
{
    public class MemberRequest
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "SSN is required")]
        public string SSN { get; set; }
    }
}
