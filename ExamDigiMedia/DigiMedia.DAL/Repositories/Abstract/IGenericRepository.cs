using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DigiMedia.DAL.Repositories.Abstract;

public interface IGenericRepository<T>
{
    T? GetById(int id);
    IQueryable<T> GetAll();
    void Create(T t);
    void Update(T t);
    void Delete(T t);
    IQueryable<T> GetByCondition(Expression<Func<T,bool>> e);
}
