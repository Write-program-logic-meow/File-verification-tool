using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace File_check
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // 在程序启动时执行
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 获取程序根目录
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            // 拼接data文件夹的路径
            string dataPath = Path.Combine(appPath, "data");
            // 检测是否存在data文件夹，如果不存在则创建
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            // 拼接config.xml文件的路径
            string configPath = Path.Combine(dataPath, "config.xml");
            // 检测是否存在config.xml文件，如果不存在则创建
            if (!File.Exists(configPath))
            {
                // 创建一个XmlDocument对象
                XmlDocument doc = new XmlDocument();
                // 创建一个根节点config
                XmlElement root = doc.CreateElement("config");
                // 将根节点添加到文档中
                doc.AppendChild(root);
                // 创建一个子节点language
                XmlElement language = doc.CreateElement("language");
                // 将子节点添加到根节点中
                root.AppendChild(language);
                // 保存文档到指定路径
                doc.Save(configPath);
            }
        }
    }
}
