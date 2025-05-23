using DigiMedia.BL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiMedia.PL.Controllers;

[Authorize(Roles ="Admin,Member")]
public class HomeController : Controller
{
    private readonly IProducService _producService;

    public HomeController(IProducService producService)
    {
        _producService = producService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_producService.GetAllProducts());
    }
}
