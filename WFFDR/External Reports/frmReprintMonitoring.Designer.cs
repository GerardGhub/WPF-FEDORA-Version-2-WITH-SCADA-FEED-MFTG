namespace WFFDR
{
    partial class frmReprintMonitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprintMonitoring));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.txtmare = new System.Windows.Forms.TextBox();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtsearchcode = new System.Windows.Forms.TextBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.txtFeedCode = new System.Windows.Forms.TextBox();
            this.labelang = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tracking_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.request_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_stamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrecords = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btngreaterthan);
            this.panel2.Controls.Add(this.txtmare);
            this.panel2.Controls.Add(this.dateTimePicker12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.txtsearchcode);
            this.panel2.Controls.Add(this.metroButton4);
            this.panel2.Controls.Add(this.txtFeedCode);
            this.panel2.Location = new System.Drawing.Point(4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 43);
            this.panel2.TabIndex = 548;
            // 
            // btngreaterthan
            // 
            this.btngreaterthan.BackColor = System.Drawing.Color.Transparent;
            this.btngreaterthan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngreaterthan.BackgroundImage")));
            this.btngreaterthan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngreaterthan.FlatAppearance.BorderSize = 0;
            this.btngreaterthan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngreaterthan.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngreaterthan.ForeColor = System.Drawing.SystemColors.Window;
            this.btngreaterthan.Location = new System.Drawing.Point(677, 1);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(53, 33);
            this.btngreaterthan.TabIndex = 641;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            // 
            // txtmare
            // 
            this.txtmare.Location = new System.Drawing.Point(464, 4);
            this.txtmare.Name = "txtmare";
            this.txtmare.Size = new System.Drawing.Size(122, 20);
            this.txtmare.TabIndex = 50;
            this.txtmare.Visible = false;
            // 
            // dateTimePicker12
            // 
            this.dateTimePicker12.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.CustomFormat = "M/d/yyyy";
            this.dateTimePicker12.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker12.Location = new System.Drawing.Point(738, 2);
            this.dateTimePicker12.Name = "dateTimePicker12";
            this.dateTimePicker12.Size = new System.Drawing.Size(195, 32);
            this.dateTimePicker12.TabIndex = 5;
            this.dateTimePicker12.ValueChanged += new System.EventHandler(this.dateTimePicker12_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(300, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Reprint Logs Monitoring";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(183, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 44;
            this.txtSearch.Visible = false;
            // 
            // txtsearchcode
            // 
            this.txtsearchcode.Location = new System.Drawing.Point(342, 41);
            this.txtsearchcode.Name = "txtsearchcode";
            this.txtsearchcode.Size = new System.Drawing.Size(122, 20);
            this.txtsearchcode.TabIndex = 49;
            this.txtsearchcode.Visible = false;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(611, 35);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(39, 17);
            this.metroButton4.TabIndex = 394;
            this.metroButton4.Text = "Update";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Visible = false;
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.Location = new System.Drawing.Point(460, 30);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(122, 20);
            this.txtFeedCode.TabIndex = 567;
            this.txtFeedCode.Visible = false;
            // 
            // labelang
            // 
            this.labelang.AutoSize = true;
            this.labelang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelang.Location = new System.Drawing.Point(10, 54);
            this.labelang.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelang.Name = "labelang";
            this.labelang.Size = new System.Drawing.Size(80, 13);
            this.labelang.TabIndex = 395;
            this.labelang.Text = "Total Records :";
            this.labelang.Visible = false;
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.ID,
            this.activity,
            this.tracking_number,
            this.module,
            this.request_by,
            this.date_added,
            this.time_stamp});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Control;
            this.dataView.Location = new System.Drawing.Point(8, 71);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersWidth = 50;
            this.dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(923, 376);
            this.dataView.TabIndex = 549;
            this.dataView.Visible = false;
            this.dataView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            // 
            // selected
            // 
            this.selected.FalseValue = "FALSE";
            this.selected.HeaderText = "Selected";
            this.selected.MinimumWidth = 12;
            this.selected.Name = "selected";
            this.selected.ReadOnly = true;
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "TRUE";
            this.selected.Visible = false;
            this.selected.Width = 125;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Width = 80;
            // 
            // activity
            // 
            this.activity.DataPropertyName = "activity";
            this.activity.HeaderText = "ACTIVITY";
            this.activity.Name = "activity";
            this.activity.ReadOnly = true;
            this.activity.Width = 145;
            // 
            // tracking_number
            // 
            this.tracking_number.DataPropertyName = "tracking_number";
            this.tracking_number.HeaderText = "TRACKING NUMBER";
            this.tracking_number.Name = "tracking_number";
            this.tracking_number.ReadOnly = true;
            this.tracking_number.Width = 150;
            // 
            // module
            // 
            this.module.DataPropertyName = "module";
            this.module.HeaderText = "MODULE";
            this.module.Name = "module";
            this.module.ReadOnly = true;
            // 
            // request_by
            // 
            this.request_by.DataPropertyName = "request_by";
            this.request_by.HeaderText = "REQUEST BY";
            this.request_by.Name = "request_by";
            this.request_by.ReadOnly = true;
            this.request_by.Width = 120;
            // 
            // date_added
            // 
            this.date_added.DataPropertyName = "date_added";
            this.date_added.HeaderText = "DATE ADDED";
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            this.date_added.Width = 115;
            // 
            // time_stamp
            // 
            this.time_stamp.DataPropertyName = "time_stamp";
            this.time_stamp.HeaderText = "TIMESTAMP";
            this.time_stamp.Name = "time_stamp";
            this.time_stamp.ReadOnly = true;
            this.time_stamp.Width = 120;
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(106, 54);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(149, 13);
            this.lblrecords.TabIndex = 550;
            this.lblrecords.Text = "Generate Repacking Barcode";
            this.lblrecords.Visible = false;
            // 
            // frmReprintMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReprintMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReprintMonitoring";
            this.Load += new System.EventHandler(this.frmReprintMonitoring_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.TextBox txtmare;
        private System.Windows.Forms.DateTimePicker dateTimePicker12;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtsearchcode;
        private System.Windows.Forms.Label labelang;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.TextBox txtFeedCode;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn tracking_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn module;
        private System.Windows.Forms.DataGridViewTextBoxColumn request_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_stamp;
    }
}