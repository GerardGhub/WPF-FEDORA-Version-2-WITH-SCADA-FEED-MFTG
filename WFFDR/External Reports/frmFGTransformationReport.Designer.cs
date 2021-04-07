
namespace WFFDR
{
    partial class frmFGTransformationReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFGTransformationReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrintorder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpprod2 = new System.Windows.Forms.DateTimePicker();
            this.dtpprod1 = new System.Windows.Forms.DateTimePicker();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearchs = new System.Windows.Forms.TextBox();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label20 = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.prod_adv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transformed_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transformed_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transformed_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transformed_status_era = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_bags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmx_id_string = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintorder
            // 
            this.btnPrintorder.BackColor = System.Drawing.SystemColors.Window;
            this.btnPrintorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintorder.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintorder.Image")));
            this.btnPrintorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintorder.Location = new System.Drawing.Point(856, 25);
            this.btnPrintorder.Name = "btnPrintorder";
            this.btnPrintorder.Size = new System.Drawing.Size(82, 28);
            this.btnPrintorder.TabIndex = 700;
            this.btnPrintorder.Text = "&Print";
            this.btnPrintorder.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 699;
            this.label3.Text = "TO :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 698;
            this.label1.Text = "FROM :";
            // 
            // dtpprod2
            // 
            this.dtpprod2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.CustomFormat = "yyyy/MM/d";
            this.dtpprod2.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod2.Location = new System.Drawing.Point(640, 23);
            this.dtpprod2.Name = "dtpprod2";
            this.dtpprod2.Size = new System.Drawing.Size(187, 30);
            this.dtpprod2.TabIndex = 697;
            this.dtpprod2.ValueChanged += new System.EventHandler(this.dtpprod2_ValueChanged);
            // 
            // dtpprod1
            // 
            this.dtpprod1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.CustomFormat = "yyyy/MM/d";
            this.dtpprod1.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod1.Location = new System.Drawing.Point(403, 23);
            this.dtpprod1.Name = "dtpprod1";
            this.dtpprod1.Size = new System.Drawing.Size(194, 30);
            this.dtpprod1.TabIndex = 696;
            this.dtpprod1.ValueChanged += new System.EventHandler(this.dtpprod1_ValueChanged);
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AllowUserToDeleteRows = false;
            this.dgvApproved.AllowUserToResizeColumns = false;
            this.dgvApproved.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvApproved.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_adv,
            this.fg_id,
            this.fg_feed_code,
            this.fg_feed_type,
            this.fg_batch,
            this.fg_proddate,
            this.status,
            this.added_by,
            this.printing_date,
            this.transformed_remarks,
            this.transformed_date,
            this.transformed_by,
            this.transformed_status_era,
            this.fg_bags,
            this.dated,
            this.bmx_id_string});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.Location = new System.Drawing.Point(20, 59);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(919, 372);
            this.dgvApproved.TabIndex = 692;
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 694;
            this.label2.Text = "Search :";
            // 
            // txtsearchs
            // 
            this.txtsearchs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchs.Location = new System.Drawing.Point(90, 31);
            this.txtsearchs.Name = "txtsearchs";
            this.txtsearchs.Size = new System.Drawing.Size(160, 13);
            this.txtsearchs.TabIndex = 693;
            this.txtsearchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.bunifuThinButton23.Location = new System.Drawing.Point(76, 19);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(187, 36);
            this.bunifuThinButton23.TabIndex = 695;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 441);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 702;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Location = new System.Drawing.Point(131, 441);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(70, 13);
            this.lblrecords.TabIndex = 701;
            this.lblrecords.Text = "Encoded by :";
            // 
            // prod_adv
            // 
            this.prod_adv.DataPropertyName = "prod_adv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.prod_adv.DefaultCellStyle = dataGridViewCellStyle3;
            this.prod_adv.Frozen = true;
            this.prod_adv.HeaderText = "ID";
            this.prod_adv.Name = "prod_adv";
            this.prod_adv.ReadOnly = true;
            this.prod_adv.Width = 43;
            // 
            // fg_id
            // 
            this.fg_id.DataPropertyName = "fg_id";
            this.fg_id.Frozen = true;
            this.fg_id.HeaderText = "BARCODE";
            this.fg_id.Name = "fg_id";
            this.fg_id.ReadOnly = true;
            this.fg_id.Width = 84;
            // 
            // fg_feed_code
            // 
            this.fg_feed_code.DataPropertyName = "fg_feed_code";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fg_feed_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.fg_feed_code.Frozen = true;
            this.fg_feed_code.HeaderText = "FEED CODE";
            this.fg_feed_code.Name = "fg_feed_code";
            this.fg_feed_code.ReadOnly = true;
            this.fg_feed_code.Width = 93;
            // 
            // fg_feed_type
            // 
            this.fg_feed_type.DataPropertyName = "fg_feed_type";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.fg_feed_type.DefaultCellStyle = dataGridViewCellStyle5;
            this.fg_feed_type.Frozen = true;
            this.fg_feed_type.HeaderText = "FEED TYPE";
            this.fg_feed_type.Name = "fg_feed_type";
            this.fg_feed_type.ReadOnly = true;
            this.fg_feed_type.Width = 91;
            // 
            // fg_batch
            // 
            this.fg_batch.DataPropertyName = "fg_batch";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fg_batch.DefaultCellStyle = dataGridViewCellStyle6;
            this.fg_batch.Frozen = true;
            this.fg_batch.HeaderText = "BATCH";
            this.fg_batch.Name = "fg_batch";
            this.fg_batch.ReadOnly = true;
            this.fg_batch.Width = 68;
            // 
            // fg_proddate
            // 
            this.fg_proddate.DataPropertyName = "fg_proddate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fg_proddate.DefaultCellStyle = dataGridViewCellStyle7;
            this.fg_proddate.Frozen = true;
            this.fg_proddate.HeaderText = "PROD PLAN";
            this.fg_proddate.Name = "fg_proddate";
            this.fg_proddate.ReadOnly = true;
            this.fg_proddate.Width = 94;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.Frozen = true;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 75;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ADDED BY";
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            this.added_by.Width = 87;
            // 
            // printing_date
            // 
            this.printing_date.DataPropertyName = "printing_date";
            this.printing_date.HeaderText = "FG DATE";
            this.printing_date.Name = "printing_date";
            this.printing_date.ReadOnly = true;
            this.printing_date.Width = 78;
            // 
            // transformed_remarks
            // 
            this.transformed_remarks.DataPropertyName = "transformed_remarks";
            this.transformed_remarks.HeaderText = "TRANSFORM_REMARKS";
            this.transformed_remarks.Name = "transformed_remarks";
            this.transformed_remarks.ReadOnly = true;
            this.transformed_remarks.Width = 159;
            // 
            // transformed_date
            // 
            this.transformed_date.DataPropertyName = "transformed_date";
            this.transformed_date.HeaderText = "TRANSFORM DATE";
            this.transformed_date.Name = "transformed_date";
            this.transformed_date.ReadOnly = true;
            this.transformed_date.Width = 132;
            // 
            // transformed_by
            // 
            this.transformed_by.DataPropertyName = "transformed_by";
            this.transformed_by.HeaderText = "TRANSFORM BY";
            this.transformed_by.Name = "transformed_by";
            this.transformed_by.ReadOnly = true;
            this.transformed_by.Width = 117;
            // 
            // transformed_status_era
            // 
            this.transformed_status_era.DataPropertyName = "transformed_status_era";
            this.transformed_status_era.HeaderText = "FROM";
            this.transformed_status_era.Name = "transformed_status_era";
            this.transformed_status_era.ReadOnly = true;
            this.transformed_status_era.Width = 63;
            // 
            // fg_bags
            // 
            this.fg_bags.DataPropertyName = "fg_bags";
            this.fg_bags.HeaderText = "BAGS";
            this.fg_bags.Name = "fg_bags";
            this.fg_bags.ReadOnly = true;
            this.fg_bags.Width = 61;
            // 
            // dated
            // 
            this.dated.DataPropertyName = "dated";
            this.dated.HeaderText = "Dated Cast";
            this.dated.Name = "dated";
            this.dated.ReadOnly = true;
            this.dated.Visible = false;
            this.dated.Width = 85;
            // 
            // bmx_id_string
            // 
            this.bmx_id_string.DataPropertyName = "bmx_id_string";
            this.bmx_id_string.HeaderText = "bmx_id_string nanu";
            this.bmx_id_string.Name = "bmx_id_string";
            this.bmx_id_string.ReadOnly = true;
            this.bmx_id_string.Visible = false;
            this.bmx_id_string.Width = 123;
            // 
            // frmFGTransformationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(954, 463);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.btnPrintorder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpprod2);
            this.Controls.Add(this.dtpprod1);
            this.Controls.Add(this.dgvApproved);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearchs);
            this.Controls.Add(this.bunifuThinButton23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFGTransformationReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FG Transformation Report";
            this.Load += new System.EventHandler(this.frmFGTransformationReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnPrintorder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpprod2;
        private System.Windows.Forms.DateTimePicker dtpprod1;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearchs;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_adv;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn printing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn transformed_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn transformed_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn transformed_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn transformed_status_era;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_bags;
        private System.Windows.Forms.DataGridViewTextBoxColumn dated;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmx_id_string;
    }
}