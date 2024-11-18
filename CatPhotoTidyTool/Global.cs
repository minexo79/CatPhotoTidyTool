using System.Reflection;

namespace CatPhotoTidyTool
{
    public class Global
    {
        public static string AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string AppAuthor = "TsaiXO (minexo79@gmail.com)";
    }
}