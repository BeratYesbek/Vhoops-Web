using Core;
using Core.DataAccess.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceRepository<T> : IEntityRepository<T>
        where T : class , IEntity
    {



    }
}
