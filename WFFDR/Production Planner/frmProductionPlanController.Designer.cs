
namespace WFFDR
{
    partial class frmProductionPlanController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionPlanController));
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_bags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_nobatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ra_feed_selection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblstats = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblprod = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpboxconfirm = new System.Windows.Forms.GroupBox();
            this.btnpendingremarks = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtaddedby = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.grpboxconfirm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.prod_id,
            this.ID,
            this.p_feed_code,
            this.p_bags,
            this.p_nobatch,
            this.rp_feed_type,
            this.proddate,
            this.ra_feed_selection});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(4, 15);
            this.dgv_table.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_table.RowHeadersWidth = 60;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(1047, 439);
            this.dgv_table.TabIndex = 550;
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            this.dgv_table.DoubleClick += new System.EventHandler(this.dgv_table_DoubleClick);
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
            this.selected.Width = 55;
            // 
            // prod_id
            // 
            this.prod_id.DataPropertyName = "prod_id";
            this.prod_id.HeaderText = "Production ID";
            this.prod_id.MinimumWidth = 6;
            this.prod_id.Name = "prod_id";
            this.prod_id.ReadOnly = true;
            this.prod_id.Width = 112;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // p_feed_code
            // 
            this.p_feed_code.DataPropertyName = "p_feed_code";
            this.p_feed_code.HeaderText = "Feed Code";
            this.p_feed_code.MinimumWidth = 6;
            this.p_feed_code.Name = "p_feed_code";
            this.p_feed_code.ReadOnly = true;
            this.p_feed_code.Width = 98;
            // 
            // p_bags
            // 
            this.p_bags.DataPropertyName = "p_bags";
            this.p_bags.HeaderText = "Bags";
            this.p_bags.MinimumWidth = 6;
            this.p_bags.Name = "p_bags";
            this.p_bags.ReadOnly = true;
            this.p_bags.Width = 69;
            // 
            // p_nobatch
            // 
            this.p_nobatch.DataPropertyName = "p_nobatch";
            this.p_nobatch.HeaderText = "Batch";
            this.p_nobatch.MinimumWidth = 6;
            this.p_nobatch.Name = "p_nobatch";
            this.p_nobatch.ReadOnly = true;
            this.p_nobatch.Width = 73;
            // 
            // rp_feed_type
            // 
            this.rp_feed_type.DataPropertyName = "rp_feed_type";
            this.rp_feed_type.HeaderText = "Feed Type";
            this.rp_feed_type.MinimumWidth = 6;
            this.rp_feed_type.Name = "rp_feed_type";
            this.rp_feed_type.ReadOnly = true;
            this.rp_feed_type.Width = 97;
            // 
            // proddate
            // 
            this.proddate.DataPropertyName = "proddate";
            this.proddate.HeaderText = "Production Plan";
            this.proddate.MinimumWidth = 6;
            this.proddate.Name = "proddate";
            this.proddate.ReadOnly = true;
            this.proddate.Width = 126;
            // 
            // ra_feed_selection
            // 
            this.ra_feed_selection.DataPropertyName = "ra_feed_selection";
            this.ra_feed_selection.HeaderText = "On Production";
            this.ra_feed_selection.MinimumWidth = 6;
            this.ra_feed_selection.Name = "ra_feed_selection";
            this.ra_feed_selection.ReadOnly = true;
            this.ra_feed_selection.Width = 118;
            // 
            // lblstats
            // 
            this.lblstats.AutoSize = true;
            this.lblstats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstats.Location = new System.Drawing.Point(20, 560);
            this.lblstats.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblstats.Name = "lblstats";
            this.lblstats.Size = new System.Drawing.Size(144, 25);
            this.lblstats.TabIndex = 599;
            this.lblstats.Text = "Total Records :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(176, 560);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(23, 25);
            this.lblrecords.TabIndex = 600;
            this.lblrecords.Text = "0";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.Yellow;
            this.txtRemarks.Location = new System.Drawing.Point(193, 510);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(684, 40);
            this.txtRemarks.TabIndex = 601;
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprod.Location = new System.Drawing.Point(49, 519);
            this.lblprod.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(123, 17);
            this.lblprod.TabIndex = 602;
            this.lblprod.Text = "Cancel Remarks  :";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(924, 510);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 603;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProdId
            // 
            this.txtProdId.BackColor = System.Drawing.Color.Yellow;
            this.txtProdId.Enabled = false;
            this.txtProdId.Location = new System.Drawing.Point(193, 475);
            this.txtProdId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(341, 22);
            this.txtProdId.TabIndex = 604;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 481);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 605;
            this.label1.Text = "Production ID  :";
            // 
            // grpboxconfirm
            // 
            this.grpboxconfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(179)))), ((int)(((byte)(215)))));
            this.grpboxconfirm.Controls.Add(this.btnpendingremarks);
            this.grpboxconfirm.Controls.Add(this.Cancelbtn);
            this.grpboxconfirm.Controls.Add(this.label11);
            this.grpboxconfirm.Controls.Add(this.txtconfirm);
            this.grpboxconfirm.Controls.Add(this.label9);
            this.grpboxconfirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpboxconfirm.Location = new System.Drawing.Point(0, 177);
            this.grpboxconfirm.Name = "grpboxconfirm";
            this.grpboxconfirm.Size = new System.Drawing.Size(1067, 201);
            this.grpboxconfirm.TabIndex = 649;
            this.grpboxconfirm.TabStop = false;
            this.grpboxconfirm.Visible = false;
            // 
            // btnpendingremarks
            // 
            this.btnpendingremarks.BackColor = System.Drawing.Color.Teal;
            this.btnpendingremarks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnpendingremarks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnpendingremarks.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpendingremarks.ForeColor = System.Drawing.Color.White;
            this.btnpendingremarks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpendingremarks.Location = new System.Drawing.Point(899, 168);
            this.btnpendingremarks.Name = "btnpendingremarks";
            this.btnpendingremarks.Size = new System.Drawing.Size(75, 28);
            this.btnpendingremarks.TabIndex = 10;
            this.btnpendingremarks.Text = "Confirm";
            this.btnpendingremarks.UseVisualStyleBackColor = false;
            this.btnpendingremarks.Click += new System.EventHandler(this.btnpendingremarks_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackColor = System.Drawing.Color.White;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cancelbtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.ForeColor = System.Drawing.Color.Black;
            this.Cancelbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancelbtn.Location = new System.Drawing.Point(980, 168);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 28);
            this.Cancelbtn.TabIndex = 7;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = false;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 36);
            this.label11.TabIndex = 6;
            this.label11.Text = "Information";
            // 
            // txtconfirm
            // 
            this.txtconfirm.BackColor = System.Drawing.Color.Yellow;
            this.txtconfirm.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconfirm.Location = new System.Drawing.Point(888, 137);
            this.txtconfirm.MaxLength = 11;
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(167, 23);
            this.txtconfirm.TabIndex = 4;
            this.txtconfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtconfirm_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(475, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(418, 33);
            this.label9.TabIndex = 3;
            this.label9.Text = "Please confirm the Production ID:";
            // 
            // txtaddedby
            // 
            this.txtaddedby.AutoSize = true;
            this.txtaddedby.Location = new System.Drawing.Point(739, 478);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(46, 17);
            this.txtaddedby.TabIndex = 650;
            this.txtaddedby.Text = "label2";
            this.txtaddedby.Visible = false;
            // 
            // frmProductionPlanController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1067, 591);
            this.Controls.Add(this.txtaddedby);
            this.Controls.Add(this.grpboxconfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProdId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblprod);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.lblstats);
            this.Controls.Add(this.dgv_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmProductionPlanController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Plan Controller";
            this.Load += new System.EventHandler(this.frmProductionPlanController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.grpboxconfirm.ResumeLayout(false);
            this.grpboxconfirm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.Label lblstats;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblprod;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_feed_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_bags;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_nobatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_feed_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ra_feed_selection;
        private System.Windows.Forms.GroupBox grpboxconfirm;
        private System.Windows.Forms.Button btnpendingremarks;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtaddedby;
    }
}