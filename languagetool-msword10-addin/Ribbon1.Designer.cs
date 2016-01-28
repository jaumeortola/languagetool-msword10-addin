namespace languagetool_msword10_addin
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.check_button = this.Factory.CreateRibbonButton();
            this.settings_button = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.check_button);
            this.group1.Items.Add(this.settings_button);
            this.group1.Label = "LanguageTool";
            this.group1.Name = "group1";
            // 
            // check_button
            // 
            this.check_button.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.check_button.Image = global::languagetool_msword10_addin.Properties.Resources.LanguageToolBig;
            this.check_button.KeyTip = "C";
            this.check_button.Label = "Check";
            this.check_button.Name = "check_button";
            this.check_button.ShowImage = true;
            this.check_button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_onclick);
            // 
            // settings_button
            // 
            this.settings_button.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.settings_button.Image = global::languagetool_msword10_addin.Properties.Resources.WMF_Agora_Settings_424242_svg;
            this.settings_button.Label = "Settings";
            this.settings_button.Name = "settings_button";
            this.settings_button.ShowImage = true;
            this.settings_button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.LTSettings_onclick);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton settings_button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton check_button;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
