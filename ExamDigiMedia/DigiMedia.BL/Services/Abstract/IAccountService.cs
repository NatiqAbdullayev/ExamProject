using DigiMedia.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Services.Abstract;

public interface IAccountService
{
    Task<bool> LoginAsync(LoginVM model);
    Task<string> RegisterAsync(RegisterVM model);
    Task LogOutAsync();
    Task CreateAdminAsync();
}
