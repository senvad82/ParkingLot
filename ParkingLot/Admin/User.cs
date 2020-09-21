using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public abstract class User
    {
        private Person _person;
        private string _userName;
        private string _password;
        public User(Person person, string userName, string password)
        {
            _person = person;
            _userName = userName;
            _password = password;
        }
    }
}
