namespace WFFDR
{
    partial class frmMoveOrderDonePrinted
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoveOrderDonePrinted));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearchs = new System.Windows.Forms.TextBox();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltotalqty = new System.Windows.Forms.Label();
            this.lblencodedby = new System.Windows.Forms.Label();
            this.bntPrint = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.added_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvApproved = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtorder = new System.Windows.Forms.Label();
            this.lblrecords = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(243, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 645;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(850, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 644;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 642;
            this.label2.Text = "Search :";
            // 
            // txtsearchs
            // 
            this.txtsearchs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchs.Location = new System.Drawing.Point(89, 11);
            this.txtsearchs.Name = "txtsearchs";
            this.txtsearchs.Size = new System.Drawing.Size(160, 13);
            this.txtsearchs.TabIndex = 641;
            this.txtsearchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsearchs.TextChanged += new System.EventHandler(this.txtsearchs_TextChanged);
            // 
            // bunifuThinButton23
            // 
            this.bunifuThinButton23.ActiveBorderThickness = 1;
            this.bunifuThinButton23.ActiveCornerRadius = 20;
            this.bunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton23.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton23.BackgroundImage")));
            this.bunifuThinButton23.ButtonText = "";
            this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton23.Enabled = false;
            this.bunifuThinButton23.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton23.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton23.IdleBorderThickness = 1;
            this.bunifuThinButton23.IdleCornerRadius = 20;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.Location = new System.Drawing.Point(75, -1);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(187, 36);
            this.bunifuThinButton23.TabIndex = 643;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(851, 39);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(70, 13);
            this.lbldate.TabIndex = 640;
            this.lbldate.Text = "Encoded by :";
            this.lbldate.Visible = false;
            // 
            // lbltotalqty
            // 
            this.lbltotalqty.AutoSize = true;
            this.lbltotalqty.Location = new System.Drawing.Point(889, 64);
            this.lbltotalqty.Name = "lbltotalqty";
            this.lbltotalqty.Size = new System.Drawing.Size(70, 13);
            this.lbltotalqty.TabIndex = 639;
            this.lbltotalqty.Text = "Encoded by :";
            this.lbltotalqty.Visible = false;
            // 
            // lblencodedby
            // 
            this.lblencodedby.AutoSize = true;
            this.lblencodedby.Location = new System.Drawing.Point(761, 11);
            this.lblencodedby.Name = "lblencodedby";
            this.lblencodedby.Size = new System.Drawing.Size(70, 13);
            this.lblencodedby.TabIndex = 638;
            this.lblencodedby.Text = "Encoded by :";
            this.lblencodedby.Visible = false;
            // 
            // bntPrint
            // 
            this.bntPrint.ActiveBorderThickness = 1;
            this.bntPrint.ActiveCornerRadius = 20;
            this.bntPrint.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bntPrint.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.bntPrint.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bntPrint.BackColor = System.Drawing.SystemColors.Window;
            this.bntPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntPrint.BackgroundImage")));
            this.bntPrint.ButtonText = "PRINT";
            this.bntPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bntPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bntPrint.IdleBorderThickness = 1;
            this.bntPrint.IdleCornerRadius = 20;
            this.bntPrint.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.bntPrint.IdleForecolor = System.Drawing.SystemColors.Window;
            this.bntPrint.IdleLineColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bntPrint.Location = new System.Drawing.Point(830, 418);
            this.bntPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.Size = new System.Drawing.Size(92, 34);
            this.bntPrint.TabIndex = 636;
            this.bntPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bntPrint.Click += new System.EventHandler(this.bntPrint_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DONE";
            this.Column2.HeaderText = "CANCEL";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // date_added
            // 
            this.date_added.DataPropertyName = "date_added";
            this.date_added.HeaderText = "DATE ADDED";
            this.date_added.Name = "date_added";
            this.date_added.ReadOnly = true;
            // 
            // TotalBags
            // 
            this.TotalBags.DataPropertyName = "TotalBags";
            this.TotalBags.HeaderText = "TOTAL BAGS";
            this.TotalBags.Name = "TotalBags";
            this.TotalBags.ReadOnly = true;
            // 
            // added_by
            // 
            this.added_by.DataPropertyName = "added_by";
            this.added_by.HeaderText = "ENCODED BY";
            this.added_by.Name = "added_by";
            this.added_by.ReadOnly = true;
            // 
            // order_no
            // 
            this.order_no.DataPropertyName = "order_no";
            this.order_no.HeaderText = "ORDER NO";
            this.order_no.Name = "order_no";
            this.order_no.ReadOnly = true;
            // 
            // dgvApproved
            // 
            this.dgvApproved.AllowUserToAddRows = false;
            this.dgvApproved.AllowUserToDeleteRows = false;
            this.dgvApproved.AllowUserToResizeColumns = false;
            this.dgvApproved.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApproved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproved.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApproved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApproved.ColumnHeadersHeight = 30;
            this.dgvApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_no,
            this.added_by,
            this.TotalBags,
            this.date_added,
            this.Column1,
            this.Column2});
            this.dgvApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvApproved.EnableHeadersVisualStyles = false;
            this.dgvApproved.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApproved.Location = new System.Drawing.Point(19, 39);
            this.dgvApproved.MultiSelect = false;
            this.dgvApproved.Name = "dgvApproved";
            this.dgvApproved.ReadOnly = true;
            this.dgvApproved.RowHeadersWidth = 50;
            this.dgvApproved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvApproved.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApproved.Size = new System.Drawing.Size(902, 372);
            this.dgvApproved.TabIndex = 637;
            this.dgvApproved.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproved_CellContentClick);
            this.dgvApproved.CurrentCellChanged += new System.EventHandler(this.dgvApproved_CurrentCellChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PENDING";
            this.Column1.HeaderText = "TOTAL RECORDS";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // txtorder
            // 
            this.txtorder.AutoSize = true;
            this.txtorder.Location = new System.Drawing.Point(866, 11);
            this.txtorder.Name = "txtorder";
            this.txtorder.Size = new System.Drawing.Size(70, 13);
            this.txtorder.TabIndex = 635;
            this.txtorder.Text = "Encoded by :";
            this.txtorder.Visible = false;
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Location = new System.Drawing.Point(126, 430);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(70, 13);
            this.lblrecords.TabIndex = 633;
            this.lblrecords.Text = "Encoded by :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 430);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 634;
            this.label20.Text = "TOTAL RECORDS :";
            // 
            // frmMoveOrderDonePrinted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearchs);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lbltotalqty);
            this.Controls.Add(this.lblencodedby);
            this.Controls.Add(this.bntPrint);
            this.Controls.Add(this.dgvApproved);
            this.Controls.Add(this.txtorder);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.label20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMoveOrderDonePrinted";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Order Done";
            this.Load += new System.EventHandler(this.frmMoveOrderDonePrinted_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearchs;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltotalqty;
        private System.Windows.Forms.Label lblencodedby;
        private Bunifu.Framework.UI.BunifuThinButton2 bntPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBags;
        private System.Windows.Forms.DataGridViewTextBoxColumn added_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_no;
        private System.Windows.Forms.DataGridView dgvApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label txtorder;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.Label label20;
    }
}