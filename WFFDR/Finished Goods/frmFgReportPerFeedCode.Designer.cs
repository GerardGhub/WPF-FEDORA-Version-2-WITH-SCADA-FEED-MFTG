﻿namespace WFFDR
{
    partial class frmFgReportPerFeedCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFgReportPerFeedCode));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblfcode = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnFeedCodeSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.f1 = new System.Windows.Forms.DateTimePicker();
            this.f2 = new System.Windows.Forms.DateTimePicker();
            this.btnHIDE = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 297);
            this.panel2.TabIndex = 543;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.lblfcode);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.btnFeedCodeSearch);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.f1);
            this.groupBox1.Controls.Add(this.f2);
            this.groupBox1.Controls.Add(this.btnHIDE);
            this.groupBox1.Location = new System.Drawing.Point(12, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(628, 293);
            this.groupBox1.TabIndex = 541;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblfcode
            // 
            this.lblfcode.AutoSize = true;
            this.lblfcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfcode.ForeColor = System.Drawing.Color.Black;
            this.lblfcode.Location = new System.Drawing.Point(7, 30);
            this.lblfcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfcode.Name = "lblfcode";
            this.lblfcode.Size = new System.Drawing.Size(158, 29);
            this.lblfcode.TabIndex = 2;
            this.lblfcode.Text = "FEED CODE:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Yellow;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(8, 247);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(157, 15);
            this.textBox4.TabIndex = 628;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Visible = false;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btnFeedCodeSearch
            // 
            this.btnFeedCodeSearch.BackColor = System.Drawing.SystemColors.Window;
            this.btnFeedCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFeedCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedCodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedCodeSearch.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnFeedCodeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFeedCodeSearch.Location = new System.Drawing.Point(216, 235);
            this.btnFeedCodeSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnFeedCodeSearch.Name = "btnFeedCodeSearch";
            this.btnFeedCodeSearch.Size = new System.Drawing.Size(236, 41);
            this.btnFeedCodeSearch.TabIndex = 547;
            this.btnFeedCodeSearch.Text = "GENERATE";
            this.btnFeedCodeSearch.UseVisualStyleBackColor = false;
            this.btnFeedCodeSearch.Click += new System.EventHandler(this.btnFeedCodeSearch_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(459, 297);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 41);
            this.button1.TabIndex = 547;
            this.button1.Text = "GENERATE";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(105, 179);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 29);
            this.label9.TabIndex = 545;
            this.label9.Text = "TO :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(69, 95);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 29);
            this.label14.TabIndex = 546;
            this.label14.Text = "FROM :";
            // 
            // f1
            // 
            this.f1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1.CustomFormat = "MM/dd/yyyy";
            this.f1.Font = new System.Drawing.Font("Lucida Bright", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f1.Location = new System.Drawing.Point(179, 80);
            this.f1.Margin = new System.Windows.Forms.Padding(4);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(377, 47);
            this.f1.TabIndex = 545;
            // 
            // f2
            // 
            this.f2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f2.CustomFormat = "MM/dd/yyyy";
            this.f2.Font = new System.Drawing.Font("Lucida Bright", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f2.Location = new System.Drawing.Point(179, 164);
            this.f2.Margin = new System.Windows.Forms.Padding(4);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(377, 47);
            this.f2.TabIndex = 544;
            // 
            // btnHIDE
            // 
            this.btnHIDE.ActiveBorderThickness = 1;
            this.btnHIDE.ActiveCornerRadius = 2;
            this.btnHIDE.ActiveFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnHIDE.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnHIDE.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.BackColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHIDE.BackgroundImage")));
            this.btnHIDE.ButtonText = "X";
            this.btnHIDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHIDE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHIDE.IdleBorderThickness = 1;
            this.btnHIDE.IdleCornerRadius = 10;
            this.btnHIDE.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.IdleForecolor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnHIDE.IdleLineColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnHIDE.Location = new System.Drawing.Point(577, -6);
            this.btnHIDE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHIDE.Name = "btnHIDE";
            this.btnHIDE.Size = new System.Drawing.Size(51, 42);
            this.btnHIDE.TabIndex = 629;
            this.btnHIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHIDE.Visible = false;
            this.btnHIDE.Click += new System.EventHandler(this.btnHIDE_Click);
            // 
            // frmFgReportPerFeedCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(656, 299);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFgReportPerFeedCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FG Feed Code Reports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFgReportPerFeedCode_FormClosing);
            this.Load += new System.EventHandler(this.frmFgReportPerFeedCode_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFeedCodeSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker f1;
        private System.Windows.Forms.DateTimePicker f2;
        private System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Label lblfcode;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHIDE;
    }
}