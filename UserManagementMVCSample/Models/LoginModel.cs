using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCSample.Models
{
    public class LoginModel
    {
        string _username = string.Empty;
        string _password = string.Empty;

        [Required(ErrorMessage = "Felhaszálónév megadása kötelezős!")]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Felhasználónév")]
        public string UserName { get => _username; set => _username = value; }
        [Required(ErrorMessage ="Jelszó megadása kötelező!")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength = 4)]
        [Display(Name = "Jelszó")]
        public string Password
        {
            get => _password; set => _password = value;
        }
    }
}
