
namespace WFFDR.Set_UP
{
    partial class FrmPlatenumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlatenumber));
            this.dgvplatenumber = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.txtboxplatenumber = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtboxtovehicle = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.txtdateadded = new System.Windows.Forms.TextBox();
            this.txtadd = new System.Windows.Forms.TextBox();
            this.txtedit = new System.Windows.Forms.TextBox();
            this.pnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_vehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvplatenumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvplatenumber
            // 
            this.dgvplatenumber.AllowUserToAddRows = false;
            this.dgvplatenumber.AllowUserToDeleteRows = false;
            this.dgvplatenumber.BackgroundColor = System.Drawing.Color.White;
            this.dgvplatenumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvplatenumber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pnid,
            this.to_vehicle,
            this.platenumber,
            this.added_by,
            this.date_added});
            this.dgvplatenumber.GridColor = System.Drawing.Color.Teal;
            this.dgvplatenumber.Location = new System.Drawing.Point(6, 21);
            this.dgvplatenumber.Name = "dgvplatenumber";
            this.dgvplatenumber.ReadOnly = true;
            this.dgvplatenumber.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvplatenumber.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvplatenumber.RowTemplate.Height = 24;
            this.dgvplatenumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvplatenumber.Size = new System.Drawing.Size(582, 228);
            this.dgvplatenumber.TabIndex = 0;
            this.dgvplatenumber.CurrentCellChanged += new System.EventHandler(this.dgvplatenumber_CurrentCellChanged);
            this.dgvplatenumber.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvplatenumber_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvplatenumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 253);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Plate Number";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(430, 276);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 17);
            this.label20.TabIndex = 499;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(582, 276);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(17, 17);
            this.lblrecords.TabIndex = 498;
            this.lblrecords.Text = "0";
            // 
            // txtboxplatenumber
            // 
            this.txtboxplatenumber.Location = new System.Drawing.Point(744, 98);
            this.txtboxplatenumber.Name = "txtboxplatenumber";
            this.txtboxplatenumber.Size = new System.Drawing.Size(100, 22);
            this.txtboxplatenumber.TabIndex = 500;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(243, 268);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.TabIndex = 497;
            this.btnDelete.Text = "&In-Active";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(131, 268);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 34);
            this.btnUpdate.TabIndex = 496;
            this.btnUpdate.Text = "&Edit";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Window;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(19, 268);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 34);
            this.btnNew.TabIndex = 495;
            this.btnNew.Text = "New  ";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtboxtovehicle
            // 
            this.txtboxtovehicle.Location = new System.Drawing.Point(744, 61);
            this.txtboxtovehicle.Name = "txtboxtovehicle";
            this.txtboxtovehicle.Size = new System.Drawing.Size(100, 22);
            this.txtboxtovehicle.TabIndex = 501;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(759, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 502;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(744, 33);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 22);
            this.txtid.TabIndex = 503;
            // 
            // txtaddedby
            // 
            this.txtaddedby.Location = new System.Drawing.Point(744, 137);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(100, 22);
            this.txtaddedby.TabIndex = 504;
            // 
            // txtdateadded
            // 
            this.txtdateadded.Location = new System.Drawing.Point(744, 174);
            this.txtdateadded.Name = "txtdateadded";
            this.txtdateadded.Size = new System.Drawing.Size(100, 22);
            this.txtdateadded.TabIndex = 505;
            // 
            // txtadd
            // 
            this.txtadd.Location = new System.Drawing.Point(903, 42);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(100, 22);
            this.txtadd.TabIndex = 506;
            this.txtadd.Text = "add";
            // 
            // txtedit
            // 
            this.txtedit.Location = new System.Drawing.Point(903, 87);
            this.txtedit.Name = "txtedit";
            this.txtedit.Size = new System.Drawing.Size(100, 22);
            this.txtedit.TabIndex = 507;
            this.txtedit.Text = "edit";
            // 
            // pnid
            // 
            this.pnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pnid.DataPropertyName = "pnid";
            this.pnid.HeaderText = "Plate No. ID";
            this.pnid.MinimumWidth = 6;
            this.pnid.Name = "pnid";
            this.pnid.ReadOnly = true;
            this.pnid.Width = 112;
            // 
            // to_vehicle
            // 
            this.to_vehicle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.to_vehicle.DataPropertyName = "to_vehicle";
            this.to_vehicle.HeaderText = "Type of Vehicle";
            this.to_vehicle.MinimumWidth = 6;
            this.to_vehicle.Name = "to_vehicle";
            this.to_vehicle.ReadOnly = true;
            // 
            // platenumber
            // 
            this.platenumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.platenumber.DataPropertyName = "platenumber";
            this.platenumber.HeaderText = "Plate No.";
            this.platenumber.MinimumWidth = 6;
            this.platenumber.Name = "platenumber";
            this.platenumber.ReadOnly = true;
            // 
            // added_by
            // 
            this.added_by.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "Added by";
            this.added_by.MinimumWidth = 6;
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            // 
            // date_added
            // 
            this.date_added.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date_added.DataPropertyName = "date_added";
            this.date_added.HeaderText = "Date Added";
            this.date_added.MinimumWidth = 6;
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            // 
            // FrmPlatenumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(616, 312);
            this.Controls.Add(this.txtedit);
            this.Controls.Add(this.txtadd);
            this.Controls.Add(this.txtdateadded);
            this.Controls.Add(this.txtaddedby);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtboxtovehicle);
            this.Controls.Add(this.txtboxplatenumber);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlatenumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plate Number Management";
            this.Load += new System.EventHandler(this.FrmPlatenumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvplatenumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvplatenumber;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.TextBox txtboxplatenumber;
        private System.Windows.Forms.TextBox txtboxtovehicle;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtid;
        public System.Windows.Forms.TextBox txtaddedby;
        public System.Windows.Forms.TextBox txtdateadded;
        public System.Windows.Forms.TextBox txtadd;
        public System.Windows.Forms.TextBox txtedit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_vehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn platenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
    }
}