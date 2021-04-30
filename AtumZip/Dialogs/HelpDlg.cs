using System.Windows.Forms;
using System.Diagnostics;

namespace AtumZip
{
    public partial class HelpDlg : Form
    {
        public HelpDlg()
        {
            InitializeComponent();

            lbMain.Text = "You can contact the developer in case of any problems!\nWould you like to open your mail program to do so?\nWe are trying our best to answer you as fast as possible.";
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
#if DEBUG
            Process.Start("mailto:st34lth4ng3l@gmail.com");
#else
            Process.Start("http://forum.ragezone.com/private.php?do=newpm&u=1333463802");
#endif
            this.Close();
        }
    }
}
