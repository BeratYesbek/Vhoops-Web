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
        Task<IResult> Add(T entity);

        Task<IResult> Update(T entity);

        Task<IResult> Delete(T entity);

        Task<IDataResult<List<T>>> GetAll();

        Task<IDataResult<T>> GetById(string id);



    }
}
