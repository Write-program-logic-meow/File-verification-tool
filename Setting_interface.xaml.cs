using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace File_check
{
    /// <summary>
    /// Setting_interface.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_interface : Window
    {
        private const string AutoStartKey = "File_check";
        private readonly RegistryKey _autoStartKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private const string ConfigFilePath = "data\\config.dat";

        public Setting_interface()
        {
            InitializeComponent();
            // 读取config.dat文件的第二行，判断CheckBox1的状态
            if (File.Exists(ConfigFilePath))
            {
                string[] lines = File.ReadAllLines(ConfigFilePath);
                if (lines.Length >= 2)
                {
                    string checkBoxLine = lines[1];
                    if (checkBoxLine == "CheckBox1=1")
                    {
                        CheckBox1.IsChecked = true;
                    }
                    else if (checkBoxLine == "CheckBox1=0")
                    {
                        CheckBox1.IsChecked = false;
                    }
                }
            }
            CheckBox1.Checked += CheckBox1_Checked;
            CheckBox1.Unchecked += CheckBox1_Unchecked;
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            // 勾选CheckBox1时，将程序设置为开机启动
            _autoStartKey.SetValue(AutoStartKey, System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            // 将CheckBox1=1写入config.dat文件的第二行
            string[] lines;
            if (File.Exists(ConfigFilePath))
            {
                lines = File.ReadAllLines(ConfigFilePath);
            }
            else
            {
                lines = new string[] { "", "" };
            }

            if (lines.Length < 2)
            {
                Array.Resize(ref lines, 2);
            }

            lines[1] = "CheckBox1=1";
            File.WriteAllLines(ConfigFilePath, lines);
        }

        
        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            // 取消勾选CheckBox1时，取消程序的开机启动
            _autoStartKey.DeleteValue(AutoStartKey, false);

            // 将CheckBox1=0写入config.dat文件的第二行
            string[] lines = File.ReadAllLines(ConfigFilePath);
            lines[1] = "CheckBox1=0";
            File.WriteAllLines(ConfigFilePath, lines);
        }
    }
}
