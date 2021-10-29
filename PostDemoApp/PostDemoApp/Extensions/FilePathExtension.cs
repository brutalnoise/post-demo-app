using System;
using System.IO;

namespace PostDemoApp.Extensions
{
    public static class FilePathExtensions
    {
        public static string AbsolutePathToJsonFile(Type type)
        {
            var suffix = ".json";

            var systemPath = Environment.
                GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData
                );

            var fileName = $"{type.Name.ToLower()}{suffix}";

            return Path.Combine(systemPath, fileName);
        }
    }
}
