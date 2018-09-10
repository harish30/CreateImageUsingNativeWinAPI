using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Forms;

namespace TestImageCreation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> filePaths;
        private void Browse_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            if (!string.IsNullOrEmpty(folderDialog.SelectedPath) && DoesFolderHaveSymbols(folderDialog.SelectedPath))
            {
                FolderBox.Text = folderDialog.SelectedPath;
                PopulatePictureBox();
            }
            else
                MessageBox.Show("Select a valid folder Path");
        }

        private void PopulatePictureBox()
        {

            //ElementHost elementHost = new ElementHost();

            //IgrTOOLS412.IgrListView412 toold = new IgrTOOLS412.IgrListView412();
            //toold.Style = 0;
            //toold.WriteIconCacheToFile = false;

            //if (filePaths.Any())
            //    for (int i = 0; i< filePaths.Count; i++)
            //    {
            //        toold.ListItems.Add(i, Path.GetDirectoryName(filePaths[i]) + @"\" +Path.GetFileNameWithoutExtension(filePaths[i]) , Path.GetFileNameWithoutExtension(filePaths[i]));
            //    }

            //elementHost.TabIndex = 0;
            //elementHost.Child = toold;
            //this.WindowsFormHost1.Child = elementHostPartial;
            Image bMap = null;
           // IconHelper icoHelper = new IconHelper();
            if (filePaths.Any())
                for (int i = 0; i < filePaths.Count; i++)
                {
                    bMap = Helper.GetFileImage(filePaths[i], Helper.IconSizeType.Large, new Size(128, 128));
                    bMap.Save("c:\\Temp\\" + Path.GetFileNameWithoutExtension(filePaths[i]) + ".jpg");
                }
        }

        private bool DoesFolderHaveSymbols(string selectedPath)
        {
            var directory = new DirectoryInfo(selectedPath);

            FileSystemInfo[] items = directory.GetFileSystemInfos("*.sym");
            if (!items.Any()) return false;

            filePaths = new List<string>();
            filePaths.AddRange(items.Select(item => item.FullName));
            return true;
        }
    }
}
