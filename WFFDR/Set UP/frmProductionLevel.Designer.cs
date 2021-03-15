namespace WFFDR
{
    partial class frmProductionLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionLevel));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.levelstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modified_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modified_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbags = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton24 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtnobatch = new System.Windows.Forms.TextBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.lblTip = new System.Windows.Forms.Label();
            this.txtdatenow2 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.txtaddedby = new System.Windows.Forms.TextBox();
            this.btnEdit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 49);
            this.panel2.TabIndex = 546;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 29);
            this.label10.TabIndex = 1;
            this.label10.Text = "Production Level Monitoring";
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.levelstatus,
            this.modified_by,
            this.modified_date});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Window;
            this.dataView.Location = new System.Drawing.Point(2, 52);
            this.dataView.Name = "dataView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersWidth = 37;
            this.dataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(642, 69);
            this.dataView.TabIndex = 547;
            this.dataView.CurrentCellChanged += new System.EventHandler(this.dataView_CurrentCellChanged);
            this.dataView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            // 
            // levelstatus
            // 
            this.levelstatus.DataPropertyName = "levelstatus";
            this.levelstatus.HeaderText = "PRODUCTION LEVEL";
            this.levelstatus.MinimumWidth = 12;
            this.levelstatus.Name = "levelstatus";
            this.levelstatus.Width = 160;
            // 
            // modified_by
            // 
            this.modified_by.DataPropertyName = "modified_by";
            this.modified_by.HeaderText = "MODIFIED BY";
            this.modified_by.MinimumWidth = 12;
            this.modified_by.Name = "modified_by";
            this.modified_by.Width = 250;
            // 
            // modified_date
            // 
            this.modified_date.DataPropertyName = "modified_date";
            this.modified_date.HeaderText = "MODIFIED DATE";
            this.modified_date.MinimumWidth = 12;
            this.modified_date.Name = "modified_date";
            this.modified_date.Width = 170;
            // 
            // txtbags
            // 
            this.txtbags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbags.Enabled = false;
            this.txtbags.Location = new System.Drawing.Point(127, 157);
            this.txtbags.Margin = new System.Windows.Forms.Padding(1);
            this.txtbags.Name = "txtbags";
            this.txtbags.Size = new System.Drawing.Size(101, 13);
            this.txtbags.TabIndex = 551;
            this.txtbags.TextChanged += new System.EventHandler(this.txtbags_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 550;
            this.label3.Text = "NUMBER OF BATCH :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 549;
            this.label2.Text = "BAGS :";
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Enabled = false;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 10;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton21.Location = new System.Drawing.Point(110, 145);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(133, 37);
            this.bunifuThinButton21.TabIndex = 553;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bunifuThinButton23.IdleCornerRadius = 10;
            this.bunifuThinButton23.IdleFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.PaleVioletRed;
            this.bunifuThinButton23.IdleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton23.Location = new System.Drawing.Point(395, 145);
            this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton23.Name = "bunifuThinButton23";
            this.bunifuThinButton23.Size = new System.Drawing.Size(141, 37);
            this.bunifuThinButton23.TabIndex = 554;
            this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ActiveBorderThickness = 1;
            this.btnUpdate.ActiveCornerRadius = 20;
            this.btnUpdate.ActiveFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.btnUpdate.ActiveLineColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.ButtonText = "UPDATE";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.IdleBorderThickness = 1;
            this.btnUpdate.IdleCornerRadius = 20;
            this.btnUpdate.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.IdleForecolor = System.Drawing.SystemColors.InfoText;
            this.btnUpdate.IdleLineColor = System.Drawing.SystemColors.InfoText;
            this.btnUpdate.Location = new System.Drawing.Point(118, 271);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 32);
            this.btnUpdate.TabIndex = 556;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // bunifuThinButton24
            // 
            this.bunifuThinButton24.ActiveBorderThickness = 1;
            this.bunifuThinButton24.ActiveCornerRadius = 20;
            this.bunifuThinButton24.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton24.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton24.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.bunifuThinButton24.BackColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton24.BackgroundImage")));
            this.bunifuThinButton24.ButtonText = "CANCEL";
            this.bunifuThinButton24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton24.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton24.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuThinButton24.IdleBorderThickness = 1;
            this.bunifuThinButton24.IdleCornerRadius = 20;
            this.bunifuThinButton24.IdleFillColor = System.Drawing.SystemColors.Window;
            this.bunifuThinButton24.IdleForecolor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuThinButton24.IdleLineColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bunifuThinButton24.Location = new System.Drawing.Point(220, 271);
            this.bunifuThinButton24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuThinButton24.Name = "bunifuThinButton24";
            this.bunifuThinButton24.Size = new System.Drawing.Size(88, 32);
            this.bunifuThinButton24.TabIndex = 557;
            this.bunifuThinButton24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton24.Visible = false;
            this.bunifuThinButton24.Click += new System.EventHandler(this.bunifuThinButton24_Click);
            // 
            // txtnobatch
            // 
            this.txtnobatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnobatch.Enabled = false;
            this.txtnobatch.Location = new System.Drawing.Point(403, 158);
            this.txtnobatch.Margin = new System.Windows.Forms.Padding(1);
            this.txtnobatch.Name = "txtnobatch";
            this.txtnobatch.Size = new System.Drawing.Size(124, 13);
            this.txtnobatch.TabIndex = 560;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(474, 252);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(39, 17);
            this.metroButton4.TabIndex = 561;
            this.metroButton4.Text = "Update";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Visible = false;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.Location = new System.Drawing.Point(297, 212);
            this.lblTip.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(111, 13);
            this.lblTip.TabIndex = 562;
            this.lblTip.Text = "NUMBER OF BATCH :";
            this.lblTip.Visible = false;
            // 
            // txtdatenow2
            // 
            this.txtdatenow2.AutoSize = true;
            this.txtdatenow2.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdatenow2.Location = new System.Drawing.Point(594, 217);
            this.txtdatenow2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtdatenow2.Name = "txtdatenow2";
            this.txtdatenow2.Size = new System.Drawing.Size(111, 13);
            this.txtdatenow2.TabIndex = 563;
            this.txtdatenow2.Text = "NUMBER OF BATCH :";
            this.txtdatenow2.Visible = false;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(441, 200);
            this.lbldate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(111, 13);
            this.lbldate.TabIndex = 564;
            this.lbldate.Text = "NUMBER OF BATCH :";
            this.lbldate.Visible = false;
            // 
            // txtaddedby
            // 
            this.txtaddedby.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtaddedby.Enabled = false;
            this.txtaddedby.Location = new System.Drawing.Point(444, 289);
            this.txtaddedby.Margin = new System.Windows.Forms.Padding(1);
            this.txtaddedby.Name = "txtaddedby";
            this.txtaddedby.Size = new System.Drawing.Size(124, 13);
            this.txtaddedby.TabIndex = 565;
            this.txtaddedby.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.ActiveBorderThickness = 1;
            this.btnEdit.ActiveCornerRadius = 20;
            this.btnEdit.ActiveFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnEdit.ActiveForecolor = System.Drawing.SystemColors.Control;
            this.btnEdit.ActiveLineColor = System.Drawing.Color.CornflowerBlue;
            this.btnEdit.BackColor = System.Drawing.SystemColors.Window;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.ButtonText = "EDIT";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEdit.IdleBorderThickness = 1;
            this.btnEdit.IdleCornerRadius = 20;
            this.btnEdit.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnEdit.IdleForecolor = System.Drawing.SystemColors.MenuText;
            this.btnEdit.IdleLineColor = System.Drawing.SystemColors.MenuText;
            this.btnEdit.Location = new System.Drawing.Point(17, 271);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 32);
            this.btnEdit.TabIndex = 555;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmProductionLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(646, 312);
            this.Controls.Add(this.txtaddedby);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.txtdatenow2);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.txtnobatch);
            this.Controls.Add(this.bunifuThinButton24);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtbags);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.bunifuThinButton23);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductionLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmaddUsers_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.TextBox txtbags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton23;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUpdate;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton24;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtnobatch;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label txtdatenow2;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.TextBox txtaddedby;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn modified_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn modified_date;
    }
}