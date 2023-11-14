using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public interface IGenericRepo<TEntity> where TEntity : class
{
    TEntity? GetById(int id);
    List<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);  
}
