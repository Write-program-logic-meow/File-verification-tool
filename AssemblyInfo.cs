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
            
            //�������Ŀ¼���Ƿ���data�ļ��У����û���򴴽�һ��data�ļ���
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(rootPath, "data");
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            //�������Ŀ¼�е�data�ļ��������Ƿ���config.dat�ļ������û���򴴽�һ��config.dat�ļ�
            string configPath = Path.Combine(dataPath, "config.dat");
            if (!File.Exists(configPath))
            {
                File.Create(configPath);
            }
        }
    }
}