namespace WFFDR
{
    partial class frmFormulationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulationList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_title = new System.Windows.Forms.Panel();
            this.lblfound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblallmaterials = new System.Windows.Forms.Label();
            this.txtfeedcodes = new System.Windows.Forms.TextBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dgv_po_approve = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po_approve)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.SystemColors.Window;
            this.panel_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_title.Controls.Add(this.lblfound);
            this.panel_title.Controls.Add(this.label2);
            this.panel_title.Controls.Add(this.btngreaterthan);
            this.panel_title.Controls.Add(this.label1);
            this.panel_title.Controls.Add(this.bunifuSearch);
            this.panel_title.Controls.Add(this.lblallmaterials);
            this.panel_title.Controls.Add(this.txtfeedcodes);
            this.panel_title.Controls.Add(this.bunifuThinButton21);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(753, 31);
            this.panel_title.TabIndex = 202;
            // 
            // lblfound
            // 
            this.lblfound.AutoSize = true;
            this.lblfound.Location = new System.Drawing.Point(269, 8);
            this.lblfound.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblfound.Name = "lblfound";
            this.lblfound.Size = new System.Drawing.Size(0, 13);
            this.lblfound.TabIndex = 407;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 406;
            this.label2.Text = "SEARCH :";
            // 
            // btngreaterthan
            // 
            this.btngreaterthan.BackColor = System.Drawing.SystemColors.Control;
            this.btngreaterthan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngreaterthan.BackgroundImage")));
            this.btngreaterthan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngreaterthan.FlatAppearance.BorderSize = 0;
            this.btngreaterthan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngreaterthan.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngreaterthan.ForeColor = System.Drawing.SystemColors.Window;
            this.btngreaterthan.Location = new System.Drawing.Point(458, 3);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(45, 24);
            this.btngreaterthan.TabIndex = 405;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            this.btngreaterthan.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 377;
            this.label1.Text = "TOTAL RECORDS :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bunifuSearch
            // 
            this.bunifuSearch.ActiveBorderThickness = 1;
            this.bunifuSearch.ActiveCornerRadius = 20;
            this.bunifuSearch.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuSearch.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuSearch.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuSearch.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSearch.BackgroundImage")));
            this.bunifuSearch.ButtonText = "SHOW MICRO RECEIVING";
            this.bunifuSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSearch.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuSearch.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuSearch.IdleBorderThickness = 1;
            this.bunifuSearch.IdleCornerRadius = 20;
            this.bunifuSearch.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuSearch.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuSearch.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuSearch.Location = new System.Drawing.Point(390, -8);
            this.bunifuSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuSearch.Name = "bunifuSearch";
            this.bunifuSearch.Size = new System.Drawing.Size(129, 26);
            this.bunifuSearch.TabIndex = 344;
            this.bunifuSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuSearch.Visible = false;
            // 
            // lblallmaterials
            // 
            this.lblallmaterials.AutoSize = true;
            this.lblallmaterials.Location = new System.Drawing.Point(696, 10);
            this.lblallmaterials.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblallmaterials.Name = "lblallmaterials";
            this.lblallmaterials.Size = new System.Drawing.Size(13, 13);
            this.lblallmaterials.TabIndex = 2;
            this.lblallmaterials.Text = "0";
            // 
            // txtfeedcodes
            // 
            this.txtfeedcodes.BackColor = System.Drawing.SystemColors.Window;
            this.txtfeedcodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfeedcodes.Location = new System.Drawing.Point(84, 8);
            this.txtfeedcodes.Name = "txtfeedcodes";
            this.txtfeedcodes.Size = new System.Drawing.Size(177, 13);
            this.txtfeedcodes.TabIndex = 1;
            this.txtfeedcodes.TextChanged += new System.EventHandler(this.txtfeedcodes_TextChanged);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Enabled = false;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.Location = new System.Drawing.Point(73, -3);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(276, 35);
            this.bunifuThinButton21.TabIndex = 375;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_po_approve
            // 
            this.dgv_po_approve.AllowUserToAddRows = false;
            this.dgv_po_approve.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_po_approve.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_po_approve.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_po_approve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_po_approve.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_po_approve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_po_approve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.rp_group,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_po_approve.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_po_approve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_po_approve.EnableHeadersVisualStyles = false;
            this.dgv_po_approve.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_po_approve.Location = new System.Drawing.Point(0, 31);
            this.dgv_po_approve.Name = "dgv_po_approve";
            this.dgv_po_approve.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_po_approve.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_po_approve.RowHeadersWidth = 50;
            this.dgv_po_approve.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_po_approve.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_po_approve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_po_approve.Size = new System.Drawing.Size(753, 630);
            this.dgv_po_approve.TabIndex = 415;
            this.dgv_po_approve.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_po_approve_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "feed_code";
            this.Column1.HeaderText = "FEED CODE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "rp_feed_type";
            this.Column2.HeaderText = "FEED TYPE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "rp_type";
            this.Column3.HeaderText = "TYPE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "rp_description";
            this.Column4.HeaderText = "DESCRIPTION";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "rp_category";
            this.Column5.HeaderText = "CATEGORY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // rp_group
            // 
            this.rp_group.DataPropertyName = "rp_group";
            this.rp_group.HeaderText = "GROUP";
            this.rp_group.Name = "rp_group";
            this.rp_group.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "quantity";
            this.Column6.HeaderText = "QUANTITY";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // frmFormulationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 661);
            this.Controls.Add(this.dgv_po_approve);
            this.Controls.Add(this.panel_title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFormulationList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List of Formulation";
            this.Load += new System.EventHandler(this.frmFormulationList_Load);
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po_approve)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuSearch;
        private System.Windows.Forms.Label lblallmaterials;
        private System.Windows.Forms.TextBox txtfeedcodes;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.DataGridView dgv_po_approve;
        private System.Windows.Forms.Label lblfound;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}