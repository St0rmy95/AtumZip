using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AtumZip
{
    public partial class SettingsDlg : Form
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public SettingsDlg()
        {
            InitializeComponent();

            if (Extensions.IsAdministrator())
                btnAdmin.Visible = false;

            CheckAssociations();
        }

        void ResetKeyList()
        {
            KeyDatabase.Clear();
            if (File.Exists(Strings.XorKeyFile))
                File.Delete(Strings.XorKeyFile);
            KeyDatabase.Save();
        }

        bool SetAssociation(string Extension, string KeyName, string OpenWith, string FileDescription)
        {
            RegistryKey BaseKey;
            RegistryKey OpenMethod;
            RegistryKey Shell;
            RegistryKey CurrentUser;

            try
            {
                BaseKey = Registry.ClassesRoot.CreateSubKey(Extension);
                BaseKey.SetValue("", KeyName);
                BaseKey.Flush();
                BaseKey.Close();

                OpenMethod = Registry.ClassesRoot.CreateSubKey(KeyName);
                OpenMethod.SetValue("", FileDescription);
                OpenMethod.CreateSubKey("DefaultIcon").SetValue("", "\"" + OpenWith + "\",0");
                OpenMethod.Flush();

                Shell = OpenMethod.CreateSubKey("Shell");
                Shell.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                Shell.CreateSubKey("edit").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                Shell.Flush();
                Shell.Close();
                OpenMethod.Close();

                // Delete the key instead of trying to change it
                CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Extension, true);
                if (CurrentUser != null)
                {
                    CurrentUser.DeleteSubKey("UserChoice", false);
                    CurrentUser.Flush();
                    CurrentUser.Close();
                }

            }
            catch (Exception ex)
            {
                if (ex is System.Security.SecurityException || ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Please restart this program with administrative privileges to set file associations!");
                    return false;
                }
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                return false;
            }


            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

            return true;
        }

        bool ResetAssociation(string KeyName)
        {
            RegistryKey Key;

            try
            {
                Key = Registry.ClassesRoot.OpenSubKey(KeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (Key == null)
                    return true;

                Key.DeleteSubKey("DefaultIcon", false);
                Key.DeleteSubKeyTree("Shell", false);
                Key.Flush();
                Key.Close();
            }
            catch (Exception ex)
            {
                if (ex is System.Security.SecurityException || ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Please restart this program with administrative privileges to set file associations!");
                    return false;
                }
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                return false;
            }

            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

            return true;
        }

        bool CheckAssociation(string KeyName)
        {
            RegistryKey Key;

            try
            {
                Key = Registry.ClassesRoot.OpenSubKey(String.Format("{0}\\Shell\\open\\command", KeyName), RegistryKeyPermissionCheck.ReadSubTree);

                if (Key == null)
                    return false;

                if (Key.GetValue("") != null)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        void CheckAssociations()
        {
            for (int i = 0; i < clbAssociations.Items.Count; i++)
            {
                if (CheckAssociation(String.Format("{0}_File", clbAssociations.Items[i].ToString())))
                    clbAssociations.SetItemCheckState(i, CheckState.Checked);
                else
                    clbAssociations.SetItemCheckState(i, CheckState.Unchecked);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAssociations.Items.Count; i++ )
            {
                clbAssociations.SetItemCheckState(clbAssociations.Items.IndexOf(clbAssociations.Items[i]), cbAll.Checked ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private void btnResetKeys_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all saved Keys? You can't undo this!", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                ResetKeyList();
            }
            MessageBox.Show("Xor Keys has been reset successfully!");
        }

        private void btnResetAssoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all file associations?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != System.Windows.Forms.DialogResult.Yes)
                return;

            for (int i = 0; i < clbAssociations.Items.Count; i++)
            {
                if (!ResetAssociation(String.Format("{0}_File", clbAssociations.Items[i].ToString())))
                    return;
            }
            CheckAssociations();

            MessageBox.Show("File Associations has been reset successfully!");

        }

        private void btnSaveAssoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change given file associations?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != System.Windows.Forms.DialogResult.Yes)
                return;

            for (int i = 0; i < clbAssociations.Items.Count; i++)
            {
                if (clbAssociations.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (!SetAssociation(clbAssociations.Items[i].ToString(), String.Format("{0}_File", clbAssociations.Items[i].ToString()), Application.ExecutablePath, ""))
                        return;
                }
                else if (clbAssociations.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    if (!ResetAssociation(String.Format("{0}_File", clbAssociations.Items[i].ToString())))
                        return;
                }
            }
            CheckAssociations();

            MessageBox.Show("File Associations has been set successfully!");
        }

        void RestartAsAdmin()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            // Run as admin
            info.Verb = "runas";
            info.FileName = Application.ExecutablePath;

            MainDlg main = (MainDlg)this.Owner;
            if (!String.IsNullOrWhiteSpace(main.m_File))
            {
                string tempFile = Path.GetTempFileName();
                string tempXor = main.m_XorKey;
                main.SaveArchive(tempFile, false);

                info.Arguments = String.Format("\"{0}\" \"{1}\"", tempFile, tempXor);
            }

            Process.Start(info);
            Environment.Exit(1337);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            RestartAsAdmin();
        }
    }
}
