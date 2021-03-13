using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User : Person, IEntity
    {
        public User(string firstName, string lastName, string email, string userID, string userUUID) : base(firstName, lastName, email, userID, userUUID)
        {

        }
    }
}
