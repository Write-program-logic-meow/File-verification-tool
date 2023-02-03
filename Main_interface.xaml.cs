using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace File_check
{
    /// <summary>
    /// Main_interface.xaml 的交互逻辑
    /// </summary>
    public partial class Main_interface : Window
    {
        public Main_interface()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 实例化 Automatic_file_check 窗口
            Automatic_file_check automaticFileCheckWindow = new Automatic_file_check();

            // 显示 Automatic_file_check 窗口，但不关闭当前窗口
            automaticFileCheckWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   //点击设置按钮，跳转到Setting_interface窗口，并且不关闭当前窗口
            Setting_interface setting_interface = new Setting_interface();
            setting_interface.Show();
        }
    }
}
