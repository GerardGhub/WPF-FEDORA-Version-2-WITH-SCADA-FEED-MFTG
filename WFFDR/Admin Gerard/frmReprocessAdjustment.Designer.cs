namespace WFFDR
{
    partial class frmReprocessAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprocessAdjustment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fg_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmx_id_string = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_adv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_bags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fg_options = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltotaldata = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.txtprodplan = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbags = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtfg_id = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtproductionid = new System.Windows.Forms.TextBox();
            this.txtfeedcode = new System.Windows.Forms.TextBox();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_fg_repack = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtprod_id = new System.Windows.Forms.TextBox();
            this.lbltotalcount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fg_repack)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataView);
            this.groupBox1.Controls.Add(this.lbltotaldata);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 310);
            this.groupBox1.TabIndex = 676;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Reprocess";
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.fg_id,
            this.bmx_id_string,
            this.prod_adv,
            this.fg_feed_code,
            this.fg_bags,
            this.fg_proddate,
            this.fg_options,
            this.status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Control;
            this.dataView.Location = new System.Drawing.Point(7, 20);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersWidth = 60;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(940, 281);
            this.dataView.TabIndex = 550;
            this.dataView.CurrentCellChanged += new System.EventHandler(this.dataView_CurrentCellChanged);
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
            // fg_id
            // 
            this.fg_id.DataPropertyName = "fg_id";
            this.fg_id.HeaderText = "FG ID";
            this.fg_id.Name = "fg_id";
            this.fg_id.ReadOnly = true;
            // 
            // bmx_id_string
            // 
            this.bmx_id_string.DataPropertyName = "bmx_id_string";
            this.bmx_id_string.HeaderText = "BARCODE";
            this.bmx_id_string.Name = "bmx_id_string";
            this.bmx_id_string.ReadOnly = true;
            // 
            // prod_adv
            // 
            this.prod_adv.DataPropertyName = "prod_adv";
            this.prod_adv.HeaderText = "PROD ID";
            this.prod_adv.Name = "prod_adv";
            this.prod_adv.ReadOnly = true;
            // 
            // fg_feed_code
            // 
            this.fg_feed_code.DataPropertyName = "fg_feed_code";
            this.fg_feed_code.HeaderText = "FEED CODE";
            this.fg_feed_code.Name = "fg_feed_code";
            this.fg_feed_code.ReadOnly = true;
            // 
            // fg_bags
            // 
            this.fg_bags.DataPropertyName = "fg_bags";
            this.fg_bags.HeaderText = "BAGS";
            this.fg_bags.Name = "fg_bags";
            this.fg_bags.ReadOnly = true;
            // 
            // fg_proddate
            // 
            this.fg_proddate.DataPropertyName = "fg_proddate";
            this.fg_proddate.HeaderText = "PRODPLAN";
            this.fg_proddate.Name = "fg_proddate";
            this.fg_proddate.ReadOnly = true;
            // 
            // fg_options
            // 
            this.fg_options.DataPropertyName = "fg_options";
            this.fg_options.HeaderText = "OPTIONS";
            this.fg_options.Name = "fg_options";
            this.fg_options.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // lbltotaldata
            // 
            this.lbltotaldata.AutoSize = true;
            this.lbltotaldata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbltotaldata.ForeColor = System.Drawing.Color.Black;
            this.lbltotaldata.Location = new System.Drawing.Point(111, 1);
            this.lbltotaldata.Name = "lbltotaldata";
            this.lbltotaldata.Size = new System.Drawing.Size(42, 13);
            this.lbltotaldata.TabIndex = 656;
            this.lbltotaldata.Text = "BAGS :";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtaddedby);
            this.GroupBox3.Controls.Add(this.txtprodplan);
            this.GroupBox3.Controls.Add(this.label16);
            this.GroupBox3.Controls.Add(this.txtstatus);
            this.GroupBox3.Controls.Add(this.label15);
            this.GroupBox3.Controls.Add(this.txtbags);
            this.GroupBox3.Controls.Add(this.label13);
            this.GroupBox3.Controls.Add(this.txtfg_id);
            this.GroupBox3.Controls.Add(this.label11);
            this.GroupBox3.Controls.Add(this.label12);
            this.GroupBox3.Controls.Add(this.label14);
            this.GroupBox3.Controls.Add(this.txtproductionid);
            this.GroupBox3.Controls.Add(this.txtfeedcode);
            this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(28, 9);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(837, 89);
            this.GroupBox3.TabIndex = 677;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Information Ledger";
            // 
            // txtaddedby
            // 
            this.txtaddedby.BackColor = System.Drawing.SystemColors.Window;
            this.txtaddedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddedby.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddedby.Location = new System.Drawing.Point(270, 0);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.ReadOnly = true;
            this.txtaddedby.Size = new System.Drawing.Size(157, 22);
            this.txtaddedby.TabIndex = 490;
            this.txtaddedby.Visible = false;
            // 
            // txtprodplan
            // 
            this.txtprodplan.BackColor = System.Drawing.Color.White;
            this.txtprodplan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprodplan.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprodplan.Location = new System.Drawing.Point(431, 25);
            this.txtprodplan.Name = "txtprodplan";
            this.txtprodplan.ReadOnly = true;
            this.txtprodplan.Size = new System.Drawing.Size(124, 22);
            this.txtprodplan.TabIndex = 489;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(610, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 488;
            this.label16.Text = "Status:";
            // 
            // txtstatus
            // 
            this.txtstatus.BackColor = System.Drawing.Color.White;
            this.txtstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstatus.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstatus.Location = new System.Drawing.Point(664, 56);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.Size = new System.Drawing.Size(156, 22);
            this.txtstatus.TabIndex = 405;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(614, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 487;
            this.label15.Text = "Bags :";
            // 
            // txtbags
            // 
            this.txtbags.BackColor = System.Drawing.SystemColors.Window;
            this.txtbags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbags.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbags.Location = new System.Drawing.Point(664, 25);
            this.txtbags.Name = "txtbags";
            this.txtbags.ReadOnly = true;
            this.txtbags.Size = new System.Drawing.Size(157, 22);
            this.txtbags.TabIndex = 426;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(307, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 422;
            this.label13.Text = "Finished Goods ID :";
            // 
            // txtfg_id
            // 
            this.txtfg_id.BackColor = System.Drawing.Color.White;
            this.txtfg_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfg_id.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfg_id.Location = new System.Drawing.Point(431, 55);
            this.txtfg_id.Name = "txtfg_id";
            this.txtfg_id.ReadOnly = true;
            this.txtfg_id.Size = new System.Drawing.Size(124, 22);
            this.txtfg_id.TabIndex = 486;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(323, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 421;
            this.label11.Text = "Production Plan :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Production ID :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Feed Code :";
            // 
            // txtproductionid
            // 
            this.txtproductionid.BackColor = System.Drawing.SystemColors.Window;
            this.txtproductionid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtproductionid.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductionid.Location = new System.Drawing.Point(110, 24);
            this.txtproductionid.Name = "txtproductionid";
            this.txtproductionid.ReadOnly = true;
            this.txtproductionid.Size = new System.Drawing.Size(157, 22);
            this.txtproductionid.TabIndex = 420;
            // 
            // txtfeedcode
            // 
            this.txtfeedcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtfeedcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfeedcode.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfeedcode.Location = new System.Drawing.Point(110, 54);
            this.txtfeedcode.Name = "txtfeedcode";
            this.txtfeedcode.ReadOnly = true;
            this.txtfeedcode.Size = new System.Drawing.Size(157, 22);
            this.txtfeedcode.TabIndex = 391;
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.BackColor = System.Drawing.SystemColors.Window;
            this.btnAdjustment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("btnAdjustment.Image")));
            this.btnAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdjustment.Location = new System.Drawing.Point(874, 70);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(82, 28);
            this.btnAdjustment.TabIndex = 691;
            this.btnAdjustment.Text = "&Adjust";
            this.btnAdjustment.UseVisualStyleBackColor = false;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgv_fg_repack);
            this.groupBox2.Controls.Add(this.txtprod_id);
            this.groupBox2.Controls.Add(this.lbltotalcount);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(953, 190);
            this.groupBox2.TabIndex = 692;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result List of Reprocess";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 491;
            this.label2.Text = "Production ID :";
            // 
            // dgv_fg_repack
            // 
            this.dgv_fg_repack.AllowUserToAddRows = false;
            this.dgv_fg_repack.AllowUserToDeleteRows = false;
            this.dgv_fg_repack.AllowUserToResizeColumns = false;
            this.dgv_fg_repack.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_fg_repack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_fg_repack.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_fg_repack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_fg_repack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_fg_repack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fg_repack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_fg_repack.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_fg_repack.EnableHeadersVisualStyles = false;
            this.dgv_fg_repack.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_fg_repack.Location = new System.Drawing.Point(6, 45);
            this.dgv_fg_repack.Name = "dgv_fg_repack";
            this.dgv_fg_repack.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_fg_repack.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_fg_repack.RowHeadersWidth = 60;
            this.dgv_fg_repack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_fg_repack.Size = new System.Drawing.Size(940, 133);
            this.dgv_fg_repack.TabIndex = 550;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "FALSE";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Selected";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 12;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.TrueValue = "TRUE";
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fg_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "FG ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "bmx_id_string";
            this.dataGridViewTextBoxColumn2.HeaderText = "BARCODE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "prod_adv";
            this.dataGridViewTextBoxColumn3.HeaderText = "PROD ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fg_feed_code";
            this.dataGridViewTextBoxColumn4.HeaderText = "FEED CODE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fg_bags";
            this.dataGridViewTextBoxColumn5.HeaderText = "BAGS";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fg_proddate";
            this.dataGridViewTextBoxColumn6.HeaderText = "PRODPLAN";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "fg_options";
            this.dataGridViewTextBoxColumn7.HeaderText = "OPTIONS";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "status";
            this.dataGridViewTextBoxColumn8.HeaderText = "STATUS";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // txtprod_id
            // 
            this.txtprod_id.BackColor = System.Drawing.SystemColors.Window;
            this.txtprod_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprod_id.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprod_id.Location = new System.Drawing.Point(106, 17);
            this.txtprod_id.Name = "txtprod_id";
            this.txtprod_id.Size = new System.Drawing.Size(157, 22);
            this.txtprod_id.TabIndex = 492;
            this.txtprod_id.TextChanged += new System.EventHandler(this.txtprod_id_TextChanged);
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.AutoSize = true;
            this.lbltotalcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbltotalcount.ForeColor = System.Drawing.Color.Black;
            this.lbltotalcount.Location = new System.Drawing.Point(154, 1);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(42, 13);
            this.lbltotalcount.TabIndex = 656;
            this.lbltotalcount.Text = "BAGS :";
            // 
            // frmReprocessAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(969, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAdjustment);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReprocessAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reprocess Adjustment";
            this.Load += new System.EventHandler(this.frmProdMonitoring_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fg_repack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataView;
        internal System.Windows.Forms.Label lbltotaldata;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtstatus;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtbags;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtfg_id;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtproductionid;
        internal System.Windows.Forms.TextBox txtfeedcode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmx_id_string;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_adv;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_bags;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fg_options;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        internal System.Windows.Forms.TextBox txtprodplan;
        internal System.Windows.Forms.Button btnAdjustment;
        internal System.Windows.Forms.TextBox txtaddedby;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_fg_repack;
        internal System.Windows.Forms.TextBox txtprod_id;
        internal System.Windows.Forms.Label lbltotalcount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}