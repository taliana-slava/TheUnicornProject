using System;
using System.Collections.Generic;
using System.Text;

namespace UnicornProject.TestData
{
    public class DefaultUser: User
    {
        public override string Login { get; set; } = "italiana.slava@gmail.com";

        public override string Password { get; set; } = "UniquePassword";
    }
}
