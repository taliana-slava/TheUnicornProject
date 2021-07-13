using System;
using System.Collections.Generic;
using System.Text;

namespace UnicornProject.Framework
{
    public class FwConfig
    {
        public DriverSettings Driver { get; set; }

        public TestSettings Test { get; set; }
    }

    public class DriverSettings
    {
        public string Brower { get; set; }
    }

    public class TestSettings
    {
        public string Url { get; set; }
    }
}
