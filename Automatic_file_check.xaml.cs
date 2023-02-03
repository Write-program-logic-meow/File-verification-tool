using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace File_check
{
    /// <summary>
    /// Automatic_file_check.xaml 的交互逻辑
    /// </summary>
    public partial class Automatic_file_check : Window
    {
        public Automatic_file_check()
        {
            InitializeComponent();
        }

        //获取文件的MD5
        public string GetMD5HashFromFile(string fileName)
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

        //获取文件的SHA1
        public string GetSHA1HashFromFile(string fileName)
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

        //获取文件的SHA256
        public string GetSHA256HashFromFile(string fileName)
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

        //定义Path1的拖拽事件
        private void Path1_DragEnter(object sender, DragEventArgs e)
        {
            //获取拖拽的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //检测是否是快捷方式
            if (Path.GetExtension(files[0]) == ".lnk")
            {
                MessageBox.Show("请不要将快捷方式拖进来！");
            }
            else
            {
                //显示文件路径
                TextBlock1.Text = files[0];
                //获取文件大小
                FileInfo fileInfo = new FileInfo(files[0]);
                double fileSize = fileInfo.Length / (1024.0 * 1024.0);
                TextBlock2.Text = fileSize.ToString("0.00") + " MB";
                //获取文件的MD5、SHA1、SHA256
                string md5 = GetMD5HashFromFile(files[0]);
                string sha1 = GetSHA1HashFromFile(files[0]);
                string sha256 = GetSHA256HashFromFile(files[0]);
                //显示文件的MD5、SHA1、SHA256
                TextBlock3.Text = md5;
                TextBlock4.Text = sha1;
                TextBlock5.Text = sha256;
            }
        }
        //定义Path2的拖拽事件
        private void Path2_DragEnter(object sender, DragEventArgs e)
        {
            //获取拖拽的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //检测是否是快捷方式
            if (Path.GetExtension(files[0]) == ".lnk")
            {
                MessageBox.Show("请不要将快捷方式拖进来！");
            }
            else
            {
                //显示文件路径
                TextBlock6.Text = files[0];
                //获取文件大小
                FileInfo fileInfo = new FileInfo(files[0]);
                double fileSize = fileInfo.Length / (1024.0 * 1024.0);
                TextBlock7.Text = fileSize.ToString("0.00") + " MB";
                //获取文件的MD5、SHA1、SHA256
                string md5 = GetMD5HashFromFile(files[0]);
                string sha1 = GetSHA1HashFromFile(files[0]);
                string sha256 = GetSHA256HashFromFile(files[0]);
                //显示文件的MD5、SHA1、SHA256
                TextBlock8.Text = md5;
                TextBlock9.Text = sha1;
                TextBlock10.Text = sha256;
                //比较文件大小
                if (TextBlock2.Text == TextBlock7.Text)
                {
                    TextBlock11.Text = "文件大小相同";
                    TextBlock11.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlock11.Text = "文件大小不相同";
                    TextBlock11.Foreground = Brushes.Red;
                }
                //比较文件MD5
                if (TextBlock3.Text == TextBlock8.Text)
                {
                    TextBlock12.Text = "文件MD5相同";
                    TextBlock12.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlock12.Text = "文件MD5不相同";
                    TextBlock12.Foreground = Brushes.Red;
                }
                //比较文件SHA1
                if (TextBlock4.Text == TextBlock9.Text)
                {
                    TextBlock13.Text = "文件SHA1相同";
                    TextBlock13.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlock13.Text = "文件SHA1不相同";
                    TextBlock13.Foreground = Brushes.Red;
                }
                //比较文件SHA256
                if (TextBlock5.Text == TextBlock10.Text)
                {
                    TextBlock14.Text = "文件SHA256相同";
                    TextBlock14.Foreground = Brushes.Green;
                }
                else
                {
                    TextBlock14.Text = "文件SHA256不相同";
                    TextBlock14.Foreground = Brushes.Red;
                }
            }
        }
    }
}
