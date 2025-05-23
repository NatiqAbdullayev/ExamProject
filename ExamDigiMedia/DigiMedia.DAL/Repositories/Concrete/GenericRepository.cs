using DigiMedia.DAL.Contexts;
using DigiMedia.DAL.Models;
using DigiMedia.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.DAL.Repositories.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel, new()
{
    public readonly AppDbContext _context;
    private readonly DbSet<T> _dbset;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbset = _context.Set<T>();
    }

    private void Save()
    {
        _context.SaveChanges();
    }

    public void Create(T t)
    {
        _dbset.Add(t);
        Save();
    }

    public void Delete(T t)
    {
        _dbset.Remove(t);
        Save();
    }

    public IQueryable<T> GetAll()
    {
        return _dbset;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> e)
    {
        return _dbset.Where(e);
    }

    public T? GetById(int id)
    {
        return _dbset.Find(id);
    }

    public void Update(T t)
    {
        _dbset.Update(t);
        Save();
    }
}
