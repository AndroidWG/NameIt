namespace NameIt
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtYear1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYear2 = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkColors = new System.Windows.Forms.CheckBox();
            this.lstBackups = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSel = new System.Windows.Forms.Button();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnHelp2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open ZIP File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(113, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(52, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Brand";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Years";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(52, 67);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(100, 20);
            this.txtBrand.TabIndex = 3;
            // 
            // txtYear1
            // 
            this.txtYear1.Location = new System.Drawing.Point(53, 121);
            this.txtYear1.MaxLength = 4;
            this.txtYear1.Name = "txtYear1";
            this.txtYear1.Size = new System.Drawing.Size(43, 20);
            this.txtYear1.TabIndex = 5;
            this.txtYear1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtYear1_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(167, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 69);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name:\r\n\r\nType:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 202);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(75, 147);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(78, 20);
            this.txtBody.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Body Style";
            // 
            // txtYear2
            // 
            this.txtYear2.Location = new System.Drawing.Point(102, 121);
            this.txtYear2.MaxLength = 4;
            this.txtYear2.Name = "txtYear2";
            this.txtYear2.Size = new System.Drawing.Size(43, 20);
            this.txtYear2.TabIndex = 6;
            this.txtYear2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtYear2_KeyPress);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(61, 93);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(91, 20);
            this.txtCountry.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Country";
            // 
            // chkColors
            // 
            this.chkColors.AutoSize = true;
            this.chkColors.Location = new System.Drawing.Point(12, 179);
            this.chkColors.Name = "chkColors";
            this.chkColors.Size = new System.Drawing.Size(76, 17);
            this.chkColors.TabIndex = 8;
            this.chkColors.Text = "Add colors";
            this.chkColors.UseVisualStyleBackColor = true;
            // 
            // lstBackups
            // 
            this.lstBackups.FormattingEnabled = true;
            this.lstBackups.Location = new System.Drawing.Point(6, 19);
            this.lstBackups.Name = "lstBackups";
            this.lstBackups.Size = new System.Drawing.Size(186, 134);
            this.lstBackups.TabIndex = 11;
            this.lstBackups.DoubleClick += new System.EventHandler(this.LstBackups_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearSel);
            this.groupBox1.Controls.Add(this.btnRestoreAll);
            this.groupBox1.Controls.Add(this.btnRestore);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.lstBackups);
            this.groupBox1.Location = new System.Drawing.Point(299, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 214);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backups";
            // 
            // btnClearSel
            // 
            this.btnClearSel.Location = new System.Drawing.Point(91, 186);
            this.btnClearSel.Name = "btnClearSel";
            this.btnClearSel.Size = new System.Drawing.Size(101, 23);
            this.btnClearSel.TabIndex = 15;
            this.btnClearSel.Text = "Clear Selected";
            this.btnClearSel.UseVisualStyleBackColor = true;
            this.btnClearSel.Click += new System.EventHandler(this.BtnClearSel_Click);
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.Location = new System.Drawing.Point(117, 157);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreAll.TabIndex = 13;
            this.btnRestoreAll.Text = "Restore All";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.BtnRestoreAll_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(7, 157);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(103, 23);
            this.btnRestore.TabIndex = 12;
            this.btnRestore.Text = "Restore Selected";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(7, 186);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(77, 23);
            this.btnClearAll.TabIndex = 14;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.Button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 231);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(509, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 19);
            this.lblVersion.Text = "Version";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 19);
            this.lblStatus.Text = "Status";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(94, 202);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear All Fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(94, 175);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 23);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnHelp2
            // 
            this.btnHelp2.Location = new System.Drawing.Point(151, 119);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(23, 23);
            this.btnHelp2.TabIndex = 19;
            this.btnHelp2.Text = "?";
            this.btnHelp2.UseVisualStyleBackColor = true;
            this.btnHelp2.Click += new System.EventHandler(this.BtnHelp2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 255);
            this.Controls.Add(this.btnHelp2);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkColors);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtYear2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYear1);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeamNG Mod Naming Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtYear1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYear2;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkColors;
        private System.Windows.Forms.ListBox lstBackups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnRestoreAll;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnHelp2;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.Button btnClearSel;
    }
}

