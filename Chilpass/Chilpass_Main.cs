using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;


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
            saveDatabaseFile.Filter = "Database Files (*.db) | *.db";
            saveDatabaseFile.Title = "Save a Database File";
            saveDatabaseFile.FileName = "NewPasswordFile";
            string filepath = null;

            if (saveDatabaseFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream myStream = (System.IO.FileStream)saveDatabaseFile.OpenFile();
                filepath = saveDatabaseFile.FileName;
            }

            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF();
            }
            NewPasswordFile.ShowDialog();


            string temp = filepath.Substring(0, filepath.Length - 2);
            temp += "txt";

            if (!File.Exists(filepath))
            {
                File.Create(temp).Close();
                using (StreamWriter sw = File.AppendText(temp))
                {
                    sw.WriteLine(filepath);
                    sw.WriteLine(NPF.GetSalt());
                    sw.WriteLine(NPF.GetHash());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(temp))
                {
                    sw.WriteLine(filepath);
                    sw.WriteLine(NPF.GetSalt());
                    sw.WriteLine(NPF.GetHash());
                }
            }


            OpenPasswordFileForm();
        }

        private void OpenPasswordFileButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            bool authorized = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Database Files (*.db) | *.db";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get path of file
                    filePath = openFileDialog.FileName;
                }
            }

            string textFile = filePath.Substring(0, filePath.Length - 2);
            textFile += "txt";

            if (File.Exists(textFile))
            {
                StreamReader sr = new StreamReader(textFile);
                string associatedFile = sr.ReadLine();
                string oldSalt = sr.ReadLine();
                string oldHash = sr.ReadLine();
                sr.Close();

                

                var openPasswordFile = Application.OpenForms["OPF"];
                if (openPasswordFile == null)
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(oldSalt);
                    openPasswordFile = new OPF(associatedFile, bytes, oldHash);
                }

                openPasswordFile.ShowDialog();
            }
            else
            {
                // some error
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

        /*
        * Open the FileForm form and close the current form.
        */
        private void OpenPasswordFileForm()
        {
            var NewPasswordFile = Application.OpenForms["FileForm"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new FileForm();
            }
            NewPasswordFile.ShowDialog();
        }
    }
}
