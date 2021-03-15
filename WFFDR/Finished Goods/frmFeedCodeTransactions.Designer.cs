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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeedCodeTransactions));
            this.txtFeedCode = new System.Windows.Forms.Label();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bags_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bagorbin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BagsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BulkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.AutoSize = true;
            this.txtFeedCode.Location = new System.Drawing.Point(26, 9);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(35, 13);
            this.txtFeedCode.TabIndex = 0;
            this.txtFeedCode.Text = "label1";
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
            this.dgv_table.ColumnHeadersHeight = 35;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.bags_int,
            this.batch_int,
            this.proddate,
            this.feed_type,
            this.bagorbin,
            this.prod_id,
            this.BagsCount,
            this.BulkCount,
            this.GrandTotal});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(0, 0);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 55;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(950, 450);
            this.dgv_table.TabIndex = 35;
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "p_feed_code";
            this.Column1.HeaderText = "FEED CODE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // bags_int
            // 
            this.bags_int.DataPropertyName = "bags_int";
            this.bags_int.HeaderText = "BAGS";
            this.bags_int.Name = "bags_int";
            this.bags_int.ReadOnly = true;
            // 
            // batch_int
            // 
            this.batch_int.DataPropertyName = "batch_int";
            this.batch_int.HeaderText = "BATCH";
            this.batch_int.Name = "batch_int";
            this.batch_int.ReadOnly = true;
            // 
            // proddate
            // 
            this.proddate.DataPropertyName = "proddate";
            this.proddate.HeaderText = "PROD DATE";
            this.proddate.Name = "proddate";
            this.proddate.ReadOnly = true;
            // 
            // feed_type
            // 
            this.feed_type.DataPropertyName = "feed_type";
            this.feed_type.HeaderText = "FEED TYPE";
            this.feed_type.Name = "feed_type";
            this.feed_type.ReadOnly = true;
            // 
            // bagorbin
            // 
            this.bagorbin.DataPropertyName = "bagorbin";
            this.bagorbin.HeaderText = "STATUS";
            this.bagorbin.Name = "bagorbin";
            this.bagorbin.ReadOnly = true;
            // 
            // prod_id
            // 
            this.prod_id.DataPropertyName = "prod_id";
            this.prod_id.HeaderText = "ID";
            this.prod_id.Name = "prod_id";
            this.prod_id.ReadOnly = true;
            // 
            // BagsCount
            // 
            this.BagsCount.DataPropertyName = "BagsCount";
            this.BagsCount.HeaderText = "BAGS";
            this.BagsCount.Name = "BagsCount";
            this.BagsCount.ReadOnly = true;
            // 
            // BulkCount
            // 
            this.BulkCount.DataPropertyName = "BulkCount";
            this.BulkCount.HeaderText = "BULK";
            this.BulkCount.Name = "BulkCount";
            this.BulkCount.ReadOnly = true;
            // 
            // GrandTotal
            // 
            this.GrandTotal.DataPropertyName = "GrandTotal";
            this.GrandTotal.HeaderText = "GRAND TOTAL";
            this.GrandTotal.Name = "GrandTotal";
            this.GrandTotal.ReadOnly = true;
            // 
            // frmFeedCodeTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(950, 450);
            this.Controls.Add(this.dgv_table);
            this.Controls.Add(this.txtFeedCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFeedCodeTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeedCode Transactions";
            this.Load += new System.EventHandler(this.frmFeedCodeTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFeedCode;
        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bags_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn bagorbin;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BulkCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrandTotal;
    }
}