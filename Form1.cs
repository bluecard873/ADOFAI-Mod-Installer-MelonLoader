using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModInstaller
{
    public partial class Form1 : Form
    {
        object adofaidir;



        public Form1()
        {
            InitializeComponent();
            
            

            try
            {
                adofaidir = Registry.CurrentUser.OpenSubKey("ModInstaller").GetValue("ADOFAIDir");
            }
            catch (Exception)
            {
                //nothing
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                RegistryKey rkey = Registry.CurrentUser.CreateSubKey("ModInstaller");
                rkey.SetValue("ADOFAIDir", folderBrowserDialog1.SelectedPath);
                adofaidir = folderBrowserDialog1.SelectedPath;

            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "dll 파일 (*.dll)|*.dll";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string source_file = openFileDialog1.FileName;
                string dest_file = Path.Combine(adofaidir.ToString(), "mods", Path.GetFileName(openFileDialog1.FileName));
                File.Copy(source_file, dest_file, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(adofaidir.ToString(), "Mods"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.Combine(adofaidir.ToString(), "Mods");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Delete(openFileDialog1.FileName);
            }
        }
    }
}
