namespace WFFDR
{
    partial class frmSystemLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemLock));
            this.label3 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PresentModule = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 205);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(533, 34);
            this.label3.TabIndex = 13;
            this.label3.Text = "TYPE YOUR PASSWORD TO CONTINUE...";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(422, 303);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(580, 38);
            this.txtpassword.TabIndex = 14;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WFFDR.Properties.Resources.lock_512;
            this.pictureBox1.Location = new System.Drawing.Point(42, 282);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // BtnContinue
            // 
            this.BtnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnContinue.Location = new System.Drawing.Point(731, 447);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(271, 83);
            this.BtnContinue.TabIndex = 16;
            this.BtnContinue.Text = "CONTINUE";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.button1_Click);
            this.BtnContinue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnContinue_KeyDown);
            this.BtnContinue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BtnContinue_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(481, 389);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(295, 32);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "Clue + Ginagawa mo?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 83);
            this.button1.TabIndex = 18;
            this.button1.Text = "CONTINUE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // PresentModule
            // 
            this.PresentModule.BackColor = System.Drawing.Color.Crimson;
            this.PresentModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.PresentModule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresentModule.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PresentModule.Location = new System.Drawing.Point(0, 0);
            this.PresentModule.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.PresentModule.Name = "PresentModule";
            this.PresentModule.Size = new System.Drawing.Size(1077, 132);
            this.PresentModule.TabIndex = 19;
            this.PresentModule.Text = "SYSTEM LOCKED";
            this.PresentModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSystemLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1077, 592);
            this.ControlBox = false;
            this.Controls.Add(this.PresentModule);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSystemLock";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSystemLock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label PresentModule;
    }
}