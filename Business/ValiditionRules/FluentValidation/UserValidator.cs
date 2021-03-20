using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValiditionRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().Must(CheckIfJustLetters).WithMessage(Messages.CheckIfJustLetters);
            RuleFor(u => u.LastName).NotEmpty().Must(CheckIfJustLetters).WithMessage(Messages.CheckIfJustLetters);
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();


            RuleFor(u => u.Password).MinimumLength(8);
            //RuleFor(u => u.Password).Must(CheckSpecialChar).WithMessage("Şifreniz en az bir özel karakter içermelidir.");


        }

        //private bool CheckSpecialChar(string arg)
        //{
        //    Regex passwordSymbol = new Regex("[^a-zA-Z0-9]");
        //    if (!passwordSymbol.IsMatch(arg))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        private bool CheckIfJustLetters(string name)
        {
            Regex passwordSymbol = new Regex(@"^[a-zA-Z]*$");
            if (!passwordSymbol.IsMatch(name))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
