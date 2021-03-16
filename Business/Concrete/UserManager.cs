using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> Add(User manager)
        {
            //IResult result = BusinessRules.Run(CheckSpecialChar(manager.password));
            await  _userDal.AddData(manager);

            return new SuccessResult();
        }
        public async Task<IResult> Delete(User manager)
        {
            return await _userDal.DeleteData(manager);
        } 
        public async Task<IResult> Update(User manager)
        {
            return await _userDal.UpdateData(manager);
        }
        public async Task<IResult> CreateLogin()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> CreateUser()
        {
            throw new NotImplementedException();
        }
        public async Task<IDataResult<List<User>>> GetAll()
        {
            return await _userDal.GetAll();
        }

        public async Task<IDataResult<User>> GetById(User managerId)
        {
            throw new NotImplementedException();
        }

        //<---------------  BusinessRules  --------------->

        //private IResult CheckSpecialChar(User user)
        //{
        //    Regex reSymbol = new Regex("[^a-zA-Z0-9]");
        //    if (!reSymbol.IsMatch(user.Password))
        //    {
        //        return new ErrorResult(Messages.CheckSpecialChar);
        //    }
        //    else
        //    {
        //        return new SuccessResult();
        //    }
        //}
    }
}
