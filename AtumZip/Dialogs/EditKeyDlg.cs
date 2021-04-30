using System;
using System.Windows.Forms;

namespace AtumZip
{
    public partial class EditKeyDlg : Form
    {
        public EditKeyDlg()
        {
            InitializeComponent();
        }

        public void Title(string Msg)
        {
            this.Text = String.Format(this.Text, Msg);
        }

        public void Set(Key key)
        {
            tbFile.Text = key.FileName;
            tbKey.Text = key.XorKey;
        }

        public Key Get()
        {
            return new Key(tbFile.Text, tbKey.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbFile.Text) || String.IsNullOrWhiteSpace(tbKey.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Error!");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
