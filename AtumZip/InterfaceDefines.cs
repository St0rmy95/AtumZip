using System.Drawing;
using System.Windows.Forms;

namespace AtumZip
{


    public static class Interface
    {
        public static readonly Color FontColor = Color.FromArgb(200, 200, 200);
        public static readonly Color FrontColor = Color.FromArgb(63, 63, 70);
        public static readonly Color BackColor = Color.FromArgb(45, 45, 48);
        public static readonly Color FieldColor = Color.FromArgb(30, 30, 30);
        public static readonly Color StatusBarColor = Color.FromArgb(0, 122, 204);
        public static readonly Color StatusBarLoadedColor = Color.FromArgb(0202, 81, 0);
    }

    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Interface.BackColor; }
        }

        public override Color MenuItemBorder
        {
            get { return Interface.BackColor; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Interface.FrontColor; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Interface.FrontColor; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Interface.BackColor; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Interface.BackColor; }
        }

        public override Color MenuBorder
        {
            get { return Interface.FrontColor; }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Interface.BackColor;
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return Interface.BackColor;
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return Interface.BackColor;
            }
        }

        Color StatusBarColor = Interface.StatusBarColor;

        public override Color StatusStripGradientBegin
        {
            get
            {
                return StatusBarColor;
            }
        }

        public override Color StatusStripGradientEnd
        {
            get
            {
                return StatusBarColor;
            }
        }

        public void SetStatusColor(Color c)
        {
            StatusBarColor = c;
        }

        public override Color SeparatorLight
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return Interface.FieldColor;
            }
        }

        public override Color ToolStripContentPanelGradientBegin
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripContentPanelGradientEnd
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripGradientBegin
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripGradientEnd
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripGradientMiddle
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripPanelGradientBegin
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ToolStripPanelGradientEnd
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Interface.FrontColor;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Interface.FrontColor;
            }
        }
    }
}
