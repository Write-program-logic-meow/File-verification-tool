using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;

namespace File_check
{
    /// <summary>
    /// Setting_interface.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_interface : Window
    {
        public Setting_interface()
        {
            InitializeComponent();
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            // 获取程序的路径
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            // 创建键值
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("File_check", path);
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            // 删除键值
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue("File_check", false);
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            //定义文件路径
            string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/config.dat"));
            //将day写入程序根目录下的data文件夹中的config.dat文件中的第一行
            File.WriteAllText(filePath, "night");
            //弹出窗口询问用户：是否重启程序来切换夜晚模式？
            if (MessageBox.Show("是否重启程序来切换夜晚模式？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //重新启动程序
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }
        }

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            //定义文件路径
            string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data/config.dat"));
            //将day写入程序根目录下的data文件夹中的config.dat文件中的第一行
            File.WriteAllText(filePath, "day");
            //弹出窗口询问用户：是否重启程序来切换白天模式？
            if (MessageBox.Show("是否重启程序来切换白天模式？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //重新启动程序
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }
        }
    }
}
