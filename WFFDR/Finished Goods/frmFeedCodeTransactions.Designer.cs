namespace WFFDR
{
    partial class frmFeedCodeTransactions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeedCodeTransactions));
            this.txtFeedCode = new System.Windows.Forms.Label();
            this.dgv_feedcode = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblqty = new System.Windows.Forms.Label();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.Feed_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAGS_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BULK_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_RECEIPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BULK_RECEIPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_RECEIPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_ISSUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BULK_ISSUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_ISSUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_MOVEORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BULK_MOVEORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_MOVEORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRAND_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalIssueMoveorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_INVENTORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_INVENTORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BULK_INVENTORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_adv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_options = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noformatdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_feedcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.AutoSize = true;
            this.txtFeedCode.Location = new System.Drawing.Point(35, 11);
            this.txtFeedCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(46, 17);
            this.txtFeedCode.TabIndex = 0;
            this.txtFeedCode.Text = "label1";
            // 
            // dgv_feedcode
            // 
            this.dgv_feedcode.AllowUserToAddRows = false;
            this.dgv_feedcode.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_feedcode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_feedcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_feedcode.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_feedcode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_feedcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_feedcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_adv,
            this.fg_feed_code,
            this.fg_feed_type,
            this.fg_options,
            this.Quantity,
            this.Noformatdate,
            this.FGDate,
            this.transaction_date,
            this.added_by,
            this.transaction_type});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_feedcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_feedcode.GridColor = System.Drawing.Color.Teal;
            this.dgv_feedcode.Location = new System.Drawing.Point(0, -1);
            this.dgv_feedcode.Name = "dgv_feedcode";
            this.dgv_feedcode.ReadOnly = true;
            this.dgv_feedcode.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_feedcode.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_feedcode.RowTemplate.Height = 24;
            this.dgv_feedcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_feedcode.Size = new System.Drawing.Size(1179, 528);
            this.dgv_feedcode.TabIndex = 1;
            this.dgv_feedcode.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_feedcode_RowPostPaint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 530);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 614;
            this.label10.Text = "Total Records :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(118, 530);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(91, 17);
            this.lblrecords.TabIndex = 613;
            this.lblrecords.Text = "Encoded by :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 530);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 616;
            this.label1.Text = "Stock on hand :";
            // 
            // lblqty
            // 
            this.lblqty.AutoSize = true;
            this.lblqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblqty.Location = new System.Drawing.Point(609, 530);
            this.lblqty.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(16, 17);
            this.lblqty.TabIndex = 615;
            this.lblqty.Text = "0";
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_table.ColumnHeadersHeight = 25;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Feed_Code,
            this.FeedType,
            this.BAGS_COUNT,
            this.BULK_COUNT,
            this.TOTAL_COUNT,
            this.BAG_RECEIPT,
            this.BULK_RECEIPT,
            this.TOTAL_RECEIPT,
            this.BAG_ISSUE,
            this.BULK_ISSUE,
            this.TOTAL_ISSUE,
            this.BAG_MOVEORDER,
            this.BULK_MOVEORDER,
            this.TOTAL_MOVEORDER,
            this.GRAND_TOTAL,
            this.TotalIssueMoveorder,
            this.TOTAL_INVENTORY,
            this.BAG_INVENTORY,
            this.BULK_INVENTORY});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Cambria", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.Color.Teal;
            this.dgv_table.Location = new System.Drawing.Point(1290, 34);
            this.dgv_table.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 60;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Cambria", 7.8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(390, 340);
            this.dgv_table.TabIndex = 617;
            // 
            // Feed_Code
            // 
            this.Feed_Code.DataPropertyName = "Feed_Code";
            this.Feed_Code.Frozen = true;
            this.Feed_Code.HeaderText = "Feed Code";
            this.Feed_Code.MinimumWidth = 6;
            this.Feed_Code.Name = "Feed_Code";
            this.Feed_Code.ReadOnly = true;
            this.Feed_Code.Width = 106;
            // 
            // FeedType
            // 
            this.FeedType.DataPropertyName = "FeedType";
            this.FeedType.Frozen = true;
            this.FeedType.HeaderText = "Feed Type";
            this.FeedType.MinimumWidth = 6;
            this.FeedType.Name = "FeedType";
            this.FeedType.ReadOnly = true;
            this.FeedType.Width = 105;
            // 
            // BAGS_COUNT
            // 
            this.BAGS_COUNT.DataPropertyName = "BAGS_COUNT";
            this.BAGS_COUNT.HeaderText = "Bag Count";
            this.BAGS_COUNT.MinimumWidth = 6;
            this.BAGS_COUNT.Name = "BAGS_COUNT";
            this.BAGS_COUNT.ReadOnly = true;
            this.BAGS_COUNT.Width = 103;
            // 
            // BULK_COUNT
            // 
            this.BULK_COUNT.DataPropertyName = "BULK_COUNT";
            this.BULK_COUNT.HeaderText = "Bulk Count";
            this.BULK_COUNT.MinimumWidth = 6;
            this.BULK_COUNT.Name = "BULK_COUNT";
            this.BULK_COUNT.ReadOnly = true;
            this.BULK_COUNT.Width = 105;
            // 
            // TOTAL_COUNT
            // 
            this.TOTAL_COUNT.DataPropertyName = "TOTAL_COUNT";
            this.TOTAL_COUNT.HeaderText = "Total Count";
            this.TOTAL_COUNT.MinimumWidth = 6;
            this.TOTAL_COUNT.Name = "TOTAL_COUNT";
            this.TOTAL_COUNT.ReadOnly = true;
            this.TOTAL_COUNT.Width = 110;
            // 
            // BAG_RECEIPT
            // 
            this.BAG_RECEIPT.DataPropertyName = "BAG_RECEIPT";
            this.BAG_RECEIPT.HeaderText = "Bag Receipt";
            this.BAG_RECEIPT.MinimumWidth = 6;
            this.BAG_RECEIPT.Name = "BAG_RECEIPT";
            this.BAG_RECEIPT.ReadOnly = true;
            this.BAG_RECEIPT.Width = 114;
            // 
            // BULK_RECEIPT
            // 
            this.BULK_RECEIPT.DataPropertyName = "BULK_RECEIPT";
            this.BULK_RECEIPT.HeaderText = "Bulk Receipt";
            this.BULK_RECEIPT.MinimumWidth = 6;
            this.BULK_RECEIPT.Name = "BULK_RECEIPT";
            this.BULK_RECEIPT.ReadOnly = true;
            this.BULK_RECEIPT.Width = 116;
            // 
            // TOTAL_RECEIPT
            // 
            this.TOTAL_RECEIPT.DataPropertyName = "TOTAL_RECEIPT";
            this.TOTAL_RECEIPT.HeaderText = "Total Receipt";
            this.TOTAL_RECEIPT.MinimumWidth = 6;
            this.TOTAL_RECEIPT.Name = "TOTAL_RECEIPT";
            this.TOTAL_RECEIPT.ReadOnly = true;
            this.TOTAL_RECEIPT.Width = 121;
            // 
            // BAG_ISSUE
            // 
            this.BAG_ISSUE.DataPropertyName = "BAG_ISSUE";
            this.BAG_ISSUE.HeaderText = "Bag Issue";
            this.BAG_ISSUE.MinimumWidth = 6;
            this.BAG_ISSUE.Name = "BAG_ISSUE";
            this.BAG_ISSUE.ReadOnly = true;
            this.BAG_ISSUE.Width = 99;
            // 
            // BULK_ISSUE
            // 
            this.BULK_ISSUE.DataPropertyName = "BULK_ISSUE";
            this.BULK_ISSUE.HeaderText = "Bulk Issue";
            this.BULK_ISSUE.MinimumWidth = 6;
            this.BULK_ISSUE.Name = "BULK_ISSUE";
            this.BULK_ISSUE.ReadOnly = true;
            this.BULK_ISSUE.Width = 101;
            // 
            // TOTAL_ISSUE
            // 
            this.TOTAL_ISSUE.DataPropertyName = "TOTAL_ISSUE";
            this.TOTAL_ISSUE.HeaderText = "Total Issue";
            this.TOTAL_ISSUE.MinimumWidth = 6;
            this.TOTAL_ISSUE.Name = "TOTAL_ISSUE";
            this.TOTAL_ISSUE.ReadOnly = true;
            this.TOTAL_ISSUE.Width = 106;
            // 
            // BAG_MOVEORDER
            // 
            this.BAG_MOVEORDER.DataPropertyName = "BAG_MOVEORDER";
            this.BAG_MOVEORDER.HeaderText = "Bag Moveorder";
            this.BAG_MOVEORDER.MinimumWidth = 6;
            this.BAG_MOVEORDER.Name = "BAG_MOVEORDER";
            this.BAG_MOVEORDER.ReadOnly = true;
            this.BAG_MOVEORDER.Width = 134;
            // 
            // BULK_MOVEORDER
            // 
            this.BULK_MOVEORDER.DataPropertyName = "BULK_MOVEORDER";
            this.BULK_MOVEORDER.HeaderText = "Bulk Moveorder";
            this.BULK_MOVEORDER.MinimumWidth = 6;
            this.BULK_MOVEORDER.Name = "BULK_MOVEORDER";
            this.BULK_MOVEORDER.ReadOnly = true;
            this.BULK_MOVEORDER.Width = 136;
            // 
            // TOTAL_MOVEORDER
            // 
            this.TOTAL_MOVEORDER.DataPropertyName = "TOTAL_MOVEORDER";
            this.TOTAL_MOVEORDER.HeaderText = "Total Moveorder";
            this.TOTAL_MOVEORDER.MinimumWidth = 6;
            this.TOTAL_MOVEORDER.Name = "TOTAL_MOVEORDER";
            this.TOTAL_MOVEORDER.ReadOnly = true;
            this.TOTAL_MOVEORDER.Width = 141;
            // 
            // GRAND_TOTAL
            // 
            this.GRAND_TOTAL.DataPropertyName = "GRAND_TOTAL";
            this.GRAND_TOTAL.HeaderText = "Total Count & Receipt";
            this.GRAND_TOTAL.MinimumWidth = 6;
            this.GRAND_TOTAL.Name = "GRAND_TOTAL";
            this.GRAND_TOTAL.ReadOnly = true;
            this.GRAND_TOTAL.Width = 175;
            // 
            // TotalIssueMoveorder
            // 
            this.TotalIssueMoveorder.DataPropertyName = "TotalIssueMoveorder";
            this.TotalIssueMoveorder.HeaderText = "Total Moveorder & Issue";
            this.TotalIssueMoveorder.MinimumWidth = 6;
            this.TotalIssueMoveorder.Name = "TotalIssueMoveorder";
            this.TotalIssueMoveorder.ReadOnly = true;
            this.TotalIssueMoveorder.Width = 191;
            // 
            // TOTAL_INVENTORY
            // 
            this.TOTAL_INVENTORY.DataPropertyName = "TOTAL_INVENTORY";
            this.TOTAL_INVENTORY.HeaderText = "Total Inventory";
            this.TOTAL_INVENTORY.MinimumWidth = 6;
            this.TOTAL_INVENTORY.Name = "TOTAL_INVENTORY";
            this.TOTAL_INVENTORY.ReadOnly = true;
            this.TOTAL_INVENTORY.Width = 131;
            // 
            // BAG_INVENTORY
            // 
            this.BAG_INVENTORY.DataPropertyName = "BAG_INVENTORY";
            this.BAG_INVENTORY.HeaderText = "Bag Inventory";
            this.BAG_INVENTORY.MinimumWidth = 6;
            this.BAG_INVENTORY.Name = "BAG_INVENTORY";
            this.BAG_INVENTORY.ReadOnly = true;
            this.BAG_INVENTORY.Width = 124;
            // 
            // BULK_INVENTORY
            // 
            this.BULK_INVENTORY.DataPropertyName = "BULK_INVENTORY";
            this.BULK_INVENTORY.HeaderText = "Bulk Inventory";
            this.BULK_INVENTORY.MinimumWidth = 6;
            this.BULK_INVENTORY.Name = "BULK_INVENTORY";
            this.BULK_INVENTORY.ReadOnly = true;
            this.BULK_INVENTORY.Width = 126;
            // 
            // prod_adv
            // 
            this.prod_adv.DataPropertyName = "prod_adv";
            this.prod_adv.HeaderText = "Production ID";
            this.prod_adv.MinimumWidth = 6;
            this.prod_adv.Name = "prod_adv";
            this.prod_adv.ReadOnly = true;
            // 
            // fg_feed_code
            // 
            this.fg_feed_code.DataPropertyName = "fg_feed_code";
            this.fg_feed_code.HeaderText = "Feed Code";
            this.fg_feed_code.MinimumWidth = 6;
            this.fg_feed_code.Name = "fg_feed_code";
            this.fg_feed_code.ReadOnly = true;
            // 
            // fg_feed_type
            // 
            this.fg_feed_type.DataPropertyName = "fg_feed_type";
            this.fg_feed_type.HeaderText = "Feed Type";
            this.fg_feed_type.MinimumWidth = 6;
            this.fg_feed_type.Name = "fg_feed_type";
            this.fg_feed_type.ReadOnly = true;
            // 
            // fg_options
            // 
            this.fg_options.DataPropertyName = "fg_options";
            this.fg_options.HeaderText = "Category";
            this.fg_options.MinimumWidth = 6;
            this.fg_options.Name = "fg_options";
            this.fg_options.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Noformatdate
            // 
            this.Noformatdate.DataPropertyName = "Noformatdate";
            this.Noformatdate.HeaderText = "Noformatdate";
            this.Noformatdate.MinimumWidth = 6;
            this.Noformatdate.Name = "Noformatdate";
            this.Noformatdate.ReadOnly = true;
            // 
            // FGDate
            // 
            this.FGDate.DataPropertyName = "FGDate";
            this.FGDate.HeaderText = "Prod Date";
            this.FGDate.MinimumWidth = 6;
            this.FGDate.Name = "FGDate";
            this.FGDate.ReadOnly = true;
            // 
            // transaction_date
            // 
            this.transaction_date.DataPropertyName = "transaction_date";
            this.transaction_date.HeaderText = "Transaction Date";
            this.transaction_date.MinimumWidth = 6;
            this.transaction_date.Name = "transaction_date";
            this.transaction_date.ReadOnly = true;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "Added By";
            this.added_by.MinimumWidth = 6;
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            // 
            // transaction_type
            // 
            this.transaction_type.DataPropertyName = "transaction_type";
            this.transaction_type.HeaderText = "Transaction Type";
            this.transaction_type.MinimumWidth = 6;
            this.transaction_type.Name = "transaction_type";
            this.transaction_type.ReadOnly = true;
            // 
            // frmFeedCodeTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1179, 554);
            this.Controls.Add(this.dgv_table);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblqty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.dgv_feedcode);
            this.Controls.Add(this.txtFeedCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFeedCodeTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeedCode Transactions";
            this.Load += new System.EventHandler(this.frmFeedCodeTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_feedcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFeedCode;
        private System.Windows.Forms.DataGridView dgv_feedcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feed_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAGS_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BULK_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_RECEIPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BULK_RECEIPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_RECEIPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_ISSUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BULK_ISSUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_ISSUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_MOVEORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn BULK_MOVEORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_MOVEORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRAND_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalIssueMoveorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_INVENTORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_INVENTORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BULK_INVENTORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_adv;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_options;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noformatdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction_type;
    }
}