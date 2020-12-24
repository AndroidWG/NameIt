namespace NameIt
{
    partial class OpenZipForm
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
            this.lstMods = new System.Windows.Forms.ListBox();
            this.btnOpenSel = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lstMods
            // 
            this.lstMods.FormattingEnabled = true;
            this.lstMods.Location = new System.Drawing.Point(13, 70);
            this.lstMods.Name = "lstMods";
            this.lstMods.Size = new System.Drawing.Size(253, 329);
            this.lstMods.TabIndex = 0;
            this.lstMods.DoubleClick += new System.EventHandler(this.LstMods_DoubleClick);
            // 
            // btnOpenSel
            // 
            this.btnOpenSel.Location = new System.Drawing.Point(14, 406);
            this.btnOpenSel.Name = "btnOpenSel";
            this.btnOpenSel.Size = new System.Drawing.Size(110, 23);
            this.btnOpenSel.TabIndex = 1;
            this.btnOpenSel.Text = "Open Selected";
            this.btnOpenSel.UseVisualStyleBackColor = true;
            this.btnOpenSel.Click += new System.EventHandler(this.BtnOpenSel_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(130, 406);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(136, 23);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose From Folder";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mods that have already been modified will appear with an M in front of them. Doub" +
    "le click on a mod to open it. Press \"Choose From Folder\" to open the Open File d" +
    "ialog.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "zip";
            this.openFileDialog1.Filter = "\"ZIP Files|*.zip|All files|*.*\"";
            this.openFileDialog1.InitialDirectory = "&UserProfile&\\BeamNG.drive\\mods";
            this.openFileDialog1.Title = "Select ZIP mod file";
            // 
            // OpenZipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnOpenSel);
            this.Controls.Add(this.lstMods);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenZipForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open ZIP File";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMods;
        private System.Windows.Forms.Button btnOpenSel;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}