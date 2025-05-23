using Microsoft.AspNetCore.Http;

namespace DigiMedia.BL.ViewModels;

public class UpdateProductVM {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
}
