using System;
using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using Tidy;

namespace CatPhotoTidyTool.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] 
        private string filePath = String.Empty;

        [ObservableProperty] 
        private uint dirCount = 100;

        [ObservableProperty] 
        private bool generateReadme = false;

        [ObservableProperty] 
        private bool openFolderWhenComplete = false;

        [ObservableProperty]
        private ushort progressValue = 0;

        [ObservableProperty] 
        private string appStatus = String.Empty;

        private Core core;

        [RelayCommand]
        private void SelectFolder()
        {
            // Create a folder browser dialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "Select a folder to tidy up"
            };

            // Show the dialog
            DialogResult result = folderBrowserDialog.ShowDialog();

            // If the user selects a folder
            if (result == DialogResult.OK)
            {
                // Set the filePath to the selected folder
                FilePath = folderBrowserDialog.SelectedPath;

                // Get Folder Count
                DirCount = Utils.GetFolderCount(FilePath);

                if (DirCount > 0)
                    AppStatus = $"發現到 {DirCount} 個子資料夾。";
                else
                {
                    AppStatus = $"以當前資料夾進行整理。";
                    DirCount = 1;
                }

                ProgressValue = 0;
            }
        }

        [RelayCommand]
        private void OpenFolder()
        {
            if (FilePath == string.Empty)
            {
                MessageBox.Show("Please select a folder first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Call Explorer to open the folder
            Process process = new Process();
            process.StartInfo.FileName = "explorer.exe";
            process.StartInfo.Arguments = FilePath;
            process.Start();
        }

        [RelayCommand]
        private void Run()
        {
            // Get Directories
            var directories = Utils.GetDirectories(FilePath);

            AppStatus = $"整理中，請稍後...";

            foreach (var subFolder in directories)
            {
                foreach (var extName in Utils.extNames)
                {
                    if (core == null)
                        core = new Core(subFolder, extName);
                    else
                        core.updatePath(subFolder, extName);

                    core.MoveFilesToNewFolder();
                }

                // Copy README To New Folder
                if (GenerateReadme)
                {
                    core.CopyReadme();
                }

                ProgressValue += 1;
            }

            AppStatus = $"整理完畢!";

            if (OpenFolderWhenComplete)
            {
                OpenFolder();
            }
        }

        [RelayCommand]
        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        [RelayCommand]
        private void EditReadme()
        {
            // if not exist, create a new readme.txt
            if (!System.IO.File.Exists("README.txt"))
            {
                System.IO.File.Create("README.txt").Close();
            }

            // open readme.txt using notepad
            Process.Start("notepad.exe", "README.txt");
        }

        [RelayCommand]
        private void ShowHelp()
        {
            String helpMessage = "CatPhotoTidyTool\n" +
                                 "Version: " + Global.AppVersion + "\n" +
                                 "Author: " + Global.AppAuthor;

            MessageBox.Show(helpMessage, "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}