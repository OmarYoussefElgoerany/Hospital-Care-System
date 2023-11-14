

using Microsoft.EntityFrameworkCore;

namespace HospitalCareSystem.DAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    private readonly HospitalContext context;

    public GenericRepo(HospitalContext context)
    {
        this.context = context;
    }
    public List<TEntity> GetAll() => context.Set<TEntity>().ToList();
    public TEntity? GetById(int id) => context.Set<TEntity>().Find(id);

    public void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
      context.Set<TEntity>()
            .Update(entity);
    }


    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }
}
