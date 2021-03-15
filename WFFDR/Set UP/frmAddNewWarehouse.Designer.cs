namespace WFFDR
{
    partial class frmAddNewWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewWarehouse));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtkey = new System.Windows.Forms.TextBox();
            this.txtadd = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblid2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtdateadded = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtwarehouse = new System.Windows.Forms.TextBox();
            this.txtaccounttitle = new System.Windows.Forms.TextBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtkey);
            this.GroupBox3.Controls.Add(this.txtadd);
            this.GroupBox3.Controls.Add(this.textBox1);
            this.GroupBox3.Controls.Add(this.lblid2);
            this.GroupBox3.Controls.Add(this.button2);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.txtdateadded);
            this.GroupBox3.Controls.Add(this.label6);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.txtwarehouse);
            this.GroupBox3.Controls.Add(this.txtaccounttitle);
            this.GroupBox3.Controls.Add(this.txtaddedby);
            this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(9, 5);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(409, 207);
            this.GroupBox3.TabIndex = 467;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Warehouse Information";
            // 
            // txtkey
            // 
            this.txtkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtkey.Enabled = false;
            this.txtkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkey.Location = new System.Drawing.Point(298, 181);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(105, 20);
            this.txtkey.TabIndex = 479;
            this.txtkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtkey.Visible = false;
            // 
            // txtadd
            // 
            this.txtadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtadd.Enabled = false;
            this.txtadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd.Location = new System.Drawing.Point(284, 155);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(105, 20);
            this.txtadd.TabIndex = 478;
            this.txtadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtadd.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(99, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 470;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblid2
            // 
            this.lblid2.AutoSize = true;
            this.lblid2.Location = new System.Drawing.Point(152, 177);
            this.lblid2.Name = "lblid2";
            this.lblid2.Size = new System.Drawing.Size(114, 13);
            this.lblid2.TabIndex = 469;
            this.lblid2.Text = "TOTAL RECORDS :";
            this.lblid2.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(14, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 468;
            this.button2.Text = "&Save ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 460;
            this.label1.Text = "Date Added :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Warehouse :";
            // 
            // txtdateadded
            // 
            this.txtdateadded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdateadded.Enabled = false;
            this.txtdateadded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateadded.Location = new System.Drawing.Point(99, 105);
            this.txtdateadded.Name = "txtdateadded";
            this.txtdateadded.Size = new System.Drawing.Size(290, 20);
            this.txtdateadded.TabIndex = 463;
            this.txtdateadded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Added by :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Account Title";
            // 
            // txtwarehouse
            // 
            this.txtwarehouse.BackColor = System.Drawing.Color.Yellow;
            this.txtwarehouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtwarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtwarehouse.Location = new System.Drawing.Point(99, 23);
            this.txtwarehouse.Name = "txtwarehouse";
            this.txtwarehouse.Size = new System.Drawing.Size(290, 20);
            this.txtwarehouse.TabIndex = 450;
            this.txtwarehouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaccounttitle
            // 
            this.txtaccounttitle.BackColor = System.Drawing.Color.Yellow;
            this.txtaccounttitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaccounttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccounttitle.Location = new System.Drawing.Point(99, 50);
            this.txtaccounttitle.Name = "txtaccounttitle";
            this.txtaccounttitle.Size = new System.Drawing.Size(290, 20);
            this.txtaccounttitle.TabIndex = 457;
            this.txtaccounttitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaddedby
            // 
            this.txtaddedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddedby.Location = new System.Drawing.Point(99, 76);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(290, 20);
            this.txtaddedby.TabIndex = 459;
            this.txtaddedby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmAddNewWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(429, 218);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddNewWarehouse_FormClosing);
            this.Load += new System.EventHandler(this.frmAddNewWarehouse_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label lblid2;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtdateadded;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtwarehouse;
        private System.Windows.Forms.TextBox txtaccounttitle;
        private System.Windows.Forms.TextBox txtaddedby;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtadd;
        private System.Windows.Forms.TextBox txtkey;
    }
}