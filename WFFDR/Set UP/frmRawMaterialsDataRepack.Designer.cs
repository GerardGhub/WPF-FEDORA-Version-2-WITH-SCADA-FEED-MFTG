namespace WFFDR
{
    partial class frmRawMaterialsDataRepack
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRawMaterialsDataRepack));
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdFedoraModules = new System.Windows.Forms.ComboBox();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.lblrecords = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblstock = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvProdPlan = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.repack_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.production_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_id_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uniquedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdPlan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFilter
            // 
            this.dtpFilter.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.CustomFormat = "M/d/yyyy";
            this.dtpFilter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilter.Location = new System.Drawing.Point(217, 37);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(135, 23);
            this.dtpFilter.TabIndex = 453;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            this.dtpFilter.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFilter_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(247, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 452;
            this.label9.Text = "FROM ";
            // 
            // cmdFedoraModules
            // 
            this.cmdFedoraModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdFedoraModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFedoraModules.FormattingEnabled = true;
            this.cmdFedoraModules.Items.AddRange(new object[] {
            "Repacking Date",
            "Production Date",
            "Production Plan"});
            this.cmdFedoraModules.Location = new System.Drawing.Point(6, 36);
            this.cmdFedoraModules.Name = "cmdFedoraModules";
            this.cmdFedoraModules.Size = new System.Drawing.Size(171, 24);
            this.cmdFedoraModules.TabIndex = 454;
            this.cmdFedoraModules.SelectedIndexChanged += new System.EventHandler(this.cmdFedoraModules_SelectedIndexChanged);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.repack_id,
            this.production_date,
            this.prod_id_repack,
            this.rp_feed_code,
            this.rp_batch,
            this.rp_item_id,
            this.rp_item_category,
            this.rp_item_code,
            this.rp_item_description,
            this.total_repack,
            this.uniquedate});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.Location = new System.Drawing.Point(6, 20);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApproved.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(820, 322);
            this.dgvApproved.TabIndex = 459;
            this.dgvApproved.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApproved_RowPostPaint);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.ForeColor = System.Drawing.Color.Black;
            this.lblrecords.Location = new System.Drawing.Point(614, 38);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(18, 18);
            this.lblrecords.TabIndex = 460;
            this.lblrecords.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblstock
            // 
            this.lblstock.AutoSize = true;
            this.lblstock.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstock.ForeColor = System.Drawing.Color.Black;
            this.lblstock.Location = new System.Drawing.Point(759, 38);
            this.lblstock.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblstock.Name = "lblstock";
            this.lblstock.Size = new System.Drawing.Size(18, 18);
            this.lblstock.TabIndex = 463;
            this.lblstock.Text = "0";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.dgvProdPlan);
            this.GroupBox3.Controls.Add(this.groupBox2);
            this.GroupBox3.Controls.Add(this.dgvApproved);
            this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(11, 94);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(832, 348);
            this.GroupBox3.TabIndex = 479;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "List of Materials in Micro Warehouse";
            // 
            // dgvProdPlan
            // 
            this.dgvProdPlan.AllowUserToAddRows = false;
            this.dgvProdPlan.AllowUserToDeleteRows = false;
            this.dgvProdPlan.AllowUserToResizeColumns = false;
            this.dgvProdPlan.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvProdPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdPlan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProdPlan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProdPlan.ColumnHeadersHeight = 30;
            this.dgvProdPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProdPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvProdPlan.EnableHeadersVisualStyles = false;
            this.dgvProdPlan.GridColor = System.Drawing.SystemColors.Control;
            this.dgvProdPlan.Location = new System.Drawing.Point(4, 20);
            this.dgvProdPlan.MultiSelect = false;
            this.dgvProdPlan.Name = "dgvProdPlan";
            this.dgvProdPlan.ReadOnly = true;
            this.dgvProdPlan.RowHeadersWidth = 50;
            this.dgvProdPlan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvProdPlan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProdPlan.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvProdPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdPlan.Size = new System.Drawing.Size(820, 322);
            this.dgvProdPlan.TabIndex = 482;
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(185, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 81);
            this.groupBox2.TabIndex = 481;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raw Material Details";
            this.groupBox2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpFilter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdFedoraModules);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblstock);
            this.groupBox1.Controls.Add(this.lblrecords);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 81);
            this.groupBox1.TabIndex = 480;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw Material Details";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.FormattingEnabled = true;
            this.txtItemCode.Items.AddRange(new object[] {
            "Repacking Date",
            "Production Date",
            "Production Plan"});
            this.txtItemCode.Location = new System.Drawing.Point(386, 36);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(160, 24);
            this.txtItemCode.TabIndex = 484;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(710, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 483;
            this.label5.Text = "ACTUAL WEIGHT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(41, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 481;
            this.label8.Text = "GROUP BY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(570, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 482;
            this.label4.Text = "TOTAL RECORDS ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(424, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 481;
            this.label3.Text = "ITEM CODE ";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.Window;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(11, 443);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 28);
            this.btnsave.TabIndex = 323;
            this.btnsave.Text = "&Search";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // repack_id
            // 
            this.repack_id.DataPropertyName = "repack_id";
            this.repack_id.HeaderText = "ID";
            this.repack_id.Name = "repack_id";
            this.repack_id.ReadOnly = true;
            this.repack_id.Visible = false;
            // 
            // production_date
            // 
            this.production_date.DataPropertyName = "production_date";
            this.production_date.HeaderText = "PLAN";
            this.production_date.Name = "production_date";
            this.production_date.ReadOnly = true;
            // 
            // prod_id_repack
            // 
            this.prod_id_repack.DataPropertyName = "prod_id_repack";
            this.prod_id_repack.HeaderText = "PROD ID";
            this.prod_id_repack.Name = "prod_id_repack";
            this.prod_id_repack.ReadOnly = true;
            // 
            // rp_feed_code
            // 
            this.rp_feed_code.DataPropertyName = "rp_feed_code";
            this.rp_feed_code.HeaderText = "FEED CODE";
            this.rp_feed_code.Name = "rp_feed_code";
            this.rp_feed_code.ReadOnly = true;
            // 
            // rp_batch
            // 
            this.rp_batch.DataPropertyName = "rp_batch";
            this.rp_batch.HeaderText = "BATCH";
            this.rp_batch.Name = "rp_batch";
            this.rp_batch.ReadOnly = true;
            // 
            // rp_item_id
            // 
            this.rp_item_id.DataPropertyName = "rp_item_id";
            this.rp_item_id.HeaderText = "ITEM ID";
            this.rp_item_id.Name = "rp_item_id";
            this.rp_item_id.ReadOnly = true;
            this.rp_item_id.Visible = false;
            // 
            // rp_item_category
            // 
            this.rp_item_category.DataPropertyName = "rp_item_category";
            this.rp_item_category.HeaderText = "CATEGORY";
            this.rp_item_category.Name = "rp_item_category";
            this.rp_item_category.ReadOnly = true;
            // 
            // rp_item_code
            // 
            this.rp_item_code.DataPropertyName = "rp_item_code";
            this.rp_item_code.HeaderText = "ITEM CODE";
            this.rp_item_code.Name = "rp_item_code";
            this.rp_item_code.ReadOnly = true;
            // 
            // rp_item_description
            // 
            this.rp_item_description.DataPropertyName = "rp_item_description";
            this.rp_item_description.HeaderText = "DESCRIPTION";
            this.rp_item_description.Name = "rp_item_description";
            this.rp_item_description.ReadOnly = true;
            // 
            // total_repack
            // 
            this.total_repack.DataPropertyName = "total_repack";
            this.total_repack.HeaderText = "QTY";
            this.total_repack.Name = "total_repack";
            this.total_repack.ReadOnly = true;
            // 
            // uniquedate
            // 
            this.uniquedate.DataPropertyName = "uniquedate";
            this.uniquedate.HeaderText = "CREATED_AT";
            this.uniquedate.Name = "uniquedate";
            this.uniquedate.ReadOnly = true;
            // 
            // frmRawMaterialsDataRepack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(855, 473);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRawMaterialsDataRepack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw Materials Data Repack";
            this.Load += new System.EventHandler(this.frmRawMaterialsDataRepack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdPlan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmdFedoraModules;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblstock;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox txtItemCode;
        private System.Windows.Forms.DataGridView dgvProdPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn repack_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn production_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_repack;
        private System.Windows.Forms.DataGridViewTextBoxColumn uniquedate;
    }
}