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
        * Open the FileForm form passing encryptiokn key and file destination
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

        /*
        * Open the NPF form, passing filepath data
        */
        public static void OpenNPF(string filepath)
        {
            var NewPasswordFile = Application.OpenForms["NPF"];
            if (NewPasswordFile == null)
            {
                NewPasswordFile = new NPF(filepath);
            }
            NewPasswordFile.ShowDialog();
        }

        /*
        * Open the OPF form, passing filepath data, bytes and hash
        */
        public static void OpenOPF(string filePath, string oldSalt, string oldHash)
        {
            var openPasswordFile = Application.OpenForms["OPF"];
            if (openPasswordFile == null)
            {
                // encoding for unicode string to bytes
                byte[] bytes = Encoding.Unicode.GetBytes(oldSalt);
                // pass data to new form
                openPasswordFile = new OPF(filePath, bytes, oldHash);
            }

            openPasswordFile.ShowDialog();
        }

        /*
        * Open the Help form
        */
        public static void OpenHelpForm()
        {
            var help = Application.OpenForms["Help"];
            if (help == null)
            {
                help = new Help();
            }
            help.ShowDialog();
        }

        /*
         * Open the NewPasswordForm, passing encryption data and filepath destination
         */
        public static void OpenNewPasswordForm(string encryptionKey, string filepath)
        {
            var NewPassword = Application.OpenForms["NewPassword"];
            if (NewPassword == null)
            {
                // encryption and filepath destination to new form
                NewPassword = new NewPassword(encryptionKey, filepath);
            }
            NewPassword.ShowDialog();
        }

        /*
        * Open the GeneratePassword form
        */
        public static void OpenGeneratePasswordForm()
        {
            var generatePassword = Application.OpenForms["GeneratePasswordForm"];
            if (generatePassword == null)
            {
                generatePassword = new GeneratePasswordForm();
            }
            generatePassword.ShowDialog();
        }
    }
}
