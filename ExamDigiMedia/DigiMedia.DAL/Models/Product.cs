using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.DAL.Models;

public class Product:BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName{ get; set; }
}
