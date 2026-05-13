using System;
using System.Collections.Generic;
using System.Text;

namespace cmasacoS5B.Utils
{
    public class FileAccessHelper
    {
        public static string GetFolderPath(string fileName)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
