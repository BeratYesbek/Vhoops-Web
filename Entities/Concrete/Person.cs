using Core;
using System;

namespace Entities
{
    public class Person : IEntity
    {
        public Person(string firstName, string lastName, string email, string userID, string userUUID) 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserID = userID;
            UserUUID = userUUID;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string UserID { get; }

        public string UserUUID { get; }
    }
}
