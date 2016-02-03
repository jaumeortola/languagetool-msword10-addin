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
            this.checking_options_label = new System.Windows.Forms.Label();
            this.comboBoxPreferences = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.typography_checkbox = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.default_language_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // LT_server_label
            // 
            this.LT_server_label.AutoSize = true;
            this.LT_server_label.Location = new System.Drawing.Point(12, 70);
            this.LT_server_label.Name = "LT_server_label";
            this.LT_server_label.Size = new System.Drawing.Size(113, 13);
            this.LT_server_label.TabIndex = 2;
            this.LT_server_label.Text = "LanguageTool Server:";
            // 
            // comboBoxLTServer
            // 
            this.comboBoxLTServer.BackColor = System.Drawing.Color.White;
            this.comboBoxLTServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLTServer.FormattingEnabled = true;
            this.comboBoxLTServer.Location = new System.Drawing.Point(15, 86);
            this.comboBoxLTServer.Name = "comboBoxLTServer";
            this.comboBoxLTServer.Size = new System.Drawing.Size(385, 21);
            this.comboBoxLTServer.TabIndex = 1;
            // 
            // checking_options_label
            // 
            this.checking_options_label.AutoSize = true;
            this.checking_options_label.Location = new System.Drawing.Point(13, 133);
            this.checking_options_label.Name = "checking_options_label";
            this.checking_options_label.Size = new System.Drawing.Size(91, 13);
            this.checking_options_label.TabIndex = 0;
            this.checking_options_label.Text = "Checking Options";
            // 
            // comboBoxPreferences
            // 
            this.comboBoxPreferences.BackColor = System.Drawing.Color.White;
            this.comboBoxPreferences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreferences.FormattingEnabled = true;
            this.comboBoxPreferences.Location = new System.Drawing.Point(16, 149);
            this.comboBoxPreferences.Name = "comboBoxPreferences";
            this.comboBoxPreferences.Size = new System.Drawing.Size(233, 21);
            this.comboBoxPreferences.TabIndex = 1;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(227, 32);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 21);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(325, 32);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 21);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancelSettings_click);
            // 
            // typography_checkbox
            // 
            this.typography_checkbox.AutoSize = true;
            this.typography_checkbox.Location = new System.Drawing.Point(296, 153);
            this.typography_checkbox.Name = "typography_checkbox";
            this.typography_checkbox.Size = new System.Drawing.Size(82, 17);
            this.typography_checkbox.TabIndex = 5;
            this.typography_checkbox.Text = "Typography";
            this.typography_checkbox.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.BackColor = System.Drawing.Color.White;
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(14, 32);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.Size = new System.Drawing.Size(158, 21);
            this.comboBoxLanguages.TabIndex = 6;
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
            this.pictureBox1.Location = new System.Drawing.Point(212, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 61);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::languagetool_msword10_addin.Properties.Resources.logo_riurau_150;
            this.pictureBox2.Location = new System.Drawing.Point(15, 225);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 37);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // LTSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(413, 283);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.default_language_label);
            this.Controls.Add(this.comboBoxLanguages);
            this.Controls.Add(this.typography_checkbox);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.comboBoxPreferences);
            this.Controls.Add(this.checking_options_label);
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
        private System.Windows.Forms.Label checking_options_label;
        private System.Windows.Forms.ComboBox comboBoxPreferences;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.CheckBox typography_checkbox;
        private System.Windows.Forms.ComboBox comboBoxLanguages;
        private System.Windows.Forms.Label default_language_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}