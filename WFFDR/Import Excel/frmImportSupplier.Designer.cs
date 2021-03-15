namespace WFFDR
{
    partial class frmImportSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportSupplier));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.bunifuUpload = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuBrowse = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuStartImport = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtdatenow = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.bunifuThinButton211 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplieridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdfsupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hr_bakDataSet = new WFFDR.hr_bakDataSet();
            this.rdf_supplierTableAdapter = new WFFDR.hr_bakDataSetTableAdapters.rdf_supplierTableAdapter();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdfsupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.metroButton1);
            this.panel4.Controls.Add(this.bunifuUpload);
            this.panel4.Controls.Add(this.bunifuBrowse);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.bunifuThinButton21);
            this.panel4.Controls.Add(this.bunifuStartImport);
            this.panel4.Controls.Add(this.txtdatenow);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtsearch);
            this.panel4.Controls.Add(this.btnbrowse);
            this.panel4.Controls.Add(this.cboSheet);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtFilename);
            this.panel4.Controls.Add(this.bunifuThinButton211);
            this.panel4.Controls.Add(this.bunifuThinButton22);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 532);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(656, 125);
            this.panel4.TabIndex = 16;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(328, 1);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(39, 29);
            this.metroButton1.TabIndex = 379;
            this.metroButton1.Text = "metroButton1";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Visible = false;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // bunifuUpload
            // 
            this.bunifuUpload.ActiveBorderThickness = 1;
            this.bunifuUpload.ActiveCornerRadius = 20;
            this.bunifuUpload.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuUpload.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuUpload.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuUpload.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuUpload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuUpload.BackgroundImage")));
            this.bunifuUpload.ButtonText = "SAVE";
            this.bunifuUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuUpload.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuUpload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuUpload.IdleBorderThickness = 1;
            this.bunifuUpload.IdleCornerRadius = 20;
            this.bunifuUpload.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuUpload.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuUpload.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuUpload.Location = new System.Drawing.Point(513, 75);
            this.bunifuUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuUpload.Name = "bunifuUpload";
            this.bunifuUpload.Size = new System.Drawing.Size(74, 32);
            this.bunifuUpload.TabIndex = 378;
            this.bunifuUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuUpload.Visible = false;
            this.bunifuUpload.Click += new System.EventHandler(this.bunifuUpload_Click);
            // 
            // bunifuBrowse
            // 
            this.bunifuBrowse.ActiveBorderThickness = 1;
            this.bunifuBrowse.ActiveCornerRadius = 20;
            this.bunifuBrowse.ActiveFillColor = System.Drawing.Color.Fuchsia;
            this.bunifuBrowse.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuBrowse.ActiveLineColor = System.Drawing.Color.Fuchsia;
            this.bunifuBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuBrowse.BackgroundImage")));
            this.bunifuBrowse.ButtonText = "-------";
            this.bunifuBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuBrowse.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuBrowse.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuBrowse.IdleBorderThickness = 1;
            this.bunifuBrowse.IdleCornerRadius = 20;
            this.bunifuBrowse.IdleFillColor = System.Drawing.Color.White;
            this.bunifuBrowse.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuBrowse.IdleLineColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuBrowse.Location = new System.Drawing.Point(511, 34);
            this.bunifuBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuBrowse.Name = "bunifuBrowse";
            this.bunifuBrowse.Size = new System.Drawing.Size(74, 33);
            this.bunifuBrowse.TabIndex = 377;
            this.bunifuBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuBrowse.Visible = false;
            this.bunifuBrowse.Click += new System.EventHandler(this.bunifuBrowse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 349;
            this.label5.Text = "FILE NAME :";
            this.label5.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 350;
            this.label7.Text = "SHEET :";
            this.label7.Visible = false;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.Crimson;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.Crimson;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "STOP IMPORTING";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.Crimson;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.Location = new System.Drawing.Point(7, 7);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(120, 33);
            this.bunifuThinButton21.TabIndex = 348;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Visible = false;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // bunifuStartImport
            // 
            this.bunifuStartImport.ActiveBorderThickness = 1;
            this.bunifuStartImport.ActiveCornerRadius = 20;
            this.bunifuStartImport.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuStartImport.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuStartImport.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuStartImport.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuStartImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuStartImport.BackgroundImage")));
            this.bunifuStartImport.ButtonText = "START IMPORTING";
            this.bunifuStartImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuStartImport.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuStartImport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuStartImport.IdleBorderThickness = 1;
            this.bunifuStartImport.IdleCornerRadius = 20;
            this.bunifuStartImport.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuStartImport.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuStartImport.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuStartImport.Location = new System.Drawing.Point(6, 5);
            this.bunifuStartImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuStartImport.Name = "bunifuStartImport";
            this.bunifuStartImport.Size = new System.Drawing.Size(120, 33);
            this.bunifuStartImport.TabIndex = 347;
            this.bunifuStartImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuStartImport.Click += new System.EventHandler(this.bunifuStartImport_Click);
            // 
            // txtdatenow
            // 
            this.txtdatenow.BackColor = System.Drawing.Color.White;
            this.txtdatenow.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdatenow.Location = new System.Drawing.Point(737, 40);
            this.txtdatenow.Multiline = true;
            this.txtdatenow.Name = "txtdatenow";
            this.txtdatenow.Size = new System.Drawing.Size(205, 22);
            this.txtdatenow.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(1281, 17);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 22);
            this.textBox3.TabIndex = 12;
            this.textBox3.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(972, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 22);
            this.textBox2.TabIndex = 11;
            this.textBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(885, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Pending :";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1190, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pending Today :";
            this.label2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(1125, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1037, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Pending :";
            this.label1.Visible = false;
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.White;
            this.txtsearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsearch.Location = new System.Drawing.Point(819, 19);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(60, 22);
            this.txtsearch.TabIndex = 6;
            this.txtsearch.Visible = false;
            // 
            // btnbrowse
            // 
            this.btnbrowse.BackColor = System.Drawing.Color.White;
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.Location = new System.Drawing.Point(239, 1);
            this.btnbrowse.Margin = new System.Windows.Forms.Padding(1);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(68, 20);
            this.btnbrowse.TabIndex = 5;
            this.btnbrowse.Text = "........";
            this.btnbrowse.UseVisualStyleBackColor = false;
            this.btnbrowse.Visible = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // cboSheet
            // 
            this.cboSheet.Enabled = false;
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(137, 86);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(1);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(354, 21);
            this.cboSheet.TabIndex = 3;
            this.cboSheet.Visible = false;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            this.cboSheet.SelectedValueChanged += new System.EventHandler(this.cboSheet_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(705, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Records :";
            this.label3.Visible = false;
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.Color.White;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(141, 42);
            this.txtFilename.Multiline = true;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(355, 20);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.Visible = false;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // bunifuThinButton211
            // 
            this.bunifuThinButton211.ActiveBorderThickness = 1;
            this.bunifuThinButton211.ActiveCornerRadius = 20;
            this.bunifuThinButton211.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton211.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton211.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton211.BackgroundImage")));
            this.bunifuThinButton211.ButtonText = "";
            this.bunifuThinButton211.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton211.Enabled = false;
            this.bunifuThinButton211.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton211.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton211.IdleBorderThickness = 1;
            this.bunifuThinButton211.IdleCornerRadius = 20;
            this.bunifuThinButton211.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton211.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton211.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton211.Location = new System.Drawing.Point(126, 33);
            this.bunifuThinButton211.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton211.Name = "bunifuThinButton211";
            this.bunifuThinButton211.Size = new System.Drawing.Size(374, 37);
            this.bunifuThinButton211.TabIndex = 375;
            this.bunifuThinButton211.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton211.Visible = false;
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Enabled = false;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton22.Location = new System.Drawing.Point(126, 76);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(374, 40);
            this.bunifuThinButton22.TabIndex = 376;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Visible = false;
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_table.AutoGenerateColumns = false;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_table.ColumnHeadersHeight = 25;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.supplierDataGridViewTextBoxColumn,
            this.supplieridDataGridViewTextBoxColumn});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_table.DataSource = this.rdfsupplierBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_table.Location = new System.Drawing.Point(0, 0);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_table.RowHeadersVisible = false;
            this.dgv_table.RowHeadersWidth = 102;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(656, 532);
            this.dgv_table.TabIndex = 36;
            this.dgv_table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_table_CellFormatting);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "#";
            this.NO.MinimumWidth = 12;
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.supplierDataGridViewTextBoxColumn.DataPropertyName = "supplier";
            this.supplierDataGridViewTextBoxColumn.FillWeight = 182.3529F;
            this.supplierDataGridViewTextBoxColumn.HeaderText = "SUPPLIER";
            this.supplierDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.supplierDataGridViewTextBoxColumn.Name = "supplierDataGridViewTextBoxColumn";
            this.supplierDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplieridDataGridViewTextBoxColumn
            // 
            this.supplieridDataGridViewTextBoxColumn.DataPropertyName = "supplier_id";
            this.supplieridDataGridViewTextBoxColumn.FillWeight = 17.64706F;
            this.supplieridDataGridViewTextBoxColumn.HeaderText = "ID";
            this.supplieridDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.supplieridDataGridViewTextBoxColumn.Name = "supplieridDataGridViewTextBoxColumn";
            this.supplieridDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplieridDataGridViewTextBoxColumn.Visible = false;
            // 
            // rdfsupplierBindingSource
            // 
            this.rdfsupplierBindingSource.DataMember = "rdf_supplier";
            this.rdfsupplierBindingSource.DataSource = this.hr_bakDataSet;
            // 
            // hr_bakDataSet
            // 
            this.hr_bakDataSet.DataSetName = "hr_bakDataSet";
            this.hr_bakDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rdf_supplierTableAdapter
            // 
            this.rdf_supplierTableAdapter.ClearBeforeFill = true;
            // 
            // frmImportSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 657);
            this.Controls.Add(this.dgv_table);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportSupplier";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Supplier";
            this.Load += new System.EventHandler(this.frmImportSupplier_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdfsupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.TextBox txtdatenow;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.ComboBox cboSheet;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.DataGridView dgv_table;
        private hr_bakDataSet hr_bakDataSet;
        private System.Windows.Forms.BindingSource rdfsupplierBindingSource;
        private hr_bakDataSetTableAdapters.rdf_supplierTableAdapter rdf_supplierTableAdapter;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuStartImport;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton211;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuBrowse;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuUpload;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieridDataGridViewTextBoxColumn;
    }
}