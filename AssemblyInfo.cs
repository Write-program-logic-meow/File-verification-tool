using System.Windows;
using System.IO;
using File_check;
using System;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

namespace File_check
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            //检测程序根目录中是否有data文件夹，如果没有则创建一个data文件夹
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(rootPath, "data");
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            //检测程序根目录中的data文件夹里面是否有config.dat文件，如果没有则创建一个config.dat文件
            string configPath = Path.Combine(dataPath, "config.dat");
            if (!File.Exists(configPath))
            {
                File.Create(configPath);
            }
        }
    }
}