using DigiMedia.BL.Services.Abstract;
using DigiMedia.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigiMedia.PL.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result = await _accountService.LoginAsync(model);

        if (!result)
        {
            ModelState.AddModelError(string.Empty,"Wrong email or password");
            return View(model);
        }

        return RedirectToAction(nameof(Index), "Home");
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result =await _accountService.RegisterAsync(model);
        if (!result.Equals("OK"))
        {
            ModelState.AddModelError(string.Empty,result);
            return View(model);
        }
        return RedirectToAction(nameof(Index),"Home");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogOutAsync();
        return RedirectToAction(nameof(Index), "Home");
    }
}
