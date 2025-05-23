using DigiMedia.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.DAL.Contexts;

public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
{
    public AppDbContext(DbContextOptions opt):base(opt)
    {
    }

    public DbSet<Product> Items { get; set; }
}
