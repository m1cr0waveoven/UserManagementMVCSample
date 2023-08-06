using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCSample.Models
{
    public class PersonModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Felhasználónév megadása kötelező!")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "A felhasználónévnek 4 és 15 karakter között kell lennie")]
        [Display(Name = "Felhasználónév")]        
        public string Username { get; set; }
        [Required(ErrorMessage = "Jelszó megadása kötelező!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A jelszónak minimum 5 karakter hosszúnak kell lennie.")]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]        
        public string Password { get; set; }
        [Required(ErrorMessage = "Vezetéknév megadása kötelező!")]
        [Display(Name = "Vezetéknév")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Keresztnév megadása kötelező!")]
        [Display(Name = "Keresztnév")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Születési idő megadása kötelező!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd.}")]
        [Display(Name = "Születési idő")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Születési hely megadása kötelező!")]
        [Display(Name = "Születési hely")]
        public string PlaceOfBirth { get; set; }
        [Required(ErrorMessage = "Lakóhely megadása kötelező!")]
        [Display(Name = "Lakóhely")]
        public string Residence { get; set; }
    }
}
