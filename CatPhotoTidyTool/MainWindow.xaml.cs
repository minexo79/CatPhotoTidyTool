using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatPhotoTidyTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // TODO: Complete And Ingergrated To Main Code
        //static void Main()
        //{
        //    // 原始目錄路徑
        //    string sourceDirectory = @"C:\YourSourceDirectory";  // 這裡換成你的來源資料夾路徑

        //    // 定義目標資料夾
        //    string rawDirectory = Path.Combine(sourceDirectory, "raw");
        //    string jpgDirectory = Path.Combine(sourceDirectory, "jpg");

        //    // 確認目標資料夾是否存在，若不存在則建立
        //    Directory.CreateDirectory(rawDirectory);
        //    Directory.CreateDirectory(jpgDirectory);

        //    // 掃描.ARW與.JPG檔案
        //    string[] arwFiles = Directory.GetFiles(sourceDirectory, "*.ARW", SearchOption.TopDirectoryOnly);
        //    string[] jpgFiles = Directory.GetFiles(sourceDirectory, "*.JPG", SearchOption.TopDirectoryOnly);

        //    // 搬移.ARW檔案到raw資料夾
        //    foreach (string file in arwFiles)
        //    {
        //        string fileName = Path.GetFileName(file);
        //        string destFile = Path.Combine(rawDirectory, fileName);
        //        File.Move(file, destFile);
        //        Console.WriteLine($"Moved: {fileName} to {rawDirectory}");
        //    }

        //    // 搬移.JPG檔案到jpg資料夾
        //    foreach (string file in jpgFiles)
        //    {
        //        string fileName = Path.GetFileName(file);
        //        string destFile = Path.Combine(jpgDirectory, fileName);
        //        File.Move(file, destFile);
        //        Console.WriteLine($"Moved: {fileName} to {jpgDirectory}");
        //    }

        //    // 建立"請先讀我.txt"文件
        //    string readMeFile = Path.Combine(sourceDirectory, "請先讀我.txt");
        //    string readMeContent = "這是系統自動產生的文件，原始的.ARW檔案已移動到raw資料夾，.JPG檔案已移動到jpg資料夾。";
        //    File.WriteAllText(readMeFile, readMeContent);

        //    Console.WriteLine($"Created '請先讀我.txt' in {sourceDirectory}");
        //}
    }
}
