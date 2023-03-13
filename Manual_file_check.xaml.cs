using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace File_check
{
    /// <summary>
    /// Manual_file_check.xaml 的交互逻辑
    /// </summary>
    public partial class Manual_file_check : Window
    {
        public Manual_file_check()
        {
            InitializeComponent();
        }

        private void Path1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 获取拖放的文件路径
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                // 解析文件信息
                FileInfo fileInfo = new FileInfo(filePath);
                string fileSize = (fileInfo.Length / 1024f / 1024f).ToString("F2") + " MB";
                string fileMD5 = GetFileHash(filePath, MD5.Create());
                string fileSHA1 = GetFileHash(filePath, SHA1.Create());
                string fileSHA256 = GetFileHash(filePath, SHA256.Create());
                string fileSHA512 = GetFileHash(filePath, SHA512.Create());

                // 更新UI
                TextBlock1.Text = filePath;
                TextBlock2.Text = fileSize;
                TextBlock3.Text = fileMD5;
                TextBlock4.Text = fileSHA1;
                TextBlock5.Text = fileSHA256;
                TextBlock9.Text = fileSHA512;
            }
        }

        private string GetFileHash(string filePath, HashAlgorithm hashAlgorithm)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                byte[] hashBytes = hashAlgorithm.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 比较TextBox1和TextBlock3的值，如果相同则把TextBlock6的文字变为文件MD5相同并显示成绿色，如果不相同则把TextBlock6的文字变为文件MD5不相同并显示成红色
            if (TextBox1.Text == TextBlock3.Text)
            {
                TextBlock6.Text = "文件MD5相同";
                TextBlock6.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                TextBlock6.Text = "文件MD5不相同";
                TextBlock6.Foreground = System.Windows.Media.Brushes.Red;
            }

            // 比较TextBox2和TextBlock4的值，如果相同则把TextBlock7的文字变为文件SHA1相同并显示成绿色，如果不相同则把TextBlock7的文字变为文件SHA1不相同并显示成红色
            if (TextBox2.Text == TextBlock4.Text)
            {
                TextBlock7.Text = "文件SHA1相同";
                TextBlock7.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                TextBlock7.Text = "文件SHA1不相同";
                TextBlock7.Foreground = System.Windows.Media.Brushes.Red;
            }

            // 比较TextBox3和TextBlock5的值，如果相同则把TextBlock8的文字变为文件SHA256相同并显示成绿色，如果不相同则把TextBlock8的文字变为文件SHA256不相同并显示成红色
            if (TextBox3.Text == TextBlock5.Text)
            {
                TextBlock8.Text = "文件SHA256相同";
                TextBlock8.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                TextBlock8.Text = "文件SHA256不相同";
                TextBlock8.Foreground = System.Windows.Media.Brushes.Red;
            }

            // 比较TextBox4和TextBlock9的值，如果相同则把TextBlock10的文字变为文件SHA512相同并显示成绿色，如果不相同则把TextBlock10的文字变为文件SHA512不相同并显示成红色
            if (TextBox4.Text == TextBlock9.Text)
            {
                TextBlock10.Text = "文件SHA512相同";
                TextBlock10.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                TextBlock10.Text = "文件SHA512不相同";
                TextBlock10.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
    }
}
