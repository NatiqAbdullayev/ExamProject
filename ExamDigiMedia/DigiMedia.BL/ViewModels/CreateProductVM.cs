using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.ViewModels;

public class CreateProductVM
{
    [Required(ErrorMessage ="Cannot be empty")]
    [MaxLength(10)]
    public string Title{ get; set; }
    
    [Required(ErrorMessage = "Cannot be empty")]
    [MaxLength(35)]
    public string Description{ get; set; }

    [Required]
    public IFormFile File{ get; set; }
}
