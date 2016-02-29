using System;

namespace languagetool_msword10_addin
{
    partial class LTSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LTSettingsForm));
            this.LT_server_label = new System.Windows.Forms.Label();
            this.comboBoxLTServer = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.comboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.default_language_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.languageSpecificSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // LT_server_label
            // 
            this.LT_server_label.AutoSize = true;
            this.LT_server_label.Location = new System.Drawing.Point(182, 14);
            this.LT_server_label.Name = "LT_server_label";
            this.LT_server_label.Size = new System.Drawing.Size(113, 13);
            this.LT_server_label.TabIndex = 2;
            this.LT_server_label.Text = "LanguageTool Server:";
            // 
            // comboBoxLTServer
            // 
            this.comboBoxLTServer.BackColor = System.Drawing.Color.White;
            this.comboBoxLTServer.FormattingEnabled = true;
            this.comboBoxLTServer.Location = new System.Drawing.Point(185, 32);
            this.comboBoxLTServer.Name = "comboBoxLTServer";
            this.comboBoxLTServer.Size = new System.Drawing.Size(240, 21);
            this.comboBoxLTServer.TabIndex = 1;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(268, 77);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 21);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "OK";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(349, 77);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 21);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancelSettings_click);
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.BackColor = System.Drawing.Color.White;
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(14, 32);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.Size = new System.Drawing.Size(151, 21);
            this.comboBoxLanguages.TabIndex = 6;
            this.comboBoxLanguages.TextChanged += new System.EventHandler(this.comboBoxLanguages_TextChanged);
            // 
            // default_language_label
            // 
            this.default_language_label.AutoSize = true;
            this.default_language_label.Location = new System.Drawing.Point(11, 14);
            this.default_language_label.Name = "default_language_label";
            this.default_language_label.Size = new System.Drawing.Size(92, 13);
            this.default_language_label.TabIndex = 7;
            this.default_language_label.Text = "Default Language";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::languagetool_msword10_addin.Properties.Resources.suportGenCat;
            this.pictureBox1.Location = new System.Drawing.Point(236, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 61);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::languagetool_msword10_addin.Properties.Resources.logo_riurau_150;
            this.pictureBox2.Location = new System.Drawing.Point(15, 133);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 37);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // languageSpecificSettings
            // 
            this.languageSpecificSettings.Location = new System.Drawing.Point(14, 77);
            this.languageSpecificSettings.Name = "languageSpecificSettings";
            this.languageSpecificSettings.Size = new System.Drawing.Size(151, 21);
            this.languageSpecificSettings.TabIndex = 10;
            this.languageSpecificSettings.Text = "Settings: Language";
            this.languageSpecificSettings.UseVisualStyleBackColor = true;
            this.languageSpecificSettings.Click += new System.EventHandler(this.languageSpecificSettings_Click);
            // 
            // LTSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(436, 194);
            this.Controls.Add(this.languageSpecificSettings);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.default_language_label);
            this.Controls.Add(this.comboBoxLanguages);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.comboBoxLTServer);
            this.Controls.Add(this.LT_server_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LTSettingsForm";
            this.Text = "LanguageTool Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LT_server_label;
        private System.Windows.Forms.ComboBox comboBoxLTServer;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.ComboBox comboBoxLanguages;
        private System.Windows.Forms.Label default_language_label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button languageSpecificSettings;
    }
}