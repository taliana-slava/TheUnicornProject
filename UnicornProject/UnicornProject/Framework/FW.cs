using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnicornProject.Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../");

        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";

            if(Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

    }
}
