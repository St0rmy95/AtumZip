using System.Windows.Forms;

namespace AtumZip
{
    public partial class AboutDlg : Form
    {
        public AboutDlg()
        {
            InitializeComponent();
#if DEBUG 
            lbText.Text = "AtumZip Copyright © 2017 by St34lth4ng3l\nContact: st34lth4ng3l@gmail.com";
#else
            lbText.Text = "AtumZip/SA Icon Copyright © 2017 by St34lth4ng3l\nContact: st34lth4ng3l on RaGEZONE\nIn case you are not allowed to use this: shame on you >:c";
            lbText.Location = new System.Drawing.Point(lbText.Location.X, lbText.Location.Y - 10);
#endif
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
