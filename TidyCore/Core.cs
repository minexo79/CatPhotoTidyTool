namespace Tidy
{
    public class Core
    {
        /// <summary>
        /// path to the folder
        /// </summary>
        private string path { get; set; }
        /// <summary>
        /// extension name
        /// </summary>
        private string extName { get; set; }

        /// <summary>
        /// a flag that create a new folder with the extension name and random number
        /// </summary>
        private bool createDiffFolder { get; set; } = false;
        
        /// <summary>
        /// Core Constructor
        /// </summary>
        /// <param name="_path">path to the folder</param>
        /// <param name="_extName">extension name</param>
        public Core(string _path, string _extName)
        {
            path = _path;
            extName = _extName;
        }
        
        /// <summary>
        /// update path and extension name
        /// </summary>
        /// <param name="_path">path to the folder</param>
        /// <param name="_extName">extension name</param>
        public void updatePath(string _path, string _extName)
        {
            path = _path;
            extName = _extName;
        }
        
        /// <summary>
        /// if folder extension name same / created, then create a new folder with the extension name and random number
        /// </summary>
        /// <param name="_createDiffFolder">a flag that create a new folder with the extension name and random number</param>
        public void setCreateDiffFolder(bool _createDiffFolder)
        {
            createDiffFolder = _createDiffFolder;
        }

        /// <summary>
        /// Get files with the specified extension name
        /// </summary>
        /// <param name="extName">extension name</param>
        /// <returns>file array</returns>
        private string[] GetFiles(string extName)
        {
            return System.IO.Directory.GetFiles(path, "*." + extName);
        }
        
        /// <summary>
        /// move files to new folder
        /// </summary>
        /// <returns>return -1 if no files found, otherwise return 0 if move files successfully.</returns>
        public int MoveFilesToNewFolder()
        {
            var files = GetFiles(extName);
            
            if (files.Length == 0)
            {
                // no files found
                return -1;
            }
            
            // create new folder depending on the extension name
            var newPath = $@"{path}/{extName.ToUpper()}";
            
            // if folder not exist / createDiffFolder false, create it
            if (!System.IO.Directory.Exists(newPath) && !createDiffFolder)
                System.IO.Directory.CreateDirectory(newPath);
            else
            {
                // create a new folder with the extension name and random number
                var random = new System.Random();
                newPath = $@"{path}/{extName.ToUpper()}_{random.Next(1000, 9999)}";
                System.IO.Directory.CreateDirectory(newPath);
            }
            
            // move files to the new folders
            foreach (var file in files)
            {
                System.IO.File.Move(file, newPath + "/" + System.IO.Path.GetFileName(file));
            }

            return 0;
        }

        /// <summary>
        /// Copy README To New Folder
        /// </summary>
        public void CopyReadme()
        {
            // current readme.txt path
            var readmePath = System.IO.Directory.GetCurrentDirectory() + @"/README.txt";

            // get new folder path
            var newPath = $@"{path}" + @"/README.txt";

            // if file exist, delete it first
            if (System.IO.File.Exists(newPath))
                System.IO.File.Delete(newPath);

            System.IO.File.Copy(readmePath, newPath);
        }
    }
}