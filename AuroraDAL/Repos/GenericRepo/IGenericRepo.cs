using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IGenericRepo<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity? GetById(int id);   
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}
