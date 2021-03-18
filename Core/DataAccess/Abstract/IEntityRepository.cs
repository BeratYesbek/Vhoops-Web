using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        Task<Result> AddData(T entity);

        Task<Result> UpdateData(T entity);

        Task<Result> DeleteData(T entity);

        Task<IDataResult<List<T>>> GetAll();

        Task<IDataResult<List<T>>> GetById(string id);



    }
}
