using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.Identity
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
