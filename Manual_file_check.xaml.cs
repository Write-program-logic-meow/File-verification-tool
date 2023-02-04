using System;
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                // 如果是快捷方式则弹出一个窗口，显示：请不要将快捷方式拖进来！
                if (Path.GetExtension(files[0]) == ".lnk")
                {
                    MessageBox.Show("请不要将快捷方式拖进来！");
                    return;
                }

                // 如果不是快捷方式，就把拖进来的文件的文件路径显示在TextBlock1上，把文件大小显示在TextBlock2上
                TextBlock1.Text = files[0];
                FileInfo fileInfo = new FileInfo(files[0]);
                double sizeInMB = (double)fileInfo.Length / 1048576;
                TextBlock2.Text = sizeInMB.ToString("0.00") + " MB";

                // 分析拖进来的文件的MD5、SHA1、SHA256的值
                string md5 = GetMD5HashFromFile(files[0]);
                string sha1 = GetSHA1HashFromFile(files[0]);
                string sha256 = GetSHA256HashFromFile(files[0]);

                // 把分析到的MD5、SHA1、SHA256的值分别显示到TextBlock3、TextBlock4、TextBlock5
                TextBlock3.Text = md5;
                TextBlock4.Text = sha1;
                TextBlock5.Text = sha256;
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
        }

        // 获取文件的MD5值
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        // 获取文件的SHA1值
        public static string GetSHA1HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retVal = sha1.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetSHA1HashFromFile() fail,error:" + ex.Message);
            }
        }

        // 获取文件的SHA256值
        public static string GetSHA256HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                byte[] retVal = sha256.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetSHA256HashFromFile() fail,error:" + ex.Message);
            }
        }

    }
}
