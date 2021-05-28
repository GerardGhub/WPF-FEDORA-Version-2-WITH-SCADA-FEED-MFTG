
namespace WFFDR.Admin
{
    partial class FrmRepackingAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepackingAdjustment));
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.dgvrawmats = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbrawmats = new System.Windows.Forms.ComboBox();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.dgvrepackreceived = new System.Windows.Forms.DataGridView();
            this.grp3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.rawmatscount = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ONHAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESERVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrepackreceived = new System.Windows.Forms.Label();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRepack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrawmats)).BeginInit();
            this.grp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepackreceived)).BeginInit();
            this.grp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.rawmatscount);
            this.grp1.Controls.Add(this.dgvrawmats);
            this.grp1.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp1.Location = new System.Drawing.Point(13, 36);
            this.grp1.Margin = new System.Windows.Forms.Padding(4);
            this.grp1.Name = "grp1";
            this.grp1.Padding = new System.Windows.Forms.Padding(4);
            this.grp1.Size = new System.Drawing.Size(593, 382);
            this.grp1.TabIndex = 677;
            this.grp1.TabStop = false;
            this.grp1.Text = "List of Raw Mats";
            this.grp1.Visible = false;
            // 
            // dgvrawmats
            // 
            this.dgvrawmats.AllowUserToAddRows = false;
            this.dgvrawmats.AllowUserToDeleteRows = false;
            this.dgvrawmats.AllowUserToResizeColumns = false;
            this.dgvrawmats.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrawmats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvrawmats.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvrawmats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrawmats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvrawmats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrawmats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_code,
            this.item_description,
            this.ONHAND,
            this.RESERVED});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrawmats.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvrawmats.EnableHeadersVisualStyles = false;
            this.dgvrawmats.GridColor = System.Drawing.SystemColors.Control;
            this.dgvrawmats.Location = new System.Drawing.Point(3, 25);
            this.dgvrawmats.Margin = new System.Windows.Forms.Padding(4);
            this.dgvrawmats.Name = "dgvrawmats";
            this.dgvrawmats.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrawmats.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvrawmats.RowHeadersWidth = 60;
            this.dgvrawmats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrawmats.Size = new System.Drawing.Size(585, 346);
            this.dgvrawmats.TabIndex = 550;
            this.dgvrawmats.CurrentCellChanged += new System.EventHandler(this.dgvrawmats_CurrentCellChanged);
            this.dgvrawmats.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 23);
            this.label1.TabIndex = 694;
            this.label1.Text = "Raw Mats Category:";
            // 
            // cbrawmats
            // 
            this.cbrawmats.BackColor = System.Drawing.Color.Yellow;
            this.cbrawmats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbrawmats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbrawmats.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbrawmats.FormattingEnabled = true;
            this.cbrawmats.Items.AddRange(new object[] {
            "MICRO",
            "MACRO"});
            this.cbrawmats.Location = new System.Drawing.Point(185, 9);
            this.cbrawmats.Name = "cbrawmats";
            this.cbrawmats.Size = new System.Drawing.Size(121, 23);
            this.cbrawmats.TabIndex = 695;
            this.cbrawmats.DropDownClosed += new System.EventHandler(this.cbrawmats_DropDownClosed);
            this.cbrawmats.Click += new System.EventHandler(this.cbrawmats_Click);
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.dgvrepackreceived);
            this.grp2.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp2.Location = new System.Drawing.Point(614, 36);
            this.grp2.Margin = new System.Windows.Forms.Padding(4);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(4);
            this.grp2.Size = new System.Drawing.Size(593, 382);
            this.grp2.TabIndex = 678;
            this.grp2.TabStop = false;
            this.grp2.Text = "List of Raw Mats";
            this.grp2.Visible = false;
            // 
            // dgvrepackreceived
            // 
            this.dgvrepackreceived.AllowUserToAddRows = false;
            this.dgvrepackreceived.AllowUserToDeleteRows = false;
            this.dgvrepackreceived.AllowUserToResizeColumns = false;
            this.dgvrepackreceived.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrepackreceived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvrepackreceived.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvrepackreceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepackreceived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvrepackreceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrepackreceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcode,
            this.itemdescription,
            this.ActualReceived,
            this.TotalRepack,
            this.Balance});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrepackreceived.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvrepackreceived.EnableHeadersVisualStyles = false;
            this.dgvrepackreceived.GridColor = System.Drawing.SystemColors.Control;
            this.dgvrepackreceived.Location = new System.Drawing.Point(12, 25);
            this.dgvrepackreceived.Margin = new System.Windows.Forms.Padding(4);
            this.dgvrepackreceived.Name = "dgvrepackreceived";
            this.dgvrepackreceived.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepackreceived.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvrepackreceived.RowHeadersWidth = 60;
            this.dgvrepackreceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrepackreceived.Size = new System.Drawing.Size(573, 346);
            this.dgvrepackreceived.TabIndex = 550;
            this.dgvrepackreceived.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvrepackreceived_RowPostPaint);
            // 
            // grp3
            // 
            this.grp3.Controls.Add(this.dataGridView2);
            this.grp3.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp3.Location = new System.Drawing.Point(13, 420);
            this.grp3.Margin = new System.Windows.Forms.Padding(4);
            this.grp3.Name = "grp3";
            this.grp3.Padding = new System.Windows.Forms.Padding(4);
            this.grp3.Size = new System.Drawing.Size(1118, 207);
            this.grp3.TabIndex = 678;
            this.grp3.TabStop = false;
            this.grp3.Text = "List of Raw Mats";
            this.grp3.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.Location = new System.Drawing.Point(8, 24);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView2.RowHeadersWidth = 60;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1102, 175);
            this.dataGridView2.TabIndex = 550;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // txtitemcode
            // 
            this.txtitemcode.Location = new System.Drawing.Point(498, 10);
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.ReadOnly = true;
            this.txtitemcode.Size = new System.Drawing.Size(100, 22);
            this.txtitemcode.TabIndex = 696;
            // 
            // rawmatscount
            // 
            this.rawmatscount.AutoSize = true;
            this.rawmatscount.Location = new System.Drawing.Point(111, 0);
            this.rawmatscount.Name = "rawmatscount";
            this.rawmatscount.Size = new System.Drawing.Size(16, 16);
            this.rawmatscount.TabIndex = 697;
            this.rawmatscount.Text = "0";
            this.rawmatscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(648, 14);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 17);
            this.lblstatus.TabIndex = 697;
            // 
            // item_code
            // 
            this.item_code.DataPropertyName = "item_code";
            this.item_code.HeaderText = "ITEM CODE";
            this.item_code.MinimumWidth = 6;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            this.item_code.Width = 125;
            // 
            // item_description
            // 
            this.item_description.DataPropertyName = "item_description";
            this.item_description.HeaderText = "ITEM DESCRIPTION";
            this.item_description.MinimumWidth = 6;
            this.item_description.Name = "item_description";
            this.item_description.ReadOnly = true;
            this.item_description.Width = 125;
            // 
            // ONHAND
            // 
            this.ONHAND.DataPropertyName = "ONHAND";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ONHAND.DefaultCellStyle = dataGridViewCellStyle3;
            this.ONHAND.HeaderText = "ONHAND";
            this.ONHAND.MinimumWidth = 6;
            this.ONHAND.Name = "ONHAND";
            this.ONHAND.ReadOnly = true;
            this.ONHAND.Width = 125;
            // 
            // RESERVED
            // 
            this.RESERVED.DataPropertyName = "RESERVED";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.RESERVED.DefaultCellStyle = dataGridViewCellStyle4;
            this.RESERVED.HeaderText = "RESERVED";
            this.RESERVED.MinimumWidth = 6;
            this.RESERVED.Name = "RESERVED";
            this.RESERVED.ReadOnly = true;
            this.RESERVED.Width = 125;
            // 
            // lblrepackreceived
            // 
            this.lblrepackreceived.AutoSize = true;
            this.lblrepackreceived.Location = new System.Drawing.Point(725, 36);
            this.lblrepackreceived.Name = "lblrepackreceived";
            this.lblrepackreceived.Size = new System.Drawing.Size(16, 17);
            this.lblrepackreceived.TabIndex = 698;
            this.lblrepackreceived.Text = "0";
            this.lblrepackreceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "ITEM CODE";
            this.itemcode.MinimumWidth = 6;
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            this.itemcode.Width = 125;
            // 
            // itemdescription
            // 
            this.itemdescription.DataPropertyName = "itemdescription";
            this.itemdescription.HeaderText = "ITEM DESCRIPTION";
            this.itemdescription.MinimumWidth = 6;
            this.itemdescription.Name = "itemdescription";
            this.itemdescription.ReadOnly = true;
            this.itemdescription.Width = 125;
            // 
            // ActualReceived
            // 
            this.ActualReceived.DataPropertyName = "ActualReceived";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.ActualReceived.DefaultCellStyle = dataGridViewCellStyle9;
            this.ActualReceived.HeaderText = "ACTUAL RECEIVED";
            this.ActualReceived.MinimumWidth = 6;
            this.ActualReceived.Name = "ActualReceived";
            this.ActualReceived.ReadOnly = true;
            this.ActualReceived.Width = 125;
            // 
            // TotalRepack
            // 
            this.TotalRepack.DataPropertyName = "TotalRepack";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.TotalRepack.DefaultCellStyle = dataGridViewCellStyle10;
            this.TotalRepack.HeaderText = "TOTAL REPACK";
            this.TotalRepack.MinimumWidth = 6;
            this.TotalRepack.Name = "TotalRepack";
            this.TotalRepack.ReadOnly = true;
            this.TotalRepack.Width = 125;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle11;
            this.Balance.HeaderText = "BALANCE";
            this.Balance.MinimumWidth = 6;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 125;
            // 
            // FrmRepackingAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1220, 653);
            this.Controls.Add(this.lblrepackreceived);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.txtitemcode);
            this.Controls.Add(this.grp3);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.cbrawmats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRepackingAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repacking Adjustment";
            this.Load += new System.EventHandler(this.FrmRepackingAdjustment_Load);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrawmats)).EndInit();
            this.grp2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepackreceived)).EndInit();
            this.grp3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.DataGridView dgvrawmats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbrawmats;
        internal System.Windows.Forms.GroupBox grp2;
        private System.Windows.Forms.DataGridView dgvrepackreceived;
        internal System.Windows.Forms.GroupBox grp3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtitemcode;
        private System.Windows.Forms.Label rawmatscount;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ONHAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESERVED;
        private System.Windows.Forms.Label lblrepackreceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRepack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
    }
}