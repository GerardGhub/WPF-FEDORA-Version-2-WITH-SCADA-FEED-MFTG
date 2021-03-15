namespace WFFDR
{
    partial class fmProductionHours
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmProductionHours));
            this.dgvProdToday = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Production_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.micro_repacking_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macro_repacking_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basemixed_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.production_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.lblcountprod3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdToday)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdToday
            // 
            this.dgvProdToday.AllowUserToAddRows = false;
            this.dgvProdToday.AllowUserToDeleteRows = false;
            this.dgvProdToday.AllowUserToResizeColumns = false;
            this.dgvProdToday.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvProdToday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdToday.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProdToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdToday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdToday.ColumnHeadersHeight = 40;
            this.dgvProdToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProdToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Emp_Number,
            this.Department,
            this.TotalPack,
            this.Production_Date,
            this.Column1,
            this.micro_repacking_time,
            this.macro_repacking_time,
            this.basemixed_time,
            this.production_time,
            this.fg_time});
            this.dgvProdToday.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdToday.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProdToday.EnableHeadersVisualStyles = false;
            this.dgvProdToday.GridColor = System.Drawing.SystemColors.Control;
            this.dgvProdToday.Location = new System.Drawing.Point(6, 47);
            this.dgvProdToday.MultiSelect = false;
            this.dgvProdToday.Name = "dgvProdToday";
            this.dgvProdToday.ReadOnly = true;
            this.dgvProdToday.RowHeadersWidth = 50;
            this.dgvProdToday.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvProdToday.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdToday.RowTemplate.Height = 25;
            this.dgvProdToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdToday.Size = new System.Drawing.Size(959, 461);
            this.dgvProdToday.TabIndex = 355;
            this.dgvProdToday.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvProdToday_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Emp_Number
            // 
            this.Emp_Number.DataPropertyName = "Emp_Number";
            this.Emp_Number.HeaderText = "FEED CODE";
            this.Emp_Number.MinimumWidth = 12;
            this.Emp_Number.Name = "Emp_Number";
            this.Emp_Number.ReadOnly = true;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "BAGS";
            this.Department.MinimumWidth = 12;
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            // 
            // TotalPack
            // 
            this.TotalPack.DataPropertyName = "TotalPack";
            this.TotalPack.HeaderText = "BATCH";
            this.TotalPack.MinimumWidth = 12;
            this.TotalPack.Name = "TotalPack";
            this.TotalPack.ReadOnly = true;
            // 
            // Production_Date
            // 
            this.Production_Date.DataPropertyName = "Production_Date";
            this.Production_Date.HeaderText = "PROD DATE";
            this.Production_Date.MinimumWidth = 12;
            this.Production_Date.Name = "Production_Date";
            this.Production_Date.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "plannerAndapprover";
            this.Column1.HeaderText = "PLANNING APPROVAL";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // micro_repacking_time
            // 
            this.micro_repacking_time.DataPropertyName = "micro_repacking_time";
            this.micro_repacking_time.HeaderText = "MICRO";
            this.micro_repacking_time.Name = "micro_repacking_time";
            this.micro_repacking_time.ReadOnly = true;
            // 
            // macro_repacking_time
            // 
            this.macro_repacking_time.DataPropertyName = "macro_repacking_time";
            this.macro_repacking_time.HeaderText = "MACRO";
            this.macro_repacking_time.Name = "macro_repacking_time";
            this.macro_repacking_time.ReadOnly = true;
            // 
            // basemixed_time
            // 
            this.basemixed_time.DataPropertyName = "basemixed_time";
            this.basemixed_time.HeaderText = "BASEMIXED";
            this.basemixed_time.Name = "basemixed_time";
            this.basemixed_time.ReadOnly = true;
            // 
            // production_time
            // 
            this.production_time.DataPropertyName = "production_time";
            this.production_time.HeaderText = "PRODUCTION";
            this.production_time.Name = "production_time";
            this.production_time.ReadOnly = true;
            // 
            // fg_time
            // 
            this.fg_time.DataPropertyName = "fg_time";
            this.fg_time.HeaderText = "FG";
            this.fg_time.Name = "fg_time";
            this.fg_time.ReadOnly = true;
            // 
            // dtpFilter
            // 
            this.dtpFilter.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.CustomFormat = "M/d/yyyy";
            this.dtpFilter.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilter.Location = new System.Drawing.Point(794, 9);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(169, 32);
            this.dtpFilter.TabIndex = 437;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 29);
            this.label13.TabIndex = 438;
            this.label13.Text = "FM Production Hours";
            // 
            // lblcountprod3
            // 
            this.lblcountprod3.AutoSize = true;
            this.lblcountprod3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountprod3.Location = new System.Drawing.Point(665, 28);
            this.lblcountprod3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblcountprod3.Name = "lblcountprod3";
            this.lblcountprod3.Size = new System.Drawing.Size(70, 15);
            this.lblcountprod3.TabIndex = 440;
            this.lblcountprod3.Text = "3 days prod";
            this.lblcountprod3.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(649, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 439;
            this.label11.Text = "TOTAL PRODUCTION";
            this.label11.Visible = false;
            // 
            // fmProductionHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(975, 514);
            this.Controls.Add(this.lblcountprod3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpFilter);
            this.Controls.Add(this.dgvProdToday);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmProductionHours";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feed Mill Production Hours";
            this.Load += new System.EventHandler(this.fmProductionHours_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdToday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdToday;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblcountprod3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Production_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn micro_repacking_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn macro_repacking_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn basemixed_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn production_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_time;
    }
}