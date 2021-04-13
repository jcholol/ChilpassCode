using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Chilpass
{
    public partial class Chilpass_Main : Form
    {
        public Chilpass_Main()
        {
            InitializeComponent();
        }

        private void NewPasswordFileButton_Click(object sender, EventArgs e)
        {
            var saveDatabaseFile = new SaveFileDialog();
            saveDatabaseFile.Filter = "Database Files (*.db) | *.db ";
            saveDatabaseFile.Title = "Save a Database File";
            saveDatabaseFile.FileName = "NewPasswordFile";

            if (saveDatabaseFile.ShowDialog() == DialogResult.OK)
            {
                //System.IO.FileStream myStream = (System.IO.FileStream)saveDatabaseFile.OpenFile();
            }

            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF();
            }
            NewPasswordFile.ShowDialog();
        }

        private void OpenPasswordFileButton_Click(object sender, EventArgs e)
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
        }

        private void GeneratePasswordButton_Click(object sender, EventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            var help = Application.OpenForms["Help"];
            if (help == null)
            {
                help = new Help();
            }
            help.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
