using DigiMedia.BL.Exceptions;
using DigiMedia.BL.Services.Abstract;
using DigiMedia.BL.ViewModels;
using DigiMedia.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Services.Concrete;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _singInManager;
    public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> singInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _singInManager = singInManager;
    }

    public async Task CreateAdminAsync()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new AppRole() { Name = "Admin" });
        }
        if (!await _roleManager.RoleExistsAsync("Member"))
        {
            await _roleManager.CreateAsync(new AppRole() { Name = "Member" });
        }

        var appUser = new AppUser() { Email = "admin@gmail.com", UserName = "admin" };

        var user = await _userManager.FindByEmailAsync(appUser.Email) ?? await _userManager.FindByNameAsync(appUser.UserName);
        if (user is null)
        {
            var res = await _userManager.CreateAsync(appUser, "Admin.123");
        }
        await _userManager.AddToRoleAsync(appUser, "Admin");
    }

    public async Task<bool> LoginAsync(LoginVM model)
    {
        if (model is null)
        {
            throw new AccountException("Register model cannot be null");
        }

        var user = await _userManager.FindByEmailAsync(model.UsernameOrEmail) ?? await _userManager.FindByNameAsync(model.UsernameOrEmail);
        if (user is null)
        {
            return false;
        }

        var isValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!isValid)
        {
            return false;
        }

        await _singInManager.SignInAsync(user, isPersistent: true);
        return isValid;
    }

    public async Task LogOutAsync()
    {
        await _singInManager.SignOutAsync();
    }

    public async Task<string> RegisterAsync(RegisterVM model)
    {
        if (model is null)
        {
            throw new AccountException("Register model cannot be null");
        }

        AppUser user = new AppUser() { UserName = model.Username, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            string s = string.Empty;
            foreach (var item in result.Errors) { s += item.Description + "\n"; }
            return s;
        }
        await _userManager.AddToRoleAsync(user, "Member");
        return "OK";
    }
}
