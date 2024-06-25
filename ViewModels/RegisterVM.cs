using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels
{
    public class RegisterVM
    {
        //Data Annotation
        [EmailAddress]
        [Required(ErrorMessage ="Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Confirm Password")]
        [Required(ErrorMessage ="Please Enter Confirm Password")]
        [Compare("Password",ErrorMessage ="password and confirm password not matched")]
        public string ConfirmPassword { get; set; }
    }
}
