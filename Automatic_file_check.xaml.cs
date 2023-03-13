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
        
        private void Path1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    // 解析文件路径
                    TextBlock1.Text = file;

                    // 获取文件大小
                    FileInfo fileInfo = new FileInfo(file);
                    double fileSizeInMB = Math.Round(fileInfo.Length / 1024.0 / 1024.0, 2);
                    TextBlock2.Text = fileSizeInMB.ToString() + " MB";

                    // 计算文件哈希值
                    using FileStream fileStream = File.OpenRead(file);
                    using HashAlgorithm md5 = MD5.Create();
                    using HashAlgorithm sha1 = SHA1.Create();
                    using HashAlgorithm sha256 = SHA256.Create();
                    using HashAlgorithm sha512 = SHA512.Create();

                    fileStream.Position = 0;
                    byte[] md5HashBytes = md5.ComputeHash(fileStream);

                    fileStream.Position = 0;
                    byte[] sha1HashBytes = sha1.ComputeHash(fileStream);

                    fileStream.Position = 0;
                    byte[] sha256HashBytes = sha256.ComputeHash(fileStream);

                    fileStream.Position = 0;
                    byte[] sha512HashBytes = sha512.ComputeHash(fileStream);

                    string md5HashString = BitConverter.ToString(md5HashBytes).Replace("-", "");
                    string sha1HashString = BitConverter.ToString(sha1HashBytes).Replace("-", "");
                    string sha256HashString = BitConverter.ToString(sha256HashBytes).Replace("-", "");
                    string sha512HashString = BitConverter.ToString(sha512HashBytes).Replace("-", "");

                    // 显示哈希值
                    TextBlock3.Text = md5HashString;
                    TextBlock4.Text = sha1HashString;
                    TextBlock5.Text = sha256HashString;
                    TextBlock15.Text = sha512HashString;
                }
            }
        }
        
        private void Path2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 获取拖放的文件路径
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string file = files[0];

                // 解析文件信息
                FileInfo fileInfo = new FileInfo(file);
                string filePath = fileInfo.FullName;
                double fileSize = Math.Round(fileInfo.Length / 1024.0 / 1024.0, 2);

                // 计算文件哈希值
                using FileStream fileStream = File.OpenRead(file);
                using HashAlgorithm md5 = MD5.Create();
                using HashAlgorithm sha1 = SHA1.Create();
                using HashAlgorithm sha256 = SHA256.Create();
                using HashAlgorithm sha512 = SHA512.Create();

                byte[] md5HashBytes = md5.ComputeHash(fileStream);
                byte[] sha1HashBytes = sha1.ComputeHash(fileStream);
                byte[] sha256HashBytes = sha256.ComputeHash(fileStream);
                byte[] sha512HashBytes = sha512.ComputeHash(fileStream);

                string md5HashString = BitConverter.ToString(md5HashBytes).Replace("-", "");
                string sha1HashString = BitConverter.ToString(sha1HashBytes).Replace("-", "");
                string sha256HashString = BitConverter.ToString(sha256HashBytes).Replace("-", "");
                string sha512HashString = BitConverter.ToString(sha512HashBytes).Replace("-", "");

                // 显示文件信息
                TextBlock6.Text = filePath;
                TextBlock7.Text = fileSize.ToString();
                TextBlock8.Text = md5HashString;
                TextBlock9.Text = sha1HashString;
                TextBlock10.Text = sha256HashString;
                TextBlock16.Text = sha512HashString;

                // 比对文件信息
                if (TextBlock2.Text == TextBlock7.Text)
                {
                    TextBlock11.Foreground = Brushes.Green;
                    TextBlock11.Text = "文件大小相同";
                }
                else
                {
                    TextBlock11.Foreground = Brushes.Red;
                    TextBlock11.Text = "文件大小不相同";
                }

                if (TextBlock3.Text == TextBlock8.Text)
                {
                    TextBlock12.Foreground = Brushes.Green;
                    TextBlock12.Text = "文件MD5相同";
                }
                else
                {
                    TextBlock12.Foreground = Brushes.Red;
                    TextBlock12.Text = "文件MD5不相同";
                }

                if (TextBlock4.Text == TextBlock9.Text)
                {
                    TextBlock13.Foreground = Brushes.Green;
                    TextBlock13.Text = "文件SHA1相同";
                }
                else
                {
                    TextBlock13.Foreground = Brushes.Red;
                    TextBlock13.Text = "文件SHA1不相同";
                }

                if (TextBlock5.Text == TextBlock10.Text)
                {
                    TextBlock14.Foreground = Brushes.Green;
                    TextBlock14.Text = "文件SHA256相同";
                }
                else
                {
                    TextBlock14.Foreground = Brushes.Red;
                    TextBlock14.Text = "文件SHA256不相同";
                }

                if (TextBlock15.Text == TextBlock16.Text)
                {
                    TextBlock17.Foreground = Brushes.Green;
                    TextBlock17.Text = "文件SHA512相同";
                }
                else
                {
                    TextBlock17.Foreground = Brushes.Red;
                    TextBlock17.Text = "文件SHA512不相同";
                }
            }
        }
    }
}
