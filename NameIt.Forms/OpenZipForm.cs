using System;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

namespace NameIt
{
    public partial class OpenZipForm : Form
    {
        private readonly MainForm mainForm;
        private string beamFolder = @"BeamNG.drive\mods\";

        public OpenZipForm(Form callingForm)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            beamFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), beamFolder);
            UpdateList();
        }

        private void UpdateList()
        {
            lstMods.Items.Clear();

            foreach (string s in Directory.GetFileSystemEntries(beamFolder, "*.zip"))
            {
                using (ZipFile zip = ZipFile.Read(Path.Combine(beamFolder, s)))
                {
                    if (zip.ContainsEntry("ModifierTool"))
                    {
                        lstMods.Items.Add("M - " + Path.GetFileName(s));
                    }
                    else if (zip.ContainsEntry("info.json"))
                    {
                        lstMods.Items.Add(Path.GetFileName(s));
                    }
                }
            }
        }

        private void OpenSelected()
        {
            string fileName = Path.Combine(beamFolder, lstMods.SelectedItem.ToString().Replace("M - ", ""));

            mainForm.StartReading(fileName);
            Close();
        }

        private void Button2_Click(object sender, EventArgs e) //Choose From Folder button
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr != DialogResult.OK) return;
            mainForm.StartReading(openFileDialog1.FileName);
            Close();
        }

        private void BtnOpenSel_Click(object sender, EventArgs e)
        {
            OpenSelected();
        }

        private void LstMods_DoubleClick(object sender, EventArgs e)
        {
            if (lstMods.SelectedItem != null)
            {
                OpenSelected();
            }
        }
    }
}
