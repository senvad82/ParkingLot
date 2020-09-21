using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class AdminUser: User
    {
        public AdminUser(Person person, string userName, string password):base(person, userName, password)
        {

        }

        public void AddUser(Person person, string userName, string password)
        {
            
        }

        public void RemoveUser(string userName)
        {

        }       


    }
}
