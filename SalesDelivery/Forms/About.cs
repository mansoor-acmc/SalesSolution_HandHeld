using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace SalesDelivery.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var titleAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
                 .OfType<AssemblyTitleAttribute>()
                 .FirstOrDefault();

            var descriptionAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                 .OfType<AssemblyDescriptionAttribute>()
                 .FirstOrDefault();

            FileInfo  fi = new FileInfo(Path.GetDirectoryName(assembly.GetName().CodeBase) + "\\SalesOrderDB.sdf");
            
            lbName.Text = titleAttribute.Title;
            lbDesc.Text = descriptionAttribute.Description;
            lbVersion.Text = AppVariables.VersionNumber;
            lbDbFile.Text = "DB=" + fi.Name + Environment.NewLine + "Size=" + ((decimal)fi.Length / (1024 * 1024)).ToString("n3") + "MB";
        }
    }
}