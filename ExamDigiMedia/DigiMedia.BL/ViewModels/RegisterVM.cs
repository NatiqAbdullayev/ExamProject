using System.ComponentModel.DataAnnotations;

namespace DigiMedia.BL.ViewModels;

public class RegisterVM {
    [Required(ErrorMessage ="Email cannot be empty")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage ="Username cannot be empty")]
    [MinLength(6)]
    public string Username{ get; set; }
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }

}