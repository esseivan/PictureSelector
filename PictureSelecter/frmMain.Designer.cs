namespace PictureSelecter
{
    partial class frmMain
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
            this.pPB = new System.Windows.Forms.Panel();
            this.btnRotCCW = new System.Windows.Forms.Button();
            this.btnRotCW = new System.Windows.Forms.Button();
            this.btnKeep = new System.Windows.Forms.Button();
            this.pKeep = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbboxSizeMode = new System.Windows.Forms.ComboBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirDossierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegardesAutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eFFACERTOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherCacherListeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sélectionnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonSélectionnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rafraichirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeFacileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.lblCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.svDialog = new System.Windows.Forms.SaveFileDialog();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.cmsDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toutMettreGardéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toutMettreNonGardéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.déchargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pPB.SuspendLayout();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.cmsDirectory.SuspendLayout();
            this.cmsFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPB
            // 
            this.pPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPB.Controls.Add(this.btnRotCCW);
            this.pPB.Controls.Add(this.btnRotCW);
            this.pPB.Controls.Add(this.btnKeep);
            this.pPB.Controls.Add(this.pKeep);
            this.pPB.Controls.Add(this.label1);
            this.pPB.Controls.Add(this.cbboxSizeMode);
            this.pPB.Location = new System.Drawing.Point(3, 416);
            this.pPB.Name = "pPB";
            this.pPB.Size = new System.Drawing.Size(625, 45);
            this.pPB.TabIndex = 1;
            // 
            // btnRotCCW
            // 
            this.btnRotCCW.Location = new System.Drawing.Point(214, 3);
            this.btnRotCCW.Name = "btnRotCCW";
            this.btnRotCCW.Size = new System.Drawing.Size(75, 39);
            this.btnRotCCW.TabIndex = 10;
            this.btnRotCCW.Text = "Rotation anti-horaire";
            this.btnRotCCW.UseVisualStyleBackColor = true;
            this.btnRotCCW.Click += new System.EventHandler(this.btnRotRight_Click);
            // 
            // btnRotCW
            // 
            this.btnRotCW.Location = new System.Drawing.Point(133, 3);
            this.btnRotCW.Name = "btnRotCW";
            this.btnRotCW.Size = new System.Drawing.Size(75, 39);
            this.btnRotCW.TabIndex = 10;
            this.btnRotCW.Text = "Rotation horaire";
            this.btnRotCW.UseVisualStyleBackColor = true;
            this.btnRotCW.Click += new System.EventHandler(this.btnRotCW_Click);
            // 
            // btnKeep
            // 
            this.btnKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeep.Location = new System.Drawing.Point(547, 3);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(75, 39);
            this.btnKeep.TabIndex = 9;
            this.btnKeep.Text = "Garder";
            this.btnKeep.UseVisualStyleBackColor = true;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // pKeep
            // 
            this.pKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pKeep.Location = new System.Drawing.Point(295, 3);
            this.pKeep.Name = "pKeep";
            this.pKeep.Size = new System.Drawing.Size(246, 39);
            this.pKeep.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mode d\'affichage";
            // 
            // cbboxSizeMode
            // 
            this.cbboxSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxSizeMode.FormattingEnabled = true;
            this.cbboxSizeMode.Location = new System.Drawing.Point(6, 21);
            this.cbboxSizeMode.Name = "cbboxSizeMode";
            this.cbboxSizeMode.Size = new System.Drawing.Size(121, 21);
            this.cbboxSizeMode.TabIndex = 6;
            this.cbboxSizeMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Location = new System.Drawing.Point(12, 419);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 39);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "Image précédente";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(93, 419);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 39);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Image suivante";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generalToolStripMenuItem,
            this.affichageToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(871, 24);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirDossierToolStripMenuItem,
            this.exporterToolStripMenuItem,
            this.toolStripSeparator5,
            this.quitterToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ouvrirDossierToolStripMenuItem
            // 
            this.ouvrirDossierToolStripMenuItem.Name = "ouvrirDossierToolStripMenuItem";
            this.ouvrirDossierToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ouvrirDossierToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.ouvrirDossierToolStripMenuItem.Text = "Ouvrir dossier d\'images";
            this.ouvrirDossierToolStripMenuItem.Click += new System.EventHandler(this.ouvrirDossierToolStripMenuItem_Click);
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exporterToolStripMenuItem.Text = "Exporter";
            this.exporterToolStripMenuItem.Click += new System.EventHandler(this.exporterToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(238, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.sauvegarderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sauvegardesAutoToolStripMenuItem,
            this.toolStripSeparator1,
            this.eFFACERTOUTToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generalToolStripMenuItem.Text = "Général";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "Ouvrir sauvegarde";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // sauvegardesAutoToolStripMenuItem
            // 
            this.sauvegardesAutoToolStripMenuItem.Name = "sauvegardesAutoToolStripMenuItem";
            this.sauvegardesAutoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.sauvegardesAutoToolStripMenuItem.Text = "Sauvegardes automatiques";
            this.sauvegardesAutoToolStripMenuItem.Click += new System.EventHandler(this.ouvrirLeDossierDeSauvegardesAutoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // eFFACERTOUTToolStripMenuItem
            // 
            this.eFFACERTOUTToolStripMenuItem.Name = "eFFACERTOUTToolStripMenuItem";
            this.eFFACERTOUTToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.eFFACERTOUTToolStripMenuItem.Text = "Décharger les images";
            this.eFFACERTOUTToolStripMenuItem.Click += new System.EventHandler(this.effacerToutToolStripMenuItem_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afficherCacherListeToolStripMenuItem,
            this.afficherToolStripMenuItem,
            this.modeFacileToolStripMenuItem});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // afficherCacherListeToolStripMenuItem
            // 
            this.afficherCacherListeToolStripMenuItem.Name = "afficherCacherListeToolStripMenuItem";
            this.afficherCacherListeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.afficherCacherListeToolStripMenuItem.Text = "Afficher / Cacher liste";
            this.afficherCacherListeToolStripMenuItem.Click += new System.EventHandler(this.afficherCacherListeToolStripMenuItem_Click);
            // 
            // afficherToolStripMenuItem
            // 
            this.afficherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toutesToolStripMenuItem,
            this.sélectionnéesToolStripMenuItem,
            this.nonSélectionnéesToolStripMenuItem,
            this.rafraichirToolStripMenuItem});
            this.afficherToolStripMenuItem.Name = "afficherToolStripMenuItem";
            this.afficherToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.afficherToolStripMenuItem.Text = "Afficher";
            // 
            // toutesToolStripMenuItem
            // 
            this.toutesToolStripMenuItem.Checked = true;
            this.toutesToolStripMenuItem.CheckOnClick = true;
            this.toutesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toutesToolStripMenuItem.Name = "toutesToolStripMenuItem";
            this.toutesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toutesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.toutesToolStripMenuItem.Text = "Toutes";
            this.toutesToolStripMenuItem.Click += new System.EventHandler(this.toutesToolStripMenuItem_Click);
            // 
            // sélectionnéesToolStripMenuItem
            // 
            this.sélectionnéesToolStripMenuItem.CheckOnClick = true;
            this.sélectionnéesToolStripMenuItem.Name = "sélectionnéesToolStripMenuItem";
            this.sélectionnéesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.sélectionnéesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sélectionnéesToolStripMenuItem.Text = "Sélectionnées";
            this.sélectionnéesToolStripMenuItem.Click += new System.EventHandler(this.sélectionnéesToolStripMenuItem_Click);
            // 
            // nonSélectionnéesToolStripMenuItem
            // 
            this.nonSélectionnéesToolStripMenuItem.CheckOnClick = true;
            this.nonSélectionnéesToolStripMenuItem.Name = "nonSélectionnéesToolStripMenuItem";
            this.nonSélectionnéesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.nonSélectionnéesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nonSélectionnéesToolStripMenuItem.Text = "Non sélectionnées";
            this.nonSélectionnéesToolStripMenuItem.Click += new System.EventHandler(this.nonSélectionnéesToolStripMenuItem_Click);
            // 
            // rafraichirToolStripMenuItem
            // 
            this.rafraichirToolStripMenuItem.Name = "rafraichirToolStripMenuItem";
            this.rafraichirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.rafraichirToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rafraichirToolStripMenuItem.Text = "Rafraichir";
            this.rafraichirToolStripMenuItem.Click += new System.EventHandler(this.rafraichirToolStripMenuItem_Click);
            // 
            // modeFacileToolStripMenuItem
            // 
            this.modeFacileToolStripMenuItem.Checked = true;
            this.modeFacileToolStripMenuItem.CheckOnClick = true;
            this.modeFacileToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.modeFacileToolStripMenuItem.Name = "modeFacileToolStripMenuItem";
            this.modeFacileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.modeFacileToolStripMenuItem.Text = "Mode facile";
            this.modeFacileToolStripMenuItem.CheckedChanged += new System.EventHandler(this.modeFacileToolStripMenuItem_CheckedChanged);
            // 
            // tvMain
            // 
            this.tvMain.AllowDrop = true;
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMain.BackColor = System.Drawing.SystemColors.Control;
            this.tvMain.Location = new System.Drawing.Point(12, 3);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(188, 407);
            this.tvMain.TabIndex = 4;
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.tvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseClick);
            this.tvMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbMain_DragDrop);
            this.tvMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbMain_DragEnter);
            this.tvMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvMain_KeyDown);
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 24);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.lblCount);
            this.spMain.Panel1.Controls.Add(this.tvMain);
            this.spMain.Panel1.Controls.Add(this.btnPrevious);
            this.spMain.Panel1.Controls.Add(this.btnNext);
            this.spMain.Panel1MinSize = 200;
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.panel1);
            this.spMain.Panel2.Controls.Add(this.pPB);
            this.spMain.Panel2MinSize = 400;
            this.spMain.Size = new System.Drawing.Size(871, 464);
            this.spMain.SplitterDistance = 200;
            this.spMain.SplitterWidth = 10;
            this.spMain.TabIndex = 6;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCount.Location = new System.Drawing.Point(174, 432);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCount.Size = new System.Drawing.Size(23, 13);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pbMain);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 407);
            this.panel1.TabIndex = 10;
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(625, 407);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbMain_DragDrop);
            this.pbMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbMain_DragEnter);
            // 
            // svDialog
            // 
            this.svDialog.DefaultExt = "Fichier de sauvegarde|*.ssv";
            this.svDialog.Filter = "Fichier de sauvegarde|*.ssv";
            this.svDialog.Title = "Sélectionner l\'emplacement de sauvegarde";
            // 
            // ofDialog
            // 
            this.ofDialog.DefaultExt = "Fichier de sauvegarde|*.ssv";
            this.ofDialog.Filter = "Fichier de sauvegarde|*.ssv";
            this.ofDialog.Title = "Sélecctionnez le fichier à charger";
            // 
            // tmrAutoSave
            // 
            this.tmrAutoSave.Enabled = true;
            this.tmrAutoSave.Interval = 60000;
            this.tmrAutoSave.Tick += new System.EventHandler(this.tmrAutoSave_Tick);
            // 
            // cmsDirectory
            // 
            this.cmsDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toutMettreGardéToolStripMenuItem,
            this.toutMettreNonGardéToolStripMenuItem,
            this.toolStripSeparator3,
            this.déchargerToolStripMenuItem});
            this.cmsDirectory.Name = "cmsDirectory";
            this.cmsDirectory.Size = new System.Drawing.Size(169, 76);
            // 
            // toutMettreGardéToolStripMenuItem
            // 
            this.toutMettreGardéToolStripMenuItem.Name = "toutMettreGardéToolStripMenuItem";
            this.toutMettreGardéToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.toutMettreGardéToolStripMenuItem.Text = "Tout garder";
            this.toutMettreGardéToolStripMenuItem.Click += new System.EventHandler(this.toutMettreGardéToolStripMenuItem_Click);
            // 
            // toutMettreNonGardéToolStripMenuItem
            // 
            this.toutMettreNonGardéToolStripMenuItem.Name = "toutMettreNonGardéToolStripMenuItem";
            this.toutMettreNonGardéToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.toutMettreNonGardéToolStripMenuItem.Text = "Ne rien garder";
            this.toutMettreNonGardéToolStripMenuItem.Click += new System.EventHandler(this.toutMettreNonGardéToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // déchargerToolStripMenuItem
            // 
            this.déchargerToolStripMenuItem.Name = "déchargerToolStripMenuItem";
            this.déchargerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.déchargerToolStripMenuItem.Text = "Décharger dossier";
            this.déchargerToolStripMenuItem.Click += new System.EventHandler(this.déchargerToolStripMenuItem_Click);
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator4,
            this.toolStripMenuItem4});
            this.cmsFile.Name = "cmsDirectory";
            this.cmsFile.Size = new System.Drawing.Size(148, 76);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem2.Text = "Garder";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem3.Text = "Ne pas garder";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(144, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem4.Text = "Décharger";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 488);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.msMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Sélectionneur d\'images";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pPB.ResumeLayout(false);
            this.pPB.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.cmsDirectory.ResumeLayout(false);
            this.cmsFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pPB;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirDossierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.Panel pKeep;
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sélectionnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonSélectionnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbboxSizeMode;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.ToolStripMenuItem rafraichirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog svDialog;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.Timer tmrAutoSave;
        private System.Windows.Forms.ToolStripMenuItem sauvegardesAutoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem eFFACERTOUTToolStripMenuItem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRotCCW;
        private System.Windows.Forms.Button btnRotCW;
        private System.Windows.Forms.ContextMenuStrip cmsDirectory;
        private System.Windows.Forms.ToolStripMenuItem toutMettreGardéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toutMettreNonGardéToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem déchargerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherCacherListeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem modeFacileToolStripMenuItem;
    }
}

