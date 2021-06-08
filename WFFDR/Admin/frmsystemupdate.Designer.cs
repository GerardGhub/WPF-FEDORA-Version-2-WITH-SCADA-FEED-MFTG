namespace WFFDR
{
    partial class frmsystemupdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsystemupdate));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.dgvUnread = new System.Windows.Forms.DataGridView();
            this.update_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_objective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnNew = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtuseridproc = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtmodule = new System.Windows.Forms.ComboBox();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtupdatedate = new System.Windows.Forms.DateTimePicker();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.txtobjective = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.btnAdd = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnread)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Small;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.metroTabControl1.Location = new System.Drawing.Point(5, 6);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1069, 316);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.dgvUnread);
            this.metroTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 5;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 34);
            this.metroTabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1061, 278);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "SYSTEM UPDATE FOR TODAY                        ";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 5;
            // 
            // dgvUnread
            // 
            this.dgvUnread.AllowUserToAddRows = false;
            this.dgvUnread.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgvUnread.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnread.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUnread.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnread.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnread.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnread.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.update_id,
            this.module,
            this.update_remarks,
            this.update_objective,
            this.update_date,
            this.added_by});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnread.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUnread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnread.EnableHeadersVisualStyles = false;
            this.dgvUnread.GridColor = System.Drawing.SystemColors.Control;
            this.dgvUnread.Location = new System.Drawing.Point(0, 0);
            this.dgvUnread.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUnread.Name = "dgvUnread";
            this.dgvUnread.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnread.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUnread.RowHeadersWidth = 50;
            this.dgvUnread.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUnread.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnread.Size = new System.Drawing.Size(1061, 278);
            this.dgvUnread.TabIndex = 428;
            this.dgvUnread.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnread_CellClick);
            this.dgvUnread.CurrentCellChanged += new System.EventHandler(this.dgvUnread_CurrentCellChanged);
            this.dgvUnread.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUnread_RowPostPaint);
            // 
            // update_id
            // 
            this.update_id.DataPropertyName = "update_id";
            this.update_id.HeaderText = "ID";
            this.update_id.MinimumWidth = 12;
            this.update_id.Name = "update_id";
            this.update_id.ReadOnly = true;
            this.update_id.Width = 50;
            // 
            // module
            // 
            this.module.DataPropertyName = "module";
            this.module.HeaderText = "MODULE";
            this.module.MinimumWidth = 12;
            this.module.Name = "module";
            this.module.ReadOnly = true;
            this.module.Width = 200;
            // 
            // update_remarks
            // 
            this.update_remarks.DataPropertyName = "update_remarks";
            this.update_remarks.HeaderText = "REMARKS";
            this.update_remarks.MinimumWidth = 12;
            this.update_remarks.Name = "update_remarks";
            this.update_remarks.ReadOnly = true;
            this.update_remarks.Width = 250;
            // 
            // update_objective
            // 
            this.update_objective.DataPropertyName = "update_objective";
            this.update_objective.HeaderText = "OBJECTIVE";
            this.update_objective.MinimumWidth = 12;
            this.update_objective.Name = "update_objective";
            this.update_objective.ReadOnly = true;
            this.update_objective.Width = 250;
            // 
            // update_date
            // 
            this.update_date.DataPropertyName = "update_date";
            this.update_date.HeaderText = "UPDATE_DATE";
            this.update_date.MinimumWidth = 12;
            this.update_date.Name = "update_date";
            this.update_date.ReadOnly = true;
            this.update_date.Width = 90;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ADDED BY";
            this.added_by.MinimumWidth = 12;
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            this.added_by.Width = 120;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 5;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 34);
            this.metroTabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1061, 278);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "          LIST OF SYSTEM UPDATE                     ";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bunifuThinButton23);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtuseridproc);
            this.groupBox1.Controls.Add(this.txtid);
            this.groupBox1.Controls.Add(this.txtmodule);
            this.groupBox1.Controls.Add(this.bunifuThinButton22);
            this.groupBox1.Controls.Add(this.bunifuThinButton21);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtupdatedate);
            this.groupBox1.Controls.Add(this.txtaddedby);
            this.groupBox1.Controls.Add(this.txtobjective);
            this.groupBox1.Controls.Add(this.txtremarks);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(8, 340);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(1077, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Update Information Field";
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBorderThickness = 1;
            this.btnCancel.ActiveCornerRadius = 20;
            this.btnCancel.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancel.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnCancel.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "CANCEL";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 20;
            this.btnCancel.IdleFillColor = System.Drawing.Color.Orange;
            this.btnCancel.IdleForecolor = System.Drawing.SystemColors.Window;
            this.btnCancel.IdleLineColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(750, 100);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 41);
            this.btnCancel.TabIndex = 439;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.ActiveBorderThickness = 1;
            this.btnNew.ActiveCornerRadius = 20;
            this.btnNew.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNew.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnNew.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNew.BackColor = System.Drawing.SystemColors.Window;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.ButtonText = "NEW";
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNew.IdleBorderThickness = 1;
            this.btnNew.IdleCornerRadius = 20;
            this.btnNew.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnNew.IdleForecolor = System.Drawing.SystemColors.Window;
            this.btnNew.IdleLineColor = System.Drawing.SystemColors.Window;
            this.btnNew.Location = new System.Drawing.Point(5, 100);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 41);
            this.btnNew.TabIndex = 438;
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtuseridproc
            // 
            this.txtuseridproc.Enabled = false;
            this.txtuseridproc.Location = new System.Drawing.Point(755, 101);
            this.txtuseridproc.Margin = new System.Windows.Forms.Padding(1);
            this.txtuseridproc.Name = "txtuseridproc";
            this.txtuseridproc.Size = new System.Drawing.Size(112, 22);
            this.txtuseridproc.TabIndex = 437;
            this.txtuseridproc.TextChanged += new System.EventHandler(this.txtuseridproc_TextChanged);
            // 
            // txtid
            // 
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(709, 87);
            this.txtid.Margin = new System.Windows.Forms.Padding(1);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(112, 22);
            this.txtid.TabIndex = 436;
            this.txtid.Visible = false;
            // 
            // txtmodule
            // 
            this.txtmodule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtmodule.Enabled = false;
            this.txtmodule.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodule.FormattingEnabled = true;
            this.txtmodule.Location = new System.Drawing.Point(153, 26);
            this.txtmodule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmodule.Name = "txtmodule";
            this.txtmodule.Size = new System.Drawing.Size(337, 27);
            this.txtmodule.TabIndex = 435;
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "IN-ACTIVE";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.Location = new System.Drawing.Point(596, 100);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(117, 41);
            this.bunifuThinButton22.TabIndex = 434;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Visible = false;
            this.bunifuThinButton22.Click += new System.EventHandler(this.bunifuThinButton22_Click);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "UPDATE";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.Location = new System.Drawing.Point(446, 100);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(117, 41);
            this.bunifuThinButton21.TabIndex = 433;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Visible = false;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 432;
            this.label4.Text = "Development Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 431;
            this.label3.Text = "Objective";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 430;
            this.label2.Text = "Remarks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 429;
            this.label1.Text = "Module Name :";
            // 
            // txtupdatedate
            // 
            this.txtupdatedate.Enabled = false;
            this.txtupdatedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtupdatedate.Location = new System.Drawing.Point(153, 64);
            this.txtupdatedate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtupdatedate.Name = "txtupdatedate";
            this.txtupdatedate.Size = new System.Drawing.Size(337, 22);
            this.txtupdatedate.TabIndex = 428;
            this.txtupdatedate.Value = new System.DateTime(2020, 3, 28, 0, 0, 0, 0);
            // 
            // txtaddedby
            // 
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Location = new System.Drawing.Point(739, 110);
            this.txtaddedby.Margin = new System.Windows.Forms.Padding(1);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(112, 22);
            this.txtaddedby.TabIndex = 427;
            // 
            // txtobjective
            // 
            this.txtobjective.Enabled = false;
            this.txtobjective.Location = new System.Drawing.Point(605, 64);
            this.txtobjective.Margin = new System.Windows.Forms.Padding(1);
            this.txtobjective.Name = "txtobjective";
            this.txtobjective.Size = new System.Drawing.Size(443, 22);
            this.txtobjective.TabIndex = 425;
            // 
            // txtremarks
            // 
            this.txtremarks.Enabled = false;
            this.txtremarks.Location = new System.Drawing.Point(605, 31);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(1);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(443, 22);
            this.txtremarks.TabIndex = 424;
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveBorderThickness = 1;
            this.btnAdd.ActiveCornerRadius = 20;
            this.btnAdd.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnAdd.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.BackColor = System.Drawing.SystemColors.Window;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.ButtonText = "ADD";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.IdleBorderThickness = 1;
            this.btnAdd.IdleCornerRadius = 20;
            this.btnAdd.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.IdleForecolor = System.Drawing.SystemColors.Window;
            this.btnAdd.IdleLineColor = System.Drawing.SystemColors.Window;
            this.btnAdd.Location = new System.Drawing.Point(152, 100);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 41);
            this.btnAdd.TabIndex = 423;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bunifuThinButton23
            // 
            this.bunifuThinButton23.ActiveBorderThickness = 1;
            this.bunifuThinButton23.ActiveCornerRadius = 20;
            this.bunifuThinButton23.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton23.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton23.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton23.BackgroundImage")));
            this.bunifuThinButton23.ButtonText = "EDIT";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 20;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.Location = new System.Drawing.Point(299, 100);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(117, 41);
            this.bunifuThinButton23.TabIndex = 440;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton23.Visible = false;
            this.bunifuThinButton23.Click += new System.EventHandler(this.bunifuThinButton23_Click);
            // 
            // frmsystemupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1099, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "frmsystemupdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Update";
            this.Load += new System.EventHandler(this.frmsystemupdate_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnread)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUnread;
        private System.Windows.Forms.TextBox txtaddedby;
        private System.Windows.Forms.TextBox txtobjective;
        private System.Windows.Forms.TextBox txtremarks;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAdd;
        private System.Windows.Forms.DateTimePicker txtupdatedate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.ComboBox txtmodule;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtuseridproc;
        private Bunifu.Framework.UI.BunifuThinButton2 btnNew;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn module;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_objective;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
    }
}