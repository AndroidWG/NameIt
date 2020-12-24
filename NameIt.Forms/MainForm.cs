using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Newtonsoft.Json.Linq;

namespace NameIt
{
    public partial class MainForm : Form
    {
        private bool alreadyModded;

        private string baseDir = "BeamNGMNT";
        private const string TempDir = @"\Temp";
        private const string BackupDir = @"\Backups";

        private string beamFolder = @"BeamNG.drive\mods\";

        private string modFilepath;
        private string modFilename;
        private string fileName;
        private JObject parsed;

        //-- Form laoding shit --

        public MainForm() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = @"v" + Application.ProductVersion;

            beamFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), beamFolder);
            Console.WriteLine($"BeamNG folder is {beamFolder}");

            baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), baseDir);

            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
                Directory.CreateDirectory(baseDir + TempDir);
                Directory.CreateDirectory(baseDir + BackupDir);
            }

            if (Directory.Exists(baseDir + TempDir))
            {
                Directory.Delete(baseDir + TempDir, true);
                Directory.CreateDirectory(baseDir + TempDir);
            }

            Directory.SetCurrentDirectory(baseDir + TempDir);
            Console.WriteLine($"Working directory is {baseDir + TempDir}");

            UpdateBackupList();
        }


        // -- Methods --

        private static bool IsBeamNgOpen {
            get
            {
                Process[] pname = Process.GetProcessesByName("BeamNG.drive");
                return pname.Length != 0;
            }
        }

        private static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        //-- Functions --

        public void StartReading(string file)
        {
            alreadyModded = false;
            chkColors.Enabled = true;

            modFilepath = file;

            modFilename = Path.GetFileName(modFilepath);

            if (IsBeamNgOpen && IsFileLocked(new FileInfo(modFilepath)))
            {
                const string message = "We detected that BeamNG is open, meaning it is currently using this file. When trying to apply changes, we will not be able to do so if you don't close BeamNG. Do you wish to continue opening this file?";
                const string title = "File is Being Used";
                const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    ReadZip();
                }
            }
            else
            {
                ReadZip();
            }
        }

        private void ReadZip()
        {
            label1.Text = modFilename;

            using (ZipFile zip = ZipFile.Read(modFilepath))
            {
                if (zip.ContainsEntry("ModifierTool"))
                {
                    alreadyModded = true;
                    Console.WriteLine("Already modified this mod!");
                }

                if (zip.ContainsEntry("AddedColors"))
                {
                    chkColors.Enabled = false;
                }

                foreach (ZipEntry z in zip)
                {
                    if (!z.FileName.Contains("info.json") || !z.FileName.Contains("vehicle")) continue;
                    
                    Console.WriteLine("Found info.json file: " + z.FileName);

                    z.Extract(ExtractExistingFileAction.OverwriteSilently);

                    fileName = z.FileName;

                    parsed = JObject.Parse(File.ReadAllText(z.FileName));
                    label5.Text = $"Name: {(string)parsed["Name"]}\n\nType: {(string)parsed["Type"]}";

                    if (alreadyModded)
                    {
                        ReadInfo();
                    }

                    lblStatus.Text = "Read info.json file successfully";
                }
            }
        }

        private void ReadInfo()
        {
            txtName.Text = (string)parsed["Name"];
            txtBrand.Text = (string)parsed["Brand"];
            txtBody.Text = (string)parsed["Body Style"];
            txtCountry.Text = (string)parsed["Country"];
            txtYear1.Text = (string)parsed["Years"]?["min"];
            txtYear2.Text = (string)parsed["Years"]?["max"];

            Console.WriteLine("Read info to textboxes");
        }

        private void CreateBackup()
        {
            string endFilePath = Path.Combine(baseDir + BackupDir, modFilename);

            if (File.Exists(endFilePath))
            {
                string message = "A backup for this file already exists. Do you wish to overwrite it?";
                string title = "Overwrite Backup";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    File.Copy(modFilepath, endFilePath, true);
                    Console.WriteLine($"Copied {modFilename} to {Path.Combine(baseDir + BackupDir, modFilename)}");

                    UpdateBackupList();
                }
                else
                {
                    Console.WriteLine($"User chose to not create a backup for mod {modFilename}");
                }
            }
            else
            {
                File.Copy(modFilepath, endFilePath);
                Console.WriteLine($"Copied {modFilename} to {Path.Combine(baseDir + BackupDir, modFilename)}");

                UpdateBackupList();
            }
        }

        private void ModifyJson()
        {
            if (alreadyModded)
            {
                parsed["Name"] = txtName.Text;
                parsed["Brand"] = txtBrand.Text;
                parsed["Country"] = txtCountry.Text;
                parsed["Body Style"] = txtBody.Text;
                parsed["Years"]["min"] = txtYear1.Text;
                parsed["Years"]["max"] = txtYear2.Text;

                File.WriteAllText(fileName, parsed.ToString());

                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    sb.Append(sr.ReadToEnd());

                    if (chkColors.Checked)
                    {
                        sb.Insert(sb.Length - 8, ",\n 	\"Pearl White\": \"1 1 1 1.2\",\n	\"Charcoal\": \"0.18 0.18 0.18 1.2\",\n	\"Silver\": \"0.65 0.65 0.65 1.2\",\n	\"Gray\": \"0.5 0.5 0.5 1.3\",\n	\"Carbon Gray\": \"0.33 0.33 0.33 1.3\",\n	\"Cream\": \"1 0.9 0.8 1.3\",\n	\"Light Brown\": \"0.6 0.45 0.35 1.4\",\n	\"Mustard Yellow\": \"0.66 0.55 0 1.4\",\n	\"Jet Black\": \"0 0 0 1.3\",\n	\"Fire Red\": \"1 0 0 1.2\",\n	\"Scarlet Red\": \"0.68 0.1 0.11 1.3\",\n	\"Flame Orange\": \"1 0.3 0 1.2\",\n	\"Sky Blue\": \"0.052 0.52 0.90 1.3\",\n	\"Burgundy\": \"0.5 0 0 1.2\",\n	\"Maroon\": \"0.3 0 0 1.2\",\n	\"Forest Green\": \"0.1 0.4 0.2 1.3\",\n	\"Opal Green\": \"0.22 0.37 0.33 1.3\",\n	\"Seafoam Green\": \"0.24 0.48 0.48 1.2\",\n	\"Shale Green\": \"0.22 0.27 0.23 1.3\",\n	\"Tropical Blue\": \"0.1 0.5 0.75 1.2\",\n	\"Sea Blue\": \"0.2 0.3 0.6 1.2\",\n	\"Royal Blue\": \"0.0 0.1 0.42 1.3\",\n	\"Aquamarine\": \"0.15 0.35 0.6 1.2\",\n	\"Midnight Pearl\": \"0 0.04 0.13 1.2\",\n	\"Brilliant Blue\": \"0.08 0.36 0.75 1.3\",\n	\"Solar Yellow\": \"0.95 0.7 0.1 1.3\",\n	\"Vibrant Red\": \"0.9 0.05 0.04 1.3\",\n	\"Pleasant Blue\": \"0.35 0.50 0.65 1.2\",\n	\"Bermuda Blue\": \"0.06 0.145 0.17 1.2\",\n	\"Navy Blue\": \"0.0 0.05 0.25 1.2\",\n	\"Steel Gray\": \"0.478 0.543 0.578 1.3\",\n	\"Purple\": \"0.444 0.055 0.370 1.3\"", 1);
                    }
                }

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(sb.ToString());
                }

                Console.WriteLine($"Created file {fileName}");
            }
            else
            {
                parsed["Name"] = txtName.Text;

                parsed.Property("Name")?.AddAfterSelf(new JProperty("Brand", txtBrand.Text));
                parsed.Property("Brand")?.AddAfterSelf(new JProperty("Country", txtCountry.Text));
                parsed.Property("Type")?.AddAfterSelf(new JProperty("Body Style", txtBody.Text));

                File.WriteAllText(fileName, parsed.ToString());

                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string jsonTmp = parsed.ToString();

                    string line;
                    do
                    {
                        line = sr.ReadLine();
                        sb.AppendLine(line);
                    } while (!line.Contains("Brand"));

                    sb.Append("  \"Years\":{ \"min\":" + txtYear1.Text + ", \"max\":" + txtYear2.Text + " },\n");

                    sb.Append(sr.ReadToEnd());

                    if (chkColors.Checked)
                    {
                        sb.Insert(sb.Length - 8, ",\n 	\"Pearl White\": \"1 1 1 1.2\",\n	\"Charcoal\": \"0.18 0.18 0.18 1.2\",\n	\"Silver\": \"0.65 0.65 0.65 1.2\",\n	\"Gray\": \"0.5 0.5 0.5 1.3\",\n	\"Carbon Gray\": \"0.33 0.33 0.33 1.3\",\n	\"Cream\": \"1 0.9 0.8 1.3\",\n	\"Light Brown\": \"0.6 0.45 0.35 1.4\",\n	\"Mustard Yellow\": \"0.66 0.55 0 1.4\",\n	\"Jet Black\": \"0 0 0 1.3\",\n	\"Fire Red\": \"1 0 0 1.2\",\n	\"Scarlet Red\": \"0.68 0.1 0.11 1.3\",\n	\"Flame Orange\": \"1 0.3 0 1.2\",\n	\"Sky Blue\": \"0.052 0.52 0.90 1.3\",\n	\"Burgundy\": \"0.5 0 0 1.2\",\n	\"Maroon\": \"0.3 0 0 1.2\",\n	\"Forest Green\": \"0.1 0.4 0.2 1.3\",\n	\"Opal Green\": \"0.22 0.37 0.33 1.3\",\n	\"Seafoam Green\": \"0.24 0.48 0.48 1.2\",\n	\"Shale Green\": \"0.22 0.27 0.23 1.3\",\n	\"Tropical Blue\": \"0.1 0.5 0.75 1.2\",\n	\"Sea Blue\": \"0.2 0.3 0.6 1.2\",\n	\"Royal Blue\": \"0.0 0.1 0.42 1.3\",\n	\"Aquamarine\": \"0.15 0.35 0.6 1.2\",\n	\"Midnight Pearl\": \"0 0.04 0.13 1.2\",\n	\"Brilliant Blue\": \"0.08 0.36 0.75 1.3\",\n	\"Solar Yellow\": \"0.95 0.7 0.1 1.3\",\n	\"Vibrant Red\": \"0.9 0.05 0.04 1.3\",\n	\"Pleasant Blue\": \"0.35 0.50 0.65 1.2\",\n	\"Bermuda Blue\": \"0.06 0.145 0.17 1.2\",\n	\"Navy Blue\": \"0.0 0.05 0.25 1.2\",\n	\"Steel Gray\": \"0.478 0.543 0.578 1.3\",\n	\"Purple\": \"0.444 0.055 0.370 1.3\"", 1);
                    }
                }

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(sb.ToString());
                }

                Console.WriteLine($"Created file {fileName}");
            }
        }

        private void SaveFile()
        {
            using (ZipFile zip = ZipFile.Read(modFilepath))
            {
                zip.UpdateFile(fileName);

                if (!alreadyModded)
                {
                    File.WriteAllText("ModifierTool", "This mod was modified with the BeamNG Mod Naming Tool.");
                    zip.AddFile("ModifierTool");
                }

                if (chkColors.Checked && chkColors.Enabled)
                {
                    File.WriteAllText("AddedColors", "");
                    zip.AddFile("AddedColors");
                }

                try
                {
                    zip.Save();

                    lblStatus.Text = $"Successfully worte to file {Path.GetFileName(modFilepath)}!";
                    Console.WriteLine($"Successfully worte to file {modFilepath}!");
                }
                catch (IOException)
                {
                    string message = IsBeamNgOpen
                        ? "The file is currently being used by BeamNG! Please close BeamNG and try again!"
                        : "The file is currently being used by another program!";

                    string title = "File is Being Used";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

                    lblStatus.Text = $"Failed to srite file {Path.GetFileName(modFilepath)}!";
                    Console.WriteLine($"Failed to srite file {modFilepath}!");
                }
            }
        }

        private void UpdateBackupList()
        {
            lstBackups.Items.Clear();

            string[] files = Directory.GetFiles(baseDir + BackupDir);
            int i = 0;

            foreach (string s in files)
            {
                lstBackups.Items.Add(Path.GetFileName(s));
                i++;
            }

            Console.WriteLine($"Found {i} files and added them to the backup list.");
        }

        private void DeleteBackups(bool deleteAll)
        {
            if (deleteAll)
            {
                foreach (string s in lstBackups.Items)
                {
                    File.Delete(Path.Combine(baseDir + BackupDir, s));
                    Console.WriteLine($"Deleted backup {s}");
                }
            }
            else
            {
                string file = lstBackups.SelectedItem.ToString();
                File.Delete(Path.Combine(baseDir + BackupDir, file));
                Console.WriteLine($"Deleted backup {file}");
            }

            UpdateBackupList();
        }

        private void RestoreFile(string file)
        {
            File.Copy(Path.Combine(baseDir + BackupDir, lstBackups.SelectedItem.ToString()), Path.Combine(beamFolder, lstBackups.SelectedItem.ToString()), true);
            Console.WriteLine($"Resored file {file} to {beamFolder}");
        }


        //-- Click Actions --

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenZipForm form = new OpenZipForm(this);
            form.Show();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (modFilepath == null)
            {
                lblStatus.Text = "No ZIP fle opened!";
            }
            else
            {
                if ((string)parsed["Type"] != "Automation")
                {
                    string message = "Are you sure you want to apply changes? This software was not tested with non-Automation mods and may break them.";
                    string title = "Apply Changes";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        CreateBackup();
                        ModifyJson();
                        SaveFile();
                    }
                }
                else
                {
                    CreateBackup();
                    ModifyJson();
                    SaveFile();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete ALL backups? This action CANNOT be undone.";
            string title = "Delete Backups";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteBackups(true);
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            if (lstBackups.SelectedItem == null)
            {
                lblStatus.Text = "No backup selected!";
            }
            else
            {
                string message = $"Are you sure you want to restore the file {lstBackups.SelectedItem}? This cannot be undone.";
                string title = "Restore Backup";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    RestoreFile(lstBackups.SelectedItem.ToString());
                }
            }
        }

        private void BtnRestoreAll_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to restore all the backed up files? This cannot be undone.";
            string title = "Restore All Backups";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                foreach (string s in lstBackups.Items)
                {
                    RestoreFile(s);
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtName.Text = "";
            txtBrand.Text = "";
            txtCountry.Text = "";
            txtYear1.Text = "";
            txtYear2.Text = "";
        }

        private void BtnClearSel_Click(object sender, EventArgs e)
        {
            if (lstBackups.SelectedItem == null)
            {
                lblStatus.Text = "No backup selected!";
            }
            else
            {
                string message = $"Are you sure you want to delete {lstBackups.SelectedItem}? This action CANNOT be undone.";
                string title = "Delete Backup";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteBackups(false);
                }
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            string msg = "When you export a car from Automation, only 5 colors are exported: Black, White, Blue, Red and the color you chose inside Automation. \nBy checking the Add Colors checkbox, another 32 colors will be added to the vehicle selection screen for this car.";
            string title = "About";
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHelp2_Click(object sender, EventArgs e)
        {
            string msg = "BeamNG requires you to have 2 years on the car metadata, when the car was introduced and discontinued.\nTo avoid errors, you also cannot (and should not) input any digits on the year fields.";
            string title = "About";
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LstBackups_DoubleClick(object sender, EventArgs e)
        {
            if (lstBackups.SelectedItem != null)
            {
                Process.Start("explorer.exe", "/select, \"" + Path.Combine(baseDir + BackupDir, lstBackups.SelectedItem.ToString()) + "\"");
            }
        }


        //-- Numbers Only --

        private void TxtYear1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtYear2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
