namespace WFFDR
{
    partial class frmFGReceivings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFGReceivings));
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.ProdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BagsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BulkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrintingDate = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblrecords = new System.Windows.Forms.Label();
            this.lblprodid = new System.Windows.Forms.Label();
            this.btnReceived = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductionDate = new System.Windows.Forms.DateTimePicker();
            this.txtProdPlan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFeedCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtProdID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_table.ColumnHeadersHeight = 30;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdID,
            this.ProdDate,
            this.PrintingDate,
            this.FeedCode,
            this.FeedType,
            this.BagsCount,
            this.BulkCount,
            this.Column5,
            this.Column1,
            this.Column2,
            this.AGING});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(3, 16);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 60;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(961, 501);
            this.dgv_table.TabIndex = 37;
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            // 
            // ProdID
            // 
            this.ProdID.DataPropertyName = "ProdID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ProdID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProdID.HeaderText = "PROD ID";
            this.ProdID.Name = "ProdID";
            this.ProdID.ReadOnly = true;
            // 
            // ProdDate
            // 
            this.ProdDate.DataPropertyName = "ProdDate";
            this.ProdDate.HeaderText = "PROD PLAN";
            this.ProdDate.Name = "ProdDate";
            this.ProdDate.ReadOnly = true;
            // 
            // PrintingDate
            // 
            this.PrintingDate.DataPropertyName = "PrintingDate";
            this.PrintingDate.HeaderText = "FG DATE";
            this.PrintingDate.Name = "PrintingDate";
            this.PrintingDate.ReadOnly = true;
            // 
            // FeedCode
            // 
            this.FeedCode.DataPropertyName = "FeedCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FeedCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.FeedCode.HeaderText = "FEED CODE";
            this.FeedCode.Name = "FeedCode";
            this.FeedCode.ReadOnly = true;
            // 
            // FeedType
            // 
            this.FeedType.DataPropertyName = "FeedType";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FeedType.DefaultCellStyle = dataGridViewCellStyle5;
            this.FeedType.HeaderText = "FEED TYPE";
            this.FeedType.Name = "FeedType";
            this.FeedType.ReadOnly = true;
            // 
            // BagsCount
            // 
            this.BagsCount.DataPropertyName = "BagsCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.BagsCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.BagsCount.HeaderText = "BAGS";
            this.BagsCount.Name = "BagsCount";
            this.BagsCount.ReadOnly = true;
            // 
            // BulkCount
            // 
            this.BulkCount.DataPropertyName = "BulkCount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.BulkCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.BulkCount.HeaderText = "BULK";
            this.BulkCount.Name = "BulkCount";
            this.BulkCount.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GrandTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column5.HeaderText = "GRAND TOTAL";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MoveOrder";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column1.HeaderText = "QTY RECEIVED";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ACTUAL";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column2.HeaderText = "REMAINING";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // AGING
            // 
            this.AGING.DataPropertyName = "AGING";
            this.AGING.HeaderText = "AGING";
            this.AGING.Name = "AGING";
            this.AGING.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrintingDate);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.dgv_table);
            this.groupBox1.Location = new System.Drawing.Point(11, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 520);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Production Schedules";
            // 
            // txtPrintingDate
            // 
            this.txtPrintingDate.Location = new System.Drawing.Point(145, 252);
            this.txtPrintingDate.Name = "txtPrintingDate";
            this.txtPrintingDate.Size = new System.Drawing.Size(100, 20);
            this.txtPrintingDate.TabIndex = 39;
            this.txtPrintingDate.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(400, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 38;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Location = new System.Drawing.Point(112, 583);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(47, 13);
            this.lblrecords.TabIndex = 39;
            this.lblrecords.Text = "Records";
            // 
            // lblprodid
            // 
            this.lblprodid.AutoSize = true;
            this.lblprodid.Location = new System.Drawing.Point(240, 583);
            this.lblprodid.Name = "lblprodid";
            this.lblprodid.Size = new System.Drawing.Size(47, 13);
            this.lblprodid.TabIndex = 645;
            this.lblprodid.Text = "Records";
            this.lblprodid.Visible = false;
            // 
            // btnReceived
            // 
            this.btnReceived.BackColor = System.Drawing.SystemColors.Window;
            this.btnReceived.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceived.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReceived.Image = ((System.Drawing.Image)(resources.GetObject("btnReceived.Image")));
            this.btnReceived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceived.Location = new System.Drawing.Point(890, 572);
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.Size = new System.Drawing.Size(88, 28);
            this.btnReceived.TabIndex = 644;
            this.btnReceived.Text = "&Received";
            this.btnReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceived.UseVisualStyleBackColor = false;
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtProductionDate);
            this.groupBox2.Controls.Add(this.txtProdPlan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFeedCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Label5);
            this.groupBox2.Controls.Add(this.txtProdID);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(966, 45);
            this.groupBox2.TabIndex = 658;
            this.groupBox2.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(765, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(134, 20);
            this.textBox2.TabIndex = 654;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 653;
            this.label6.Text = "Feed Code :";
            // 
            // txtProductionDate
            // 
            this.txtProductionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionDate.CustomFormat = "M/d/yyyy";
            this.txtProductionDate.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtProductionDate.Location = new System.Drawing.Point(142, 17);
            this.txtProductionDate.Name = "txtProductionDate";
            this.txtProductionDate.Size = new System.Drawing.Size(109, 23);
            this.txtProductionDate.TabIndex = 652;
            this.txtProductionDate.ValueChanged += new System.EventHandler(this.txtProductionDate_ValueChanged);
            // 
            // txtProdPlan
            // 
            this.txtProdPlan.BackColor = System.Drawing.SystemColors.Control;
            this.txtProdPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdPlan.Enabled = false;
            this.txtProdPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdPlan.Location = new System.Drawing.Point(771, 18);
            this.txtProdPlan.Name = "txtProdPlan";
            this.txtProdPlan.Size = new System.Drawing.Size(134, 20);
            this.txtProdPlan.TabIndex = 456;
            this.txtProdPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdPlan.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(908, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 455;
            this.label3.Text = "Prod Plan :";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(795, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 453;
            this.label2.Text = "Feed Code :";
            this.label2.Visible = false;
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.BackColor = System.Drawing.Color.Yellow;
            this.txtFeedCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeedCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeedCode.Location = new System.Drawing.Point(482, 18);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(134, 20);
            this.txtFeedCode.TabIndex = 454;
            this.txtFeedCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFeedCode.TextChanged += new System.EventHandler(this.txtFeedCode_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 451;
            this.label1.Text = "Finished Goods Date :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(795, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(94, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Production ID :";
            this.Label5.Visible = false;
            // 
            // txtProdID
            // 
            this.txtProdID.BackColor = System.Drawing.Color.Yellow;
            this.txtProdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdID.Location = new System.Drawing.Point(832, 17);
            this.txtProdID.Name = "txtProdID";
            this.txtProdID.Size = new System.Drawing.Size(134, 20);
            this.txtProdID.TabIndex = 450;
            this.txtProdID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProdID.Visible = false;
            this.txtProdID.TextChanged += new System.EventHandler(this.txtFeedCode_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 659;
            this.label4.Text = "Total Records :";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "M/d/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(285, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 23);
            this.dtpTo.TabIndex = 655;
            // 
            // frmFGReceivings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(990, 604);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblprodid);
            this.Controls.Add(this.btnReceived);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFGReceivings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finished Goods Receiving";
            this.Load += new System.EventHandler(this.frmFGReceivings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblrecords;
        protected internal System.Windows.Forms.Button btnReceived;
        private System.Windows.Forms.Label lblprodid;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtPrintingDate;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFeedCode;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtProdID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtProductionDate;
        private System.Windows.Forms.TextBox txtProdPlan;
        private System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BulkCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGING;
        private System.Windows.Forms.DateTimePicker dtpTo;
    }
}