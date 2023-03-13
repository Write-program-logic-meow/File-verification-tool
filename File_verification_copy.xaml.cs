using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace File_check
{
    /// <summary>
    /// File_verification_copy.xaml 的交互逻辑
    /// </summary>
    public partial class File_verification_copy : Window
    {
        public File_verification_copy()
        {
            InitializeComponent();
        }

        private void Path1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 获取拖放文件的路径
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                // 计算文件大小并转换为MB
                FileInfo fileInfo = new FileInfo(filePath);
                double fileSizeInMB = Math.Round(fileInfo.Length / 1024.0 / 1024.0, 2);

                // 计算文件哈希值
                using FileStream fileStream = File.OpenRead(filePath);
                using HashAlgorithm md5 = MD5.Create();
                using HashAlgorithm sha1 = SHA1.Create();
                using HashAlgorithm sha256 = SHA256.Create();
                using HashAlgorithm sha512 = SHA512.Create();

                string md5Hash = BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", "");
                fileStream.Position = 0;

                string sha1Hash = BitConverter.ToString(sha1.ComputeHash(fileStream)).Replace("-", "");
                fileStream.Position = 0;

                string sha256Hash = BitConverter.ToString(sha256.ComputeHash(fileStream)).Replace("-", "");
                fileStream.Position = 0;

                string sha512Hash = BitConverter.ToString(sha512.ComputeHash(fileStream)).Replace("-", "");

                // 更新UI元素
                TextBlock1.Text = filePath;
                TextBlock2.Text = fileSizeInMB.ToString() + " MB";
                TextBlock3.Text = md5Hash;
                TextBlock4.Text = sha1Hash;
                TextBlock5.Text = sha256Hash;
                TextBlock6.Text = sha512Hash;
            }
        }


        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            MessageBox.Show("清除完成！");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock1的文本
            string text = TextBlock1.Text;
            // 将文本复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的内容设置为已复制文件路径！
            Label1.Content = "已复制文件路径！";
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock2的文本内容
            string text = TextBlock2.Text;
            // 将文本内容复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的文本内容设置为已复制文件大小！
            Label1.Content = "已复制文件大小！";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock3的文本内容
            string text = TextBlock3.Text;
            // 将文本内容复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的文本内容设置为已复制MD5！
            Label1.Content = "已复制MD5！";
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock4的文本内容
            string text = TextBlock4.Text;
            // 将文本内容复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的文本内容设置为已复制SHA1！
            Label1.Content = "已复制SHA1！";
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock5的文本内容
            string text = TextBlock5.Text;
            // 将文本内容复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的文本内容设置为已复制SHA256！
            Label1.Content = "已复制SHA256！";
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            // 获取TextBlock6的文本内容
            string text = TextBlock6.Text;
            // 将文本内容复制到剪贴板
            Clipboard.SetText(text);
            // 将Label1的文本内容设置为已复制SHA512！
            Label1.Content = "已复制SHA512！";
        }
    }
}
