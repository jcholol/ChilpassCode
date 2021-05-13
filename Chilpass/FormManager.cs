using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Chilpass
{
    /*
     * Creators: Jonathan Cho and Hans Wilter
     * FormManager Class
     * Summary: Contains static methods for form management.
     *      Methods for opening Form Windows
     * 
     */
    class FormManager
    {
        /*
        * Open the FileForm form and close the current form.
        */
        public static void OpenPasswordFileForm(string encrypKey, string file)
        {
            var NewPasswordFile = Application.OpenForms["FileForm"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new FileForm(encrypKey, file);
            }
            NewPasswordFile.ShowDialog();
        }

        public static void OpenNPF(string filepath)
        {
            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF(filepath);
            }
            NewPasswordFile.ShowDialog();
        }

        public static void OpenOPF(string filePath, string oldSalt, string oldHash)
        {
            var openPasswordFile = Application.OpenForms["OPF"];
            if (openPasswordFile == null)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(oldSalt);
                openPasswordFile = new OPF(filePath, bytes, oldHash);
            }

            openPasswordFile.ShowDialog();
        }

        public static void OpenHelpForm()
        {
            var help = Application.OpenForms["Help"];
            if (help == null)
            {
                help = new Help();
            }
            help.ShowDialog();
        }

        public static void OpenNewPasswordForm(string encryptionKey, string filepath)
        {
            var NewPassword = Application.OpenForms["NewPassword"];
            if (NewPassword == null)
            {
                NewPassword = new NewPassword(encryptionKey, filepath);
            }
            NewPassword.ShowDialog();
        }
    }
}
