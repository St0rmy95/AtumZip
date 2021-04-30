using System;
using System.Windows.Forms;

namespace AtumZip
{
    public enum XorType
    {
        Encrypt,
        Decrypt
    };

    public partial class XorDlg : Form
    {
        public string XorKey;

        public XorDlg()
        {
            InitializeComponent();
        }

        public void SetType(XorType formType, string Key = "")
        {
            lbDecrypt.Visible = false;
            lbEncrypt.Visible = false;
            btnDelete.Visible = false;

            if (formType == XorType.Encrypt)
            {
                lbEncrypt.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                lbDecrypt.Visible = true;
            }

            if (!String.IsNullOrEmpty(Key))
            { 
                tbKey.Text = Key;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            XorKey = tbKey.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XorKey = tbKey.Text = String.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
