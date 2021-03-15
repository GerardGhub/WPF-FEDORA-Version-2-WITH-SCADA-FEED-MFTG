namespace WFFDR
{
    partial class frmImportRawMaterials
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportRawMaterials));
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.rdfmaterialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hr_bakDataSet = new WFFDR.hr_bakDataSet();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtdatenow = new System.Windows.Forms.TextBox();
            this.bunifuUpload = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton211 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.rdf_materialsTableAdapter = new WFFDR.hr_bakDataSetTableAdapters.rdf_materialsTableAdapter();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemgroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnoperation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdfmaterialsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
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
            this.item_code,
            this.itemidDataGridViewTextBoxColumn,
            this.itemdescriptionDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.itemgroupDataGridViewTextBoxColumn});
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_table.DataSource = this.rdfmaterialsBindingSource;
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
            this.dgv_table.RowHeadersWidth = 70;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(656, 550);
            this.dgv_table.TabIndex = 35;
            this.dgv_table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_table_CellFormatting);
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            this.dgv_table.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_table_RowPrePaint);
            // 
            // rdfmaterialsBindingSource
            // 
            this.rdfmaterialsBindingSource.DataMember = "rdf_materials";
            this.rdfmaterialsBindingSource.DataSource = this.hr_bakDataSet;
            // 
            // hr_bakDataSet
            // 
            this.hr_bakDataSet.DataSetName = "hr_bakDataSet";
            this.hr_bakDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.Color.White;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(99, 30);
            this.txtFilename.Multiline = true;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(413, 20);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // cboSheet
            // 
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.Enabled = false;
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(103, 64);
            this.cboSheet.Margin = new System.Windows.Forms.Padding(1);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(402, 21);
            this.cboSheet.TabIndex = 3;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            this.cboSheet.SelectedValueChanged += new System.EventHandler(this.cboSheet_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Sheet :";
            // 
            // btnbrowse
            // 
            this.btnbrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btnbrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnbrowse.FlatAppearance.BorderSize = 0;
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbrowse.Location = new System.Drawing.Point(548, 28);
            this.btnbrowse.Margin = new System.Windows.Forms.Padding(1);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(81, 25);
            this.btnbrowse.TabIndex = 5;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "File Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(718, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pending Today :";
            this.label2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(734, 108);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 22);
            this.textBox3.TabIndex = 12;
            this.textBox3.Visible = false;
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
            // bunifuUpload
            // 
            this.bunifuUpload.ActiveBorderThickness = 1;
            this.bunifuUpload.ActiveCornerRadius = 20;
            this.bunifuUpload.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuUpload.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuUpload.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuUpload.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuUpload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuUpload.BackgroundImage")));
            this.bunifuUpload.ButtonText = "UPLOAD";
            this.bunifuUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuUpload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuUpload.IdleBorderThickness = 1;
            this.bunifuUpload.IdleCornerRadius = 20;
            this.bunifuUpload.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bunifuUpload.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bunifuUpload.IdleLineColor = System.Drawing.SystemColors.Window;
            this.bunifuUpload.Location = new System.Drawing.Point(546, 60);
            this.bunifuUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuUpload.Name = "bunifuUpload";
            this.bunifuUpload.Size = new System.Drawing.Size(88, 33);
            this.bunifuUpload.TabIndex = 343;
            this.bunifuUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuUpload.Visible = false;
            this.bunifuUpload.Click += new System.EventHandler(this.bunifuUpload_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnoperation);
            this.panel4.Controls.Add(this.txtItemCode);
            this.panel4.Controls.Add(this.bunifuUpload);
            this.panel4.Controls.Add(this.txtdatenow);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnbrowse);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.cboSheet);
            this.panel4.Controls.Add(this.txtFilename);
            this.panel4.Controls.Add(this.bunifuThinButton21);
            this.panel4.Controls.Add(this.bunifuThinButton211);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 550);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(656, 107);
            this.panel4.TabIndex = 15;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Enabled = false;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 5;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.Location = new System.Drawing.Point(85, 54);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(435, 40);
            this.bunifuThinButton21.TabIndex = 376;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuThinButton211
            // 
            this.bunifuThinButton211.ActiveBorderThickness = 1;
            this.bunifuThinButton211.ActiveCornerRadius = 20;
            this.bunifuThinButton211.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton211.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton211.BackgroundImage")));
            this.bunifuThinButton211.ButtonText = "";
            this.bunifuThinButton211.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton211.Enabled = false;
            this.bunifuThinButton211.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton211.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton211.IdleBorderThickness = 1;
            this.bunifuThinButton211.IdleCornerRadius = 5;
            this.bunifuThinButton211.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton211.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton211.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton211.Location = new System.Drawing.Point(84, 22);
            this.bunifuThinButton211.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton211.Name = "bunifuThinButton211";
            this.bunifuThinButton211.Size = new System.Drawing.Size(435, 37);
            this.bunifuThinButton211.TabIndex = 375;
            this.bunifuThinButton211.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdf_materialsTableAdapter
            // 
            this.rdf_materialsTableAdapter.ClearBeforeFill = true;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Location = new System.Drawing.Point(186, 3);
            this.txtItemCode.Multiline = true;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(141, 20);
            this.txtItemCode.TabIndex = 377;
            this.txtItemCode.Visible = false;
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "#";
            this.NO.MinimumWidth = 12;
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            // 
            // item_code
            // 
            this.item_code.DataPropertyName = "item_code";
            this.item_code.HeaderText = "ITEM CODE";
            this.item_code.MinimumWidth = 12;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "ITEM ID";
            this.itemidDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemdescriptionDataGridViewTextBoxColumn
            // 
            this.itemdescriptionDataGridViewTextBoxColumn.DataPropertyName = "item_description";
            this.itemdescriptionDataGridViewTextBoxColumn.HeaderText = "DESCRIPTION";
            this.itemdescriptionDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.itemdescriptionDataGridViewTextBoxColumn.Name = "itemdescriptionDataGridViewTextBoxColumn";
            this.itemdescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "CATEGORY";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemgroupDataGridViewTextBoxColumn
            // 
            this.itemgroupDataGridViewTextBoxColumn.DataPropertyName = "item_group";
            this.itemgroupDataGridViewTextBoxColumn.HeaderText = "GROUP";
            this.itemgroupDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.itemgroupDataGridViewTextBoxColumn.Name = "itemgroupDataGridViewTextBoxColumn";
            this.itemgroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnoperation
            // 
            this.btnoperation.BackColor = System.Drawing.SystemColors.Control;
            this.btnoperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnoperation.FlatAppearance.BorderSize = 0;
            this.btnoperation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnoperation.Location = new System.Drawing.Point(362, 3);
            this.btnoperation.Margin = new System.Windows.Forms.Padding(1);
            this.btnoperation.Name = "btnoperation";
            this.btnoperation.Size = new System.Drawing.Size(81, 25);
            this.btnoperation.TabIndex = 378;
            this.btnoperation.Text = "Browse";
            this.btnoperation.UseVisualStyleBackColor = false;
            this.btnoperation.Visible = false;
            this.btnoperation.Click += new System.EventHandler(this.btnoperation_Click);
            // 
            // frmImportRawMaterials
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
            this.Name = "frmImportRawMaterials";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Raw Materials";
            this.Load += new System.EventHandler(this.frmImportRawMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdfmaterialsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hr_bakDataSet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_table;
        private hr_bakDataSet hr_bakDataSet;
        private System.Windows.Forms.BindingSource rdfmaterialsBindingSource;
        private hr_bakDataSetTableAdapters.rdf_materialsTableAdapter rdf_materialsTableAdapter;
        internal System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.ComboBox cboSheet;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnbrowse;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox txtdatenow;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuUpload;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton211;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        internal System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemgroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnoperation;
    }
}