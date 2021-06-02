namespace WFFDR
{
    partial class frmFGReprocessReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFGReprocessReports));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.lblrecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductionId = new System.Windows.Forms.TextBox();
            this.dgvprodhis = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblprod = new System.Windows.Forms.Label();
            this.ProdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_bags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PENDING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrecordhis = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprodhis)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(21, 22);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 17);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "FROM";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblprod);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.dgvprodhis);
            this.GroupBox1.Controls.Add(this.dgvApproved);
            this.GroupBox1.Controls.Add(this.lblrecords);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 70);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Size = new System.Drawing.Size(1247, 587);
            this.GroupBox1.TabIndex = 556;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "FG Reprocess Reports";
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
            this.dgvApproved.ColumnHeadersHeight = 25;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdID,
            this.fg_feed_code,
            this.fg_feed_type,
            this.fg_bags,
            this.batch_int,
            this.fg_proddate,
            this.fg_added_by,
            this.PENDING,
            this.DONE,
            this.TOTAL});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.Location = new System.Drawing.Point(11, 27);
            this.dgvApproved.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(1228, 319);
            this.dgvApproved.TabIndex = 482;
            this.dgvApproved.CurrentCellChanged += new System.EventHandler(this.dgvApproved_CurrentCellChanged);
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 558;
            this.label1.Text = "TO";
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.CustomFormat = "M/d/yyyy";
            this.dtp2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(359, 7);
            this.dtp2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(215, 39);
            this.dtp2.TabIndex = 557;
            this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(157, 2);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(48, 17);
            this.lblrecords.TabIndex = 559;
            this.lblrecords.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 675);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 560;
            this.label2.Text = "TOTAL RECORDS :";
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.CustomFormat = "M/d/yyyy";
            this.dtp1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(80, 7);
            this.dtp1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(219, 39);
            this.dtp1.TabIndex = 561;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged_1);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Window;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1151, 665);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 34);
            this.btnPrint.TabIndex = 483;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnExits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(604, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 562;
            this.label3.Text = "PRODUCTION ID";
            // 
            // txtProductionId
            // 
            this.txtProductionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductionId.Location = new System.Drawing.Point(749, 7);
            this.txtProductionId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductionId.Multiline = true;
            this.txtProductionId.Name = "txtProductionId";
            this.txtProductionId.Size = new System.Drawing.Size(223, 40);
            this.txtProductionId.TabIndex = 563;
            this.txtProductionId.TextChanged += new System.EventHandler(this.txtProductionId_TextChanged);
            // 
            // dgvprodhis
            // 
            this.dgvprodhis.AllowUserToAddRows = false;
            this.dgvprodhis.AllowUserToDeleteRows = false;
            this.dgvprodhis.AllowUserToResizeColumns = false;
            this.dgvprodhis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvprodhis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvprodhis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvprodhis.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvprodhis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvprodhis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvprodhis.ColumnHeadersHeight = 25;
            this.dgvprodhis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvprodhis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvprodhis.EnableHeadersVisualStyles = false;
            this.dgvprodhis.GridColor = System.Drawing.SystemColors.Control;
            this.dgvprodhis.Location = new System.Drawing.Point(8, 372);
            this.dgvprodhis.Margin = new System.Windows.Forms.Padding(4);
            this.dgvprodhis.MultiSelect = false;
            this.dgvprodhis.Name = "dgvprodhis";
            this.dgvprodhis.ReadOnly = true;
            this.dgvprodhis.RowHeadersWidth = 50;
            this.dgvprodhis.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvprodhis.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvprodhis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvprodhis.Size = new System.Drawing.Size(1228, 207);
            this.dgvprodhis.TabIndex = 483;
            this.dgvprodhis.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvprodhis_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 20);
            this.label4.TabIndex = 484;
            this.label4.Text = "List of Production Historical Ledger";
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Location = new System.Drawing.Point(308, 351);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(39, 20);
            this.lblprod.TabIndex = 485;
            this.lblprod.Text = "yaya";
            this.lblprod.Visible = false;
            // 
            // ProdID
            // 
            this.ProdID.DataPropertyName = "ProdID";
            this.ProdID.HeaderText = "PROD ID";
            this.ProdID.MinimumWidth = 6;
            this.ProdID.Name = "ProdID";
            this.ProdID.ReadOnly = true;
            // 
            // fg_feed_code
            // 
            this.fg_feed_code.DataPropertyName = "fg_feed_code";
            this.fg_feed_code.HeaderText = "FEED CODE";
            this.fg_feed_code.MinimumWidth = 6;
            this.fg_feed_code.Name = "fg_feed_code";
            this.fg_feed_code.ReadOnly = true;
            // 
            // fg_feed_type
            // 
            this.fg_feed_type.DataPropertyName = "fg_feed_type";
            this.fg_feed_type.HeaderText = "FEED TYPE";
            this.fg_feed_type.MinimumWidth = 6;
            this.fg_feed_type.Name = "fg_feed_type";
            this.fg_feed_type.ReadOnly = true;
            // 
            // fg_bags
            // 
            this.fg_bags.DataPropertyName = "fg_bags";
            this.fg_bags.HeaderText = "BAGS";
            this.fg_bags.MinimumWidth = 6;
            this.fg_bags.Name = "fg_bags";
            this.fg_bags.ReadOnly = true;
            // 
            // batch_int
            // 
            this.batch_int.DataPropertyName = "batch_int";
            this.batch_int.HeaderText = "BATCH";
            this.batch_int.MinimumWidth = 6;
            this.batch_int.Name = "batch_int";
            this.batch_int.ReadOnly = true;
            this.batch_int.Visible = false;
            // 
            // fg_proddate
            // 
            this.fg_proddate.DataPropertyName = "fg_proddate";
            this.fg_proddate.HeaderText = "PROD PLAN";
            this.fg_proddate.MinimumWidth = 6;
            this.fg_proddate.Name = "fg_proddate";
            this.fg_proddate.ReadOnly = true;
            // 
            // fg_added_by
            // 
            this.fg_added_by.DataPropertyName = "fg_added_by";
            this.fg_added_by.HeaderText = "DUMP DATE";
            this.fg_added_by.MinimumWidth = 6;
            this.fg_added_by.Name = "fg_added_by";
            this.fg_added_by.ReadOnly = true;
            // 
            // PENDING
            // 
            this.PENDING.DataPropertyName = "PENDING";
            this.PENDING.HeaderText = "PENDING";
            this.PENDING.MinimumWidth = 6;
            this.PENDING.Name = "PENDING";
            this.PENDING.ReadOnly = true;
            this.PENDING.Visible = false;
            // 
            // DONE
            // 
            this.DONE.DataPropertyName = "DONE";
            this.DONE.HeaderText = "DONE";
            this.DONE.MinimumWidth = 6;
            this.DONE.Name = "DONE";
            this.DONE.ReadOnly = true;
            this.DONE.Visible = false;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.MinimumWidth = 6;
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // lblrecordhis
            // 
            this.lblrecordhis.AutoSize = true;
            this.lblrecordhis.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecordhis.Location = new System.Drawing.Point(142, 675);
            this.lblrecordhis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrecordhis.Name = "lblrecordhis";
            this.lblrecordhis.Size = new System.Drawing.Size(141, 17);
            this.lblrecordhis.TabIndex = 564;
            this.lblrecordhis.Text = "TOTAL RECORDS :";
            // 
            // frmFGReprocessReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1275, 712);
            this.Controls.Add(this.lblrecordhis);
            this.Controls.Add(this.txtProductionId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFGReprocessReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FG Reprocess Report Module";
            this.Load += new System.EventHandler(this.frmFGReprocessReports_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprodhis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DataGridView dgvApproved;
        internal System.Windows.Forms.Label lblrecords;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp1;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductionId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvprodhis;
        private System.Windows.Forms.Label lblprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_bags;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn PENDING;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        internal System.Windows.Forms.Label lblrecordhis;
    }
}