using Ace_Globals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using OpenTKLib;
using Assimp;

namespace AtumZip
{
    public partial class MainDlg : Form
    {
        public string m_File;
        private Archive m_Archive;
        private bool m_Saved = true;
        public string m_XorKey;
        DarkColorTable m_ColorTable;
        int SearchIndex = 0;

        OGLControl glControl;
        OpenGLContext glContext;
        string currentMeshFile = "";

        public MainDlg()
        {
            InitializeComponent();

            SetupColors();
            SetLoadedState(false);

            if (Extensions.IsAdministrator())
                lbStatus.Image = Properties.Resources.Admin;

            KeyDatabase.Load();

            pbPreview.Width = 0;
            pbPreview.Visible = false;
            rtbPreview.Width = 0;
            rtbPreview.Visible = false;
            pnlPreview.Visible = false;
            splitContainer.SplitterDistance = this.Width;

            comboEncrypt.SelectedIndex = (int)Properties.Settings.Default.EncryptionType;

            string[] args = Environment.GetCommandLineArgs();

            string sFile = "";

            if (args.Length >= 2)
                sFile = args[1];
            if (args.Length >= 3)
                m_XorKey = args[2];

            if (File.Exists(sFile))
                LoadZipFile(sFile);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //          UI Handlers
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Ace ZIP Files|*.inf;*.obj;*.tex;*.dat;*.map;*.sky;*.cld|All files (*.*)|*.*";
            openFileDialog.Title = "Open ZIP File";
            openFileDialog.FileName = "";
            openFileDialog.Multiselect = false;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CloseCurrentFile();
                LoadZipFile(openFileDialog.FileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();
        }

        private void menuItemAdd_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Title = "Add File";
            openFileDialog.FileName = "";
            openFileDialog.Multiselect = true;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                    AddItem(file);
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            if (lvFiles.SelectedItems.Count <= 0)
                return;

            ListViewItem item = lvFiles.SelectedItems[0];

            openFileDialog.Filter = String.Format("{0}|{0}.*", Path.GetFileNameWithoutExtension(item.Text));
            openFileDialog.Title = "Replace File";
            openFileDialog.FileName = item.Text;
            openFileDialog.Multiselect = false;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AddItem(openFileDialog.FileName);
                SetStatus(String.Format("Replaced {0}", item.Text));
            }

        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            foreach (ListViewItem item in lvFiles.SelectedItems)
                RemoveItem(item);
        }

        private void menuItemExtractAll_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            folderBrowserDialog.SelectedPath = Path.GetDirectoryName(m_File);
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Extract Entries";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in lvFiles.Items)
                {
                    ExtractItem(item, folderBrowserDialog.SelectedPath);
                }
                SetStatus(String.Format("Finished axtracting all entries to {0}", folderBrowserDialog.SelectedPath));
            }
        }

        private void menuItemExtract_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            folderBrowserDialog.SelectedPath = Path.GetDirectoryName(m_File);
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Extract Entries";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in lvFiles.SelectedItems)
                {
                    ExtractItem(item, folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void menuItemView_Click(object sender, EventArgs e)
        {
            if (!isLoaded())
                return;

            if (lvFiles.SelectedItems.Count == 0)
                return;

            ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(lvFiles.SelectedItems[0].Text));

            if (ent == null)
                return;

            ent.extractTo(Path.GetTempPath());

            string file = String.Format("{0}\\{1}{2}", Path.GetTempPath(), ent.getName(), ent.getExtension());

            Process p = Process.Start(file);

            if (p != null)
                p.WaitForExit();

            File.Delete(file);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.Title = "Save Zip File";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = m_File;

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                SaveArchive(saveFileDialog.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();
            Environment.Exit(0);
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count <= 0)
            {
                pbPreview.Width = 0;
                pbPreview.Visible = false;
                rtbPreview.Width = 0;
                rtbPreview.Visible = false;
                splitContainer.SplitterDistance = this.Width;

                lbSelection.Text = String.Empty;

                return;
            }

            if(File.Exists(currentMeshFile))
                File.Delete(currentMeshFile);

            if (File.Exists(currentMeshFile + ".mtl"))
                File.Delete(currentMeshFile + ".mtl");

            if (glControl != null)
            {
                if (glControl.GLrender != null)
                {
                    glControl.GLrender.ClearAllObjects();
                    glControl.GLrender.GLControlInstance.Dispose();
                }
                glControl.Dispose();
            }

            ListViewItem Item = lvFiles.SelectedItems[0];

            lbSelection.Text = String.Format("Sel {0}", Item.Index + 1);

            ImageListIndex indx = FileType.GetImageIndex(Path.GetExtension(Item.Text));

            if (indx == ImageListIndex.Image)
            {
                pbPreview.Width = 399;
                pbPreview.Visible = true;
                rtbPreview.Width = 0;
                rtbPreview.Visible = false;
                pnlPreview.Visible = false;

                ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(Item.Text));
                Image img = null;

                using (MemoryStream ms = new MemoryStream(ent.getData()))
                {
                    try
                    {
                        if (Path.GetExtension(Item.Text) == ".tga")
                        {
                            TargaImage tgaImg = new TargaImage(ms);
                            img = tgaImg.Image;
                        }
                        else
                        {
                            img = Image.FromStream(ms);
                        }
                    }
                    catch
                    { }
                }

                if (img != null)
                {
                    pbPreview.Image = img;
                    pbPreview.Width = img.Width;
                    pbPreview.Location = new Point(pbPreview.Location.X, (this.Height / 2) - (img.Height / 2) - 20);
                    splitContainer.SplitterDistance = Math.Max(this.Width - img.Width - 20, 200);
                }
            }
            else if (indx == ImageListIndex.Text)
            {
                pbPreview.Width = 0;
                pbPreview.Visible = false;
                rtbPreview.Width = 500;
                rtbPreview.Visible = true;
                pnlPreview.Visible = false;
                splitContainer.SplitterDistance = this.Width - 500;

                rtbPreview.Text = "";

                ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(Item.Text));
                if (ent != null)
                    rtbPreview.Text = Encoding.Default.GetString(ent.getData());
            }
            else if (indx == ImageListIndex.Mesh)
            {
                pnlPreview.Visible = true;
                splitContainer.SplitterDistance = this.Width - 500;

                glControl = new OGLControl();
                glControl.Parent = pnlPreview;
                glControl.Dock = DockStyle.Fill;
                glContext = new OpenGLContext(glControl);
                glControl.GLrender.PrimitiveTypes = OpenTK.Graphics.OpenGL.PrimitiveType.Triangles;
                glControl.GLrender.Camera.ZNear = 0.01f;
                glControl.GLrender.Camera.ZFar = float.MaxValue;

                string tempFile = Path.GetTempFileName();
                currentMeshFile = Path.ChangeExtension(Path.GetTempFileName(), "obj");
                ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(Item.Text));
                ent.extractTo(tempFile, true);

                using (AssimpContext context = new AssimpContext())
                {
                    Scene mesh = context.ImportFile(tempFile);
                    context.ExportFile(mesh, currentMeshFile, "obj");
                }
                File.Delete(tempFile);

                Model model = new Model(currentMeshFile);

                glControl.GLrender.AddModel(model);
                glControl.GLrender.SelectedModelIndex = 0;
            }
            else
            {
                pbPreview.Width = 0;
                pbPreview.Visible = false;
                rtbPreview.Width = 0;
                rtbPreview.Visible = false;
                pnlPreview.Visible = false;
            }
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();
            m_File = "new";
            m_Archive = new Archive("", false, EncryptionType.None);

            SetSavedState(false);
            SetLoadedState(true);
        }

        private void menuXorKey_Click(object sender, EventArgs e)
        {
            XorDlg xor = new XorDlg();
            xor.SetType(XorType.Encrypt, m_XorKey);

            if (xor.ShowDialog() == DialogResult.OK)
                m_XorKey = xor.XorKey;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(m_File) && m_File != "new")
            {
                SaveArchive(m_File);
                SetSavedState(true);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        #region DRAG_DROP
        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!isLoaded() && files.Length > 0)
            {
                LoadZipFile(files[0]);
            }
            else
            {
                foreach (string file in files)
                    AddItem(file);
            }
        }

        private void lvFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<string> selection = new List<string>();
            foreach (ListViewItem item in lvFiles.SelectedItems)
            {
                ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(item.Text));

                if (ent == null)
                    return;
                ent.extractTo(Path.GetTempPath());

                string file = String.Format("{0}\\{1}{2}", Path.GetTempPath(), ent.getName(), ent.getExtension());
                selection.Add(file);
            }

            DataObject data = new DataObject(DataFormats.FileDrop, selection.ToArray());
            DoDragDrop(data, DragDropEffects.Move);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //          ZIP Handlers
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        public void LoadZipFile(string path, bool breakOnFail = false)
        {
            m_File = path;
            this.Text = String.Format(Strings.WindowNameLoaded, m_File, "");

            m_Archive = new Archive(m_File, true, (EncryptionType)comboEncrypt.SelectedIndex);
            List<ArchiveEntry> entries = m_Archive.getEntries();

            if (m_Archive == null || entries == null)
            {
                if (breakOnFail)
                {
                    MessageBox.Show("The file is not a valid zip file or the Xor key is wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseCurrentFile();
                    return;
                }

                if (!KeyDatabase.SearchKey(Path.GetFileName(path), out m_XorKey)
                    || MessageBox.Show(String.Format("The Key {0} was found for {1} in our database, would you like to use it?", m_XorKey, Path.GetFileName(path))
                    , "A key was found!"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    XorDlg xor = new XorDlg();
                    xor.SetType(XorType.Decrypt);

                    if (xor.ShowDialog() != DialogResult.OK)
                    {
                        CloseCurrentFile();
                        return;
                    }

                    m_XorKey = xor.XorKey;
                }

                if (String.IsNullOrEmpty(m_XorKey))
                {
                    CloseCurrentFile();
                    return;
                }

                string decryptedPath = String.Format("{0}{1}", Path.GetTempPath(), Path.GetFileName(path));

                if (File.Exists(decryptedPath))
                    File.Delete(decryptedPath);

                File.Copy(path, decryptedPath);

                // Decrypt here
                XorFile(decryptedPath, m_XorKey);

                LoadZipFile(decryptedPath, true);

                File.Delete(decryptedPath);
                return;
            }

            // Load associated icons


            foreach (ArchiveEntry entry in entries)
            {
                AddFile(entry.getNameExtension(), entry.getExtension(), entry.getSizeData(), entry.getId(), path + "\\" + entry.getName());
            }

            SetLoadedState(true);
        }

        private void XorFile(string file, string XorKey)
        {
            byte[] data = File.ReadAllBytes(file);
            int i = 0;
            for (int dataPos = 0; dataPos < data.Length; dataPos++)
            {
                if (i == XorKey.Length)
                    i = 0;
                else if ((dataPos % 0x10000L) == 0L)
                    i = 0;

                data[dataPos] = Convert.ToByte(data[dataPos] ^ XorKey[i]);
                i++;
            }

            File.WriteAllBytes(file, data);
        }

        public void ExtractZipFile(string Destination)
        {
            m_Archive.extractTo(Destination);
        }

        public void AddFile(string name, string type, int size, int ID, string path)
        {
            ListViewItem Item = new ListViewItem(name);

            Item.ImageIndex = (int)FileType.GetImageIndex(Path.GetExtension(name));

            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, FileType.GetDescription(type)));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, Extensions.GetSizeFormat(size)));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, ID.ToString()));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, path));

            lvFiles.Items.Add(Item);
        }

        public void ReplaceFile(string name, string type, int size, int ID, string path)
        {
            int Index = lvFiles.FindItemWithText(name).Index;

            if (Index < 0 || Index > lvFiles.Items.Count)
                return;

            ListViewItem Item = new ListViewItem(name);

            Item.ImageIndex = (int)FileType.GetImageIndex(Path.GetExtension(name));

            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, FileType.GetDescription(type)));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, Extensions.GetSizeFormat(size)));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, ID.ToString()));
            Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, path));

            lvFiles.Items.RemoveAt(Index);
            lvFiles.Items.Insert(Index, Item);
            lvFiles.Refresh();
        }

        public void AddItem(string Path)
        {
            ArchiveEntry entry = new ArchiveEntry(Path, null, false, EncryptionType.None);
            if (m_Archive.add(entry))
            {
                AddFile(entry.getNameExtension(), entry.getExtension(), entry.getSizeData(), entry.getId(), Path);

                SetSavedState(false);
                SetStatus(String.Format("Added {0} to the archive.", entry.getNameExtension()));
            }
            else
            {
                ReplaceFile(entry.getNameExtension(), entry.getExtension(), entry.getSizeData(), entry.getId(), Path);

                SetSavedState(false);
                SetStatus(String.Format("Replaced {0} in the archive.", entry.getNameExtension()));
            }
        }

        public void RemoveItem(ListViewItem Item)
        {
            if (Item == null)
                return;

            if (m_Archive.remove(Path.GetFileNameWithoutExtension(Item.Text)))
            {
                lvFiles.Items.Remove(Item);
                SetSavedState(false);
                SetStatus(String.Format("Removed {0} from the archive.", Item.Text));
            }
        }

        public void ExtractItem(ListViewItem Item, string Destination)
        {
            if (Item == null || String.IsNullOrWhiteSpace(Destination))
                return;

            ArchiveEntry ent = m_Archive.getByName(Path.GetFileNameWithoutExtension(Item.Text));
            if (ent != null)
            {
                ent.extractTo(Destination);
                SetStatus(String.Format("Extracted {0} to {1}", Item.Text, Destination));
            }
        }

        public void SaveArchive(string Destination, bool Encrypt = true)
        {
            m_Archive.write(Destination);

            if (!String.IsNullOrEmpty(m_XorKey) && Encrypt)
                XorFile(Destination, m_XorKey);

            SetStatus(String.Format("Saved archive to {0}", Destination));
            m_File = Destination;
            SetSavedState(true);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //          Management Handlers
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetSavedState(bool State)
        {
            m_Saved = State;

            if (!isLoaded())
            {
                this.Text = Strings.WindowName;
                return;
            }

            if (!m_Saved)
                this.Text = String.Format(Strings.WindowNameLoaded, m_File, "*");
            else
                this.Text = String.Format(Strings.WindowNameLoaded, m_File, "");
        }

        private void SetLoadedState(bool State)
        {
            extractToToolStripMenuItem.Enabled = State;
            menuXorKey.Enabled = State;
            openEntryToolStripMenuItem.Enabled = State;
            saveAsToolStripMenuItem.Enabled = State;
            saveToolStripMenuItem.Enabled = State;
            closeToolStripMenuItem.Enabled = State;
            tbSearch.Visible = State;
            btnFind.Visible = State;

            if (State)
                SetStatus(String.Format("Loaded {0} entries.", m_Archive.getCountEntries()));
            else
                SetStatus("Ready...");

            m_ColorTable.SetStatusColor(State ? Interface.StatusBarLoadedColor : Interface.StatusBarColor);
        }


        bool isLoaded()
        {
            return !String.IsNullOrWhiteSpace(m_File);
        }

        void SetStatus(string Status)
        {
            lbStatus.Text = Status;
        }

        void CloseCurrentFile()
        {
            if (!m_Saved && m_Archive.getCountEntries() != 0)
            {
                if (MessageBox.Show("Would you like to save the previous changes before opening a new file?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(this, new EventArgs());
                }
            }

            if (File.Exists(currentMeshFile))
                File.Delete(currentMeshFile);

            if (File.Exists(currentMeshFile + ".mtl"))
                File.Delete(currentMeshFile + ".mtl");

            if (glControl != null)
            {
                if (glControl.GLrender != null)
                {
                    glControl.GLrender.ClearAllObjects();
                    glControl.GLrender.GLControlInstance.Dispose();
                }
                glControl.Dispose();
            }

            m_XorKey = String.Empty;

            lvFiles.Items.Clear();

            if (m_Archive != null)
                m_Archive = null;

            m_File = String.Empty;

            tbSearch.Text = Strings.SearchDefaultText;
            SearchIndex = 0;

            pbPreview.Width = 0;
            pbPreview.Visible = false;
            pbPreview.Image = null;
            rtbPreview.Width = 0;
            rtbPreview.Visible = false;
            rtbPreview.Text = String.Empty;
            splitContainer.SplitterDistance = this.Width;

            SetSavedState(true);
            SetLoadedState(false);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbSearch.Text) || tbSearch.Text == Strings.SearchDefaultText)
                return;

            int Count = 0;
            int SelectIndex = -1;

            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                // Deselect all other items by default
                lvFiles.Items[i].Selected = false;
                lvFiles.Items[i].Focused = false;

                if(lvFiles.Items[i].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                {
                    if (SelectIndex < 0)
                        SelectIndex = i;

                    Count++;
                }
            }

            if (SelectIndex >= 0)
            {
                lvFiles.Items[SelectIndex].Selected = true;
                lvFiles.Items[SelectIndex].Focused = true;
                lvFiles.EnsureVisible(SelectIndex);
            }

            if (Count != 0)
            {
                SearchIndex = 0;
                SetStatus(String.Format("Found {0} entries containing \"{1}\".", Count, tbSearch.Text));
            }
            else
            {
                SearchIndex = -1;
                SetStatus(String.Format("No entry found with name \"{0}\".", tbSearch.Text));
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (SearchIndex < 0)
                return;

            int Count = 0;
            int SelectIndex = -1;
            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                // Deselect all other items by default
                lvFiles.Items[i].Selected = false;
                lvFiles.Items[i].Focused = false;

                if (lvFiles.Items[i].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                {
                    if (Count == SearchIndex)
                        SelectIndex = i;

                    Count++;
                }
            }

            if (SelectIndex >= 0)
            {
                lvFiles.Items[SelectIndex].Selected = true;
                lvFiles.Items[SelectIndex].Focused = true;
                lvFiles.EnsureVisible(SelectIndex);
            }


            SearchIndex++;

            if (Count < SearchIndex)
            {
                // No further items found, reset it
                SetStatus("Reached end of search, starting from top again.");
                SearchIndex = 0;
            }
            else
            {
                SetStatus(String.Format("Showing entry {0}/{1} for keyword: \"{2}\"", SearchIndex, Count, tbSearch.Text));
            }
        }

        private void tbSearch_MouseEnter(object sender, EventArgs e)
        {
            if (tbSearch.Text == Strings.SearchDefaultText)
                tbSearch.Text = String.Empty;
        }

        private void tbSearch_MouseLeave(object sender, EventArgs e)
        {
            if (tbSearch.Text == String.Empty && !tbSearch.Focused)
                tbSearch.Text = Strings.SearchDefaultText;
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == Strings.SearchDefaultText)
                tbSearch.Text = String.Empty;
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == String.Empty)
                tbSearch.Text = Strings.SearchDefaultText;
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void lvFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                tbSearch.SelectAll();
                tbSearch.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnFind_Click(sender, e);
            }

            if (e.KeyCode == Keys.Delete)
            {
                menuItemDelete_Click(sender, e);
            }
        }

        private void SetupColors()
        {
            m_ColorTable = new DarkColorTable();
            menuStrip.Renderer = new ToolStripProfessionalRenderer(m_ColorTable);
            statusStrip.Renderer = new ToolStripProfessionalRenderer(m_ColorTable);
            cntxMenu.Renderer = new ToolStripProfessionalRenderer(m_ColorTable);
        }


        void lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;

                using (var headerFont = new Font("Microsoft Sans Serif", 9, FontStyle.Regular))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Interface.FrontColor), e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Gainsboro, e.Bounds, sf);
                    e.Graphics.DrawLine(new Pen(Interface.BackColor), new Point(e.Bounds.X - 2, e.Bounds.Top), new Point(e.Bounds.X - 2, e.Bounds.Bottom));
                    e.Graphics.DrawLine(new Pen(Interface.BackColor), new Point(1, e.Bounds.Bottom - 1), new Point(lvFiles.Width, e.Bounds.Bottom - 1));
                }
            }
        }

        private void lvFiles_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvFiles_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvFiles_Resize(object sender, EventArgs e)
        {
            int Size = 0;
            for (int i = 0; i < lvFiles.Columns.Count - 1; i++)
                Size += lvFiles.Columns[i].Width;

            lvFiles.Columns[lvFiles.Columns.Count - 1].Width = lvFiles.Width - 2 - Size;
        }


        private void lvFiles_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == lvFiles.Columns.Count - 1)
                return;

            int Size = 0;
            for (int i = 0; i < lvFiles.Columns.Count - 1; i++)
                Size += lvFiles.Columns[i].Width;

            int NewSize = lvFiles.Width - 2 - Size;

            if (lvFiles.Columns[lvFiles.Columns.Count - 1].Width != NewSize)
                lvFiles.Columns[lvFiles.Columns.Count - 1].Width = NewSize;
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
                btnFind_Click(sender, e);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpDlg Dlg = new HelpDlg();
            Dlg.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDlg Dlg = new AboutDlg();
            Dlg.ShowDialog();
        }

        private void viewKeyDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyDbDlg Dlg = new KeyDbDlg();
            Dlg.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDlg Dlg = new SettingsDlg();
            Dlg.ShowDialog(this);
        }

        private void extractDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prepare openfiledialog
            openFileDialog.Filter = "Ace ZIP Files|*.inf;*.obj;*.tex;*.dat;*.map;*.sky;*.cld|All files (*.*)|*.*";
            openFileDialog.Title = "Open ZIP File";
            openFileDialog.FileName = "";
            openFileDialog.Multiselect = true;

            // Prepare folderBrowserDialog
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Extract Files";

            // Show both 
            if (this.openFileDialog.ShowDialog() == DialogResult.OK && folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                new MassExtractDlg().ShowDialog(this, this.openFileDialog.FileNames, folderBrowserDialog.SelectedPath, (EncryptionType)comboEncrypt.SelectedIndex);

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void comboEncrypt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded())
            {
                string file = m_File;

                CloseCurrentFile();
                LoadZipFile(file);
            }

            Properties.Settings.Default.EncryptionType = (EncryptionType)comboEncrypt.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
