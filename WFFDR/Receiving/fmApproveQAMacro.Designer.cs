namespace WFFDR
{
    partial class fmApproveQAMacro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmApproveQAMacro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_title = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblallmaterials = new System.Windows.Forms.Label();
            this.txtmainsearch = new System.Windows.Forms.TextBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv_po_approve = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_ordered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stacking_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_total_delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodmaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po_approve)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.SystemColors.Window;
            this.panel_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_title.Controls.Add(this.label2);
            this.panel_title.Controls.Add(this.btngreaterthan);
            this.panel_title.Controls.Add(this.label1);
            this.panel_title.Controls.Add(this.bunifuSearch);
            this.panel_title.Controls.Add(this.lblallmaterials);
            this.panel_title.Controls.Add(this.txtmainsearch);
            this.panel_title.Controls.Add(this.bunifuThinButton21);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(656, 29);
            this.panel_title.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 407;
            this.label2.Text = "SEARCH :";
            this.label2.Visible = false;
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
            this.btngreaterthan.Location = new System.Drawing.Point(387, -2);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(45, 24);
            this.btngreaterthan.TabIndex = 406;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            this.btngreaterthan.Visible = false;
            this.btngreaterthan.Click += new System.EventHandler(this.btngreaterthan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 376;
            this.label1.Text = "TOTAL RECORDS :";
            this.label1.Visible = false;
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
            this.bunifuSearch.ButtonText = "SHOW MACRO RECEIVING";
            this.bunifuSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSearch.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuSearch.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuSearch.IdleBorderThickness = 1;
            this.bunifuSearch.IdleCornerRadius = 20;
            this.bunifuSearch.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuSearch.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuSearch.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuSearch.Location = new System.Drawing.Point(395, -4);
            this.bunifuSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuSearch.Name = "bunifuSearch";
            this.bunifuSearch.Size = new System.Drawing.Size(134, 26);
            this.bunifuSearch.TabIndex = 344;
            this.bunifuSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuSearch.Visible = false;
            this.bunifuSearch.Click += new System.EventHandler(this.bunifuSearch_Click);
            // 
            // lblallmaterials
            // 
            this.lblallmaterials.AutoSize = true;
            this.lblallmaterials.Location = new System.Drawing.Point(618, 9);
            this.lblallmaterials.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblallmaterials.Name = "lblallmaterials";
            this.lblallmaterials.Size = new System.Drawing.Size(13, 13);
            this.lblallmaterials.TabIndex = 2;
            this.lblallmaterials.Text = "0";
            this.lblallmaterials.Visible = false;
            // 
            // txtmainsearch
            // 
            this.txtmainsearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtmainsearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmainsearch.Enabled = false;
            this.txtmainsearch.Location = new System.Drawing.Point(84, 11);
            this.txtmainsearch.Name = "txtmainsearch";
            this.txtmainsearch.Size = new System.Drawing.Size(248, 13);
            this.txtmainsearch.TabIndex = 1;
            this.txtmainsearch.Visible = false;
            this.txtmainsearch.TextChanged += new System.EventHandler(this.txtmainsearch_TextChanged);
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
            this.bunifuThinButton21.Location = new System.Drawing.Point(72, 5);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(276, 25);
            this.bunifuThinButton21.TabIndex = 375;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(390, 127);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(3, 3);
            this.flowLayoutPanel1.TabIndex = 199;
            // 
            // dgv_po_approve
            // 
            this.dgv_po_approve.AllowUserToAddRows = false;
            this.dgv_po_approve.AllowUserToDeleteRows = false;
            this.dgv_po_approve.AllowUserToResizeColumns = false;
            this.dgv_po_approve.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_po_approve.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_po_approve.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_po_approve.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_po_approve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_po_approve.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_po_approve.ColumnHeadersHeight = 35;
            this.dgv_po_approve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_po_approve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column8,
            this.qty_ordered,
            this.stacking_level,
            this.qty_total_delivered,
            this.goodmaterial});
            this.dgv_po_approve.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_po_approve.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_po_approve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_po_approve.EnableHeadersVisualStyles = false;
            this.dgv_po_approve.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_po_approve.Location = new System.Drawing.Point(0, 29);
            this.dgv_po_approve.MultiSelect = false;
            this.dgv_po_approve.Name = "dgv_po_approve";
            this.dgv_po_approve.ReadOnly = true;
            this.dgv_po_approve.RowHeadersVisible = false;
            this.dgv_po_approve.RowHeadersWidth = 102;
            this.dgv_po_approve.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_po_approve.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_po_approve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_po_approve.Size = new System.Drawing.Size(656, 628);
            this.dgv_po_approve.TabIndex = 200;
            this.dgv_po_approve.Visible = false;
            this.dgv_po_approve.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_po_approve_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "po_number";
            this.Column1.HeaderText = "PO #";
            this.Column1.MinimumWidth = 12;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "item_code";
            this.Column2.HeaderText = "ITEM CODE";
            this.Column2.MinimumWidth = 12;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "item_description";
            this.Column8.HeaderText = "DESCRIPTION";
            this.Column8.MinimumWidth = 12;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // qty_ordered
            // 
            this.qty_ordered.DataPropertyName = "qty_ordered";
            this.qty_ordered.HeaderText = "QTY ORDER";
            this.qty_ordered.MinimumWidth = 12;
            this.qty_ordered.Name = "qty_ordered";
            this.qty_ordered.ReadOnly = true;
            // 
            // stacking_level
            // 
            this.stacking_level.DataPropertyName = "stacking_level";
            this.stacking_level.HeaderText = "EXPECTED DELIVERY";
            this.stacking_level.MinimumWidth = 12;
            this.stacking_level.Name = "stacking_level";
            this.stacking_level.ReadOnly = true;
            // 
            // qty_total_delivered
            // 
            this.qty_total_delivered.DataPropertyName = "qty_total_delivered";
            this.qty_total_delivered.HeaderText = "ACTUAL DELIVER";
            this.qty_total_delivered.MinimumWidth = 12;
            this.qty_total_delivered.Name = "qty_total_delivered";
            this.qty_total_delivered.ReadOnly = true;
            // 
            // goodmaterial
            // 
            this.goodmaterial.DataPropertyName = "goodmaterial";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.goodmaterial.DefaultCellStyle = dataGridViewCellStyle3;
            this.goodmaterial.HeaderText = "GOOD";
            this.goodmaterial.MinimumWidth = 12;
            this.goodmaterial.Name = "goodmaterial";
            this.goodmaterial.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(233, 382);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 203;
            // 
            // fmApproveQAMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(656, 657);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dgv_po_approve);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "fmApproveQAMacro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   List of Approve Macro Receiving Entry";
            this.Load += new System.EventHandler(this.fmApproveQAMacro_Load);
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po_approve)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_title;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuSearch;
        private System.Windows.Forms.Label lblallmaterials;
        private System.Windows.Forms.TextBox txtmainsearch;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_po_approve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_ordered;
        private System.Windows.Forms.DataGridViewTextBoxColumn stacking_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_total_delivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodmaterial;
    }
}