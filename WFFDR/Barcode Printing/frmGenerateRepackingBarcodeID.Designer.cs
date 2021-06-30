namespace WFFDR
{
    partial class frmGenerateRepackingBarcodeID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateRepackingBarcodeID));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton218 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.button1 = new System.Windows.Forms.Button();
            this.txtfooter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHR_OIC = new System.Windows.Forms.ComboBox();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.crV1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtsearchcode = new System.Windows.Forms.TextBox();
            this.hr_bakDataSet1 = new WFFDR.hr_bakDataSet();
            this.label8 = new System.Windows.Forms.Label();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.txtluffy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.txtmare = new System.Windows.Forms.TextBox();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblfound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblprod = new System.Windows.Forms.Label();
            this.txtprod_id = new System.Windows.Forms.TextBox();
            this.lblfeedtype = new System.Windows.Forms.Label();
            this.txtFeedCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.string_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uniquedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.Black;
            this.chkAll.Location = new System.Drawing.Point(804, 65);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(117, 17);
            this.chkAll.TabIndex = 45;
            this.chkAll.Text = "Select/Deselect All";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(183, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 44;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.string_id,
            this.Emp_Number,
            this.Emp_Name,
            this.rp_feed_code,
            this.Department,
            this.Position,
            this.Status,
            this.TotalPack,
            this.PrintCount,
            this.ID,
            this.uniquedate,
            this.Packby});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Control;
            this.dataView.Location = new System.Drawing.Point(4, 84);
            this.dataView.Name = "dataView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersWidth = 40;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(934, 305);
            this.dataView.TabIndex = 46;
            this.dataView.CurrentCellChanged += new System.EventHandler(this.dataView_CurrentCellChanged);
            this.dataView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            this.dataView.DoubleClick += new System.EventHandler(this.dataView_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.bunifuThinButton21);
            this.groupBox1.Controls.Add(this.bunifuThinButton218);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtfooter);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbHR_OIC);
            this.groupBox1.Controls.Add(this.dt);
            this.groupBox1.Location = new System.Drawing.Point(7, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 65);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
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
            this.btnclose.Location = new System.Drawing.Point(408, 78);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 34);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Visible = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(461, 86);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Zebra Paper";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
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
            this.bunifuThinButton21.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.bunifuThinButton218.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton218.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton218.IdleBorderThickness = 1;
            this.bunifuThinButton218.IdleCornerRadius = 20;
            this.bunifuThinButton218.IdleFillColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton218.IdleForecolor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton218.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton218.Location = new System.Drawing.Point(674, 67);
            this.bunifuThinButton218.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton218.Name = "bunifuThinButton218";
            this.bunifuThinButton218.Size = new System.Drawing.Size(84, 34);
            this.bunifuThinButton218.TabIndex = 366;
            this.bunifuThinButton218.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton218.Visible = false;
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
            this.button1.Location = new System.Drawing.Point(399, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 47;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtfooter
            // 
            this.txtfooter.BackColor = System.Drawing.SystemColors.Control;
            this.txtfooter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfooter.Enabled = false;
            this.txtfooter.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfooter.Location = new System.Drawing.Point(138, 17);
            this.txtfooter.Multiline = true;
            this.txtfooter.Name = "txtfooter";
            this.txtfooter.Size = new System.Drawing.Size(620, 44);
            this.txtfooter.TabIndex = 46;
            this.txtfooter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(364, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 44);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Type Printer Layout";
            this.groupBox2.Visible = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Description :";
            this.label4.Visible = false;
            // 
            // cmbPos
            // 
            this.cmbPos.FormattingEnabled = true;
            this.cmbPos.Items.AddRange(new object[] {
            "HR Manager"});
            this.cmbPos.Location = new System.Drawing.Point(91, 138);
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(281, 21);
            this.cmbPos.TabIndex = 41;
            this.cmbPos.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Company Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Approved by:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Valid Until";
            this.label1.Visible = false;
            // 
            // cmbHR_OIC
            // 
            this.cmbHR_OIC.FormattingEnabled = true;
            this.cmbHR_OIC.Items.AddRange(new object[] {
            "Rollaine C. Palo"});
            this.cmbHR_OIC.Location = new System.Drawing.Point(91, 110);
            this.cmbHR_OIC.Name = "cmbHR_OIC";
            this.cmbHR_OIC.Size = new System.Drawing.Size(281, 21);
            this.cmbHR_OIC.TabIndex = 6;
            this.cmbHR_OIC.Visible = false;
            // 
            // dt
            // 
            this.dt.CustomFormat = "MMMM dd, yyyy";
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt.Location = new System.Drawing.Point(91, 86);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(281, 20);
            this.dt.TabIndex = 1;
            this.dt.Value = new System.DateTime(2019, 1, 31, 0, 0, 0, 0);
            this.dt.Visible = false;
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "CLOSE";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.Orange;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.Location = new System.Drawing.Point(950, 405);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(84, 34);
            this.bunifuThinButton22.TabIndex = 368;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Click += new System.EventHandler(this.bunifuThinButton22_Click);
            // 
            // crV1
            // 
            this.crV1.ActiveViewIndex = -1;
            this.crV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crV1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crV1.Location = new System.Drawing.Point(766, 264);
            this.crV1.Margin = new System.Windows.Forms.Padding(1);
            this.crV1.Name = "crV1";
            this.crV1.Size = new System.Drawing.Size(20, 63);
            this.crV1.TabIndex = 48;
            this.crV1.ToolPanelWidth = 75;
            this.crV1.Visible = false;
            // 
            // txtsearchcode
            // 
            this.txtsearchcode.Location = new System.Drawing.Point(342, 41);
            this.txtsearchcode.Name = "txtsearchcode";
            this.txtsearchcode.Size = new System.Drawing.Size(122, 20);
            this.txtsearchcode.TabIndex = 49;
            this.txtsearchcode.Visible = false;
            this.txtsearchcode.TextChanged += new System.EventHandler(this.txtsearchcode_TextChanged);
            // 
            // hr_bakDataSet1
            // 
            this.hr_bakDataSet1.DataSetName = "hr_bakDataSet";
            this.hr_bakDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 381;
            this.label8.Text = "Total Records :";
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
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // txtluffy
            // 
            this.txtluffy.AutoSize = true;
            this.txtluffy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtluffy.Location = new System.Drawing.Point(95, 65);
            this.txtluffy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtluffy.Name = "txtluffy";
            this.txtluffy.Size = new System.Drawing.Size(55, 13);
            this.txtluffy.TabIndex = 395;
            this.txtluffy.Text = "00000000";
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
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.metroButton4);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 58);
            this.panel2.TabIndex = 545;
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
            this.btngreaterthan.Location = new System.Drawing.Point(677, 2);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(53, 41);
            this.btngreaterthan.TabIndex = 641;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            this.btngreaterthan.Click += new System.EventHandler(this.btngreaterthan_Click);
            // 
            // txtmare
            // 
            this.txtmare.Location = new System.Drawing.Point(464, 4);
            this.txtmare.Name = "txtmare";
            this.txtmare.Size = new System.Drawing.Size(122, 20);
            this.txtmare.TabIndex = 50;
            this.txtmare.Visible = false;
            this.txtmare.TextChanged += new System.EventHandler(this.txtmare_TextChanged);
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
            this.dateTimePicker12.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(399, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Repacking  Barcode Raw Material";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(447, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 14);
            this.label6.TabIndex = 395;
            this.label6.Text = "Generate Repacking Barcode";
            this.label6.Visible = false;
            // 
            // lblfound
            // 
            this.lblfound.AutoSize = true;
            this.lblfound.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfound.ForeColor = System.Drawing.Color.Black;
            this.lblfound.Location = new System.Drawing.Point(226, 403);
            this.lblfound.Name = "lblfound";
            this.lblfound.Size = new System.Drawing.Size(27, 28);
            this.lblfound.TabIndex = 6;
            this.lblfound.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 381;
            this.label5.Text = "Total Records :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(7, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 28);
            this.label7.TabIndex = 546;
            this.label7.Text = "TOTAL RECORDS:";
            // 
            // btnrefresh
            // 
            this.btnrefresh.ActiveBorderThickness = 1;
            this.btnrefresh.ActiveCornerRadius = 20;
            this.btnrefresh.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnrefresh.ActiveForecolor = System.Drawing.SystemColors.Control;
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
            this.btnrefresh.Location = new System.Drawing.Point(742, 405);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(84, 34);
            this.btnrefresh.TabIndex = 547;
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprod.Location = new System.Drawing.Point(165, 65);
            this.lblprod.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(78, 13);
            this.lblprod.TabIndex = 548;
            this.lblprod.Text = "Production ID :";
            this.lblprod.Visible = false;
            // 
            // txtprod_id
            // 
            this.txtprod_id.Location = new System.Drawing.Point(257, 62);
            this.txtprod_id.Name = "txtprod_id";
            this.txtprod_id.Size = new System.Drawing.Size(122, 20);
            this.txtprod_id.TabIndex = 549;
            this.txtprod_id.Visible = false;
            this.txtprod_id.TextChanged += new System.EventHandler(this.txtprod_id_TextChanged);
            // 
            // lblfeedtype
            // 
            this.lblfeedtype.AutoSize = true;
            this.lblfeedtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfeedtype.Location = new System.Drawing.Point(389, 65);
            this.lblfeedtype.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblfeedtype.Name = "lblfeedtype";
            this.lblfeedtype.Size = new System.Drawing.Size(65, 13);
            this.lblfeedtype.TabIndex = 550;
            this.lblfeedtype.Text = "Feed Code :";
            this.lblfeedtype.Visible = false;
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.Location = new System.Drawing.Point(467, 63);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(122, 20);
            this.txtFeedCode.TabIndex = 551;
            this.txtFeedCode.Visible = false;
            this.txtFeedCode.TextChanged += new System.EventHandler(this.txtFeedCode_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(594, 66);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 552;
            this.label12.Text = "Item Code :";
            this.label12.Visible = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(664, 63);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(122, 20);
            this.txtItemCode.TabIndex = 553;
            this.txtItemCode.Visible = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "FALSE";
            this.selected.HeaderText = "SELECTED";
            this.selected.MinimumWidth = 12;
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "TRUE";
            this.selected.Width = 50;
            // 
            // string_id
            // 
            this.string_id.DataPropertyName = "string_id";
            this.string_id.HeaderText = "BARCODE ID";
            this.string_id.Name = "string_id";
            // 
            // Emp_Number
            // 
            this.Emp_Number.DataPropertyName = "Emp_Number";
            this.Emp_Number.HeaderText = "ITEM CODE";
            this.Emp_Number.MinimumWidth = 12;
            this.Emp_Number.Name = "Emp_Number";
            this.Emp_Number.Width = 130;
            // 
            // Emp_Name
            // 
            this.Emp_Name.DataPropertyName = "Name";
            this.Emp_Name.HeaderText = "DESCRIPTION";
            this.Emp_Name.MinimumWidth = 12;
            this.Emp_Name.Name = "Emp_Name";
            this.Emp_Name.Width = 170;
            // 
            // rp_feed_code
            // 
            this.rp_feed_code.DataPropertyName = "rp_feed_code";
            this.rp_feed_code.HeaderText = "FEED CODE";
            this.rp_feed_code.Name = "rp_feed_code";
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "MFG DATE";
            this.Department.MinimumWidth = 12;
            this.Department.Name = "Department";
            this.Department.Width = 250;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "EXPIRY DATE";
            this.Position.MinimumWidth = 12;
            this.Position.Name = "Position";
            this.Position.Width = 250;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "DAYS";
            this.Status.MinimumWidth = 12;
            this.Status.Name = "Status";
            this.Status.Visible = false;
            this.Status.Width = 50;
            // 
            // TotalPack
            // 
            this.TotalPack.DataPropertyName = "TotalPack";
            this.TotalPack.HeaderText = "TOTALPACK";
            this.TotalPack.MinimumWidth = 12;
            this.TotalPack.Name = "TotalPack";
            this.TotalPack.Width = 70;
            // 
            // PrintCount
            // 
            this.PrintCount.DataPropertyName = "PrintCount";
            this.PrintCount.HeaderText = "PRINT COUNT";
            this.PrintCount.MinimumWidth = 12;
            this.PrintCount.Name = "PrintCount";
            this.PrintCount.Width = 50;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "PRIMARYKEY";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Width = 50;
            // 
            // uniquedate
            // 
            this.uniquedate.DataPropertyName = "uniquedate";
            this.uniquedate.HeaderText = "RepackDate";
            this.uniquedate.Name = "uniquedate";
            this.uniquedate.Visible = false;
            // 
            // Packby
            // 
            this.Packby.DataPropertyName = "Packby";
            this.Packby.HeaderText = "REPACKBY";
            this.Packby.MinimumWidth = 12;
            this.Packby.Name = "Packby";
            this.Packby.Width = 170;
            // 
            // frmGenerateRepackingBarcodeID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(942, 438);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFeedCode);
            this.Controls.Add(this.lblfeedtype);
            this.Controls.Add(this.txtprod_id);
            this.Controls.Add(this.lblprod);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblfound);
            this.Controls.Add(this.txtluffy);
            this.Controls.Add(this.bunifuThinButton22);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.crV1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.chkAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateRepackingBarcodeID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Repacking Barcode ID";
            this.Load += new System.EventHandler(this.frmGenerateRepackingBarcodeID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtfooter;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crV1;
        private System.Windows.Forms.TextBox txtsearchcode;
        private hr_bakDataSet hr_bakDataSet1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton218;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Label txtluffy;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker12;
        internal System.Windows.Forms.Label lblfound;
        private System.Windows.Forms.TextBox txtmare;
        internal System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuThinButton2 btnrefresh;
        private System.Windows.Forms.Label lblprod;
        private System.Windows.Forms.TextBox txtprod_id;
        private System.Windows.Forms.Label lblfeedtype;
        private System.Windows.Forms.TextBox txtFeedCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn string_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn uniquedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packby;
    }
}