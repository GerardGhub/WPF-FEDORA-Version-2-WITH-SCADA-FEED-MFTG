
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepackingAdjustment));
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.rawmatscount = new System.Windows.Forms.Label();
            this.dgvrawmats = new System.Windows.Forms.DataGridView();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ONHAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESERVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbrawmats = new System.Windows.Forms.ComboBox();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.dgvrepackreceived = new System.Windows.Forms.DataGridView();
            this.grp3 = new System.Windows.Forms.GroupBox();
            this.dgvrepack = new System.Windows.Forms.DataGridView();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.lblrepackreceived = new System.Windows.Forms.Label();
            this.ReceivedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRepack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblrepack = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.repack_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_repack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repackid = new System.Windows.Forms.Label();
            this.grp4 = new System.Windows.Forms.GroupBox();
            this.lblitemcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblitemid = new System.Windows.Forms.Label();
            this.cbreceivedid = new System.Windows.Forms.ComboBox();
            this.grp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrawmats)).BeginInit();
            this.grp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepackreceived)).BeginInit();
            this.grp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepack)).BeginInit();
            this.grp4.SuspendLayout();
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
            // dgvrawmats
            // 
            this.dgvrawmats.AllowUserToAddRows = false;
            this.dgvrawmats.AllowUserToDeleteRows = false;
            this.dgvrawmats.AllowUserToResizeColumns = false;
            this.dgvrawmats.AllowUserToResizeRows = false;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrawmats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvrawmats.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvrawmats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrawmats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvrawmats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrawmats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_code,
            this.item_description,
            this.ONHAND,
            this.RESERVED});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrawmats.DefaultCellStyle = dataGridViewCellStyle39;
            this.dgvrawmats.EnableHeadersVisualStyles = false;
            this.dgvrawmats.GridColor = System.Drawing.SystemColors.Control;
            this.dgvrawmats.Location = new System.Drawing.Point(3, 25);
            this.dgvrawmats.Margin = new System.Windows.Forms.Padding(4);
            this.dgvrawmats.Name = "dgvrawmats";
            this.dgvrawmats.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrawmats.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvrawmats.RowHeadersWidth = 60;
            this.dgvrawmats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrawmats.Size = new System.Drawing.Size(585, 346);
            this.dgvrawmats.TabIndex = 550;
            this.dgvrawmats.CurrentCellChanged += new System.EventHandler(this.dgvrawmats_CurrentCellChanged);
            this.dgvrawmats.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
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
            dataGridViewCellStyle37.Format = "N2";
            dataGridViewCellStyle37.NullValue = null;
            this.ONHAND.DefaultCellStyle = dataGridViewCellStyle37;
            this.ONHAND.HeaderText = "ONHAND";
            this.ONHAND.MinimumWidth = 6;
            this.ONHAND.Name = "ONHAND";
            this.ONHAND.ReadOnly = true;
            this.ONHAND.Width = 125;
            // 
            // RESERVED
            // 
            this.RESERVED.DataPropertyName = "RESERVED";
            dataGridViewCellStyle38.Format = "N2";
            dataGridViewCellStyle38.NullValue = null;
            this.RESERVED.DefaultCellStyle = dataGridViewCellStyle38;
            this.RESERVED.HeaderText = "RESERVED";
            this.RESERVED.MinimumWidth = 6;
            this.RESERVED.Name = "RESERVED";
            this.RESERVED.ReadOnly = true;
            this.RESERVED.Width = 125;
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
            this.grp2.Controls.Add(this.lblrepackreceived);
            this.grp2.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp2.Location = new System.Drawing.Point(614, 36);
            this.grp2.Margin = new System.Windows.Forms.Padding(4);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(4);
            this.grp2.Size = new System.Drawing.Size(836, 382);
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
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrepackreceived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            this.dgvrepackreceived.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvrepackreceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepackreceived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.dgvrepackreceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrepackreceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceivedID,
            this.itemcode,
            this.itemdescription,
            this.ActualReceived,
            this.TotalRepack,
            this.Balance});
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrepackreceived.DefaultCellStyle = dataGridViewCellStyle46;
            this.dgvrepackreceived.EnableHeadersVisualStyles = false;
            this.dgvrepackreceived.GridColor = System.Drawing.SystemColors.Control;
            this.dgvrepackreceived.Location = new System.Drawing.Point(12, 25);
            this.dgvrepackreceived.Margin = new System.Windows.Forms.Padding(4);
            this.dgvrepackreceived.Name = "dgvrepackreceived";
            this.dgvrepackreceived.ReadOnly = true;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepackreceived.RowHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvrepackreceived.RowHeadersWidth = 60;
            this.dgvrepackreceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrepackreceived.Size = new System.Drawing.Size(812, 346);
            this.dgvrepackreceived.TabIndex = 550;
            this.dgvrepackreceived.CurrentCellChanged += new System.EventHandler(this.dgvrepackreceived_CurrentCellChanged);
            this.dgvrepackreceived.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvrepackreceived_RowPostPaint);
            // 
            // grp3
            // 
            this.grp3.Controls.Add(this.lblrepack);
            this.grp3.Controls.Add(this.dgvrepack);
            this.grp3.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp3.Location = new System.Drawing.Point(13, 420);
            this.grp3.Margin = new System.Windows.Forms.Padding(4);
            this.grp3.Name = "grp3";
            this.grp3.Padding = new System.Windows.Forms.Padding(4);
            this.grp3.Size = new System.Drawing.Size(712, 223);
            this.grp3.TabIndex = 678;
            this.grp3.TabStop = false;
            this.grp3.Text = "List of Raw Mats";
            this.grp3.Visible = false;
            // 
            // dgvrepack
            // 
            this.dgvrepack.AllowUserToAddRows = false;
            this.dgvrepack.AllowUserToDeleteRows = false;
            this.dgvrepack.AllowUserToResizeColumns = false;
            this.dgvrepack.AllowUserToResizeRows = false;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrepack.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle48;
            this.dgvrepack.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvrepack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dgvrepack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrepack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.repack_id,
            this.rp_item_id,
            this.rp_item_code,
            this.rp_item_description,
            this.total_repack});
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvrepack.DefaultCellStyle = dataGridViewCellStyle50;
            this.dgvrepack.EnableHeadersVisualStyles = false;
            this.dgvrepack.GridColor = System.Drawing.SystemColors.Control;
            this.dgvrepack.Location = new System.Drawing.Point(8, 24);
            this.dgvrepack.Margin = new System.Windows.Forms.Padding(4);
            this.dgvrepack.Name = "dgvrepack";
            this.dgvrepack.ReadOnly = true;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvrepack.RowHeadersDefaultCellStyle = dataGridViewCellStyle51;
            this.dgvrepack.RowHeadersWidth = 60;
            this.dgvrepack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvrepack.Size = new System.Drawing.Size(696, 175);
            this.dgvrepack.TabIndex = 550;
            this.dgvrepack.CurrentCellChanged += new System.EventHandler(this.dgvrepack_CurrentCellChanged);
            this.dgvrepack.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // txtitemcode
            // 
            this.txtitemcode.Location = new System.Drawing.Point(498, 10);
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.ReadOnly = true;
            this.txtitemcode.Size = new System.Drawing.Size(100, 22);
            this.txtitemcode.TabIndex = 696;
            this.txtitemcode.Visible = false;
            this.txtitemcode.TextChanged += new System.EventHandler(this.txtitemcode_TextChanged);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(648, 14);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 17);
            this.lblstatus.TabIndex = 697;
            // 
            // lblrepackreceived
            // 
            this.lblrepackreceived.AutoSize = true;
            this.lblrepackreceived.Location = new System.Drawing.Point(111, 1);
            this.lblrepackreceived.Name = "lblrepackreceived";
            this.lblrepackreceived.Size = new System.Drawing.Size(16, 16);
            this.lblrepackreceived.TabIndex = 698;
            this.lblrepackreceived.Text = "0";
            this.lblrepackreceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblrepackreceived.Visible = false;
            // 
            // ReceivedID
            // 
            this.ReceivedID.DataPropertyName = "ReceivedID";
            this.ReceivedID.HeaderText = "Received ID";
            this.ReceivedID.MinimumWidth = 6;
            this.ReceivedID.Name = "ReceivedID";
            this.ReceivedID.ReadOnly = true;
            this.ReceivedID.Width = 125;
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
            dataGridViewCellStyle43.Format = "N2";
            dataGridViewCellStyle43.NullValue = null;
            this.ActualReceived.DefaultCellStyle = dataGridViewCellStyle43;
            this.ActualReceived.HeaderText = "ACTUAL RECEIVED";
            this.ActualReceived.MinimumWidth = 6;
            this.ActualReceived.Name = "ActualReceived";
            this.ActualReceived.ReadOnly = true;
            this.ActualReceived.Width = 125;
            // 
            // TotalRepack
            // 
            this.TotalRepack.DataPropertyName = "TotalRepack";
            dataGridViewCellStyle44.Format = "N2";
            dataGridViewCellStyle44.NullValue = null;
            this.TotalRepack.DefaultCellStyle = dataGridViewCellStyle44;
            this.TotalRepack.HeaderText = "TOTAL REPACK";
            this.TotalRepack.MinimumWidth = 6;
            this.TotalRepack.Name = "TotalRepack";
            this.TotalRepack.ReadOnly = true;
            this.TotalRepack.Width = 125;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle45.Format = "N2";
            dataGridViewCellStyle45.NullValue = null;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle45;
            this.Balance.HeaderText = "BALANCE";
            this.Balance.MinimumWidth = 6;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 125;
            // 
            // lblrepack
            // 
            this.lblrepack.AutoSize = true;
            this.lblrepack.Location = new System.Drawing.Point(112, 0);
            this.lblrepack.Name = "lblrepack";
            this.lblrepack.Size = new System.Drawing.Size(16, 16);
            this.lblrepack.TabIndex = 700;
            this.lblrepack.Text = "0";
            this.lblrepack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblrepack.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(172, 181);
            this.btnsave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(113, 34);
            this.btnsave.TabIndex = 700;
            this.btnsave.Text = "&Adjust";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // repack_id
            // 
            this.repack_id.DataPropertyName = "repack_id";
            this.repack_id.HeaderText = "Repack ID";
            this.repack_id.MinimumWidth = 6;
            this.repack_id.Name = "repack_id";
            this.repack_id.ReadOnly = true;
            this.repack_id.Width = 125;
            // 
            // rp_item_id
            // 
            this.rp_item_id.DataPropertyName = "rp_item_id";
            this.rp_item_id.HeaderText = "Received ID";
            this.rp_item_id.MinimumWidth = 6;
            this.rp_item_id.Name = "rp_item_id";
            this.rp_item_id.ReadOnly = true;
            this.rp_item_id.Width = 125;
            // 
            // rp_item_code
            // 
            this.rp_item_code.DataPropertyName = "rp_item_code";
            this.rp_item_code.HeaderText = "Item Code";
            this.rp_item_code.MinimumWidth = 6;
            this.rp_item_code.Name = "rp_item_code";
            this.rp_item_code.ReadOnly = true;
            this.rp_item_code.Width = 125;
            // 
            // rp_item_description
            // 
            this.rp_item_description.DataPropertyName = "rp_item_description";
            this.rp_item_description.HeaderText = "Item Description";
            this.rp_item_description.MinimumWidth = 6;
            this.rp_item_description.Name = "rp_item_description";
            this.rp_item_description.ReadOnly = true;
            this.rp_item_description.Width = 125;
            // 
            // total_repack
            // 
            this.total_repack.DataPropertyName = "total_repack";
            this.total_repack.HeaderText = "Repack";
            this.total_repack.MinimumWidth = 6;
            this.total_repack.Name = "total_repack";
            this.total_repack.ReadOnly = true;
            this.total_repack.Width = 125;
            // 
            // repackid
            // 
            this.repackid.AutoSize = true;
            this.repackid.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repackid.Location = new System.Drawing.Point(144, 96);
            this.repackid.Name = "repackid";
            this.repackid.Size = new System.Drawing.Size(85, 23);
            this.repackid.TabIndex = 701;
            this.repackid.Text = "repackid";
            // 
            // grp4
            // 
            this.grp4.Controls.Add(this.cbreceivedid);
            this.grp4.Controls.Add(this.lblitemid);
            this.grp4.Controls.Add(this.label5);
            this.grp4.Controls.Add(this.label4);
            this.grp4.Controls.Add(this.label3);
            this.grp4.Controls.Add(this.label2);
            this.grp4.Controls.Add(this.lblitemcode);
            this.grp4.Controls.Add(this.repackid);
            this.grp4.Controls.Add(this.btnsave);
            this.grp4.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp4.Location = new System.Drawing.Point(1158, 420);
            this.grp4.Margin = new System.Windows.Forms.Padding(4);
            this.grp4.Name = "grp4";
            this.grp4.Padding = new System.Windows.Forms.Padding(4);
            this.grp4.Size = new System.Drawing.Size(292, 223);
            this.grp4.TabIndex = 701;
            this.grp4.TabStop = false;
            this.grp4.Text = "Adjustment Details";
            this.grp4.Visible = false;
            // 
            // lblitemcode
            // 
            this.lblitemcode.AutoSize = true;
            this.lblitemcode.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblitemcode.Location = new System.Drawing.Point(144, 24);
            this.lblitemcode.Name = "lblitemcode";
            this.lblitemcode.Size = new System.Drawing.Size(91, 23);
            this.lblitemcode.TabIndex = 702;
            this.lblitemcode.Text = "itemcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 703;
            this.label2.Text = "Item Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 23);
            this.label3.TabIndex = 704;
            this.label3.Text = "Change Received ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 705;
            this.label4.Text = "Repack ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 706;
            this.label5.Text = "Received ID:";
            // 
            // lblitemid
            // 
            this.lblitemid.AutoSize = true;
            this.lblitemid.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblitemid.Location = new System.Drawing.Point(152, 61);
            this.lblitemid.Name = "lblitemid";
            this.lblitemid.Size = new System.Drawing.Size(107, 23);
            this.lblitemid.TabIndex = 707;
            this.lblitemid.Text = "ReceivedID";
            // 
            // cbreceivedid
            // 
            this.cbreceivedid.BackColor = System.Drawing.Color.Yellow;
            this.cbreceivedid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbreceivedid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbreceivedid.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbreceivedid.FormattingEnabled = true;
            this.cbreceivedid.Location = new System.Drawing.Point(186, 138);
            this.cbreceivedid.Name = "cbreceivedid";
            this.cbreceivedid.Size = new System.Drawing.Size(101, 23);
            this.cbreceivedid.TabIndex = 702;
            // 
            // FrmRepackingAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1464, 656);
            this.Controls.Add(this.grp4);
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
            this.grp2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepackreceived)).EndInit();
            this.grp3.ResumeLayout(false);
            this.grp3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrepack)).EndInit();
            this.grp4.ResumeLayout(false);
            this.grp4.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvrepack;
        private System.Windows.Forms.TextBox txtitemcode;
        private System.Windows.Forms.Label rawmatscount;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ONHAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESERVED;
        private System.Windows.Forms.Label lblrepackreceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRepack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.Label lblrepack;
        internal System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridViewTextBoxColumn repack_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_repack;
        private System.Windows.Forms.Label repackid;
        internal System.Windows.Forms.GroupBox grp4;
        private System.Windows.Forms.Label lblitemcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblitemid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbreceivedid;
    }
}