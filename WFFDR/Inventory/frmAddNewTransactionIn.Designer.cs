namespace WFFDR
{
    partial class frmAddNewTransactionIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewTransactionIn));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblcountrawmats = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.ComboBox();
            this.txtremarks = new System.Windows.Forms.ComboBox();
            this.lbltotaldata = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddedBy = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.dgvViewDescriptions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbldateandtime = new System.Windows.Forms.Label();
            this.dtpMfgDate = new System.Windows.Forms.DateTimePicker();
            this.mfg_datePicker = new System.Windows.Forms.DateTimePicker();
            this.xpired = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtTransactno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.txtxp = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtmaterialid = new System.Windows.Forms.TextBox();
            this.lbldatabasis = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblcountrawmats);
            this.GroupBox1.Controls.Add(this.txtSupplier);
            this.GroupBox1.Controls.Add(this.txtremarks);
            this.GroupBox1.Controls.Add(this.lbltotaldata);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.txtAddedBy);
            this.GroupBox1.Controls.Add(this.txtCategory);
            this.GroupBox1.Controls.Add(this.dgvViewDescriptions);
            this.GroupBox1.Controls.Add(this.lbldateandtime);
            this.GroupBox1.Controls.Add(this.dtpMfgDate);
            this.GroupBox1.Controls.Add(this.mfg_datePicker);
            this.GroupBox1.Controls.Add(this.xpired);
            this.GroupBox1.Controls.Add(this.textBox1);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.txtqty);
            this.GroupBox1.Controls.Add(this.txtTransactno);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtdescription);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label22);
            this.GroupBox1.Controls.Add(this.label21);
            this.GroupBox1.Controls.Add(this.label20);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.cboItemCode);
            this.GroupBox1.Controls.Add(this.txtxp);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(10, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(635, 283);
            this.GroupBox1.TabIndex = 556;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Raw Materials information";
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // lblcountrawmats
            // 
            this.lblcountrawmats.AutoSize = true;
            this.lblcountrawmats.Location = new System.Drawing.Point(185, 265);
            this.lblcountrawmats.Name = "lblcountrawmats";
            this.lblcountrawmats.Size = new System.Drawing.Size(37, 15);
            this.lblcountrawmats.TabIndex = 657;
            this.lblcountrawmats.Text = "Date :";
            this.lblcountrawmats.Visible = false;
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.Yellow;
            this.txtSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSupplier.FormattingEnabled = true;
            this.txtSupplier.ItemHeight = 15;
            this.txtSupplier.Location = new System.Drawing.Point(129, 159);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(169, 23);
            this.txtSupplier.TabIndex = 656;
            // 
            // txtremarks
            // 
            this.txtremarks.BackColor = System.Drawing.Color.Yellow;
            this.txtremarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtremarks.FormattingEnabled = true;
            this.txtremarks.ItemHeight = 15;
            this.txtremarks.Items.AddRange(new object[] {
            "Delivery",
            "Adjustment",
            "Production"});
            this.txtremarks.Location = new System.Drawing.Point(452, 157);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(165, 23);
            this.txtremarks.TabIndex = 655;
            // 
            // lbltotaldata
            // 
            this.lbltotaldata.AutoSize = true;
            this.lbltotaldata.Location = new System.Drawing.Point(107, 245);
            this.lbltotaldata.Name = "lbltotaldata";
            this.lbltotaldata.Size = new System.Drawing.Size(37, 15);
            this.lbltotaldata.TabIndex = 654;
            this.lbltotaldata.Text = "Date :";
            this.lbltotaldata.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(331, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 653;
            this.label9.Text = "Added By :";
            // 
            // txtAddedBy
            // 
            this.txtAddedBy.Enabled = false;
            this.txtAddedBy.Location = new System.Drawing.Point(452, 189);
            this.txtAddedBy.Name = "txtAddedBy";
            this.txtAddedBy.Size = new System.Drawing.Size(165, 23);
            this.txtAddedBy.TabIndex = 652;
            this.txtAddedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(130, 127);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(168, 23);
            this.txtCategory.TabIndex = 651;
            this.txtCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvViewDescriptions
            // 
            this.dgvViewDescriptions.AllowUserToAddRows = false;
            this.dgvViewDescriptions.AllowUserToDeleteRows = false;
            this.dgvViewDescriptions.AllowUserToResizeColumns = false;
            this.dgvViewDescriptions.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.dgvViewDescriptions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvViewDescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewDescriptions.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dgvViewDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewDescriptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvViewDescriptions.ColumnHeadersHeight = 30;
            this.dgvViewDescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewDescriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvViewDescriptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvViewDescriptions.EnableHeadersVisualStyles = false;
            this.dgvViewDescriptions.GridColor = System.Drawing.SystemColors.Control;
            this.dgvViewDescriptions.Location = new System.Drawing.Point(33, 237);
            this.dgvViewDescriptions.MultiSelect = false;
            this.dgvViewDescriptions.Name = "dgvViewDescriptions";
            this.dgvViewDescriptions.ReadOnly = true;
            this.dgvViewDescriptions.RowHeadersWidth = 50;
            this.dgvViewDescriptions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvViewDescriptions.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvViewDescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewDescriptions.Size = new System.Drawing.Size(38, 64);
            this.dgvViewDescriptions.TabIndex = 644;
            this.dgvViewDescriptions.Visible = false;
            this.dgvViewDescriptions.CurrentCellChanged += new System.EventHandler(this.dgvViewDescriptions_CurrentCellChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BagsCount";
            this.dataGridViewTextBoxColumn1.HeaderText = "bagscount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BulkCount";
            this.dataGridViewTextBoxColumn2.HeaderText = "bulk";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "move_order_qty";
            this.dataGridViewTextBoxColumn3.HeaderText = "movorder";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // lbldateandtime
            // 
            this.lbldateandtime.AutoSize = true;
            this.lbldateandtime.Location = new System.Drawing.Point(185, 237);
            this.lbldateandtime.Name = "lbldateandtime";
            this.lbldateandtime.Size = new System.Drawing.Size(37, 15);
            this.lbldateandtime.TabIndex = 650;
            this.lbldateandtime.Text = "Date :";
            this.lbldateandtime.Visible = false;
            this.lbldateandtime.Click += new System.EventHandler(this.lbldateandtime_Click);
            // 
            // dtpMfgDate
            // 
            this.dtpMfgDate.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMfgDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMfgDate.Location = new System.Drawing.Point(452, 67);
            this.dtpMfgDate.Name = "dtpMfgDate";
            this.dtpMfgDate.Size = new System.Drawing.Size(165, 22);
            this.dtpMfgDate.TabIndex = 649;
            this.dtpMfgDate.Value = new System.DateTime(2019, 12, 27, 11, 44, 5, 0);
            // 
            // mfg_datePicker
            // 
            this.mfg_datePicker.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfg_datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mfg_datePicker.Location = new System.Drawing.Point(452, 35);
            this.mfg_datePicker.Name = "mfg_datePicker";
            this.mfg_datePicker.Size = new System.Drawing.Size(165, 22);
            this.mfg_datePicker.TabIndex = 648;
            this.mfg_datePicker.Value = new System.DateTime(2019, 12, 27, 11, 44, 5, 0);
            // 
            // xpired
            // 
            this.xpired.CalendarMonthBackground = System.Drawing.Color.Yellow;
            this.xpired.CalendarTitleBackColor = System.Drawing.Color.Yellow;
            this.xpired.CalendarTrailingForeColor = System.Drawing.Color.Yellow;
            this.xpired.Font = new System.Drawing.Font("Arial Unicode MS", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.xpired.Location = new System.Drawing.Point(452, 97);
            this.xpired.Name = "xpired";
            this.xpired.Size = new System.Drawing.Size(165, 22);
            this.xpired.TabIndex = 647;
            this.xpired.Value = new System.DateTime(2020, 1, 25, 11, 44, 0, 0);
            this.xpired.ValueChanged += new System.EventHandler(this.xpired_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(273, 237);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 23);
            this.textBox1.TabIndex = 357;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 355;
            this.label5.Text = "Qty :";
            // 
            // txtqty
            // 
            this.txtqty.BackColor = System.Drawing.Color.Yellow;
            this.txtqty.Location = new System.Drawing.Point(130, 190);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(168, 23);
            this.txtqty.TabIndex = 354;
            this.txtqty.TextChanged += new System.EventHandler(this.txtqty_TextChanged);
            this.txtqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // txtTransactno
            // 
            this.txtTransactno.Enabled = false;
            this.txtTransactno.Location = new System.Drawing.Point(129, 37);
            this.txtTransactno.Name = "txtTransactno";
            this.txtTransactno.Size = new System.Drawing.Size(168, 23);
            this.txtTransactno.TabIndex = 353;
            this.txtTransactno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 352;
            this.label1.Text = "Transaction No :";
            // 
            // txtdescription
            // 
            this.txtdescription.Enabled = false;
            this.txtdescription.Location = new System.Drawing.Point(130, 97);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(168, 23);
            this.txtdescription.TabIndex = 351;
            this.txtdescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 350;
            this.label7.Text = "Reason:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 349;
            this.label8.Text = "Expiry Days :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(329, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 348;
            this.label22.Text = "Expiration :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(330, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 347;
            this.label21.Text = "Mfg Date :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(330, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 346;
            this.label20.Text = "Date :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(24, 134);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Category :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(30, 163);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Supplier :";
            this.Label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(13, 106);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Description :";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 76);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(77, 13);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "Item Code :";
            // 
            // cboItemCode
            // 
            this.cboItemCode.BackColor = System.Drawing.Color.Yellow;
            this.cboItemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.ItemHeight = 15;
            this.cboItemCode.Location = new System.Drawing.Point(130, 68);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(168, 23);
            this.cboItemCode.TabIndex = 345;
            this.cboItemCode.SelectedIndexChanged += new System.EventHandler(this.cboItemCode_SelectedIndexChanged);
            // 
            // txtxp
            // 
            this.txtxp.Enabled = false;
            this.txtxp.Location = new System.Drawing.Point(452, 126);
            this.txtxp.Name = "txtxp";
            this.txtxp.Size = new System.Drawing.Size(165, 23);
            this.txtxp.TabIndex = 334;
            this.txtxp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtxp.TextChanged += new System.EventHandler(this.txtqtyreceived_TextChanged);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.Window;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(570, 297);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 28);
            this.btnsave.TabIndex = 555;
            this.btnsave.Text = "Save ";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtmaterialid
            // 
            this.txtmaterialid.Enabled = false;
            this.txtmaterialid.Location = new System.Drawing.Point(186, 302);
            this.txtmaterialid.Name = "txtmaterialid";
            this.txtmaterialid.Size = new System.Drawing.Size(69, 20);
            this.txtmaterialid.TabIndex = 657;
            this.txtmaterialid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmaterialid.Visible = false;
            // 
            // lbldatabasis
            // 
            this.lbldatabasis.AutoSize = true;
            this.lbldatabasis.Location = new System.Drawing.Point(339, 304);
            this.lbldatabasis.Name = "lbldatabasis";
            this.lbldatabasis.Size = new System.Drawing.Size(13, 13);
            this.lbldatabasis.TabIndex = 658;
            this.lbldatabasis.Text = "0";
            this.lbldatabasis.Visible = false;
            // 
            // frmAddNewTransactionIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(655, 333);
            this.Controls.Add(this.lbldatabasis);
            this.Controls.Add(this.txtmaterialid);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewTransactionIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Transaction IN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddNewTransactionIn_FormClosed);
            this.Load += new System.EventHandler(this.frmAddNewTransactionIn_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDescriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.TextBox txtxp;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtTransactno;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtqty;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpMfgDate;
        private System.Windows.Forms.DateTimePicker mfg_datePicker;
        private System.Windows.Forms.DateTimePicker xpired;
        private System.Windows.Forms.Label lbldateandtime;
        private System.Windows.Forms.DataGridView dgvViewDescriptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox txtCategory;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddedBy;
        private System.Windows.Forms.Label lbltotaldata;
        private System.Windows.Forms.ComboBox txtremarks;
        private System.Windows.Forms.ComboBox txtSupplier;
        public System.Windows.Forms.TextBox txtmaterialid;
        private System.Windows.Forms.Label lblcountrawmats;
        private System.Windows.Forms.Label lbldatabasis;
    }
}