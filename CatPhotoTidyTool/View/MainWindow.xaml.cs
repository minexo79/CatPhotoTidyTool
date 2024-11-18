using System;
using System.Windows;
using CatPhotoTidyTool.ViewModel;

namespace CatPhotoTidyTool.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = mainWindowViewModel;
        }
    }
}
