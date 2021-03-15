namespace WFFDR
{
    partial class frmPrintBasemixedEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBasemixedEntry));
            this.dataView = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bmx_proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmx_id_string = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_adv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestamp_process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtsearchcode = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton218 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.button1 = new System.Windows.Forms.Button();
            this.txtfooter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHR_OIC = new System.Windows.Forms.ComboBox();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.crV1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.txtluffy = new System.Windows.Forms.Label();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblfound = new System.Windows.Forms.Label();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label12 = new System.Windows.Forms.Label();
            this.txtprintno = new System.Windows.Forms.TextBox();
            this.lblprintno = new System.Windows.Forms.Label();
            this.txtprod_id = new System.Windows.Forms.TextBox();
            this.lblprod = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.bmx_proddate,
            this.bmx_id_string,
            this.prod_adv,
            this.Emp_Number,
            this.Emp_Name,
            this.Department,
            this.Position,
            this.PrintNo,
            this.Status,
            this.TotalPack,
            this.Packby,
            this.PrintCount,
            this.ID,
            this.timestamp_process});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Control;
            this.dataView.Location = new System.Drawing.Point(6, 94);
            this.dataView.Name = "dataView";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataView.RowHeadersWidth = 50;
            this.dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(981, 315);
            this.dataView.TabIndex = 47;
            this.dataView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataView_CellFormatting);
            this.dataView.CurrentCellChanged += new System.EventHandler(this.dataView_CurrentCellChanged);
            this.dataView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            this.dataView.DoubleClick += new System.EventHandler(this.dataView_DoubleClick);
            // 
            // selected
            // 
            this.selected.FalseValue = "FALSE";
            this.selected.HeaderText = "Selected";
            this.selected.MinimumWidth = 12;
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "TRUE";
            this.selected.Width = 250;
            // 
            // bmx_proddate
            // 
            this.bmx_proddate.DataPropertyName = "bmx_proddate";
            this.bmx_proddate.HeaderText = "Proddate";
            this.bmx_proddate.Name = "bmx_proddate";
            this.bmx_proddate.Visible = false;
            // 
            // bmx_id_string
            // 
            this.bmx_id_string.DataPropertyName = "bmx_id_string";
            this.bmx_id_string.HeaderText = "ID";
            this.bmx_id_string.Name = "bmx_id_string";
            // 
            // prod_adv
            // 
            this.prod_adv.DataPropertyName = "prod_adv";
            this.prod_adv.HeaderText = "PROD ID";
            this.prod_adv.Name = "prod_adv";
            // 
            // Emp_Number
            // 
            this.Emp_Number.DataPropertyName = "Feed_Code";
            this.Emp_Number.HeaderText = "Feed Code";
            this.Emp_Number.MinimumWidth = 12;
            this.Emp_Number.Name = "Emp_Number";
            this.Emp_Number.Width = 120;
            // 
            // Emp_Name
            // 
            this.Emp_Name.DataPropertyName = "Feed_Type";
            this.Emp_Name.HeaderText = "Feed Type";
            this.Emp_Name.MinimumWidth = 12;
            this.Emp_Name.Name = "Emp_Name";
            this.Emp_Name.Width = 250;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Bags";
            this.Department.HeaderText = "Bags";
            this.Department.MinimumWidth = 12;
            this.Department.Name = "Department";
            this.Department.Width = 70;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Batch";
            this.Position.HeaderText = "Batch";
            this.Position.MinimumWidth = 12;
            this.Position.Name = "Position";
            this.Position.Width = 75;
            // 
            // PrintNo
            // 
            this.PrintNo.DataPropertyName = "PrintNo";
            this.PrintNo.HeaderText = "No.of.Print";
            this.PrintNo.MinimumWidth = 12;
            this.PrintNo.Name = "PrintNo";
            this.PrintNo.Width = 55;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "ActualWeight";
            this.Status.HeaderText = "Weight";
            this.Status.MinimumWidth = 12;
            this.Status.Name = "Status";
            this.Status.Width = 80;
            // 
            // TotalPack
            // 
            this.TotalPack.DataPropertyName = "ProdDate";
            this.TotalPack.HeaderText = "ProdDate";
            this.TotalPack.MinimumWidth = 12;
            this.TotalPack.Name = "TotalPack";
            this.TotalPack.Visible = false;
            this.TotalPack.Width = 250;
            // 
            // Packby
            // 
            this.Packby.DataPropertyName = "AddedBy";
            this.Packby.HeaderText = "Addedby";
            this.Packby.MinimumWidth = 12;
            this.Packby.Name = "Packby";
            this.Packby.Width = 250;
            // 
            // PrintCount
            // 
            this.PrintCount.DataPropertyName = "PrintCount";
            this.PrintCount.HeaderText = "PRINT COUNT";
            this.PrintCount.MinimumWidth = 12;
            this.PrintCount.Name = "PrintCount";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "KEY";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // timestamp_process
            // 
            this.timestamp_process.DataPropertyName = "timestamp_process";
            this.timestamp_process.HeaderText = "TimeStamp";
            this.timestamp_process.Name = "timestamp_process";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.ForeColor = System.Drawing.Color.Black;
            this.chkAll.Location = new System.Drawing.Point(822, 73);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(117, 17);
            this.chkAll.TabIndex = 48;
            this.chkAll.Text = "Select/Deselect All";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 384;
            this.label8.Text = "Generate Basemixed Barcode";
            // 
            // txtsearchcode
            // 
            this.txtsearchcode.Location = new System.Drawing.Point(434, 18);
            this.txtsearchcode.Name = "txtsearchcode";
            this.txtsearchcode.Size = new System.Drawing.Size(122, 20);
            this.txtsearchcode.TabIndex = 383;
            this.txtsearchcode.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(318, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 382;
            this.txtSearch.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.bunifuThinButton22);
            this.groupBox1.Controls.Add(this.bunifuThinButton21);
            this.groupBox1.Controls.Add(this.bunifuThinButton218);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtfooter);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbHR_OIC);
            this.groupBox1.Controls.Add(this.dt);
            this.groupBox1.Location = new System.Drawing.Point(6, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 127);
            this.groupBox1.TabIndex = 385;
            this.groupBox1.TabStop = false;
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "Close";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton22.Location = new System.Drawing.Point(774, 68);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(84, 34);
            this.bunifuThinButton22.TabIndex = 368;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Click += new System.EventHandler(this.bunifuThinButton22_Click);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "Direct Print";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.Location = new System.Drawing.Point(572, 68);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(84, 34);
            this.bunifuThinButton21.TabIndex = 367;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Visible = false;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // bunifuThinButton218
            // 
            this.bunifuThinButton218.ActiveBorderThickness = 1;
            this.bunifuThinButton218.ActiveCornerRadius = 20;
            this.bunifuThinButton218.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton218.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton218.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton218.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton218.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton218.BackgroundImage")));
            this.bunifuThinButton218.ButtonText = "Print Preview";
            this.bunifuThinButton218.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton218.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton218.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton218.IdleBorderThickness = 1;
            this.bunifuThinButton218.IdleCornerRadius = 20;
            this.bunifuThinButton218.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton218.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton218.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton218.Location = new System.Drawing.Point(674, 67);
            this.bunifuThinButton218.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton218.Name = "bunifuThinButton218";
            this.bunifuThinButton218.Size = new System.Drawing.Size(84, 34);
            this.bunifuThinButton218.TabIndex = 366;
            this.bunifuThinButton218.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton218.Click += new System.EventHandler(this.bunifuThinButton218_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(459, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 47;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // txtfooter
            // 
            this.txtfooter.Location = new System.Drawing.Point(489, 12);
            this.txtfooter.Multiline = true;
            this.txtfooter.Name = "txtfooter";
            this.txtfooter.Size = new System.Drawing.Size(372, 51);
            this.txtfooter.TabIndex = 46;
            this.txtfooter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(159, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 44);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Type Printer Layout";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(106, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Zebra Sticker";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Zebra Paper";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Description :";
            // 
            // cmbPos
            // 
            this.cmbPos.FormattingEnabled = true;
            this.cmbPos.Items.AddRange(new object[] {
            "HR Manager"});
            this.cmbPos.Location = new System.Drawing.Point(90, 67);
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(281, 21);
            this.cmbPos.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(397, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Company Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Approved by:";
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(375, 58);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 34);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Valid Until";
            // 
            // cmbHR_OIC
            // 
            this.cmbHR_OIC.FormattingEnabled = true;
            this.cmbHR_OIC.Items.AddRange(new object[] {
            "Rollaine C. Palo"});
            this.cmbHR_OIC.Location = new System.Drawing.Point(90, 40);
            this.cmbHR_OIC.Name = "cmbHR_OIC";
            this.cmbHR_OIC.Size = new System.Drawing.Size(281, 21);
            this.cmbHR_OIC.TabIndex = 6;
            // 
            // dt
            // 
            this.dt.CustomFormat = "MMMM dd, yyyy";
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt.Location = new System.Drawing.Point(90, 15);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(281, 20);
            this.dt.TabIndex = 1;
            this.dt.Value = new System.DateTime(2019, 1, 31, 0, 0, 0, 0);
            // 
            // crV1
            // 
            this.crV1.ActiveViewIndex = -1;
            this.crV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crV1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crV1.Location = new System.Drawing.Point(441, 281);
            this.crV1.Margin = new System.Windows.Forms.Padding(1);
            this.crV1.Name = "crV1";
            this.crV1.Size = new System.Drawing.Size(20, 63);
            this.crV1.TabIndex = 386;
            this.crV1.ToolPanelWidth = 75;
            this.crV1.Visible = false;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(374, 10);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(39, 17);
            this.metroButton4.TabIndex = 393;
            this.metroButton4.Text = "Update";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Visible = false;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // txtluffy
            // 
            this.txtluffy.AutoSize = true;
            this.txtluffy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtluffy.Location = new System.Drawing.Point(167, 74);
            this.txtluffy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtluffy.Name = "txtluffy";
            this.txtluffy.Size = new System.Drawing.Size(49, 13);
            this.txtluffy.TabIndex = 396;
            this.txtluffy.Text = "0000000";
            // 
            // bunifuThinButton23
            // 
            this.bunifuThinButton23.ActiveBorderThickness = 1;
            this.bunifuThinButton23.ActiveCornerRadius = 20;
            this.bunifuThinButton23.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton23.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton23.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton23.BackgroundImage")));
            this.bunifuThinButton23.ButtonText = "PRINT";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 20;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.Location = new System.Drawing.Point(725, 63);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(84, 30);
            this.bunifuThinButton23.TabIndex = 397;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton23.Click += new System.EventHandler(this.bunifuThinButton23_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btngreaterthan);
            this.panel2.Controls.Add(this.dateTimePicker12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtsearchcode);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.metroButton4);
            this.panel2.Location = new System.Drawing.Point(6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 58);
            this.panel2.TabIndex = 547;
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
            this.btngreaterthan.Location = new System.Drawing.Point(689, 10);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(53, 41);
            this.btngreaterthan.TabIndex = 642;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            this.btngreaterthan.Click += new System.EventHandler(this.btngreaterthan_Click);
            // 
            // dateTimePicker12
            // 
            this.dateTimePicker12.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.CustomFormat = "M/d/yyyy";
            this.dateTimePicker12.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker12.Location = new System.Drawing.Point(746, 10);
            this.dateTimePicker12.Name = "dateTimePicker12";
            this.dateTimePicker12.Size = new System.Drawing.Size(195, 32);
            this.dateTimePicker12.TabIndex = 8;
            this.dateTimePicker12.ValueChanged += new System.EventHandler(this.dateTimePicker12_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(403, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Reprint Basemixed Barcode Entry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 28);
            this.label7.TabIndex = 552;
            this.label7.Text = "TOTAL RECORDS:";
            // 
            // lblfound
            // 
            this.lblfound.AutoSize = true;
            this.lblfound.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfound.ForeColor = System.Drawing.Color.Black;
            this.lblfound.Location = new System.Drawing.Point(228, 417);
            this.lblfound.Name = "lblfound";
            this.lblfound.Size = new System.Drawing.Size(27, 28);
            this.lblfound.TabIndex = 551;
            this.lblfound.Text = "0";
            // 
            // btnrefresh
            // 
            this.btnrefresh.ActiveBorderThickness = 1;
            this.btnrefresh.ActiveCornerRadius = 20;
            this.btnrefresh.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnrefresh.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnrefresh.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnrefresh.BackColor = System.Drawing.SystemColors.Window;
            this.btnrefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrefresh.BackgroundImage")));
            this.btnrefresh.ButtonText = "REFRESH";
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnrefresh.IdleBorderThickness = 1;
            this.btnrefresh.IdleCornerRadius = 20;
            this.btnrefresh.IdleFillColor = System.Drawing.Color.Orange;
            this.btnrefresh.IdleForecolor = System.Drawing.SystemColors.Window;
            this.btnrefresh.IdleLineColor = System.Drawing.SystemColors.Window;
            this.btnrefresh.Location = new System.Drawing.Point(855, 411);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(84, 34);
            this.btnrefresh.TabIndex = 553;
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(662, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 558;
            this.label12.Text = "Item Code :";
            this.label12.Visible = false;
            // 
            // txtprintno
            // 
            this.txtprintno.Location = new System.Drawing.Point(535, 70);
            this.txtprintno.Name = "txtprintno";
            this.txtprintno.Size = new System.Drawing.Size(122, 20);
            this.txtprintno.TabIndex = 557;
            this.txtprintno.Visible = false;
            this.txtprintno.TextChanged += new System.EventHandler(this.txtprintno_TextChanged);
            // 
            // lblprintno
            // 
            this.lblprintno.AutoSize = true;
            this.lblprintno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprintno.Location = new System.Drawing.Point(457, 74);
            this.lblprintno.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprintno.Name = "lblprintno";
            this.lblprintno.Size = new System.Drawing.Size(51, 13);
            this.lblprintno.TabIndex = 556;
            this.lblprintno.Text = "Print No :";
            this.lblprintno.Visible = false;
            // 
            // txtprod_id
            // 
            this.txtprod_id.Location = new System.Drawing.Point(325, 71);
            this.txtprod_id.Name = "txtprod_id";
            this.txtprod_id.Size = new System.Drawing.Size(122, 20);
            this.txtprod_id.TabIndex = 555;
            this.txtprod_id.Visible = false;
            this.txtprod_id.TextChanged += new System.EventHandler(this.txtprod_id_TextChanged);
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprod.Location = new System.Drawing.Point(233, 74);
            this.lblprod.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(78, 13);
            this.lblprod.TabIndex = 554;
            this.lblprod.Text = "Production ID :";
            this.lblprod.Visible = false;
            // 
            // frmPrintBasemixedEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(949, 448);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtprintno);
            this.Controls.Add(this.lblprintno);
            this.Controls.Add(this.txtprod_id);
            this.Controls.Add(this.lblprod);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblfound);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.txtluffy);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.crV1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "frmPrintBasemixedEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPrintBasemixedEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtsearchcode;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton218;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtfooter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHR_OIC;
        private System.Windows.Forms.DateTimePicker dt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crV1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Label txtluffy;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label lblfound;
        private System.Windows.Forms.DateTimePicker dateTimePicker12;
        private Bunifu.Framework.UI.BunifuThinButton2 btnrefresh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtprintno;
        private System.Windows.Forms.Label lblprintno;
        private System.Windows.Forms.TextBox txtprod_id;
        private System.Windows.Forms.Label lblprod;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmx_proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmx_id_string;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_adv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packby;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp_process;
    }
}