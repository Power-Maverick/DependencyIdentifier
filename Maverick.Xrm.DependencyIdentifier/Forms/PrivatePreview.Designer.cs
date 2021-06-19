
namespace Maverick.Xrm.DependencyIdentifier.Forms
{
    partial class PrivatePreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivatePreview));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblToolName = new System.Windows.Forms.Label();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnSubmitSecretKey = new System.Windows.Forms.Button();
            this.linklblDanish = new System.Windows.Forms.LinkLabel();
            this.linklblArun = new System.Windows.Forms.LinkLabel();
            this.linklblLinn = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Maroon;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(634, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to private preview of";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblToolName
            // 
            this.lblToolName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolName.ForeColor = System.Drawing.Color.Maroon;
            this.lblToolName.Location = new System.Drawing.Point(12, 47);
            this.lblToolName.Name = "lblToolName";
            this.lblToolName.Size = new System.Drawing.Size(610, 67);
            this.lblToolName.TabIndex = 2;
            this.lblToolName.Text = "Dependency Identifier";
            this.lblToolName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.AutoSize = true;
            this.lblSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretKey.Location = new System.Drawing.Point(8, 144);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(337, 20);
            this.lblSecretKey.TabIndex = 3;
            this.lblSecretKey.Text = "Enter the private access key to access the tool";
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretKey.Location = new System.Drawing.Point(12, 167);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(610, 26);
            this.txtSecretKey.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(9, 259);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(473, 39);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "*The tool is currently under private preview and will soon be released for genera" +
    "l public. \r\n\r\nPlease check for a public announcement from one of the author of t" +
    "he tool. Follow them on Twitter:";
            // 
            // btnSubmitSecretKey
            // 
            this.btnSubmitSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitSecretKey.Location = new System.Drawing.Point(12, 209);
            this.btnSubmitSecretKey.Name = "btnSubmitSecretKey";
            this.btnSubmitSecretKey.Size = new System.Drawing.Size(173, 36);
            this.btnSubmitSecretKey.TabIndex = 6;
            this.btnSubmitSecretKey.Text = "Submit and Enter";
            this.btnSubmitSecretKey.UseVisualStyleBackColor = true;
            this.btnSubmitSecretKey.Click += new System.EventHandler(this.btnSubmitSecretKey_Click);
            // 
            // linklblDanish
            // 
            this.linklblDanish.AutoSize = true;
            this.linklblDanish.Location = new System.Drawing.Point(9, 309);
            this.linklblDanish.Name = "linklblDanish";
            this.linklblDanish.Size = new System.Drawing.Size(143, 13);
            this.linklblDanish.TabIndex = 7;
            this.linklblDanish.TabStop = true;
            this.linklblDanish.Text = "Danish N. (@DanzMaverick)";
            this.linklblDanish.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDanish_LinkClicked);
            // 
            // linklblArun
            // 
            this.linklblArun.AutoSize = true;
            this.linklblArun.Location = new System.Drawing.Point(9, 333);
            this.linklblArun.Name = "linklblArun";
            this.linklblArun.Size = new System.Drawing.Size(134, 13);
            this.linklblArun.TabIndex = 8;
            this.linklblArun.TabStop = true;
            this.linklblArun.Text = "Arun Vinoth (@ArunVinoth)\r\n";
            this.linklblArun.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblArun_LinkClicked);
            // 
            // linklblLinn
            // 
            this.linklblLinn.AutoSize = true;
            this.linklblLinn.Location = new System.Drawing.Point(9, 357);
            this.linklblLinn.Name = "linklblLinn";
            this.linklblLinn.Size = new System.Drawing.Size(153, 13);
            this.linklblLinn.TabIndex = 9;
            this.linklblLinn.TabStop = true;
            this.linklblLinn.Text = "Linn Zaw Win (@LinnZawWin)";
            this.linklblLinn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLinn_LinkClicked);
            // 
            // PrivatePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 392);
            this.Controls.Add(this.linklblLinn);
            this.Controls.Add(this.linklblArun);
            this.Controls.Add(this.linklblDanish);
            this.Controls.Add(this.btnSubmitSecretKey);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtSecretKey);
            this.Controls.Add(this.lblSecretKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblToolName);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrivatePreview";
            this.Text = "Private Preview Notification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblToolName;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnSubmitSecretKey;
        private System.Windows.Forms.LinkLabel linklblDanish;
        private System.Windows.Forms.LinkLabel linklblArun;
        private System.Windows.Forms.LinkLabel linklblLinn;
    }
}