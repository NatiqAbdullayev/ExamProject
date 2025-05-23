using System.ComponentModel.DataAnnotations;

namespace DigiMedia.BL.ViewModels;

public class LoginVM
{

    [Required(ErrorMessage ="Invalid username or email")]
    public string UsernameOrEmail { get; set; }

    [Required(ErrorMessage ="Invalid password")]
    public string Password { get; set; }


}
