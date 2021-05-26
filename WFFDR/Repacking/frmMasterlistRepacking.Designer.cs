namespace WFFDR
{
    partial class frmMasterlistRepacking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_table_2nd_sup = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgReceivingEntry = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvretaillogs = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel_title = new System.Windows.Forms.Panel();
            this.txtretailid = new System.Windows.Forms.TextBox();
            this.lblrepackcount = new System.Windows.Forms.Label();
            this.txtsearchreceiving = new System.Windows.Forms.TextBox();
            this.txtmainsearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table_2nd_sup)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceivingEntry)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvretaillogs)).BeginInit();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_table);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel8);
            this.splitContainer1.Size = new System.Drawing.Size(3459, 1849);
            this.splitContainer1.SplitterDistance = 1125;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.tabControl1);
            this.panel8.Controls.Add(this.panel_title);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(2330, 1849);
            this.panel8.TabIndex = 211;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2318, 1779);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 38;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.dgv_table_2nd_sup);
            this.tabPage1.Location = new System.Drawing.Point(4, 43);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2310, 1732);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Partial Repacking";
            // 
            // dgv_table_2nd_sup
            // 
            this.dgv_table_2nd_sup.AllowUserToAddRows = false;
            this.dgv_table_2nd_sup.AllowUserToDeleteRows = false;
            this.dgv_table_2nd_sup.AllowUserToResizeColumns = false;
            this.dgv_table_2nd_sup.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_table_2nd_sup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_table_2nd_sup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table_2nd_sup.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table_2nd_sup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_table_2nd_sup.ColumnHeadersHeight = 65;
            this.dgv_table_2nd_sup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table_2nd_sup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_table_2nd_sup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table_2nd_sup.EnableHeadersVisualStyles = false;
            this.dgv_table_2nd_sup.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table_2nd_sup.Location = new System.Drawing.Point(3, 3);
            this.dgv_table_2nd_sup.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgv_table_2nd_sup.MultiSelect = false;
            this.dgv_table_2nd_sup.Name = "dgv_table_2nd_sup";
            this.dgv_table_2nd_sup.ReadOnly = true;
            this.dgv_table_2nd_sup.RowHeadersVisible = false;
            this.dgv_table_2nd_sup.RowHeadersWidth = 102;
            this.dgv_table_2nd_sup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table_2nd_sup.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_table_2nd_sup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table_2nd_sup.Size = new System.Drawing.Size(2304, 1726);
            this.dgv_table_2nd_sup.TabIndex = 40;
            this.dgv_table_2nd_sup.CurrentCellChanged += new System.EventHandler(this.dgv_table_2nd_sup_CurrentCellChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dtgReceivingEntry);
            this.tabPage2.Location = new System.Drawing.Point(4, 43);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2310, 1732);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Receiving Entry";
            // 
            // dtgReceivingEntry
            // 
            this.dtgReceivingEntry.AllowUserToAddRows = false;
            this.dtgReceivingEntry.AllowUserToDeleteRows = false;
            this.dtgReceivingEntry.AllowUserToResizeColumns = false;
            this.dtgReceivingEntry.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            this.dtgReceivingEntry.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgReceivingEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReceivingEntry.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReceivingEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dtgReceivingEntry.ColumnHeadersHeight = 65;
            this.dtgReceivingEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgReceivingEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtgReceivingEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReceivingEntry.EnableHeadersVisualStyles = false;
            this.dtgReceivingEntry.GridColor = System.Drawing.SystemColors.Control;
            this.dtgReceivingEntry.Location = new System.Drawing.Point(3, 3);
            this.dtgReceivingEntry.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtgReceivingEntry.MultiSelect = false;
            this.dtgReceivingEntry.Name = "dtgReceivingEntry";
            this.dtgReceivingEntry.ReadOnly = true;
            this.dtgReceivingEntry.RowHeadersVisible = false;
            this.dtgReceivingEntry.RowHeadersWidth = 102;
            this.dtgReceivingEntry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Teal;
            this.dtgReceivingEntry.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgReceivingEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReceivingEntry.Size = new System.Drawing.Size(2304, 1726);
            this.dtgReceivingEntry.TabIndex = 41;
            this.dtgReceivingEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReceivingEntry_CellContentClick);
            this.dtgReceivingEntry.CurrentCellChanged += new System.EventHandler(this.dtgReceivingEntry_CurrentCellChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvretaillogs);
            this.tabPage3.Location = new System.Drawing.Point(4, 43);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(2310, 1732);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Repacking Logs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvretaillogs
            // 
            this.dgvretaillogs.AllowUserToAddRows = false;
            this.dgvretaillogs.AllowUserToDeleteRows = false;
            this.dgvretaillogs.AllowUserToResizeColumns = false;
            this.dgvretaillogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            this.dgvretaillogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvretaillogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvretaillogs.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvretaillogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvretaillogs.ColumnHeadersHeight = 65;
            this.dgvretaillogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvretaillogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvretaillogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvretaillogs.EnableHeadersVisualStyles = false;
            this.dgvretaillogs.GridColor = System.Drawing.SystemColors.Control;
            this.dgvretaillogs.Location = new System.Drawing.Point(3, 3);
            this.dgvretaillogs.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgvretaillogs.MultiSelect = false;
            this.dgvretaillogs.Name = "dgvretaillogs";
            this.dgvretaillogs.ReadOnly = true;
            this.dgvretaillogs.RowHeadersVisible = false;
            this.dgvretaillogs.RowHeadersWidth = 102;
            this.dgvretaillogs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvretaillogs.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvretaillogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvretaillogs.Size = new System.Drawing.Size(2304, 1726);
            this.dgvretaillogs.TabIndex = 41;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 43);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(2310, 1732);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Receiving Logs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.SystemColors.Control;
            this.panel_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_title.Controls.Add(this.txtretailid);
            this.panel_title.Controls.Add(this.lblrepackcount);
            this.panel_title.Controls.Add(this.txtsearchreceiving);
            this.panel_title.Controls.Add(this.txtmainsearch);
            this.panel_title.Controls.Add(this.label2);
            this.panel_title.Controls.Add(this.txtsearch);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(2328, 65);
            this.panel_title.TabIndex = 37;
            // 
            // txtretailid
            // 
            this.txtretailid.BackColor = System.Drawing.SystemColors.Control;
            this.txtretailid.Location = new System.Drawing.Point(1387, 11);
            this.txtretailid.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtretailid.Name = "txtretailid";
            this.txtretailid.Size = new System.Drawing.Size(208, 38);
            this.txtretailid.TabIndex = 4;
            this.txtretailid.TextChanged += new System.EventHandler(this.txtretailid_TextChanged);
            // 
            // lblrepackcount
            // 
            this.lblrepackcount.AutoSize = true;
            this.lblrepackcount.Location = new System.Drawing.Point(1805, 14);
            this.lblrepackcount.Name = "lblrepackcount";
            this.lblrepackcount.Size = new System.Drawing.Size(93, 32);
            this.lblrepackcount.TabIndex = 3;
            this.lblrepackcount.Text = "label1";
            // 
            // txtsearchreceiving
            // 
            this.txtsearchreceiving.BackColor = System.Drawing.SystemColors.Control;
            this.txtsearchreceiving.Location = new System.Drawing.Point(1129, 14);
            this.txtsearchreceiving.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtsearchreceiving.Name = "txtsearchreceiving";
            this.txtsearchreceiving.Size = new System.Drawing.Size(208, 38);
            this.txtsearchreceiving.TabIndex = 2;
            this.txtsearchreceiving.TextChanged += new System.EventHandler(this.txtsearchreceiving_TextChanged);
            // 
            // txtmainsearch
            // 
            this.txtmainsearch.BackColor = System.Drawing.SystemColors.Control;
            this.txtmainsearch.Location = new System.Drawing.Point(149, 13);
            this.txtmainsearch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtmainsearch.Name = "txtmainsearch";
            this.txtmainsearch.Size = new System.Drawing.Size(660, 38);
            this.txtmainsearch.TabIndex = 1;
            this.txtmainsearch.TextChanged += new System.EventHandler(this.txtmainsearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search";
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.SystemColors.Control;
            this.txtsearch.Location = new System.Drawing.Point(905, 18);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(208, 38);
            this.txtsearch.TabIndex = 1;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_table.ColumnHeadersHeight = 65;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(0, 0);
            this.dgv_table.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            this.dgv_table.RowHeadersVisible = false;
            this.dgv_table.RowHeadersWidth = 102;
            this.dgv_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgv_table.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(1125, 1849);
            this.dgv_table.TabIndex = 34;
            this.dgv_table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_table_CellClick);
            this.dgv_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_table_CellContentClick);
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            // 
            // frmMasterlistRepacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3459, 1849);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMasterlistRepacking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterList Repacking";
            this.Load += new System.EventHandler(this.frmMasterlistRepacking_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table_2nd_sup)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceivingEntry)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvretaillogs)).EndInit();
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.TextBox txtmainsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_table_2nd_sup;
        private System.Windows.Forms.DataGridView dtgReceivingEntry;
        private System.Windows.Forms.TextBox txtsearchreceiving;
        private System.Windows.Forms.Label lblrepackcount;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtretailid;
        private System.Windows.Forms.DataGridView dgvretaillogs;
        private System.Windows.Forms.DataGridView dgv_table;
    }
}