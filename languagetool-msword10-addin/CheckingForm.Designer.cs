namespace languagetool_msword10_addin
{
    partial class CheckingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingForm));
            this.suggestionsBox = new System.Windows.Forms.ListBox();
            this.contextTextBox = new System.Windows.Forms.RichTextBox();
            this.changeSuggestion = new System.Windows.Forms.Button();
            this.ignoreSuggestion = new System.Windows.Forms.Button();
            this.suggestionsLabel = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ignoreAllButton = new System.Windows.Forms.Button();
            this.moreinfoLinkLabel = new System.Windows.Forms.LinkLabel();
            this.languageBox = new System.Windows.Forms.RichTextBox();
            this.servernameBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // suggestionsBox
            // 
            this.suggestionsBox.FormattingEnabled = true;
            this.suggestionsBox.Location = new System.Drawing.Point(23, 236);
            this.suggestionsBox.Name = "suggestionsBox";
            this.suggestionsBox.Size = new System.Drawing.Size(292, 134);
            this.suggestionsBox.TabIndex = 0;
            // 
            // contextTextBox
            // 
            this.contextTextBox.Location = new System.Drawing.Point(23, 37);
            this.contextTextBox.Name = "contextTextBox";
            this.contextTextBox.Size = new System.Drawing.Size(292, 94);
            this.contextTextBox.TabIndex = 1;
            this.contextTextBox.Text = "";
            this.contextTextBox.TextChanged += new System.EventHandler(this.textUpdated);
            // 
            // changeSuggestion
            // 
            this.changeSuggestion.Enabled = false;
            this.changeSuggestion.Location = new System.Drawing.Point(326, 236);
            this.changeSuggestion.Name = "changeSuggestion";
            this.changeSuggestion.Size = new System.Drawing.Size(100, 23);
            this.changeSuggestion.TabIndex = 2;
            this.changeSuggestion.Text = "Change";
            this.changeSuggestion.UseVisualStyleBackColor = true;
            this.changeSuggestion.Click += new System.EventHandler(this.changeSuggestion_Click);
            // 
            // ignoreSuggestion
            // 
            this.ignoreSuggestion.Location = new System.Drawing.Point(326, 266);
            this.ignoreSuggestion.Name = "ignoreSuggestion";
            this.ignoreSuggestion.Size = new System.Drawing.Size(100, 23);
            this.ignoreSuggestion.TabIndex = 3;
            this.ignoreSuggestion.Text = "Ignore once";
            this.ignoreSuggestion.UseVisualStyleBackColor = true;
            this.ignoreSuggestion.Click += new System.EventHandler(this.ignoreSuggestion_Click);
            // 
            // suggestionsLabel
            // 
            this.suggestionsLabel.AutoSize = true;
            this.suggestionsLabel.Location = new System.Drawing.Point(20, 218);
            this.suggestionsLabel.Name = "suggestionsLabel";
            this.suggestionsLabel.Size = new System.Drawing.Size(65, 13);
            this.suggestionsLabel.TabIndex = 4;
            this.suggestionsLabel.Text = "Suggestions";
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.Location = new System.Drawing.Point(23, 137);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(292, 78);
            this.messageBox.TabIndex = 5;
            this.messageBox.Text = "";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(326, 326);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ignoreAllButton
            // 
            this.ignoreAllButton.Location = new System.Drawing.Point(326, 296);
            this.ignoreAllButton.Name = "ignoreAllButton";
            this.ignoreAllButton.Size = new System.Drawing.Size(100, 23);
            this.ignoreAllButton.TabIndex = 7;
            this.ignoreAllButton.Text = "Ignore all";
            this.ignoreAllButton.UseVisualStyleBackColor = true;
            this.ignoreAllButton.Click += new System.EventHandler(this.ignoreAlwaysSuggestion_Click);
            // 
            // moreinfoLinkLabel
            // 
            this.moreinfoLinkLabel.AutoSize = true;
            this.moreinfoLinkLabel.Location = new System.Drawing.Point(323, 137);
            this.moreinfoLinkLabel.Name = "moreinfoLinkLabel";
            this.moreinfoLinkLabel.Size = new System.Drawing.Size(85, 13);
            this.moreinfoLinkLabel.TabIndex = 8;
            this.moreinfoLinkLabel.TabStop = true;
            this.moreinfoLinkLabel.Text = "More information";
            this.moreinfoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_LinkClicked);
            // 
            // languageBox
            // 
            this.languageBox.BackColor = System.Drawing.SystemColors.Control;
            this.languageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.languageBox.Location = new System.Drawing.Point(23, 10);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(191, 21);
            this.languageBox.TabIndex = 9;
            this.languageBox.Text = "";
            // 
            // servernameBox
            // 
            this.servernameBox.BackColor = System.Drawing.SystemColors.Control;
            this.servernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servernameBox.Location = new System.Drawing.Point(23, 376);
            this.servernameBox.Name = "servernameBox";
            this.servernameBox.Size = new System.Drawing.Size(403, 37);
            this.servernameBox.TabIndex = 10;
            this.servernameBox.Text = "";
            // 
            // CheckingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 425);
            this.Controls.Add(this.servernameBox);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.moreinfoLinkLabel);
            this.Controls.Add(this.ignoreAllButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.suggestionsLabel);
            this.Controls.Add(this.ignoreSuggestion);
            this.Controls.Add(this.changeSuggestion);
            this.Controls.Add(this.contextTextBox);
            this.Controls.Add(this.suggestionsBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckingForm";
            this.Text = "Proofreading with LanguageTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox suggestionsBox;
        public System.Windows.Forms.RichTextBox contextTextBox;
        public System.Windows.Forms.Button changeSuggestion;
        private System.Windows.Forms.Button ignoreSuggestion;
        private System.Windows.Forms.Label suggestionsLabel;
        public System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button ignoreAllButton;
        public System.Windows.Forms.LinkLabel moreinfoLinkLabel;
        public System.Windows.Forms.RichTextBox languageBox;
        public System.Windows.Forms.RichTextBox servernameBox;
    }
}