
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionPlanController));
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.lblstats = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblprod = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_feed_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_bags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_nobatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_feed_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ra_feed_selection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_table
            // 
            this.dgv_table.AllowUserToAddRows = false;
            this.dgv_table.AllowUserToDeleteRows = false;
            this.dgv_table.AllowUserToResizeColumns = false;
            this.dgv_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgv_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_table.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_table.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_table.EnableHeadersVisualStyles = false;
            this.dgv_table.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_table.Location = new System.Drawing.Point(3, 12);
            this.dgv_table.MultiSelect = false;
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_table.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_table.RowHeadersWidth = 60;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(785, 357);
            this.dgv_table.TabIndex = 550;
            this.dgv_table.CurrentCellChanged += new System.EventHandler(this.dgv_table_CurrentCellChanged);
            this.dgv_table.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_table_RowPostPaint);
            this.dgv_table.DoubleClick += new System.EventHandler(this.dgv_table_DoubleClick);
            // 
            // lblstats
            // 
            this.lblstats.AutoSize = true;
            this.lblstats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstats.Location = new System.Drawing.Point(15, 455);
            this.lblstats.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblstats.Name = "lblstats";
            this.lblstats.Size = new System.Drawing.Size(116, 20);
            this.lblstats.TabIndex = 599;
            this.lblstats.Text = "Total Records :";
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(132, 455);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(18, 20);
            this.lblrecords.TabIndex = 600;
            this.lblrecords.Text = "0";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Enabled = false;
            this.txtRemarks.Location = new System.Drawing.Point(145, 414);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(514, 33);
            this.txtRemarks.TabIndex = 601;
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprod.Location = new System.Drawing.Point(37, 422);
            this.lblprod.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(94, 13);
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
            this.btnCancel.Location = new System.Drawing.Point(693, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 603;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProdId
            // 
            this.txtProdId.BackColor = System.Drawing.Color.PaleGreen;
            this.txtProdId.Enabled = false;
            this.txtProdId.Location = new System.Drawing.Point(145, 386);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(257, 20);
            this.txtProdId.TabIndex = 604;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 391);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 605;
            this.label1.Text = "Production ID  :";
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
            this.prod_id.Name = "prod_id";
            this.prod_id.ReadOnly = true;
            this.prod_id.Width = 89;
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
            this.p_feed_code.Name = "p_feed_code";
            this.p_feed_code.ReadOnly = true;
            this.p_feed_code.Width = 78;
            // 
            // p_bags
            // 
            this.p_bags.DataPropertyName = "p_bags";
            this.p_bags.HeaderText = "Bags";
            this.p_bags.Name = "p_bags";
            this.p_bags.ReadOnly = true;
            this.p_bags.Width = 56;
            // 
            // p_nobatch
            // 
            this.p_nobatch.DataPropertyName = "p_nobatch";
            this.p_nobatch.HeaderText = "Batch";
            this.p_nobatch.Name = "p_nobatch";
            this.p_nobatch.ReadOnly = true;
            this.p_nobatch.Width = 60;
            // 
            // rp_feed_type
            // 
            this.rp_feed_type.DataPropertyName = "rp_feed_type";
            this.rp_feed_type.HeaderText = "Feed Type";
            this.rp_feed_type.Name = "rp_feed_type";
            this.rp_feed_type.ReadOnly = true;
            this.rp_feed_type.Width = 77;
            // 
            // proddate
            // 
            this.proddate.DataPropertyName = "proddate";
            this.proddate.HeaderText = "Production Plan";
            this.proddate.Name = "proddate";
            this.proddate.ReadOnly = true;
            this.proddate.Width = 98;
            // 
            // ra_feed_selection
            // 
            this.ra_feed_selection.DataPropertyName = "ra_feed_selection";
            this.ra_feed_selection.HeaderText = "On Production";
            this.ra_feed_selection.Name = "ra_feed_selection";
            this.ra_feed_selection.ReadOnly = true;
            this.ra_feed_selection.Width = 92;
            // 
            // frmProductionPlanController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 480);
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
            this.MaximizeBox = false;
            this.Name = "frmProductionPlanController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Plan Controller";
            this.Load += new System.EventHandler(this.frmProductionPlanController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
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
    }
}