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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLTServer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPreferences = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TypographyRulesEnabled = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Servidor de LanguageTool:";
            // 
            // comboBoxLTServer
            // 
            this.comboBoxLTServer.BackColor = System.Drawing.Color.White;
            this.comboBoxLTServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLTServer.FormattingEnabled = true;
            this.comboBoxLTServer.Location = new System.Drawing.Point(15, 131);
            this.comboBoxLTServer.Name = "comboBoxLTServer";
            this.comboBoxLTServer.Size = new System.Drawing.Size(386, 21);
            this.comboBoxLTServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Preferències de revisió en català";
            // 
            // comboBoxPreferences
            // 
            this.comboBoxPreferences.BackColor = System.Drawing.Color.White;
            this.comboBoxPreferences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreferences.FormattingEnabled = true;
            this.comboBoxPreferences.Location = new System.Drawing.Point(15, 39);
            this.comboBoxPreferences.Name = "comboBoxPreferences";
            this.comboBoxPreferences.Size = new System.Drawing.Size(233, 21);
            this.comboBoxPreferences.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Desa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel·la";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelSettings_click);
            // 
            // TypographyRulesEnabled
            // 
            this.TypographyRulesEnabled.AutoSize = true;
            this.TypographyRulesEnabled.Location = new System.Drawing.Point(295, 43);
            this.TypographyRulesEnabled.Name = "TypographyRulesEnabled";
            this.TypographyRulesEnabled.Size = new System.Drawing.Size(73, 17);
            this.TypographyRulesEnabled.TabIndex = 5;
            this.TypographyRulesEnabled.Text = "Tipografia";
            this.TypographyRulesEnabled.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(15, 185);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.Size = new System.Drawing.Size(158, 21);
            this.comboBoxLanguages.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Llengua per defecte";
            // 
            // LTSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxLanguages);
            this.Controls.Add(this.TypographyRulesEnabled);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxPreferences);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLTServer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LTSettingsForm";
            this.Text = "Configuració de LanguageTool";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.LTSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLTServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPreferences;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox TypographyRulesEnabled;
        private System.Windows.Forms.ComboBox comboBoxLanguages;
        private System.Windows.Forms.Label label3;
    }
}