namespace HLSourceUkr
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.btLocalize = new System.Windows.Forms.Button();
            this.btOpenFolder = new System.Windows.Forms.Button();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btLocalize
            // 
            resources.ApplyResources(this.btLocalize, "btLocalize");
            this.btLocalize.Name = "btLocalize";
            this.btLocalize.UseVisualStyleBackColor = true;
            this.btLocalize.Click += new System.EventHandler(this.btLocalize_Click);
            // 
            // btOpenFolder
            // 
            resources.ApplyResources(this.btOpenFolder, "btOpenFolder");
            this.btOpenFolder.Name = "btOpenFolder";
            this.btOpenFolder.UseVisualStyleBackColor = true;
            this.btOpenFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // lbHeader
            // 
            resources.ApplyResources(this.lbHeader, "lbHeader");
            this.lbHeader.Name = "lbHeader";
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.Name = "lbMessage";
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tbMessage, "tbMessage");
            this.tbMessage.Name = "tbMessage";
            // 
            // btExit
            // 
            resources.ApplyResources(this.btExit, "btExit");
            this.btExit.Name = "btExit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btRemove
            // 
            resources.ApplyResources(this.btRemove, "btRemove");
            this.btRemove.Name = "btRemove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // fMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.btOpenFolder);
            this.Controls.Add(this.btLocalize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLocalize;
        private System.Windows.Forms.Button btOpenFolder;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btRemove;
    }
}

