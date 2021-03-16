using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository
    {
        Task<Result> AddData(string entity);

        Task<Result> UpdateData(string entity);

        Task<Result> DeleteData(string entity);

        Task<IDataResult<List<string>>> GetAll();

        Task Get(IGetStringListener getStringListener);


    }
}
