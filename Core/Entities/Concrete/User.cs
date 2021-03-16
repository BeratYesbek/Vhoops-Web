using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : Person, IEntity
    {
        public User(string firstName, string lastName, string email, string password, string userID, string userUUID) : base(firstName, lastName, email, password, userID, userUUID)
        {

        }
    }
}
