using EsseivaN.Tools;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Environment;

// TODO :
// Autosave
// Ajout de getsion de plusieurs dossiers en meme temps

namespace PictureSelecter
{
    public partial class frmMain : Form
    {
        private CommonOpenFileDialog openFolder = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            InitialDirectory = GetFolderPath(SpecialFolder.MyPictures),
            Multiselect = true
        };

        private bool pictureAutoSizeMode = false;
        private Image currentImage = null;
        private List<PictureFolder> folders = new List<PictureFolder>();
        private int selectedChild = 0;
        private int selectedFolder = 0;
        private int displayMode = 0;
        private string autoSavePath;
        private string instanceRunTime;
        private int counter = 0;
        private bool btnClicked = false;

        private SettingsManager<PictureFolder> settings = new SettingsManager<PictureFolder>();

        //private bool Dragging;
        //private int xPos;
        //private int yPos;

        public frmMain()
        {
            InitializeComponent();
            cbboxSizeMode.Items.Add("Auto");
            cbboxSizeMode.Items.AddRange(Enum.GetNames(typeof(PictureBoxSizeMode)));
            cbboxSizeMode.SelectedIndex = 5;
            svDialog.InitialDirectory = GetFolderPath(SpecialFolder.MyPictures);
            ofDialog.InitialDirectory = GetFolderPath(SpecialFolder.MyPictures);
            autoSavePath = GetFolderPath(SpecialFolder.MyDocuments) + "\\SelectionneurImages_AutoSaves";
            if (!Directory.Exists(autoSavePath))
            {
                Directory.CreateDirectory(autoSavePath);
            }

            instanceRunTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".ssv";

            pbMain.AllowDrop = true;
        }

        private void writeLog(string log)
        {
            Console.WriteLine(log);
        }

        /// <summary>
        /// Sauvegarde automatique
        /// </summary>
        private void AutoSave()
        {
            try
            {
                if (folders.Count != 0)
                {
                    string path = autoSavePath + "\\" + instanceRunTime;
                    Export(path);
                }
            }
            catch (Exception ex)
            {
                writeLog("Unable to autosave at " + autoSavePath + "\\" + instanceRunTime + "\nError : " + ex.Message);
            }
        }

        private void ouvrirDossierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFolderDialog("Sélectionnez le dossier à ouvrir") == CommonFileDialogResult.Ok)
            {
                foreach (string filename in openFolder.FileNames)
                {
                    if (folders.Where((p, b) => (p.GetFolderPath() == filename)).Count() == 0)
                    {
                        writeLog("Dossier choisi : " + filename);
                        PictureFolder pf = new PictureFolder(filename);
                        folders.Add(pf);
                        OuvrirImages(pf);
                    }
                }
            }
        }

        private CommonFileDialogResult openFolderDialog(string Titre)
        {
            openFolder.Title = Titre;
            return openFolder.ShowDialog();
        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFolderDialog("Sélectionnez l'emplacement d'export") == CommonFileDialogResult.Ok)
            {
                string exportPath = openFolder.FileName;
                writeLog("Dossier choisi : " + exportPath);
                string destPath;
                int i = 0;
                int j = 0;
                foreach (PictureFolder pictureFolder in folders)
                {
                    j += pictureFolder.GetImages().Count;
                    foreach (ImageInfo imageInfo in pictureFolder.GetImages())
                    {
                        if (imageInfo.getSaved())
                        {
                            destPath = exportPath + "\\" + imageInfo.getName();
                            if (File.Exists(destPath))
                            {
                                writeLog("File already existing : " + destPath);
                            }
                            else
                            {
                                try
                                {
                                    File.Copy(imageInfo.getFullName(), destPath);
                                    i++;
                                }
                                catch (Exception ex)
                                {
                                    if (MessageBox.Show("Impossible de copier :\n" + imageInfo.getFullName() + "\nà la destination suivante :\n" + destPath + "\nErreur : \n" + ex.Message, "ERREUR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Copie de " + i + "/" + j + " images terminées.\nDestination : " + exportPath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Ouvrir dossier
        /// </summary>
        private void OuvrirImages(PictureFolder pictureFolder)
        {
            string folderPath = pictureFolder.GetFolderPath();
            var rootDirectoryInfo = new DirectoryInfo(folderPath);
            pictureFolder.ClearImages();
            // Récupérer tous les fichiers
            var t_files = rootDirectoryInfo.GetFiles("*.*");
            foreach (var item in t_files)
            {
                if (item.Extension == ".png" || item.Extension == ".jpg" || item.Extension == ".jpeg")
                {
                    // Sauvegarder les images .png ou .jpg
                    pictureFolder.AddImage(new ImageInfo(item.Name, folderPath));
                    writeLog(item.Name);
                }
            }
            // Populer le treeView
            ListDirectories(displayMode);
        }

        private void afficherCacherListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spMain.Panel1Collapsed = afficherCacherListeToolStripMenuItem.Checked;
        }

        private void ListDirectories(int mode)
        {
            counter = 0;
            tvMain.Nodes.Clear();
            foreach (PictureFolder pictureFolder in folders)
            {
                ListDirectory(pictureFolder, displayMode);
            }
            tvMain.ExpandAll();
            lblCount.Text = counter.ToString();
        }

        private void ListDirectory(PictureFolder pictureFolder, int mode)
        {
            var rootDirectoryInfo = new DirectoryInfo(pictureFolder.GetFolderPath());
            // Filtrer les images suivant le filtre sélectionné
            pictureFolder.ApplyFilter(mode);
            TreeNode directoryNode = new TreeNode(rootDirectoryInfo.Name) { };
            foreach (var image in pictureFolder.GetImagesFiltered())
            {
                directoryNode.Nodes.Add(new TreeNode(image.getName()) { BackColor = image.getSaved() ? Color.PaleGreen : Color.PaleVioletRed });
                counter++;
            }
            tvMain.Nodes.Add(directoryNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (btnClicked)
            {
                return;
            }
            var child = tvMain.SelectedNode;
            var parent = child.Parent;
            if (parent == null)
            {
                selectedChild = -1;
                selectedFolder = child.Index;
                pKeep.BackColor = SystemColors.Control;
            }
            else
            {
                selectedChild = child.Index;
                selectedFolder = parent.Index;
            }
            writeLog("Child : " + selectedChild + " Folder : " + selectedFolder);
            currentImage?.Dispose();
            displayPicture();
        }

        private void displayPicture()
        {
            if (selectedChild == -1)
            {
                pbMain.Image = null;
                return;
            }

            PictureFolder pictureFolder = folders.ElementAt(selectedFolder);
            ImageInfo imageInfo = pictureFolder.GetImagesFiltered().ElementAtOrDefault(selectedChild);
            if (imageInfo == null)
            {
                return;
            }

            string filePath = imageInfo.getFullName();
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Erreur ! Fichier non trouvé : \n" + filePath, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pbMain.Image = null;
                return;
            }

            currentImage = Image.FromFile(filePath);
            if (currentImage.PropertyIdList.Contains(0x112))
            {
                var property = currentImage.GetPropertyItem(0x112);
                var value = property.Value[0];
                writeLog(value.ToString());
                switch (value)
                {
                    case 1:
                        // No rotation required.
                        break;
                    case 2:
                        currentImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        currentImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        currentImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        currentImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        currentImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
            }

            //// Rotate the image according to EXIF data
            //var bmp = new Bitmap(pathToImageFile);
            //var exif = new EXIFextractor(ref bmp, "n"); // get source from http://www.codeproject.com/KB/graphics/exifextractor.aspx?fid=207371

            //if (exif["Orientation"] != null)
            //{
            //    RotateFlipType flip = OrientationToFlipType(exif["Orientation"].ToString());

            //    if (flip != RotateFlipType.RotateNoneFlipNone) // don't flip of orientation is correct
            //    {
            //        bmp.RotateFlip(flip);
            //        exif.setTag(0x112, "1"); // Optional: reset orientation tag
            //        bmp.Save(pathToImageFile, ImageFormat.Jpeg);
            //    }


            pbMain.Image = currentImage;
            if (pictureAutoSizeMode)
            {
                pictureBox_AutoSize();
            }
            setSaved(imageInfo.getSaved());
        }

        private void setSaved(bool state)
        {
            if (selectedChild == -1)
            {
                return;
            }

            PictureFolder pictureFolder = folders.ElementAt(selectedFolder);
            pictureFolder.SetSaved(selectedChild, state);
            pKeep.BackColor = state ? Color.PaleGreen : Color.PaleVioletRed;
            tvMain.Nodes[selectedFolder].Nodes[selectedChild].BackColor = state ? Color.PaleGreen : Color.PaleVioletRed;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbboxSizeMode.SelectedIndex != 0)
            {
                pictureAutoSizeMode = false;
                pbMain.SizeMode = (PictureBoxSizeMode)(cbboxSizeMode.SelectedIndex - 1);
            }
            else
            {
                pictureAutoSizeMode = true;
                if (currentImage != null)
                {
                    pictureBox_AutoSize();
                }
            }
        }

        private void pictureBox_AutoSize()
        {
            if (currentImage.Width < pbMain.Width && currentImage.Height < pbMain.Height)
            {
                pbMain.SizeMode = PictureBoxSizeMode.Normal;
            }
            else
            {
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private class ImageInfo
        {
            public bool saved = false;
            private string name;
            public string rootPath;
            private static int counter = 0;
            private int id;

            public void setRootPath(string path)
            {
                rootPath = path;
            }

            public string getRootPath()
            {
                return rootPath;
            }

            public string getFullName()
            {
                return rootPath + "\\" + name;
            }

            private ImageInfo()
            {
            }

            public ImageInfo(string Name, string RootPath) : this(Name, RootPath, false)
            {
            }

            public ImageInfo(string Name, string RootPath, bool Saved)
            {
                name = Name;
                rootPath = RootPath;
                saved = Saved;
                id = counter++;
            }

            public string getName()
            {
                return name;
            }

            public bool getSaved()
            {
                return saved;
            }

            public void setSaved(bool state)
            {
                saved = state;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnClicked = true;
            if (folders.Count == 0)
            {
                btnClicked = false;
                return;
            }

            if (selectedChild > 0)
            {
                selectedChild--;
            }
            else
            {
                if (selectedFolder > 0)
                {
                    selectedFolder--;
                }
                else
                {
                    selectedFolder = tvMain.Nodes.Count - 1;
                }

                selectedChild = tvMain.Nodes[selectedFolder].Nodes.Count - 1;
            }
            displayPicture();
            if (selectedChild != -1)
            {
                tvMain.SelectedNode = tvMain.Nodes[selectedFolder].Nodes[selectedChild];
            }
            else
            {
                tvMain.SelectedNode = tvMain.Nodes[selectedFolder];
            }
            tvMain.Focus();
            btnClicked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnClicked = true;
            if (folders.Count == 0)
            {
                btnClicked = false;
                return;
            }

            if (selectedChild < (tvMain.Nodes[selectedFolder].Nodes.Count - 1))
            {
                selectedChild++;
            }
            else
            {
                if (selectedFolder < tvMain.Nodes.Count - 1)
                {
                    selectedFolder++;
                }
                else
                {
                    selectedFolder = 0;
                }

                selectedChild = tvMain.Nodes[selectedFolder].Nodes.Count == 0 ? -1 : 0;
            }
            displayPicture();
            if (selectedChild != -1)
            {
                tvMain.SelectedNode = tvMain.Nodes[selectedFolder].Nodes[selectedChild];
            }
            else
            {
                tvMain.SelectedNode = tvMain.Nodes[selectedFolder];
            }

            tvMain.Focus();
            btnClicked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folders.Count == 0)
            {
                return;
            }

            if (selectedChild != -1)
            {
                setSaved(!folders.ElementAt(selectedFolder).GetImagesFiltered().ElementAt(selectedChild).getSaved());
            }
            else
            {
                var t = folders.ElementAt(selectedFolder);
                var t2 = t.GetImagesFiltered();
                bool state;
                for (int i = 0; i < t.GetImagesFiltered().Count; i++)
                {
                    state = !t2.ElementAt(i).getSaved();
                    t.SetSaved(i, state);
                    tvMain.Nodes[selectedFolder].Nodes[i].BackColor = state ? Color.PaleGreen : Color.PaleVioletRed;
                }
            }

            tvMain.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    btnKeep.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Down:
                    btnNext.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Right:
                    btnRotLeft.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Up:
                    btnPrevious.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Left:
                    btnRotCCW.PerformClick();
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void toutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!toutesToolStripMenuItem.Checked)
            {
                toutesToolStripMenuItem.Checked = true;
            }
            else
            {
                sélectionnéesToolStripMenuItem.Checked = nonSélectionnéesToolStripMenuItem.Checked = false;
                writeLog("Afficher tout");
                displayMode = 0;
            }
            ListDirectories(displayMode);
        }

        private void sélectionnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!sélectionnéesToolStripMenuItem.Checked)
            {
                sélectionnéesToolStripMenuItem.Checked = true;
            }
            else
            {
                toutesToolStripMenuItem.Checked = nonSélectionnéesToolStripMenuItem.Checked = false;
                writeLog("Afficher sélectionnés");
                displayMode = 1;
            }
            ListDirectories(displayMode);
        }

        private void nonSélectionnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!nonSélectionnéesToolStripMenuItem.Checked)
            {
                nonSélectionnéesToolStripMenuItem.Checked = true;
            }
            else
            {
                toutesToolStripMenuItem.Checked = sélectionnéesToolStripMenuItem.Checked = false;
                writeLog("Afficher non sélectionnés");
                displayMode = 2;
            }
            ListDirectories(displayMode);
        }

        private void rechargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writeLog("TODO");
        }

        private void Export(string path)
        {
            settings.Clear();
            settings.AddSettingRange(folders);
            settings.Save(path);
        }

        private string addLine(string source, string line)
        {
            return source += line + "\n";
        }

        private void askImport()
        {
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                writeLog("Fichier choisi : " + ofDialog.FileName);
                import(ofDialog.FileName);
            }
        }

        private void import(string path)
        {
            string data = File.ReadAllText(path).Replace("\r", "");
            string[] lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] lines_2;
            ImageInfo imageinfo;
            PictureFolder pictureFolder = new PictureFolder(null);
            if (lines.Length < 2)
            {
                MessageBox.Show("Sauvegarde invalide", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Tag de début et fin de sauvegarde
            if (lines.FirstOrDefault() == "#00 START OF SAVE" && lines.LastOrDefault() == "#09 END OF SAVE")
            {
                writeLog("Valid save format");

                int i = 1;
                while (i < (lines.Length - 1))
                {
                    lines_2 = lines[i++].Split(new char[] { ' ' }, 2);

                    // Tag de début de dossier
                    if (lines_2[0] == "#10" && lines_2[1] != string.Empty)
                    {
                        string folderPath = lines_2[1];
                        if (folders.Where((p, b) => p.GetFolderPath() == folderPath).Count() != 0)
                        {
                            MessageBox.Show("Emplacement :\n" + folderPath + "\ndéjà chargé !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            pictureFolder = new PictureFolder(lines_2[1]);

                            while (i < (lines.Length - 1))
                            {
                                lines_2 = lines[i].Split(new char[] { ' ' }, 2);

                                // Tag d'image
                                if (lines_2[0] == "#11" && lines_2[1] != string.Empty)
                                {
                                    i++;
                                    imageinfo = new ImageInfo(lines_2[1], pictureFolder.GetFolderPath());
                                    lines_2 = lines[i].Split(new char[] { ' ' }, 2);

                                    // Tag de save
                                    if (lines_2[0] == "#12" && lines_2[1] != string.Empty)
                                    {
                                        i++;
                                        imageinfo.setSaved(lines_2[1] == "1");
                                        pictureFolder.AddImage(imageinfo);
                                    }
                                    else
                                    {
                                        pictureFolder.AddImage(imageinfo);
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }

                    lines_2 = lines[i].Split(new char[] { ' ' }, 2);
                    // Fin de dossier
                    if (lines_2[0] == "#02")
                    {
                        if (pictureFolder.GetImages() == null || pictureFolder.GetImages()?.Count == 0)
                        {
                            MessageBox.Show("Dossier sans images valides :\n" + pictureFolder.GetFolderPath(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            folders.Add(pictureFolder);
                        }
                    }
                    // Fin de sauvegarde
                    else if (lines_2[0] == "#09")
                    {
                        break;
                    }
                }
                ListDirectories(displayMode);
            }
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (svDialog.ShowDialog() == DialogResult.OK)
            {
                writeLog("Dossier choisi : " + svDialog.FileName);
                Export(svDialog.FileName);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folders.Count != 0)
            {
                if (MessageBox.Show("Vous êtes sur le point de quitter.\nVérifier de bien avoir sauvegardé avant de quitter !\nVoulez-vous vraiment quitter ?", "ATTENTION", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
            }

            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            askImport();
        }

        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void ouvrirLeDossierDeSauvegardesAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(autoSavePath);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Contains("INSTALLED"))
            {
                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Close();
                return;
            }
        }

        private class PictureFolder
        {
            public List<ImageInfo> images;
            private List<ImageInfo> images_f;
            public string folderPath;

            public PictureFolder(string folderPath)
            {
                this.folderPath = folderPath;
            }

            public void ApplyFilter(int mode)
            {
                images_f = images.Where((i, b) => ((mode == 0) || (mode == 1 && i.getSaved()) || (mode == 2 && !i.getSaved()))).ToList();
            }

            public string GetFolderPath() => folderPath;

            public void SetFolderPath(string folderPath) => this.folderPath = folderPath;

            public List<ImageInfo> GetImagesFiltered() => images_f;

            public List<ImageInfo> GetImages()
            {
                return images;
            }

            public int GetImagesCount() => images.Count;

            public void SetImages(List<ImageInfo> images)
            {
                if (images == null)
                {
                    images = new List<ImageInfo>();
                }

                this.images = ((ImageInfo[])images.ToArray().Clone()).ToList();
            }

            public void ClearImages()
            {
                if (images == null)
                {
                    images = new List<ImageInfo>();
                }

                images.Clear();
            }

            public void AddImage(ImageInfo image)
            {
                if (images == null)
                {
                    images = new List<ImageInfo>();
                }

                images.Add(image);
            }

            public void RemoveImage(int index)
            {
                images.RemoveAt(index);
            }

            public void SetSaved(int index, bool state)
            {
                images.ElementAt(images.IndexOf(images_f.ElementAt(index))).setSaved(state);
            }
        }

        private void effacerToutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Attention !\nToutes données non sauvegardées seront perdues !!\nTous les dossiers ouverts seront déchargés !\nCONTINUER ?", "ATTENTION", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                folders.Clear();
                tvMain.Nodes.Clear();
                pKeep.BackColor = SystemColors.Control;
                counter = 0;
                lblCount.Text = "0";
            }
        }

        private void rafraichirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDirectories(displayMode);
            tvMain.SelectedNode = tvMain.Nodes[selectedFolder];
            displayPicture();
        }

        private void pbMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    writeLog("Drag and drop folder : " + file);

                    var copies = folders.Where((p, b) => (p.GetFolderPath() == file));

                    if (copies.Count() == 0)
                    {
                        PictureFolder pictureFolder = new PictureFolder(file);
                        OuvrirImages(pictureFolder);
                        if (pictureFolder.GetImages() == null || pictureFolder.GetImages()?.Count == 0)
                        {
                            MessageBox.Show("Dossier sans images valides :\n" + pictureFolder.GetFolderPath(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            folders.Add(pictureFolder);
                        }
                    }
                    else
                    {
                        PictureFolder pictureFolder = copies.FirstOrDefault();
                        OuvrirImages(pictureFolder);
                        if (pictureFolder.GetImages() == null || pictureFolder.GetImages()?.Count == 0)
                        {
                            MessageBox.Show("Dossier sans images valides :\n" + pictureFolder.GetFolderPath(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    string ext = Path.GetExtension(file);
                    if (ext.Equals(".ssv", StringComparison.CurrentCultureIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Copy;
                        import(file);
                    }
                }
            }
            ListDirectories(displayMode);
        }

        private void pbMain_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                if (Directory.Exists(file))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    string ext = Path.GetExtension(file);
                    if (ext.Equals(".ssv", StringComparison.CurrentCultureIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void btnRotRight_Click(object sender, EventArgs e)
        {
            if (folders.Count == 0)
            {
                currentImage = null;
                return;
            }

            if (currentImage != null)
            {
                currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pbMain.Image = currentImage;
            }
            tvMain.Focus();
        }

        private void btnRotLeft_Click(object sender, EventArgs e)
        {
            if (folders.Count == 0)
            {
                currentImage = null;
                return;
            }

            if (currentImage != null)
            {
                currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pbMain.Image = currentImage;
            }
            tvMain.Focus();
        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = e.Node;
                writeLog(node.Index.ToString());

                if (node.Parent == null)
                {
                    // Dossier
                    cmsDirectory.Show(tvMain, e.Location);
                    selectedChild = -1;
                    selectedFolder = node.Index;
                    tvMain.SelectedNode = tvMain.Nodes[selectedFolder];
                }
                else
                {
                    cmsFile.Show(tvMain, e.Location);
                    selectedChild = node.Index;
                    selectedFolder = node.Parent.Index;
                    tvMain.SelectedNode = tvMain.Nodes[selectedFolder].Nodes[selectedChild];
                }
            }
        }

        private void toutMettreGardéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSavedAll(true);
        }

        private void toutMettreNonGardéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSavedAll(false);
        }

        private void SetSavedAll(bool state)
        {
            var parent = tvMain.SelectedNode.Parent;
            if (parent != null)
            {
                return;
            }

            PictureFolder pictureFolder = folders.ElementAt(selectedFolder);

            for (int i = 0; i < pictureFolder.GetImagesCount(); i++)
            {
                pictureFolder.SetSaved(i, state);
            }
            ListDirectories(displayMode);
        }

        private void déchargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parent = tvMain.SelectedNode.Parent;
            if (parent != null)
            {
                return;
            }

            folders.RemoveAt(selectedFolder);

            ListDirectories(displayMode);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var parent = tvMain.SelectedNode.Parent;
            if (parent == null)
            {
                return;
            }

            setSaved(true);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var parent = tvMain.SelectedNode.Parent;
            if (parent == null)
            {
                return;
            }

            setSaved(false);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var parent = tvMain.SelectedNode.Parent;
            if (parent == null)
            {
                return;
            }

            folders.ElementAt(selectedFolder).RemoveImage(selectedChild);

            ListDirectories(displayMode);
        }

        private void tvMain_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void modeFacileToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private Image zoomImage(Image image, double factor)
        //{
        //    Size newSize = new Size((int)(currentImage.Width * factor), (int)(currentImage.Height * factor));
        //    return new Bitmap(currentImage, newSize);
        //}

        //private void pbMain_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Dragging = true;
        //        xPos = e.X;
        //        yPos = e.Y;
        //    }
        //}

        //private void pbMain_MouseUp(object sender, MouseEventArgs e)
        //{
        //    Dragging = false;
        //}

        //private void pbMain_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Control c = sender as Control;
        //    if (Dragging && c != null)
        //    {
        //        c.Top = e.Y + c.Top - yPos;
        //        c.Left = e.X + c.Left - xPos;
        //    }
        //}
    }
}
