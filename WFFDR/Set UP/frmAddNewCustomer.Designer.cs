﻿namespace WFFDR
{
    partial class frmAddNewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewCustomer));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtadd = new System.Windows.Forms.TextBox();
            this.txtleadman = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.txtdateadded = new System.Windows.Forms.TextBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnsave);
            this.GroupBox1.Controls.Add(this.txtid);
            this.GroupBox1.Controls.Add(this.txtadd);
            this.GroupBox1.Controls.Add(this.txtleadman);
            this.GroupBox1.Controls.Add(this.textBox1);
            this.GroupBox1.Controls.Add(this.txtmobile);
            this.GroupBox1.Controls.Add(this.cboType);
            this.GroupBox1.Controls.Add(this.txtname);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label22);
            this.GroupBox1.Controls.Add(this.label21);
            this.GroupBox1.Controls.Add(this.label20);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.cboCompany);
            this.GroupBox1.Controls.Add(this.txtaddress);
            this.GroupBox1.Controls.Add(this.txtaddedby);
            this.GroupBox1.Controls.Add(this.txtdateadded);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(13, 4);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(847, 398);
            this.GroupBox1.TabIndex = 555;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Customer Information";
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.Window;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(703, 325);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 34);
            this.btnsave.TabIndex = 322;
            this.btnsave.Text = "Save ";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtid
            // 
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(603, 236);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(219, 27);
            this.txtid.TabIndex = 493;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtid.Visible = false;
            // 
            // txtadd
            // 
            this.txtadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtadd.Enabled = false;
            this.txtadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd.Location = new System.Drawing.Point(123, 217);
            this.txtadd.Margin = new System.Windows.Forms.Padding(4);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(386, 23);
            this.txtadd.TabIndex = 492;
            this.txtadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtadd.Visible = false;
            // 
            // txtleadman
            // 
            this.txtleadman.BackColor = System.Drawing.Color.Yellow;
            this.txtleadman.Location = new System.Drawing.Point(173, 118);
            this.txtleadman.Margin = new System.Windows.Forms.Padding(4);
            this.txtleadman.Name = "txtleadman";
            this.txtleadman.Size = new System.Drawing.Size(223, 27);
            this.txtleadman.TabIndex = 355;
            this.txtleadman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(349, 236);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 27);
            this.textBox1.TabIndex = 354;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txtmobile
            // 
            this.txtmobile.BackColor = System.Drawing.Color.Yellow;
            this.txtmobile.Location = new System.Drawing.Point(603, 81);
            this.txtmobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(219, 27);
            this.txtmobile.TabIndex = 353;
            this.txtmobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.Color.Yellow;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.ItemHeight = 20;
            this.cboType.Items.AddRange(new object[] {
            "Poultry",
            "Swine"});
            this.cboType.Location = new System.Drawing.Point(603, 44);
            this.cboType.Margin = new System.Windows.Forms.Padding(4);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(221, 28);
            this.cboType.TabIndex = 352;
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.Color.Yellow;
            this.txtname.Location = new System.Drawing.Point(173, 44);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(223, 27);
            this.txtname.TabIndex = 351;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(439, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 349;
            this.label8.Text = "Date Added :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(439, 123);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 17);
            this.label22.TabIndex = 348;
            this.label22.Text = "Address :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(440, 90);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 17);
            this.label21.TabIndex = 347;
            this.label21.Text = "Mobile :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(440, 54);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 17);
            this.label20.TabIndex = 346;
            this.label20.Text = "Type :";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(23, 126);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(85, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Lead Man :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(23, 161);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 17);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Added by :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(23, 91);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(85, 17);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Company :";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(51, 54);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(58, 17);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "Name :";
            // 
            // cboCompany
            // 
            this.cboCompany.BackColor = System.Drawing.Color.Yellow;
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.ItemHeight = 20;
            this.cboCompany.Items.AddRange(new object[] {
            "Red Dragon Farm",
            "MIS Department"});
            this.cboCompany.Location = new System.Drawing.Point(173, 81);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(223, 28);
            this.cboCompany.TabIndex = 346;
            // 
            // txtaddress
            // 
            this.txtaddress.BackColor = System.Drawing.Color.Yellow;
            this.txtaddress.Location = new System.Drawing.Point(603, 118);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(219, 27);
            this.txtaddress.TabIndex = 330;
            this.txtaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaddedby
            // 
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Location = new System.Drawing.Point(173, 155);
            this.txtaddedby.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(223, 27);
            this.txtaddedby.TabIndex = 336;
            this.txtaddedby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdateadded
            // 
            this.txtdateadded.Enabled = false;
            this.txtdateadded.Location = new System.Drawing.Point(603, 155);
            this.txtdateadded.Margin = new System.Windows.Forms.Padding(4);
            this.txtdateadded.Name = "txtdateadded";
            this.txtdateadded.Size = new System.Drawing.Size(219, 27);
            this.txtdateadded.TabIndex = 334;
            this.txtdateadded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmAddNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(875, 409);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddNewCustomer_FormClosing);
            this.Load += new System.EventHandler(this.frmAddNewCustomer_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtaddedby;
        private System.Windows.Forms.TextBox txtdateadded;
        private System.Windows.Forms.TextBox txtmobile;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtleadman;
        private System.Windows.Forms.TextBox txtadd;
        private System.Windows.Forms.TextBox txtid;
    }
}