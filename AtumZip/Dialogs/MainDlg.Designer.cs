namespace AtumZip
{
    partial class MainDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXorKey = new System.Windows.Forms.ToolStripMenuItem();
            this.extractDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewKeyDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnFind = new System.Windows.Forms.ToolStripMenuItem();
            this.comboEncrypt = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.cntxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFileTypes = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.headFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cntxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.tbSearch,
            this.btnFind,
            this.comboEncrypt});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1382, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 23);
            this.fileToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.newToolStripMenuItem.Image = global::AtumZip.Properties.Resources.New;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.openToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.saveToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.saveAsToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.closeToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Close;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.exitToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Close;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractToToolStripMenuItem,
            this.menuXorKey,
            this.extractDirectoryToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 23);
            this.editToolStripMenuItem.Text = "EDIT";
            // 
            // extractToToolStripMenuItem
            // 
            this.extractToToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.extractToToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.extractToToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Extract;
            this.extractToToolStripMenuItem.Name = "extractToToolStripMenuItem";
            this.extractToToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractToToolStripMenuItem.Text = "Extract Archive";
            this.extractToToolStripMenuItem.Click += new System.EventHandler(this.menuItemExtractAll_Click);
            // 
            // menuXorKey
            // 
            this.menuXorKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.menuXorKey.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuXorKey.Image = global::AtumZip.Properties.Resources.Key;
            this.menuXorKey.Name = "menuXorKey";
            this.menuXorKey.Size = new System.Drawing.Size(187, 22);
            this.menuXorKey.Text = "Add/Remove Xor Key";
            this.menuXorKey.Click += new System.EventHandler(this.menuXorKey_Click);
            // 
            // extractDirectoryToolStripMenuItem
            // 
            this.extractDirectoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.extractDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.extractDirectoryToolStripMenuItem.Image = global::AtumZip.Properties.Resources.MassExtract;
            this.extractDirectoryToolStripMenuItem.Name = "extractDirectoryToolStripMenuItem";
            this.extractDirectoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractDirectoryToolStripMenuItem.Text = "Extract Directory";
            this.extractDirectoryToolStripMenuItem.Click += new System.EventHandler(this.extractDirectoryToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openEntryToolStripMenuItem,
            this.viewKeyDatabaseToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
            this.viewToolStripMenuItem.Text = "VIEW";
            // 
            // openEntryToolStripMenuItem
            // 
            this.openEntryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.openEntryToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.openEntryToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Show;
            this.openEntryToolStripMenuItem.Name = "openEntryToolStripMenuItem";
            this.openEntryToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openEntryToolStripMenuItem.Text = "View Entry";
            this.openEntryToolStripMenuItem.Click += new System.EventHandler(this.menuItemView_Click);
            // 
            // viewKeyDatabaseToolStripMenuItem
            // 
            this.viewKeyDatabaseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.viewKeyDatabaseToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.viewKeyDatabaseToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Key;
            this.viewKeyDatabaseToolStripMenuItem.Name = "viewKeyDatabaseToolStripMenuItem";
            this.viewKeyDatabaseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.viewKeyDatabaseToolStripMenuItem.Text = "View Key Database";
            this.viewKeyDatabaseToolStripMenuItem.Click += new System.EventHandler(this.viewKeyDatabaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.helpToolStripMenuItem.Text = "HELP";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.helpToolStripMenuItem1.ForeColor = System.Drawing.Color.Gainsboro;
            this.helpToolStripMenuItem1.Image = global::AtumZip.Properties.Resources.Help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.aboutToolStripMenuItem.Image = global::AtumZip.Properties.Resources.About;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.settingsToolStripMenuItem.Image = global::AtumZip.Properties.Resources.Settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbSearch.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 23);
            this.tbSearch.Text = "Search...";
            this.tbSearch.ToolTipText = "Search for entry.";
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.MouseEnter += new System.EventHandler(this.tbSearch_MouseEnter);
            this.tbSearch.MouseLeave += new System.EventHandler(this.tbSearch_MouseLeave);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFind.Image = global::AtumZip.Properties.Resources.Next;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 23);
            this.btnFind.Text = "Find Next";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // comboEncrypt
            // 
            this.comboEncrypt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboEncrypt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEncrypt.ForeColor = System.Drawing.Color.Gainsboro;
            this.comboEncrypt.Items.AddRange(new object[] {
            "None",
            "Crome-Rivals"});
            this.comboEncrypt.Name = "comboEncrypt";
            this.comboEncrypt.Size = new System.Drawing.Size(121, 23);
            this.comboEncrypt.SelectedIndexChanged += new System.EventHandler(this.comboEncrypt_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.lbSpace,
            this.lbSelection});
            this.statusStrip.Location = new System.Drawing.Point(0, 704);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1382, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(39, 17);
            this.lbStatus.Text = "Ready";
            // 
            // lbSpace
            // 
            this.lbSpace.Name = "lbSpace";
            this.lbSpace.Size = new System.Drawing.Size(1306, 17);
            this.lbSpace.Spring = true;
            // 
            // lbSelection
            // 
            this.lbSelection.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbSelection.Name = "lbSelection";
            this.lbSelection.Size = new System.Drawing.Size(22, 17);
            this.lbSelection.Text = "Sel";
            // 
            // cntxMenu
            // 
            this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemView,
            this.menuItemExtract,
            this.menuItemReplace,
            this.menuItemDelete,
            this.menuItemAdd});
            this.cntxMenu.Name = "cntxMenu";
            this.cntxMenu.Size = new System.Drawing.Size(124, 114);
            // 
            // menuItemView
            // 
            this.menuItemView.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuItemView.Image = global::AtumZip.Properties.Resources.Show;
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(123, 22);
            this.menuItemView.Text = "View";
            this.menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
            // 
            // menuItemExtract
            // 
            this.menuItemExtract.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuItemExtract.Image = global::AtumZip.Properties.Resources.Extract;
            this.menuItemExtract.Name = "menuItemExtract";
            this.menuItemExtract.Size = new System.Drawing.Size(123, 22);
            this.menuItemExtract.Text = "Extract";
            this.menuItemExtract.Click += new System.EventHandler(this.menuItemExtract_Click);
            // 
            // menuItemReplace
            // 
            this.menuItemReplace.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuItemReplace.Image = global::AtumZip.Properties.Resources.Replace;
            this.menuItemReplace.Name = "menuItemReplace";
            this.menuItemReplace.Size = new System.Drawing.Size(123, 22);
            this.menuItemReplace.Text = "Replace";
            this.menuItemReplace.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuItemDelete.Image = global::AtumZip.Properties.Resources.Delete;
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(123, 22);
            this.menuItemDelete.Text = "Delete";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuItemAdd.Image = global::AtumZip.Properties.Resources.Add;
            this.menuItemAdd.Name = "menuItemAdd";
            this.menuItemAdd.Size = new System.Drawing.Size(123, 22);
            this.menuItemAdd.Text = "Add New";
            this.menuItemAdd.Click += new System.EventHandler(this.menuItemAdd_Click);
            // 
            // imgFileTypes
            // 
            this.imgFileTypes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFileTypes.ImageStream")));
            this.imgFileTypes.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFileTypes.Images.SetKeyName(0, "binaryfile.ico");
            this.imgFileTypes.Images.SetKeyName(1, "file.ico");
            this.imgFileTypes.Images.SetKeyName(2, "configfile.ico");
            this.imgFileTypes.Images.SetKeyName(3, "image.ico");
            this.imgFileTypes.Images.SetKeyName(4, "mesh.ico");
            this.imgFileTypes.Images.SetKeyName(5, "video.ico");
            this.imgFileTypes.Images.SetKeyName(6, "soundfile.ico");
            this.imgFileTypes.Images.SetKeyName(7, "textfile.ico");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvFiles);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlPreview);
            this.splitContainer.Panel2.Controls.Add(this.rtbPreview);
            this.splitContainer.Panel2.Controls.Add(this.pbPreview);
            this.splitContainer.Size = new System.Drawing.Size(1382, 677);
            this.splitContainer.SplitterDistance = 1155;
            this.splitContainer.TabIndex = 5;
            // 
            // lvFiles
            // 
            this.lvFiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFiles.AllowDrop = true;
            this.lvFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headFile,
            this.headType,
            this.headSize,
            this.headId,
            this.headPath});
            this.lvFiles.ContextMenuStrip = this.cntxMenu;
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.LargeImageList = this.imgFileTypes;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.OwnerDraw = true;
            this.lvFiles.Size = new System.Drawing.Size(1155, 677);
            this.lvFiles.SmallImageList = this.imgFileTypes;
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvFiles_ColumnWidthChanging);
            this.lvFiles.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv_DrawColumnHeader);
            this.lvFiles.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvFiles_DrawItem);
            this.lvFiles.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvFiles_DrawSubItem);
            this.lvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvFiles_ItemDrag);
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            this.lvFiles.DoubleClick += new System.EventHandler(this.menuItemView_Click);
            this.lvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFiles_KeyDown);
            this.lvFiles.Resize += new System.EventHandler(this.lvFiles_Resize);
            // 
            // headFile
            // 
            this.headFile.Text = "File";
            this.headFile.Width = 197;
            // 
            // headType
            // 
            this.headType.Text = "Type";
            this.headType.Width = 159;
            // 
            // headSize
            // 
            this.headSize.Text = "Size";
            this.headSize.Width = 103;
            // 
            // headId
            // 
            this.headId.Text = "ID";
            this.headId.Width = 125;
            // 
            // headPath
            // 
            this.headPath.Text = "Path";
            this.headPath.Width = 900;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Location = new System.Drawing.Point(2, 3);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(500, 500);
            this.pnlPreview.TabIndex = 5;
            // 
            // rtbPreview
            // 
            this.rtbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPreview.ForeColor = System.Drawing.Color.Gainsboro;
            this.rtbPreview.Location = new System.Drawing.Point(0, 0);
            this.rtbPreview.Margin = new System.Windows.Forms.Padding(0);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.Size = new System.Drawing.Size(223, 677);
            this.rtbPreview.TabIndex = 4;
            this.rtbPreview.Text = "";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(223, 677);
            this.pbPreview.TabIndex = 3;
            this.pbPreview.TabStop = false;
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1382, 726);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainDlg";
            this.Text = "AtumZip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFrm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cntxMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuXorKey;
        private System.Windows.Forms.ToolStripMenuItem openEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemExtract;
        private System.Windows.Forms.ImageList imgFileTypes;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader headFile;
        private System.Windows.Forms.ColumnHeader headType;
        private System.Windows.Forms.ColumnHeader headSize;
        private System.Windows.Forms.ColumnHeader headPath;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemReplace;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem btnFind;
        private System.Windows.Forms.ToolStripMenuItem viewKeyDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbSelection;
        private System.Windows.Forms.ToolStripStatusLabel lbSpace;
        private System.Windows.Forms.ColumnHeader headId;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.ToolStripMenuItem extractDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comboEncrypt;
    }
}

