namespace languagetool_msword10_addin
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.message_label = new System.Windows.Forms.Label();
            this.ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Location = new System.Drawing.Point(12, 25);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(80, 13);
            this.message_label.TabIndex = 0;
            this.message_label.Text = "No errors found";
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(53, 62);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(76, 23);
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.click_OK);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 97);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.message_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageForm";
            this.Text = "Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setMessage(string str)
        {
            this.message_label.Text = str;
        }

        #endregion

        private System.Windows.Forms.Label message_label;
        private System.Windows.Forms.Button ok_button;
    }
}