namespace WFFDR
{
    partial class frmFormulationtoProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulationtoProduction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btngreaterthan = new System.Windows.Forms.Button();
            this.txtmare = new System.Windows.Forms.TextBox();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtsearchcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFeedCode = new System.Windows.Forms.TextBox();
            this.lblfeedtype = new System.Windows.Forms.Label();
            this.txtprod_id = new System.Windows.Forms.TextBox();
            this.lblprod = new System.Windows.Forms.Label();
            this.txtluffy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btngreaterthan);
            this.panel2.Controls.Add(this.txtmare);
            this.panel2.Controls.Add(this.dateTimePicker12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.txtsearchcode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.metroButton4);
            this.panel2.Location = new System.Drawing.Point(-1, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 44);
            this.panel2.TabIndex = 546;
            // 
            // btngreaterthan
            // 
            this.btngreaterthan.BackColor = System.Drawing.Color.Transparent;
            this.btngreaterthan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngreaterthan.BackgroundImage")));
            this.btngreaterthan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngreaterthan.FlatAppearance.BorderSize = 0;
            this.btngreaterthan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngreaterthan.Font = new System.Drawing.Font("Verdana", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngreaterthan.ForeColor = System.Drawing.SystemColors.Window;
            this.btngreaterthan.Location = new System.Drawing.Point(677, 2);
            this.btngreaterthan.Margin = new System.Windows.Forms.Padding(1);
            this.btngreaterthan.Name = "btngreaterthan";
            this.btngreaterthan.Size = new System.Drawing.Size(53, 32);
            this.btngreaterthan.TabIndex = 641;
            this.btngreaterthan.UseVisualStyleBackColor = false;
            this.btngreaterthan.Click += new System.EventHandler(this.btngreaterthan_Click);
            // 
            // txtmare
            // 
            this.txtmare.Location = new System.Drawing.Point(464, 4);
            this.txtmare.Name = "txtmare";
            this.txtmare.Size = new System.Drawing.Size(122, 20);
            this.txtmare.TabIndex = 50;
            this.txtmare.Visible = false;
            // 
            // dateTimePicker12
            // 
            this.dateTimePicker12.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.CustomFormat = "M/d/yyyy";
            this.dateTimePicker12.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker12.Location = new System.Drawing.Point(738, 2);
            this.dateTimePicker12.Name = "dateTimePicker12";
            this.dateTimePicker12.Size = new System.Drawing.Size(195, 32);
            this.dateTimePicker12.TabIndex = 5;
            this.dateTimePicker12.ValueChanged += new System.EventHandler(this.dateTimePicker12_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(326, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Formulation to Production";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(183, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 44;
            this.txtSearch.Visible = false;
            // 
            // txtsearchcode
            // 
            this.txtsearchcode.Location = new System.Drawing.Point(342, 41);
            this.txtsearchcode.Name = "txtsearchcode";
            this.txtsearchcode.Size = new System.Drawing.Size(122, 20);
            this.txtsearchcode.TabIndex = 49;
            this.txtsearchcode.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(447, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 14);
            this.label6.TabIndex = 395;
            this.label6.Text = "Generate Repacking Barcode";
            this.label6.Visible = false;
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(611, 35);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(1);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(39, 17);
            this.metroButton4.TabIndex = 394;
            this.metroButton4.Text = "Update";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Visible = false;
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.quantity,
            this.Column10,
            this.Column11,
            this.Column12});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.GridColor = System.Drawing.SystemColors.Control;
            this.dataView.Location = new System.Drawing.Point(6, 70);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataView.RowHeadersWidth = 60;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(940, 374);
            this.dataView.TabIndex = 547;
            this.dataView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataView_RowPostPaint);
            this.dataView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataView_RowPrePaint);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(682, 45);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(122, 20);
            this.txtItemCode.TabIndex = 561;
            this.txtItemCode.Visible = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(612, 48);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 560;
            this.label12.Text = "Item Code :";
            this.label12.Visible = false;
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.Location = new System.Drawing.Point(485, 45);
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(122, 20);
            this.txtFeedCode.TabIndex = 559;
            this.txtFeedCode.Visible = false;
            this.txtFeedCode.TextChanged += new System.EventHandler(this.txtFeedCode_TextChanged);
            // 
            // lblfeedtype
            // 
            this.lblfeedtype.AutoSize = true;
            this.lblfeedtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfeedtype.Location = new System.Drawing.Point(407, 47);
            this.lblfeedtype.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblfeedtype.Name = "lblfeedtype";
            this.lblfeedtype.Size = new System.Drawing.Size(65, 13);
            this.lblfeedtype.TabIndex = 558;
            this.lblfeedtype.Text = "Feed Code :";
            this.lblfeedtype.Visible = false;
            // 
            // txtprod_id
            // 
            this.txtprod_id.Location = new System.Drawing.Point(275, 44);
            this.txtprod_id.Name = "txtprod_id";
            this.txtprod_id.Size = new System.Drawing.Size(122, 20);
            this.txtprod_id.TabIndex = 557;
            this.txtprod_id.Visible = false;
            this.txtprod_id.TextChanged += new System.EventHandler(this.txtprod_id_TextChanged);
            // 
            // lblprod
            // 
            this.lblprod.AutoSize = true;
            this.lblprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprod.Location = new System.Drawing.Point(183, 47);
            this.lblprod.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprod.Name = "lblprod";
            this.lblprod.Size = new System.Drawing.Size(78, 13);
            this.lblprod.TabIndex = 556;
            this.lblprod.Text = "Production ID :";
            this.lblprod.Visible = false;
            // 
            // txtluffy
            // 
            this.txtluffy.AutoSize = true;
            this.txtluffy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtluffy.Location = new System.Drawing.Point(113, 47);
            this.txtluffy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtluffy.Name = "txtluffy";
            this.txtluffy.Size = new System.Drawing.Size(55, 13);
            this.txtluffy.TabIndex = 555;
            this.txtluffy.Text = "00000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 554;
            this.label5.Text = "Total Records :";
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
            this.selected.Width = 125;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 12;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "recipe_id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "production_id";
            this.Column2.HeaderText = "PROD ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "proddate";
            this.Column3.HeaderText = "PROD DATE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "feed_code";
            this.Column4.HeaderText = "FEED CODE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "rp_feed_type";
            this.Column5.HeaderText = "FEED TYPE";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "item_code";
            this.Column6.HeaderText = "ITEM CODE";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "rp_description";
            this.Column7.HeaderText = "DESCRIPTION";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "rp_category";
            this.Column8.HeaderText = "CATEGORY";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "rp_group";
            this.Column9.HeaderText = "GROUP";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "QTY";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "repacking_status";
            this.Column10.HeaderText = "STATUS";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "time_stamp_per_process";
            this.Column11.HeaderText = "TIMESTAMP";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "repacking_by";
            this.Column12.HeaderText = "BY";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // frmFormulationtoProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(954, 450);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFeedCode);
            this.Controls.Add(this.lblfeedtype);
            this.Controls.Add(this.txtprod_id);
            this.Controls.Add(this.lblprod);
            this.Controls.Add(this.txtluffy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFormulationtoProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFormulationtoProduction_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btngreaterthan;
        private System.Windows.Forms.TextBox txtmare;
        private System.Windows.Forms.DateTimePicker dateTimePicker12;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtsearchcode;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFeedCode;
        private System.Windows.Forms.Label lblfeedtype;
        private System.Windows.Forms.TextBox txtprod_id;
        private System.Windows.Forms.Label lblprod;
        private System.Windows.Forms.Label txtluffy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}