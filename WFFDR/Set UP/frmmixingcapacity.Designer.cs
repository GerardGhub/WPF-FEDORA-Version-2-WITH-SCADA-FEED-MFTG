namespace WFFDR
{
    partial class frmmixingcapacity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmixingcapacity));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblfeedtype = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuThinButton2();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.txtcapacity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInactive = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnedit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtdatetime = new System.Windows.Forms.TextBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.txtby40 = new System.Windows.Forms.TextBox();
            this.txtcorntype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCorn = new System.Windows.Forms.ComboBox();
            this.txtcbocorn = new System.Windows.Forms.TextBox();
            this.rp_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mixing_capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qa_corn_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corn_type_formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).BeginInit();
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
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_table.ColumnHeadersHeight = 25;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rp_feed_type,
            this.mixing_capacity,
            this.qa_corn_code,
            this.corn_type_formula,
            this.TimeStamp});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(3, 53);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersWidth = 45;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(839, 443);
            this.dgv_table.TabIndex = 546;
            this.dgv_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_table_CellContentClick);
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl1.Location = new System.Drawing.Point(425, 31);
            this.lbl1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(49, 13);
            this.lbl1.TabIndex = 548;
            this.lbl1.Text = "4544545";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lblfeedtype);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 49);
            this.panel1.TabIndex = 547;
            // 
            // lblfeedtype
            // 
            this.lblfeedtype.AutoSize = true;
            this.lblfeedtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfeedtype.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblfeedtype.Location = new System.Drawing.Point(4, 6);
            this.lblfeedtype.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblfeedtype.Name = "lblfeedtype";
            this.lblfeedtype.Size = new System.Drawing.Size(221, 20);
            this.lblfeedtype.TabIndex = 550;
            this.lblfeedtype.Text = "Formulation Table Information";
            this.lblfeedtype.Click += new System.EventHandler(this.lblfeedtype_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(268, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LIST OF MIXING CAPACITY :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.ActiveBorderThickness = 1;
            this.btnUpdate.ActiveCornerRadius = 10;
            this.btnUpdate.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnUpdate.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.btnUpdate.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpdate.IdleBorderThickness = 1;
            this.btnUpdate.IdleCornerRadius = 10;
            this.btnUpdate.IdleFillColor = System.Drawing.Color.White;
            this.btnUpdate.IdleForecolor = System.Drawing.Color.Black;
            this.btnUpdate.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpdate.Location = new System.Drawing.Point(644, 538);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 40);
            this.btnUpdate.TabIndex = 549;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(226, 243);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(39, 17);
            this.metroButton2.TabIndex = 550;
            this.metroButton2.Text = "metroConfirmation";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Visible = false;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtcapacity
            // 
            this.txtcapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcapacity.Enabled = false;
            this.txtcapacity.Location = new System.Drawing.Point(75, 510);
            this.txtcapacity.Margin = new System.Windows.Forms.Padding(1);
            this.txtcapacity.Name = "txtcapacity";
            this.txtcapacity.Size = new System.Drawing.Size(136, 20);
            this.txtcapacity.TabIndex = 552;
            this.txtcapacity.TextChanged += new System.EventHandler(this.txtcapacity_TextChanged);
            this.txtcapacity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcapacity_KeyDown);
            this.txtcapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcapacity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 515);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 551;
            this.label2.Text = "CAPACITY :";
            // 
            // dgvInactive
            // 
            this.dgvInactive.AllowUserToAddRows = false;
            this.dgvInactive.AllowUserToDeleteRows = false;
            this.dgvInactive.AllowUserToResizeColumns = false;
            this.dgvInactive.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            this.dgvInactive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInactive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInactive.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInactive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInactive.ColumnHeadersHeight = 35;
            this.dgvInactive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInactive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvInactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvInactive.EnableHeadersVisualStyles = false;
            this.dgvInactive.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInactive.Location = new System.Drawing.Point(876, 301);
            this.dgvInactive.MultiSelect = false;
            this.dgvInactive.Name = "dgvInactive";
            this.dgvInactive.ReadOnly = true;
            this.dgvInactive.RowHeadersVisible = false;
            this.dgvInactive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvInactive.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInactive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInactive.Size = new System.Drawing.Size(218, 98);
            this.dgvInactive.TabIndex = 555;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "item_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "item_code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "item_description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "total_quantity_raw";
            this.dataGridViewTextBoxColumn4.HeaderText = "Stocks";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "qty_repack_available";
            this.dataGridViewTextBoxColumn5.HeaderText = "Repack";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // btnedit
            // 
            this.btnedit.ActiveBorderThickness = 1;
            this.btnedit.ActiveCornerRadius = 10;
            this.btnedit.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnedit.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.btnedit.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnedit.BackColor = System.Drawing.SystemColors.Window;
            this.btnedit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnedit.BackgroundImage")));
            this.btnedit.ButtonText = "E&dit";
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.btnedit.IdleBorderThickness = 1;
            this.btnedit.IdleCornerRadius = 10;
            this.btnedit.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnedit.IdleForecolor = System.Drawing.Color.Black;
            this.btnedit.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btnedit.Location = new System.Drawing.Point(644, 538);
            this.btnedit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(88, 40);
            this.btnedit.TabIndex = 556;
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnedit.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBorderThickness = 1;
            this.btnCancel.ActiveCornerRadius = 10;
            this.btnCancel.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancel.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.btnCancel.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 10;
            this.btnCancel.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnCancel.IdleForecolor = System.Drawing.Color.Black;
            this.btnCancel.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.Location = new System.Drawing.Point(755, 539);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 40);
            this.btnCancel.TabIndex = 557;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtdatetime
            // 
            this.txtdatetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdatetime.Enabled = false;
            this.txtdatetime.Location = new System.Drawing.Point(755, 425);
            this.txtdatetime.Margin = new System.Windows.Forms.Padding(1);
            this.txtdatetime.Name = "txtdatetime";
            this.txtdatetime.Size = new System.Drawing.Size(108, 20);
            this.txtdatetime.TabIndex = 558;
            this.txtdatetime.Visible = false;
            // 
            // txtaddedby
            // 
            this.txtaddedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Location = new System.Drawing.Point(755, 218);
            this.txtaddedby.Margin = new System.Windows.Forms.Padding(1);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(108, 20);
            this.txtaddedby.TabIndex = 559;
            this.txtaddedby.Visible = false;
            this.txtaddedby.TextChanged += new System.EventHandler(this.txtaddedby_TextChanged);
            // 
            // txtby40
            // 
            this.txtby40.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtby40.Enabled = false;
            this.txtby40.Location = new System.Drawing.Point(208, 306);
            this.txtby40.Margin = new System.Windows.Forms.Padding(1);
            this.txtby40.Name = "txtby40";
            this.txtby40.Size = new System.Drawing.Size(108, 13);
            this.txtby40.TabIndex = 560;
            this.txtby40.Visible = false;
            this.txtby40.TextChanged += new System.EventHandler(this.txtby40_TextChanged);
            // 
            // txtcorntype
            // 
            this.txtcorntype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcorntype.Enabled = false;
            this.txtcorntype.Location = new System.Drawing.Point(694, 511);
            this.txtcorntype.Margin = new System.Windows.Forms.Padding(1);
            this.txtcorntype.Name = "txtcorntype";
            this.txtcorntype.Size = new System.Drawing.Size(148, 20);
            this.txtcorntype.TabIndex = 562;
            this.txtcorntype.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 515);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 561;
            this.label3.Text = "CORN TYPE:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(614, 516);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 563;
            this.label4.Text = "CORN CODE:";
            // 
            // cboCorn
            // 
            this.cboCorn.BackColor = System.Drawing.Color.Yellow;
            this.cboCorn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCorn.FormattingEnabled = true;
            this.cboCorn.ItemHeight = 13;
            this.cboCorn.Location = new System.Drawing.Point(372, 510);
            this.cboCorn.Name = "cboCorn";
            this.cboCorn.Size = new System.Drawing.Size(141, 21);
            this.cboCorn.TabIndex = 564;
            this.cboCorn.Visible = false;
            this.cboCorn.SelectedIndexChanged += new System.EventHandler(this.cboCorn_SelectedIndexChanged);
            this.cboCorn.SelectionChangeCommitted += new System.EventHandler(this.cboCorn_SelectionChangeCommitted);
            // 
            // txtcbocorn
            // 
            this.txtcbocorn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcbocorn.Enabled = false;
            this.txtcbocorn.Location = new System.Drawing.Point(372, 510);
            this.txtcbocorn.Margin = new System.Windows.Forms.Padding(1);
            this.txtcbocorn.Name = "txtcbocorn";
            this.txtcbocorn.Size = new System.Drawing.Size(141, 20);
            this.txtcbocorn.TabIndex = 565;
            this.txtcbocorn.TextChanged += new System.EventHandler(this.txtcbocorn_TextChanged);
            // 
            // rp_feed_type
            // 
            this.rp_feed_type.DataPropertyName = "rp_feed_type";
            this.rp_feed_type.HeaderText = "FEED TYPE";
            this.rp_feed_type.Name = "rp_feed_type";
            this.rp_feed_type.ReadOnly = true;
            // 
            // mixing_capacity
            // 
            this.mixing_capacity.DataPropertyName = "mixing_capacity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mixing_capacity.DefaultCellStyle = dataGridViewCellStyle3;
            this.mixing_capacity.HeaderText = "MIXING CAPACITY";
            this.mixing_capacity.Name = "mixing_capacity";
            this.mixing_capacity.ReadOnly = true;
            // 
            // qa_corn_code
            // 
            this.qa_corn_code.DataPropertyName = "qa_corn_code";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qa_corn_code.DefaultCellStyle = dataGridViewCellStyle4;
            this.qa_corn_code.HeaderText = "CORN TYPE";
            this.qa_corn_code.Name = "qa_corn_code";
            this.qa_corn_code.ReadOnly = true;
            // 
            // corn_type_formula
            // 
            this.corn_type_formula.DataPropertyName = "corn_type_formula";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.corn_type_formula.DefaultCellStyle = dataGridViewCellStyle5;
            this.corn_type_formula.HeaderText = "CORN CODE";
            this.corn_type_formula.Name = "corn_type_formula";
            this.corn_type_formula.ReadOnly = true;
            // 
            // TimeStamp
            // 
            this.TimeStamp.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeStamp.DefaultCellStyle = dataGridViewCellStyle6;
            this.TimeStamp.HeaderText = "DATE OF UPDATE";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            this.TimeStamp.Visible = false;
            // 
            // frmmixingcapacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(854, 582);
            this.Controls.Add(this.txtcbocorn);
            this.Controls.Add(this.cboCorn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcorntype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtby40);
            this.Controls.Add(this.txtaddedby);
            this.Controls.Add(this.txtdatetime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.dgvInactive);
            this.Controls.Add(this.txtcapacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmmixingcapacity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mixing Capacity";
            this.Load += new System.EventHandler(this.frmmixingcapacity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.Label lbl1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUpdate;
        private System.Windows.Forms.Label lblfeedtype;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TextBox txtcapacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Bunifu.Framework.UI.BunifuThinButton2 btnedit;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private System.Windows.Forms.TextBox txtdatetime;
        private System.Windows.Forms.TextBox txtaddedby;
        private System.Windows.Forms.TextBox txtby40;
        private System.Windows.Forms.TextBox txtcorntype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCorn;
        private System.Windows.Forms.TextBox txtcbocorn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mixing_capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn qa_corn_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn corn_type_formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
    }
}