using DigiMedia.BL.Services.Abstract;
using DigiMedia.BL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiMedia.PL.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IProducService _producService;

    public ProductController(IProducService producService)
    {
        _producService = producService;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return View(_producService.GetAllProducts());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateProductVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        //if (!model.File.ContentType.Equals("image"))
        //{
        //    ModelState.AddModelError(string.Empty, "File must be image format");
        //    return View(model);
        //}

        _producService.CreateProduct(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        return View(_producService.MapToViewModel(_producService.GetProductById(id)));
    }

    [HttpPost]
    public IActionResult Update(int id, UpdateProductVM model)
    {
        
        
        _producService.UpdateProduct(id, model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _producService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
