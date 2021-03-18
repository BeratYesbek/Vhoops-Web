using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        Task<Result> Add(T entity);

        Task<Result> Update(T entity);

        Task<Result> Delete(T entity);

        Task<IDataResult<List<T>>> GetAll();

        Task<IDataResult<T>> GetById(string id);



    }
}
