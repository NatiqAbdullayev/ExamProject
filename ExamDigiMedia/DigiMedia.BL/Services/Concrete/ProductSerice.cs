using DigiMedia.BL.Exceptions;
using DigiMedia.BL.Services.Abstract;
using DigiMedia.BL.ViewModels;
using DigiMedia.DAL.Models;
using DigiMedia.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.BL.Services.Concrete;

public class ProductSerice : IProducService
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductSerice(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public void CreateProduct(CreateProductVM model)
    {
        if (model is null)
        {
            throw new ProductException("Product model cannot be null");
        }
        //File rename
        string fileName = Path.GetFileNameWithoutExtension(model.File.FileName);
        string extension = Path.GetExtension(model.File.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;

        //File save

        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages", resultName);
      

        using FileStream stream = new FileStream(path, FileMode.Create);
        model.File.CopyTo(stream);

        //Mapping
        Product product = new Product()
        {
            Title = model.Title,
            Description = model.Description,
            ImageName = resultName
        };
        _productRepository.Create(product);

    }

    public void Delete(int id)
    {
        var entity = GetProductById(id);
        _productRepository.Delete(entity);
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAll().ToList();
    }

    public Product GetProductById(int id)
    {
        var entity = _productRepository.GetById(id);
        if (entity is null)
        {
            throw new ProductException($"Cannot find any entity with this id:{id}");
        }
        return entity;
    }

    public UpdateProductVM MapToViewModel(Product model)
    {
        return new UpdateProductVM()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
        };
    }

    public void UpdateProduct(int id, UpdateProductVM model)
    {
        if (id != model.Id)
        {
            throw new ProductException($"Product {id} is not valid.");
        }

        if (model is null)
        {
            throw new ProductException("Product model cannot be null");
        }

        var entity = GetProductById(id);


        if (model.File is not null)
        {
            //File rename
            string fileName = Path.GetFileNameWithoutExtension(model.File.FileName);
            string extension = Path.GetExtension(model.File.FileName);
            string resultName = fileName + Guid.NewGuid().ToString() + extension;

            //File save

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages", resultName);
           
            using FileStream stream = new FileStream(path, FileMode.Create);
            model.File.CopyTo(stream);
            entity.ImageName = resultName;
        }

        //Mapping
        entity.Title = model.Title;
        entity.Description = model.Description;
        _productRepository.Update(entity);
    }
}
