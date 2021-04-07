using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chilpass
{
    public partial class MAIN : Form
    {

        public MAIN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NPFbutton_Click(object sender, EventArgs e)
        {
            var saveDatabaseFile = new SaveFileDialog();
            saveDatabaseFile.Filter = "Database Files (*.db) | *.db ";
            saveDatabaseFile.Title = "Save a Database File";
            saveDatabaseFile.FileName = "NewPasswordFile";

            if (saveDatabaseFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream myStream = (System.IO.FileStream)saveDatabaseFile.OpenFile();
            }

            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF();
            }
            NewPasswordFile.ShowDialog();
        }

        private void OPFbutton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Database Files (*.db) | *.db ";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get path of file
                    filePath = openFileDialog.FileName;

                    //Read contents into a stream
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            var OpenPasswordFile = Application.OpenForms["OPF"];
            if (OpenPasswordFile == null)
            {
                OpenPasswordFile = new OPF();
            }
            OpenPasswordFile.ShowDialog();
        }

        private void GPbutton_Click(object sender, EventArgs e)
        {

        }

        private void HELPbutton_Click(object sender, EventArgs e)
        {
            var help = Application.OpenForms["Help"];
            if (help == null)
            {
                help = new Help();
            }
            help.ShowDialog();
        }

        private void EXITbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
