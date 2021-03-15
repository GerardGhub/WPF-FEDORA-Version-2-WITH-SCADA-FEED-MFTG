
namespace WFFDR
{
    partial class frmInactiveRawmaterials
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInactiveRawmaterials));
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ONHAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESERVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACREPACK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIVING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUTING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_RECEIVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buffer_of_stocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_repack_available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACRESERVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_quantity_raw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_production = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active_qty_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtItemAddedBy = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
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
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.item_code,
            this.item_description,
            this.Category,
            this.item_group,
            this.ONHAND,
            this.RESERVED,
            this.MACREPACK,
            this.RECEIVING,
            this.ISSUE,
            this.OUTING,
            this.TOTAL_RECEIVED,
            this.price,
            this.buffer_of_stocks,
            this.qty_repack_available,
            this.qty_repack,
            this.MACRESERVED,
            this.total_quantity_raw,
            this.qty_production,
            this.active_qty_repack,
            this.classification});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(0, 0);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 55;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(934, 497);
            this.dgv_table.TabIndex = 35;
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            this.dgv_table.DoubleClick += new System.EventHandler(this.dgv_table_DoubleClick);
            // 
            // item_code
            // 
            this.item_code.DataPropertyName = "item_code";
            this.item_code.Frozen = true;
            this.item_code.HeaderText = "ITEM_CODE";
            this.item_code.MinimumWidth = 12;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            this.item_code.Width = 94;
            // 
            // item_description
            // 
            this.item_description.DataPropertyName = "item_description";
            this.item_description.Frozen = true;
            this.item_description.HeaderText = "DESCRIPTION";
            this.item_description.MinimumWidth = 12;
            this.item_description.Name = "item_description";
            this.item_description.ReadOnly = true;
            this.item_description.Width = 105;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "CATEGORY";
            this.Category.MinimumWidth = 12;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 91;
            // 
            // item_group
            // 
            this.item_group.DataPropertyName = "item_group";
            this.item_group.HeaderText = "GROUP";
            this.item_group.MinimumWidth = 12;
            this.item_group.Name = "item_group";
            this.item_group.ReadOnly = true;
            this.item_group.Width = 71;
            // 
            // ONHAND
            // 
            this.ONHAND.DataPropertyName = "ONHAND";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ONHAND.DefaultCellStyle = dataGridViewCellStyle3;
            this.ONHAND.HeaderText = "ONHAND";
            this.ONHAND.Name = "ONHAND";
            this.ONHAND.ReadOnly = true;
            this.ONHAND.Width = 79;
            // 
            // RESERVED
            // 
            this.RESERVED.DataPropertyName = "RESERVED";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.RESERVED.DefaultCellStyle = dataGridViewCellStyle4;
            this.RESERVED.HeaderText = "RESERVED";
            this.RESERVED.Name = "RESERVED";
            this.RESERVED.ReadOnly = true;
            this.RESERVED.Width = 91;
            // 
            // MACREPACK
            // 
            this.MACREPACK.DataPropertyName = "MACREPACK";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.MACREPACK.DefaultCellStyle = dataGridViewCellStyle5;
            this.MACREPACK.HeaderText = "REPACK";
            this.MACREPACK.Name = "MACREPACK";
            this.MACREPACK.ReadOnly = true;
            this.MACREPACK.Width = 75;
            // 
            // RECEIVING
            // 
            this.RECEIVING.DataPropertyName = "RECEIVING";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.RECEIVING.DefaultCellStyle = dataGridViewCellStyle6;
            this.RECEIVING.HeaderText = "RECEIVING";
            this.RECEIVING.Name = "RECEIVING";
            this.RECEIVING.ReadOnly = true;
            this.RECEIVING.Width = 90;
            // 
            // ISSUE
            // 
            this.ISSUE.DataPropertyName = "ISSUE";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.ISSUE.DefaultCellStyle = dataGridViewCellStyle7;
            this.ISSUE.HeaderText = "ISSUE";
            this.ISSUE.Name = "ISSUE";
            this.ISSUE.ReadOnly = true;
            this.ISSUE.Width = 64;
            // 
            // OUTING
            // 
            this.OUTING.DataPropertyName = "OUTING";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.OUTING.DefaultCellStyle = dataGridViewCellStyle8;
            this.OUTING.HeaderText = "OUTING";
            this.OUTING.Name = "OUTING";
            this.OUTING.ReadOnly = true;
            this.OUTING.Width = 74;
            // 
            // TOTAL_RECEIVED
            // 
            this.TOTAL_RECEIVED.DataPropertyName = "TOTAL_RECEIVED";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.TOTAL_RECEIVED.DefaultCellStyle = dataGridViewCellStyle9;
            this.TOTAL_RECEIVED.HeaderText = "TOTAL_RECEIVED";
            this.TOTAL_RECEIVED.Name = "TOTAL_RECEIVED";
            this.TOTAL_RECEIVED.ReadOnly = true;
            this.TOTAL_RECEIVED.Width = 127;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "PRICE";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 64;
            // 
            // buffer_of_stocks
            // 
            this.buffer_of_stocks.DataPropertyName = "buffer_of_stocks";
            this.buffer_of_stocks.HeaderText = "BUFFER_STOCKS";
            this.buffer_of_stocks.Name = "buffer_of_stocks";
            this.buffer_of_stocks.ReadOnly = true;
            this.buffer_of_stocks.Width = 123;
            // 
            // qty_repack_available
            // 
            this.qty_repack_available.DataPropertyName = "qty_repack_available";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.qty_repack_available.DefaultCellStyle = dataGridViewCellStyle10;
            this.qty_repack_available.HeaderText = "STOCK ON HAND";
            this.qty_repack_available.MinimumWidth = 12;
            this.qty_repack_available.Name = "qty_repack_available";
            this.qty_repack_available.ReadOnly = true;
            this.qty_repack_available.Width = 83;
            // 
            // qty_repack
            // 
            this.qty_repack.DataPropertyName = "qty_repack";
            this.qty_repack.HeaderText = "TOTAL REPACK";
            this.qty_repack.MinimumWidth = 12;
            this.qty_repack.Name = "qty_repack";
            this.qty_repack.ReadOnly = true;
            this.qty_repack.Width = 104;
            // 
            // MACRESERVED
            // 
            this.MACRESERVED.DataPropertyName = "MACRESERVED";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.MACRESERVED.DefaultCellStyle = dataGridViewCellStyle11;
            this.MACRESERVED.HeaderText = "RECIPE";
            this.MACRESERVED.Name = "MACRESERVED";
            this.MACRESERVED.ReadOnly = true;
            this.MACRESERVED.Width = 71;
            // 
            // total_quantity_raw
            // 
            this.total_quantity_raw.DataPropertyName = "total_quantity_raw";
            this.total_quantity_raw.HeaderText = "QUANTITY";
            this.total_quantity_raw.MinimumWidth = 12;
            this.total_quantity_raw.Name = "total_quantity_raw";
            this.total_quantity_raw.ReadOnly = true;
            this.total_quantity_raw.Visible = false;
            this.total_quantity_raw.Width = 87;
            // 
            // qty_production
            // 
            this.qty_production.DataPropertyName = "qty_production";
            this.qty_production.HeaderText = "RESERVED PROD";
            this.qty_production.MinimumWidth = 12;
            this.qty_production.Name = "qty_production";
            this.qty_production.ReadOnly = true;
            this.qty_production.Width = 114;
            // 
            // active_qty_repack
            // 
            this.active_qty_repack.DataPropertyName = "active_qty_repack";
            this.active_qty_repack.HeaderText = "GRAND TOTAL";
            this.active_qty_repack.Name = "active_qty_repack";
            this.active_qty_repack.ReadOnly = true;
            // 
            // classification
            // 
            this.classification.DataPropertyName = "classification";
            this.classification.HeaderText = "classification";
            this.classification.Name = "classification";
            this.classification.ReadOnly = true;
            this.classification.Visible = false;
            this.classification.Width = 92;
            // 
            // txtItemAddedBy
            // 
            this.txtItemAddedBy.BackColor = System.Drawing.Color.White;
            this.txtItemAddedBy.Location = new System.Drawing.Point(385, 204);
            this.txtItemAddedBy.Name = "txtItemAddedBy";
            this.txtItemAddedBy.Size = new System.Drawing.Size(165, 20);
            this.txtItemAddedBy.TabIndex = 350;
            this.txtItemAddedBy.Visible = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.Location = new System.Drawing.Point(385, 272);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(165, 20);
            this.txtItemCode.TabIndex = 349;
            this.txtItemCode.Visible = false;
            // 
            // frmInactiveRawmaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 497);
            this.Controls.Add(this.txtItemAddedBy);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.dgv_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInactiveRawmaterials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw Materials inactive";
            this.Load += new System.EventHandler(this.frmInactiveRawmaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn ONHAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESERVED;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACREPACK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIVING;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUTING;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_RECEIVED;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn buffer_of_stocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_repack_available;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACRESERVED;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_quantity_raw;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_production;
        private System.Windows.Forms.DataGridViewTextBoxColumn active_qty_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn classification;
        internal System.Windows.Forms.TextBox txtItemAddedBy;
        internal System.Windows.Forms.TextBox txtItemCode;
    }
}