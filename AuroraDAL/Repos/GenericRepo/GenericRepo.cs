using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public GenericRepo(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Generic Crud [ Get All, Get By Id, Add, Update, Delete ] 

    public List<TEntity> GetAll() => appDbContext.Set<TEntity>().ToList();

    public TEntity? GetById(int id) => appDbContext.Set<TEntity>().Find(id);

    public TEntity Add(TEntity entity)
    {
        appDbContext.Set<TEntity>().Add(entity);
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        appDbContext.Set<TEntity>().Update(entity);
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        appDbContext.Set<TEntity>().Remove(entity);
        return entity;
    }

    #endregion

}
