using System;
using System.Collections.Generic;
using System.Text;

namespace UnicornProject.TestData
{
    public class UserRepository : IUser
    {
        public User GetDefaultUser()
        {
            return new DefaultUser();
        }
    }
}
