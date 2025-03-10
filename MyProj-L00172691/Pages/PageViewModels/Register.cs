using System.ComponentModel.DataAnnotations;

namespace MyProj_L00172691.Pages.PageViewModels
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]

        public string ConfirmPassword { get; set; }
    }
}
