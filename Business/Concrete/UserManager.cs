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
            IResult result = BusinessRules.Run(CheckSpecialChar(manager.Password));
            if (result == null)
            {
                return  result;
            }
            else
            {
                await _userDal.AddData(manager);

                return new SuccessResult(Messages.UserAdded);
            }

        }
        public async Task<IResult> Delete(User manager)
        {
            if (false)
            {

            }
            else
            {
                await _userDal.DeleteData(manager);

                return new SuccessResult(Messages.UserDeleted);
            }
        } 
        public async Task<IResult> Update(User manager)
        {
            if (false)
            {
               
            }
            else
            {
                await _userDal.UpdateData(manager);

                return new SuccessResult(Messages.UserUpdated);
            }
        }
        public async Task<IResult> CreateLogin(User manager)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> CreateUser(User manager)
        {
            throw new NotImplementedException();
        }
        public async Task<IDataResult<List<User>>> GetAll()
        {
            return await _userDal.GetAll();
        }

        public async Task<IDataResult<User>> GetById(User managerId)
        {
           
            return new SuccessDataResult<User>();

        }
        public Task<IResult> UpdateProfileImage(User manager)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UploadProfileImage(User manager)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetProfileImage(User manager)
        {
            throw new NotImplementedException();
        }


        //<---------------  BusinessRules  --------------->

        private IResult CheckSpecialChar(string password)
        {
            Regex passwordSymbol = new Regex("[^a-zA-Z0-9]");
            if (!passwordSymbol.IsMatch(password))
            {
                return new  ErrorResult(Messages.CheckSpecialChar);
            }
            else
            {
                return new SuccessResult();
            }
        }

        
    }
}
