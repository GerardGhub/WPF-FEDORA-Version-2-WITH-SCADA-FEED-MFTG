namespace WFFDR
{
    partial class frmBulkValueMgmt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBulkValueMgmt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lblidactive = new System.Windows.Forms.Label();
            this.dgvBulkData = new System.Windows.Forms.DataGridView();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtremarks = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtdateadded = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblactive = new System.Windows.Forms.Label();
            this.dgvInactive = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulkData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.lblidactive);
            this.GroupBox3.Controls.Add(this.dgvBulkData);
            this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(7, 138);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(555, 194);
            this.GroupBox3.TabIndex = 512;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Active Data";
            // 
            // lblidactive
            // 
            this.lblidactive.AutoSize = true;
            this.lblidactive.Location = new System.Drawing.Point(112, 0);
            this.lblidactive.Name = "lblidactive";
            this.lblidactive.Size = new System.Drawing.Size(83, 13);
            this.lblidactive.TabIndex = 485;
            this.lblidactive.Text = "Date Added :";
            // 
            // dgvBulkData
            // 
            this.dgvBulkData.AllowUserToAddRows = false;
            this.dgvBulkData.AllowUserToDeleteRows = false;
            this.dgvBulkData.AllowUserToResizeColumns = false;
            this.dgvBulkData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvBulkData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBulkData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBulkData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBulkData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBulkData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBulkData.ColumnHeadersHeight = 30;
            this.dgvBulkData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBulkData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qty,
            this.remarks,
            this.added_by,
            this.date_added});
            this.dgvBulkData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvBulkData.EnableHeadersVisualStyles = false;
            this.dgvBulkData.GridColor = System.Drawing.SystemColors.Control;
            this.dgvBulkData.Location = new System.Drawing.Point(6, 20);
            this.dgvBulkData.MultiSelect = false;
            this.dgvBulkData.Name = "dgvBulkData";
            this.dgvBulkData.ReadOnly = true;
            this.dgvBulkData.RowHeadersWidth = 50;
            this.dgvBulkData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvBulkData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBulkData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBulkData.Size = new System.Drawing.Size(538, 166);
            this.dgvBulkData.TabIndex = 435;
            this.dgvBulkData.CurrentCellChanged += new System.EventHandler(this.dgvBulkData_CurrentCellChanged);
            this.dgvBulkData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBulkData_RowPostPaint);
            this.dgvBulkData.DoubleClick += new System.EventHandler(this.dgvBulkData_DoubleClick);
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "QUANTITY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 91;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 88;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ADDED BY";
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            this.added_by.Width = 93;
            // 
            // date_added
            // 
            this.date_added.DataPropertyName = "date_added";
            this.date_added.HeaderText = "DATE ADDED";
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            this.date_added.Width = 108;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtremarks);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.txtdateadded);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtqty);
            this.groupBox1.Controls.Add(this.txtaddedby);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 129);
            this.groupBox1.TabIndex = 513;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bulk Information";
            // 
            // txtremarks
            // 
            this.txtremarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtremarks.FormattingEnabled = true;
            this.txtremarks.Items.AddRange(new object[] {
            "Special Quantity",
            "Standard"});
            this.txtremarks.Location = new System.Drawing.Point(99, 51);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(145, 21);
            this.txtremarks.TabIndex = 484;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(457, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 468;
            this.btnSave.Text = "&Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 460;
            this.label1.Text = "Date Added :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Quantity :";
            // 
            // txtdateadded
            // 
            this.txtdateadded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdateadded.Enabled = false;
            this.txtdateadded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateadded.Location = new System.Drawing.Point(388, 52);
            this.txtdateadded.Name = "txtdateadded";
            this.txtdateadded.Size = new System.Drawing.Size(145, 20);
            this.txtdateadded.TabIndex = 463;
            this.txtdateadded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Added by :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Remarks :";
            // 
            // txtqty
            // 
            this.txtqty.BackColor = System.Drawing.Color.Yellow;
            this.txtqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqty.Location = new System.Drawing.Point(99, 23);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(145, 20);
            this.txtqty.TabIndex = 450;
            this.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaddedby
            // 
            this.txtaddedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddedby.Location = new System.Drawing.Point(388, 23);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(145, 20);
            this.txtaddedby.TabIndex = 459;
            this.txtaddedby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblactive);
            this.groupBox2.Controls.Add(this.dgvInactive);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 194);
            this.groupBox2.TabIndex = 514;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INActive Data";
            // 
            // lblactive
            // 
            this.lblactive.AutoSize = true;
            this.lblactive.Location = new System.Drawing.Point(112, 2);
            this.lblactive.Name = "lblactive";
            this.lblactive.Size = new System.Drawing.Size(83, 13);
            this.lblactive.TabIndex = 486;
            this.lblactive.Text = "Date Added :";
            // 
            // dgvInactive
            // 
            this.dgvInactive.AllowUserToAddRows = false;
            this.dgvInactive.AllowUserToDeleteRows = false;
            this.dgvInactive.AllowUserToResizeColumns = false;
            this.dgvInactive.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvInactive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInactive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInactive.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInactive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInactive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInactive.ColumnHeadersHeight = 30;
            this.dgvInactive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInactive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvInactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvInactive.EnableHeadersVisualStyles = false;
            this.dgvInactive.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInactive.Location = new System.Drawing.Point(8, 18);
            this.dgvInactive.MultiSelect = false;
            this.dgvInactive.Name = "dgvInactive";
            this.dgvInactive.ReadOnly = true;
            this.dgvInactive.RowHeadersWidth = 50;
            this.dgvInactive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvInactive.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInactive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInactive.Size = new System.Drawing.Size(538, 166);
            this.dgvInactive.TabIndex = 436;
            this.dgvInactive.CurrentCellChanged += new System.EventHandler(this.dgvInactive_CurrentCellChanged);
            this.dgvInactive.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvInactive_RowPostPaint);
            this.dgvInactive.DoubleClick += new System.EventHandler(this.dgvInactive_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn1.HeaderText = "QUANTITY";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 91;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "remarks";
            this.dataGridViewTextBoxColumn2.HeaderText = "REMARKS";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 88;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "added_by";
            this.dataGridViewTextBoxColumn3.HeaderText = "ADDED BY";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 93;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "date_added";
            this.dataGridViewTextBoxColumn4.HeaderText = "DATE ADDED";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 108;
            // 
            // frmBulkValueMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(573, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBulkValueMgmt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk  Data Management";
            this.Load += new System.EventHandler(this.frmBulkValueMgmt_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulkData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.DataGridView dgvBulkData;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtdateadded;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtaddedby;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.ComboBox txtremarks;
        internal System.Windows.Forms.Label lblidactive;
        private System.Windows.Forms.DataGridView dgvInactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        internal System.Windows.Forms.Label lblactive;
    }
}