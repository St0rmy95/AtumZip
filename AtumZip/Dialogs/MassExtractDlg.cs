using Ace_Globals;
using AtumZip;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AtumZip
{
    public partial class MassExtractDlg : Form
    {
        string[] Files;
        string ExtractPath;
        EncryptionType encryptionType;

        public MassExtractDlg()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWin32Window owner ,string[] Files, string ExtractPath, EncryptionType encryptionType)
        {
            this.Files = Files;
            this.ExtractPath = ExtractPath;
            this.encryptionType = encryptionType;

            this.ShowDialog(owner);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            this.Close();
        }

        private void MassExtractDlg_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            labelProgress.Text = String.Format("Extracting {0} of {1} files.", e.UserState, Files.Length);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Archive arch = null;
            int currentFileCount = 1;

            foreach (string file in Files)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                backgroundWorker.ReportProgress((int)(((float)currentFileCount / (float)Files.Length) * 100.0f), currentFileCount);

                try
                {
                    // extract
                    arch = new Archive(file, true, encryptionType);
                    arch.extractTo(String.Format("{0}\\{1}", ExtractPath, arch.getName()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Could not extract {0}!\n\n{1}", file, ex.StackTrace), "Failed to extract!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                currentFileCount++;
            }
        }
    }
}
