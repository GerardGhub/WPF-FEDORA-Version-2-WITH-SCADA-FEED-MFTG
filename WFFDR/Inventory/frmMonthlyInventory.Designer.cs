
namespace WFFDR
{
    partial class frmMonthlyInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonthlyInventory));
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
            this.report = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACRESERVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_quantity_raw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_production = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active_qty_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_USED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVEMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACRO_RECIPE_NOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrecord = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblitemcode = new System.Windows.Forms.Label();
            this.btnShowData = new System.Windows.Forms.Button();
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
            this.dgv_table.ColumnHeadersHeight = 30;
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
            this.report,
            this.qty_repack,
            this.MACRESERVED,
            this.total_quantity_raw,
            this.qty_production,
            this.active_qty_repack,
            this.classification,
            this.LAST_USED,
            this.MOVEMENT,
            this.MACRO_RECIPE_NOT});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(8, 10);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 40;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(752, 562);
            this.dgv_table.TabIndex = 35;
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
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
            this.ONHAND.HeaderText = "STOCK ON HAND";
            this.ONHAND.Name = "ONHAND";
            this.ONHAND.ReadOnly = true;
            this.ONHAND.Width = 121;
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
            this.RECEIVING.Visible = false;
            this.RECEIVING.Width = 90;
            // 
            // ISSUE
            // 
            this.ISSUE.DataPropertyName = "ISSUE";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.ISSUE.DefaultCellStyle = dataGridViewCellStyle7;
            this.ISSUE.HeaderText = "RECEIPT";
            this.ISSUE.Name = "ISSUE";
            this.ISSUE.ReadOnly = true;
            this.ISSUE.Visible = false;
            this.ISSUE.Width = 78;
            // 
            // OUTING
            // 
            this.OUTING.DataPropertyName = "OUTING";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.OUTING.DefaultCellStyle = dataGridViewCellStyle8;
            this.OUTING.HeaderText = "ISSUE";
            this.OUTING.Name = "OUTING";
            this.OUTING.ReadOnly = true;
            this.OUTING.Visible = false;
            this.OUTING.Width = 64;
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
            this.TOTAL_RECEIVED.Visible = false;
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
            this.qty_repack_available.Visible = false;
            this.qty_repack_available.Width = 121;
            // 
            // report
            // 
            this.report.DataPropertyName = "report";
            this.report.HeaderText = "REPORT";
            this.report.Name = "report";
            this.report.ReadOnly = true;
            this.report.Visible = false;
            this.report.Width = 77;
            // 
            // qty_repack
            // 
            this.qty_repack.DataPropertyName = "qty_repack";
            this.qty_repack.HeaderText = "TOTAL REPACK";
            this.qty_repack.MinimumWidth = 12;
            this.qty_repack.Name = "qty_repack";
            this.qty_repack.ReadOnly = true;
            this.qty_repack.Visible = false;
            this.qty_repack.Width = 113;
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
            this.qty_production.Visible = false;
            this.qty_production.Width = 125;
            // 
            // active_qty_repack
            // 
            this.active_qty_repack.DataPropertyName = "active_qty_repack";
            this.active_qty_repack.HeaderText = "GRAND TOTAL";
            this.active_qty_repack.Name = "active_qty_repack";
            this.active_qty_repack.ReadOnly = true;
            this.active_qty_repack.Width = 109;
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
            // LAST_USED
            // 
            this.LAST_USED.DataPropertyName = "LAST_USED";
            this.LAST_USED.HeaderText = "LAST_USED";
            this.LAST_USED.Name = "LAST_USED";
            this.LAST_USED.ReadOnly = true;
            this.LAST_USED.Width = 95;
            // 
            // MOVEMENT
            // 
            this.MOVEMENT.DataPropertyName = "MOVEMENT";
            this.MOVEMENT.HeaderText = "DAYS OF MOVEMENT";
            this.MOVEMENT.Name = "MOVEMENT";
            this.MOVEMENT.ReadOnly = true;
            this.MOVEMENT.Width = 143;
            // 
            // MACRO_RECIPE_NOT
            // 
            this.MACRO_RECIPE_NOT.DataPropertyName = "MACRO_RECIPE_NOT";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.MACRO_RECIPE_NOT.DefaultCellStyle = dataGridViewCellStyle12;
            this.MACRO_RECIPE_NOT.HeaderText = "QTY FOR REPACKING";
            this.MACRO_RECIPE_NOT.Name = "MACRO_RECIPE_NOT";
            this.MACRO_RECIPE_NOT.ReadOnly = true;
            this.MACRO_RECIPE_NOT.Width = 144;
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(107, 591);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(14, 15);
            this.lblrecord.TabIndex = 406;
            this.lblrecord.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 15);
            this.label10.TabIndex = 405;
            this.label10.Text = "Total Records :";
            // 
            // lblitemcode
            // 
            this.lblitemcode.AutoSize = true;
            this.lblitemcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblitemcode.Location = new System.Drawing.Point(230, 591);
            this.lblitemcode.Name = "lblitemcode";
            this.lblitemcode.Size = new System.Drawing.Size(14, 15);
            this.lblitemcode.TabIndex = 407;
            this.lblitemcode.Text = "0";
            this.lblitemcode.Visible = false;
            // 
            // btnShowData
            // 
            this.btnShowData.BackColor = System.Drawing.SystemColors.Window;
            this.btnShowData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowData.Image = ((System.Drawing.Image)(resources.GetObject("btnShowData.Image")));
            this.btnShowData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowData.Location = new System.Drawing.Point(667, 578);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(93, 28);
            this.btnShowData.TabIndex = 426;
            this.btnShowData.Text = "&Show Data";
            this.btnShowData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowData.UseVisualStyleBackColor = false;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // frmMonthlyInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(772, 612);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.lblitemcode);
            this.Controls.Add(this.lblrecord);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgv_table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMonthlyInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Inventory WIP Report";
            this.Load += new System.EventHandler(this.frmMonthlyInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_table;
        internal System.Windows.Forms.Label lblrecord;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label lblitemcode;
        protected internal System.Windows.Forms.Button btnShowData;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn report;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACRESERVED;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_quantity_raw;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_production;
        private System.Windows.Forms.DataGridViewTextBoxColumn active_qty_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn classification;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_USED;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOVEMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACRO_RECIPE_NOT;
    }
}