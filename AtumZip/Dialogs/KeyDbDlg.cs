using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace AtumZip
{
    public partial class KeyDbDlg : Form
    {
        List<Key> m_Keys;

        public KeyDbDlg()
        {
            InitializeComponent();

            m_Keys = KeyDatabase.Get();

            ReloadItems();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditKeyDlg Dlg = new EditKeyDlg();
            Dlg.Title("Add");
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                Key k = Dlg.Get();

                if (!m_Keys.Exists(k.FileName))
                    m_Keys.Add(Dlg.Get());
                else
                    MessageBox.Show("A key already exists for this file!", "Error!");

                ReloadItems();

                KeyDatabase.Save();
            }
        }

        private void ReloadItems()
        {
            lvKeys.Items.Clear();

            foreach (Key k in m_Keys)
            {
                ListViewItem it = new ListViewItem(k.FileName);
                it.SubItems.Add(new ListViewItem.ListViewSubItem(it, k.XorKey));

                lvKeys.Items.Add(it);
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvKeys.SelectedItems.Count <= 0 || lvKeys.SelectedItems[0] == null)
                return;

            Key k = m_Keys.FindLast(key => key.FileName.ToLower() == lvKeys.SelectedItems[0].Text.ToLower());

            if (k == null)
                return;

            if (MessageBox.Show(String.Format("Are you sure you want to delete the key for {0}?", k.FileName)
                , "Attention!"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_Keys.Remove(k);
            }

            ReloadItems();
            KeyDatabase.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSelected()
        {
            if (lvKeys.SelectedItems.Count <= 0 || lvKeys.SelectedItems[0] == null)
                return;

            Key k = m_Keys.FindLast(key => key.FileName.ToLower() == lvKeys.SelectedItems[0].Text.ToLower());

            if (k == null)
                return;

            EditKeyDlg Dlg = new EditKeyDlg();

            Dlg.Title("Edit");
            Dlg.Set(k);

            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                Key res = Dlg.Get();
                int ind = m_Keys.IndexOf(k);
                m_Keys.Remove(k);
                m_Keys.Insert(ind, res);
            }
            ReloadItems();
            KeyDatabase.Save();
        }
    }
}
