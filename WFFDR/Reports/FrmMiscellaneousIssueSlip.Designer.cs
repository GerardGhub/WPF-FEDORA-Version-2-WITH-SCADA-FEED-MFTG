
namespace WFFDR.Reports
{
    partial class FrmMiscellaneousIssueSlip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMiscellaneousIssueSlip));
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtorderno = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.txtProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearchs = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltotalqty = new System.Windows.Forms.Label();
            this.lblencodedby = new System.Windows.Forms.Label();
            this.txtorder = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.orderno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(364, 26);
            this.label11.TabIndex = 692;
            this.label11.Text = "Miscellaneous Issue Printing Slip";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(630, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 691;
            this.label10.Text = "FROM :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(789, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 690;
            this.label9.Text = "TO :";
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.CustomFormat = "M/d/yyyy";
            this.dtp2.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(820, 9);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(109, 23);
            this.dtp2.TabIndex = 689;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.CustomFormat = "M/d/yyyy";
            this.dtp1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(677, 9);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(109, 23);
            this.dtp1.TabIndex = 688;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(560, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 687;
            this.label8.Text = "Issue Date :";
            // 
            // txtorderno
            // 
            this.txtorderno.Location = new System.Drawing.Point(545, 446);
            this.txtorderno.Margin = new System.Windows.Forms.Padding(2);
            this.txtorderno.Name = "txtorderno";
            this.txtorderno.Size = new System.Drawing.Size(76, 20);
            this.txtorderno.TabIndex = 686;
            this.txtorderno.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.GroupBox1.Controls.Add(this.dtpTo);
            this.GroupBox1.Controls.Add(this.dgvApproved);
            this.GroupBox1.Controls.Add(this.txtProductionDate);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(6, 31);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(922, 411);
            this.GroupBox1.TabIndex = 684;
            this.GroupBox1.TabStop = false;
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "M/d/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(808, -24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 23);
            this.dtpTo.TabIndex = 661;
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AllowUserToDeleteRows = false;
            this.dgvApproved.AllowUserToResizeColumns = false;
            this.dgvApproved.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproved.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvApproved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderno,
            this.TotalBags,
            this.added_by,
            this.printing_date,
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApproved.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(902, 388);
            this.dgvApproved.TabIndex = 433;
            this.dgvApproved.CurrentCellChanged += new System.EventHandler(this.dgvApproved_CurrentCellChanged);
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint);
            // 
            // txtProductionDate
            // 
            this.txtProductionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionDate.CustomFormat = "M/d/yyyy";
            this.txtProductionDate.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtProductionDate.Location = new System.Drawing.Point(664, -24);
            this.txtProductionDate.Name = "txtProductionDate";
            this.txtProductionDate.Size = new System.Drawing.Size(109, 23);
            this.txtProductionDate.TabIndex = 660;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(529, -17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 659;
            this.label7.Text = "Finished Goods Date :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(675, 449);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 683;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(194, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 680;
            this.label1.Text = "Search :";
            this.label1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(254, 452);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 20);
            this.textBox2.TabIndex = 679;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 678;
            this.label3.Text = "Encoded by :";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(939, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 677;
            this.label4.Text = "Encoded by :";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(759, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 676;
            this.label5.Text = "Encoded by :";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(863, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 675;
            this.label6.Text = "Encoded by :";
            this.label6.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(8, 456);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 13);
            this.label20.TabIndex = 674;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(118, 456);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(14, 13);
            this.lblrecords.TabIndex = 673;
            this.lblrecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-269, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 671;
            this.label2.Text = "Search :";
            // 
            // txtsearchs
            // 
            this.txtsearchs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchs.Location = new System.Drawing.Point(-209, 338);
            this.txtsearchs.Name = "txtsearchs";
            this.txtsearchs.Size = new System.Drawing.Size(160, 20);
            this.txtsearchs.TabIndex = 670;
            this.txtsearchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(572, -48);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(70, 13);
            this.lbldate.TabIndex = 669;
            this.lbldate.Text = "Encoded by :";
            this.lbldate.Visible = false;
            // 
            // lbltotalqty
            // 
            this.lbltotalqty.AutoSize = true;
            this.lbltotalqty.Location = new System.Drawing.Point(610, -24);
            this.lbltotalqty.Name = "lbltotalqty";
            this.lbltotalqty.Size = new System.Drawing.Size(70, 13);
            this.lbltotalqty.TabIndex = 668;
            this.lbltotalqty.Text = "Encoded by :";
            this.lbltotalqty.Visible = false;
            // 
            // lblencodedby
            // 
            this.lblencodedby.AutoSize = true;
            this.lblencodedby.Location = new System.Drawing.Point(482, -77);
            this.lblencodedby.Name = "lblencodedby";
            this.lblencodedby.Size = new System.Drawing.Size(70, 13);
            this.lblencodedby.TabIndex = 667;
            this.lblencodedby.Text = "Encoded by :";
            this.lblencodedby.Visible = false;
            // 
            // txtorder
            // 
            this.txtorder.AutoSize = true;
            this.txtorder.Location = new System.Drawing.Point(587, -77);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(70, 13);
            this.txtorder.TabIndex = 666;
            this.txtorder.Text = "Encoded by :";
            this.txtorder.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(773, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 693;
            this.button2.Text = "Print";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(960, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 685;
            this.button1.Text = "Print";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(936, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 682;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Window;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(854, 446);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 681;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(571, -84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 672;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // orderno
            // 
            this.orderno.DataPropertyName = "orderno";
            this.orderno.HeaderText = "ORDER NO";
            this.orderno.MinimumWidth = 6;
            this.orderno.Name = "orderno";
            this.orderno.ReadOnly = true;
            // 
            // TotalBags
            // 
            this.TotalBags.DataPropertyName = "TotalBags";
            this.TotalBags.HeaderText = "TOTAL BAGS";
            this.TotalBags.MinimumWidth = 6;
            this.TotalBags.Name = "TotalBags";
            this.TotalBags.ReadOnly = true;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ADDED BY";
            this.added_by.MinimumWidth = 6;
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            // 
            // printing_date
            // 
            this.printing_date.DataPropertyName = "printing_date";
            this.printing_date.HeaderText = "ISSUE DATE";
            this.printing_date.MinimumWidth = 6;
            this.printing_date.Name = "printing_date";
            this.printing_date.ReadOnly = true;
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
            // FrmMiscellaneousIssueSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 480);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtorderno);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearchs);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lbltotalqty);
            this.Controls.Add(this.lblencodedby);
            this.Controls.Add(this.txtorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMiscellaneousIssueSlip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMiscellaneousIssueSlip_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtorderno;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.DateTimePicker txtProductionDate;
        internal System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearchs;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltotalqty;
        private System.Windows.Forms.Label lblencodedby;
        private System.Windows.Forms.Label txtorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderno;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBags;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn printing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}