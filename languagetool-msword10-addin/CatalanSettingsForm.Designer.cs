using System;

namespace languagetool_msword10_addin
{
    partial class CatalanSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalanSettingsForm));
            this.checking_options_label = new System.Windows.Forms.Label();
            this.comboBoxPreferences = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.typography_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checking_options_label
            // 
            this.checking_options_label.AutoSize = true;
            this.checking_options_label.Location = new System.Drawing.Point(12, 21);
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
            this.comboBoxPreferences.Location = new System.Drawing.Point(15, 37);
            this.comboBoxPreferences.Name = "comboBoxPreferences";
            this.comboBoxPreferences.Size = new System.Drawing.Size(166, 21);
            this.comboBoxPreferences.TabIndex = 1;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(125, 96);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 21);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "OK";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(224, 96);
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
            this.typography_checkbox.Location = new System.Drawing.Point(224, 39);
            this.typography_checkbox.Name = "typography_checkbox";
            this.typography_checkbox.Size = new System.Drawing.Size(82, 17);
            this.typography_checkbox.TabIndex = 5;
            this.typography_checkbox.Text = "Typography";
            this.typography_checkbox.UseVisualStyleBackColor = true;
            // 
            // CatalanSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(315, 151);
            this.Controls.Add(this.typography_checkbox);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.comboBoxPreferences);
            this.Controls.Add(this.checking_options_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CatalanSettingsForm";
            this.Text = "Settings: Language";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label checking_options_label;
        private System.Windows.Forms.ComboBox comboBoxPreferences;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.CheckBox typography_checkbox;
    }
}