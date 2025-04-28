using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.Identity
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
