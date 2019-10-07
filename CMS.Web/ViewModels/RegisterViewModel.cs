using System.ComponentModel.DataAnnotations;

namespace CMS.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        //[RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email Format Invalid")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}