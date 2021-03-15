
namespace WFFDR
{
    partial class frmNearlyExpired
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNearlyExpired));
            this.lblrecords3 = new System.Windows.Forms.Label();
            this.dgv_all = new System.Windows.Forms.DataGridView();
            this.r_item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_item_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_count_good = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_expiry_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAYSEXPIRED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_receiving_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReprint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).BeginInit();
            this.SuspendLayout();
            // 
            // lblrecords3
            // 
            this.lblrecords3.AutoSize = true;
            this.lblrecords3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords3.ForeColor = System.Drawing.Color.Black;
            this.lblrecords3.Location = new System.Drawing.Point(14, 3);
            this.lblrecords3.Name = "lblrecords3";
            this.lblrecords3.Size = new System.Drawing.Size(24, 25);
            this.lblrecords3.TabIndex = 38;
            this.lblrecords3.Text = "0";
            // 
            // dgv_all
            // 
            this.dgv_all.AllowUserToAddRows = false;
            this.dgv_all.AllowUserToDeleteRows = false;
            this.dgv_all.AllowUserToResizeColumns = false;
            this.dgv_all.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_all.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_all.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_all.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_all.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_all.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_all.ColumnHeadersHeight = 30;
            this.dgv_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.r_item_code,
            this.r_item_description,
            this.r_item_category,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.r_quantity,
            this.actual_count_good,
            this.dataGridViewTextBoxColumn14,
            this.r_expiry_date,
            this.dataGridViewTextBoxColumn10,
            this.DAYSEXPIRED,
            this.transaction_type,
            this.r_receiving_by});
            this.dgv_all.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_all.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_all.EnableHeadersVisualStyles = false;
            this.dgv_all.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_all.Location = new System.Drawing.Point(0, 0);
            this.dgv_all.MultiSelect = false;
            this.dgv_all.Name = "dgv_all";
            this.dgv_all.ReadOnly = true;
            this.dgv_all.RowHeadersWidth = 55;
            this.dgv_all.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_all.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_all.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_all.Size = new System.Drawing.Size(996, 460);
            this.dgv_all.TabIndex = 39;
            this.dgv_all.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_all_RowPostPaint);
            // 
            // r_item_code
            // 
            this.r_item_code.DataPropertyName = "r_item_code";
            this.r_item_code.Frozen = true;
            this.r_item_code.HeaderText = "ITEM CODE";
            this.r_item_code.MinimumWidth = 12;
            this.r_item_code.Name = "r_item_code";
            this.r_item_code.ReadOnly = true;
            this.r_item_code.Width = 91;
            // 
            // r_item_description
            // 
            this.r_item_description.DataPropertyName = "r_item_description";
            this.r_item_description.Frozen = true;
            this.r_item_description.HeaderText = "DESCRIPTION";
            this.r_item_description.MinimumWidth = 12;
            this.r_item_description.Name = "r_item_description";
            this.r_item_description.ReadOnly = true;
            this.r_item_description.Width = 105;
            // 
            // r_item_category
            // 
            this.r_item_category.DataPropertyName = "r_item_category";
            this.r_item_category.Frozen = true;
            this.r_item_category.HeaderText = "CATEGORY";
            this.r_item_category.MinimumWidth = 12;
            this.r_item_category.Name = "r_item_category";
            this.r_item_category.ReadOnly = true;
            this.r_item_category.Width = 91;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "qty_repack_available";
            this.dataGridViewTextBoxColumn11.HeaderText = "STOCK ON HAND";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 121;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "uniquedate";
            this.dataGridViewTextBoxColumn12.HeaderText = "RECEIVED DATE";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 118;
            // 
            // r_quantity
            // 
            this.r_quantity.DataPropertyName = "r_quantity";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.r_quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.r_quantity.HeaderText = "QTY";
            this.r_quantity.Name = "r_quantity";
            this.r_quantity.ReadOnly = true;
            this.r_quantity.Width = 54;
            // 
            // actual_count_good
            // 
            this.actual_count_good.DataPropertyName = "actual_count_good";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.actual_count_good.DefaultCellStyle = dataGridViewCellStyle4;
            this.actual_count_good.HeaderText = "ACTUAL";
            this.actual_count_good.MinimumWidth = 12;
            this.actual_count_good.Name = "actual_count_good";
            this.actual_count_good.ReadOnly = true;
            this.actual_count_good.Visible = false;
            this.actual_count_good.Width = 74;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "actual_count_reject";
            this.dataGridViewTextBoxColumn14.HeaderText = "REJECT";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 73;
            // 
            // r_expiry_date
            // 
            this.r_expiry_date.DataPropertyName = "r_expiry_date";
            this.r_expiry_date.HeaderText = "EXPIRY DATE";
            this.r_expiry_date.Name = "r_expiry_date";
            this.r_expiry_date.ReadOnly = true;
            this.r_expiry_date.Width = 103;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "r_supplier";
            this.dataGridViewTextBoxColumn10.HeaderText = "SUPPLIER";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 85;
            // 
            // DAYSEXPIRED
            // 
            this.DAYSEXPIRED.DataPropertyName = "DAYSEXPIRED";
            this.DAYSEXPIRED.HeaderText = "AGING";
            this.DAYSEXPIRED.Name = "DAYSEXPIRED";
            this.DAYSEXPIRED.ReadOnly = true;
            this.DAYSEXPIRED.Width = 66;
            // 
            // transaction_type
            // 
            this.transaction_type.DataPropertyName = "transaction_type";
            this.transaction_type.HeaderText = "TRANSACTION TYPE";
            this.transaction_type.Name = "transaction_type";
            this.transaction_type.ReadOnly = true;
            this.transaction_type.Width = 140;
            // 
            // r_receiving_by
            // 
            this.r_receiving_by.DataPropertyName = "r_receiving_by";
            this.r_receiving_by.HeaderText = "RECEIVED BY";
            this.r_receiving_by.Name = "r_receiving_by";
            this.r_receiving_by.ReadOnly = true;
            this.r_receiving_by.Width = 103;
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.SystemColors.Window;
            this.btnReprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.Location = new System.Drawing.Point(907, 466);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(82, 28);
            this.btnReprint.TabIndex = 694;
            this.btnReprint.Text = "&Print";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // frmNearlyExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(996, 497);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.lblrecords3);
            this.Controls.Add(this.dgv_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNearlyExpired";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw Materials Nearly Expired";
            this.Load += new System.EventHandler(this.frmNearlyExpired_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_all)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblrecords3;
        private System.Windows.Forms.DataGridView dgv_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_item_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_count_good;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_expiry_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAYSEXPIRED;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_receiving_by;
        internal System.Windows.Forms.Button btnReprint;
    }
}