namespace WFFDR
{
    partial class frmMiscellaneousOutReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiscellaneousOutReport));
            this.txtorder = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.transact_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrecords = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearchs = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltotalqty = new System.Windows.Forms.Label();
            this.lblencodedby = new System.Windows.Forms.Label();
            this.dtpprod2 = new System.Windows.Forms.DateTimePicker();
            this.dtpprod1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnPrintorder = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtorder
            // 
            this.txtorder.AutoSize = true;
            this.txtorder.Location = new System.Drawing.Point(349, 427);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(70, 13);
            this.txtorder.TabIndex = 648;
            this.txtorder.Text = "Encoded by :";
            this.txtorder.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 430);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 647;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AllowUserToDeleteRows = false;
            this.dgvApproved.AllowUserToResizeColumns = false;
            this.dgvApproved.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproved.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transact_number,
            this.descripto,
            this.qty,
            this.TOTAL,
            this.date_added});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.Location = new System.Drawing.Point(6, 39);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(919, 372);
            this.dgvApproved.TabIndex = 650;
            this.dgvApproved.CurrentCellChanged += new System.EventHandler(this.dgvApproved_CurrentCellChanged);
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint);
            // 
            // transact_number
            // 
            this.transact_number.DataPropertyName = "transact_number";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.transact_number.DefaultCellStyle = dataGridViewCellStyle19;
            this.transact_number.HeaderText = "TRANSACT NO";
            this.transact_number.Name = "transact_number";
            this.transact_number.ReadOnly = true;
            // 
            // descripto
            // 
            this.descripto.DataPropertyName = "descripto";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.descripto.DefaultCellStyle = dataGridViewCellStyle20;
            this.descripto.HeaderText = "DESCRIPTION";
            this.descripto.Name = "descripto";
            this.descripto.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = null;
            this.qty.DefaultCellStyle = dataGridViewCellStyle21;
            this.qty.HeaderText = "QTY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TOTAL.DefaultCellStyle = dataGridViewCellStyle22;
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // date_added
            // 
            this.date_added.DataPropertyName = "date_added";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.date_added.DefaultCellStyle = dataGridViewCellStyle23;
            this.date_added.HeaderText = "DATE ADDED";
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Location = new System.Drawing.Point(113, 430);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(70, 13);
            this.lblrecords.TabIndex = 646;
            this.lblrecords.Text = "Encoded by :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(230, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 658;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 655;
            this.label2.Text = "Search :";
            // 
            // txtsearchs
            // 
            this.txtsearchs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchs.Location = new System.Drawing.Point(76, 11);
            this.txtsearchs.Name = "txtsearchs";
            this.txtsearchs.Size = new System.Drawing.Size(160, 13);
            this.txtsearchs.TabIndex = 654;
            this.txtsearchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsearchs.TextChanged += new System.EventHandler(this.txtsearchs_TextChanged);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(838, 39);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(70, 13);
            this.lbldate.TabIndex = 653;
            this.lbldate.Text = "Encoded by :";
            this.lbldate.Visible = false;
            // 
            // lbltotalqty
            // 
            this.lbltotalqty.AutoSize = true;
            this.lbltotalqty.Location = new System.Drawing.Point(876, 64);
            this.lbltotalqty.Name = "lbltotalqty";
            this.lbltotalqty.Size = new System.Drawing.Size(70, 13);
            this.lbltotalqty.TabIndex = 652;
            this.lbltotalqty.Text = "Encoded by :";
            this.lbltotalqty.Visible = false;
            // 
            // lblencodedby
            // 
            this.lblencodedby.AutoSize = true;
            this.lblencodedby.Location = new System.Drawing.Point(686, 430);
            this.lblencodedby.Name = "lblencodedby";
            this.lblencodedby.Size = new System.Drawing.Size(70, 13);
            this.lblencodedby.TabIndex = 651;
            this.lblencodedby.Text = "Encoded by :";
            this.lblencodedby.Visible = false;
            // 
            // dtpprod2
            // 
            this.dtpprod2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.CustomFormat = "M/d/yyyy";
            this.dtpprod2.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod2.Location = new System.Drawing.Point(626, 3);
            this.dtpprod2.Name = "dtpprod2";
            this.dtpprod2.Size = new System.Drawing.Size(187, 30);
            this.dtpprod2.TabIndex = 660;
            // 
            // dtpprod1
            // 
            this.dtpprod1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.CustomFormat = "M/d/yyyy";
            this.dtpprod1.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod1.Location = new System.Drawing.Point(389, 3);
            this.dtpprod1.Name = "dtpprod1";
            this.dtpprod1.Size = new System.Drawing.Size(194, 30);
            this.dtpprod1.TabIndex = 659;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 661;
            this.label1.Text = "FROM :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 662;
            this.label3.Text = "TO :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(523, 416);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 657;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // bunifuThinButton23
            // 
            this.bunifuThinButton23.ActiveBorderThickness = 1;
            this.bunifuThinButton23.ActiveCornerRadius = 20;
            this.bunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton23.BackgroundImage")));
            this.bunifuThinButton23.ButtonText = "";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Enabled = false;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 10;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.Location = new System.Drawing.Point(62, -1);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(187, 36);
            this.bunifuThinButton23.TabIndex = 656;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintorder
            // 
            this.btnPrintorder.BackColor = System.Drawing.SystemColors.Window;
            this.btnPrintorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintorder.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintorder.Image")));
            this.btnPrintorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintorder.Location = new System.Drawing.Point(825, 5);
            this.btnPrintorder.Name = "btnPrintorder";
            this.btnPrintorder.Size = new System.Drawing.Size(99, 28);
            this.btnPrintorder.TabIndex = 692;
            this.btnPrintorder.Text = " &Print Range";
            this.btnPrintorder.UseVisualStyleBackColor = false;
            this.btnPrintorder.Click += new System.EventHandler(this.btnPrintorder_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.SystemColors.Window;
            this.btnReprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.Location = new System.Drawing.Point(843, 418);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(82, 28);
            this.btnReprint.TabIndex = 693;
            this.btnReprint.Text = "&Print";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // frmMiscellaneousOutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnPrintorder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpprod2);
            this.Controls.Add(this.dtpprod1);
            this.Controls.Add(this.txtorder);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dgvApproved);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearchs);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lbltotalqty);
            this.Controls.Add(this.lblencodedby);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMiscellaneousOutReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw Mats Miscellaneous Out Report";
            this.Load += new System.EventHandler(this.frmMiscellaneousOutReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtorder;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.Label lblrecords;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearchs;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltotalqty;
        private System.Windows.Forms.Label lblencodedby;
        private System.Windows.Forms.DateTimePicker dtpprod2;
        private System.Windows.Forms.DateTimePicker dtpprod1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn transact_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripto;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        internal System.Windows.Forms.Button btnPrintorder;
        internal System.Windows.Forms.Button btnReprint;
    }
}