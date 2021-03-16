using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceRepository<T>
    {
        Task<IResult> Add(T manager);
        Task<IResult> Delete(T manager);
        Task<IResult> Update(T manager);
        Task<IDataResult<T>> GetById(T managerId);
        Task<IDataResult<List<T>>> GetAll();


    }
}
