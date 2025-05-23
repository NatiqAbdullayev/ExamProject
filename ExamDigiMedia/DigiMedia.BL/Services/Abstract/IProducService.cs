using DigiMedia.BL.ViewModels;
using DigiMedia.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Services.Abstract;

public interface IProducService
{
    void CreateProduct(CreateProductVM model);
    void UpdateProduct(int id,UpdateProductVM model);
    void Delete(int id);
    Product GetProductById(int id);
    List<Product> GetAllProducts();
    UpdateProductVM MapToViewModel(Product model);
}
