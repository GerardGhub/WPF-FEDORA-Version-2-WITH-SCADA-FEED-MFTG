namespace WFFDR
{
    partial class frmFGMoveorderPrinting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFGMoveorderPrinting));
            this.label20 = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.txtorder = new System.Windows.Forms.Label();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.order_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblencodedby = new System.Windows.Forms.Label();
            this.lbltotalqty = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.txtsearchs = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 437);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 13);
            this.label20.TabIndex = 430;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(124, 437);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(14, 13);
            this.lblrecords.TabIndex = 429;
            this.lblrecords.Text = "0";
            // 
            // txtorder
            // 
            this.txtorder.AutoSize = true;
            this.txtorder.Location = new System.Drawing.Point(1041, 9);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(70, 13);
            this.txtorder.TabIndex = 431;
            this.txtorder.Text = "Encoded by :";
            this.txtorder.Visible = false;
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AllowUserToDeleteRows = false;
            this.dgvApproved.AllowUserToResizeColumns = false;
            this.dgvApproved.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproved.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvApproved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_no,
            this.added_by,
            this.TotalBags,
            this.date_added,
            this.Column1,
            this.Column2});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.Color.Teal;
            this.dgvApproved.Location = new System.Drawing.Point(7, 17);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApproved.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(902, 388);
            this.dgvApproved.TabIndex = 433;
            this.dgvApproved.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproved_CellClick);
            this.dgvApproved.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproved_CellContentClick);
            this.dgvApproved.CurrentCellChanged += new System.EventHandler(this.dgvApproved_CurrentCellChanged_1);
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint_1);
            this.dgvApproved.DoubleClick += new System.EventHandler(this.dgvApproved_DoubleClick);
            // 
            // order_no
            // 
            this.order_no.DataPropertyName = "order_no";
            this.order_no.HeaderText = "ORDER NO";
            this.order_no.MinimumWidth = 6;
            this.order_no.Name = "order_no";
            this.order_no.ReadOnly = true;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ENCODED BY";
            this.added_by.MinimumWidth = 6;
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            // 
            // TotalBags
            // 
            this.TotalBags.DataPropertyName = "TotalBags";
            this.TotalBags.HeaderText = "TOTAL BAGS";
            this.TotalBags.MinimumWidth = 6;
            this.TotalBags.Name = "TotalBags";
            this.TotalBags.ReadOnly = true;
            // 
            // date_added
            // 
            this.date_added.DataPropertyName = "date_added";
            this.date_added.HeaderText = "DATE ADDED";
            this.date_added.MinimumWidth = 6;
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PENDING";
            this.Column1.HeaderText = "TOTAL RECORDS";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DONE";
            this.Column2.HeaderText = "CANCEL";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // lblencodedby
            // 
            this.lblencodedby.AutoSize = true;
            this.lblencodedby.Location = new System.Drawing.Point(936, 9);
            this.lblencodedby.Name = "lblencodedby";
            this.lblencodedby.Size = new System.Drawing.Size(70, 13);
            this.lblencodedby.TabIndex = 434;
            this.lblencodedby.Text = "Encoded by :";
            this.lblencodedby.Visible = false;
            // 
            // lbltotalqty
            // 
            this.lbltotalqty.AutoSize = true;
            this.lbltotalqty.Location = new System.Drawing.Point(938, 62);
            this.lbltotalqty.Name = "lbltotalqty";
            this.lbltotalqty.Size = new System.Drawing.Size(70, 13);
            this.lbltotalqty.TabIndex = 435;
            this.lbltotalqty.Text = "Encoded by :";
            this.lbltotalqty.Visible = false;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(1026, 37);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(70, 13);
            this.lbldate.TabIndex = 436;
            this.lbldate.Text = "Encoded by :";
            this.lbldate.Visible = false;
            this.lbldate.Click += new System.EventHandler(this.lbldate_Click);
            // 
            // txtsearchs
            // 
            this.txtsearchs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchs.Location = new System.Drawing.Point(937, 421);
            this.txtsearchs.Name = "txtsearchs";
            this.txtsearchs.Size = new System.Drawing.Size(160, 20);
            this.txtsearchs.TabIndex = 437;
            this.txtsearchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsearchs.Visible = false;
            this.txtsearchs.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(1103, 421);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 632;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1025, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 602;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dgvApproved);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(7, 24);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(922, 411);
            this.GroupBox1.TabIndex = 633;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Window;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(935, 418);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 483;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(961, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 634;
            this.button1.Text = "Print";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(614, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 668;
            this.label10.Text = "FROM :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(776, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 667;
            this.label9.Text = "TO :";
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.CustomFormat = "MM/dd/yyyy";
            this.dtp2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(810, 7);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(109, 23);
            this.dtp2.TabIndex = 666;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.CustomFormat = "MM/dd/yyyy";
            this.dtp1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(661, 7);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(109, 23);
            this.dtp1.TabIndex = 665;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 664;
            this.label8.Text = "MOVE ORDER Date :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(234, 26);
            this.label11.TabIndex = 669;
            this.label11.Text = "Transact Move Order";
            // 
            // frmFGMoveorderPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(931, 456);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtsearchs);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lbltotalqty);
            this.Controls.Add(this.lblencodedby);
            this.Controls.Add(this.txtorder);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblrecords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFGMoveorderPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFGMoveorderPrinting_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFGMoveorderPrinting_FormClosed);
            this.Load += new System.EventHandler(this.frmFGMoveorderPrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.Label txtorder;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.Label lblencodedby;
        private System.Windows.Forms.Label lbltotalqty;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.TextBox txtsearchs;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBags;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
    }
}