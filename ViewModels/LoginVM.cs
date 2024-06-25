using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels
{
    public class LoginVM
    {
        //Data Annotation
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
