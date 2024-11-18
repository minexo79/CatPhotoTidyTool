using System.IO;

namespace Tidy
{
    public static class Utils
    {
        public static string[] extNames { get; } = new string[] { "jpg", "png", "arw", "dng", "cr2" };

        /// <summary>
        /// Get sub folder count
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static uint GetFolderCount(string path)
        {
            return (uint)System.IO.Directory.GetDirectories(path).Length;
        }

        /// <summary>
        /// Get directories
        /// </summary>
        /// <returns>directories array</returns>
        public static string[] GetDirectories(string path)
        {
            List<string> directories = System.IO.Directory.GetDirectories(path).ToList();

            if (directories.Count() == 0)
                directories.Add(path);

            foreach (var directory in directories)
            {
                System.Console.WriteLine(directory);
            }

            return directories.ToArray();
        }
    }
}