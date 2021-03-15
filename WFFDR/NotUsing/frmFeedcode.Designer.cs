namespace WFFDR
{
    partial class frmFeedcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeedcode));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMYUP = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ToolStripBCancel = new System.Windows.Forms.ToolStripButton();
            this.txtFeedCode = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtFeedType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSacksColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProdType = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblrecords = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonNew,
            this.ToolStripButtonEdit,
            this.toolStripButtonMYUP,
            this.ToolStripButtonUpdate,
            this.toolStripButtonDelete,
            this.ToolStripBCancel});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ToolStrip1.Size = new System.Drawing.Size(2269, 69);
            this.ToolStrip1.TabIndex = 29;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButtonNew
            // 
            this.ToolStripButtonNew.AutoSize = false;
            this.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonNew.Name = "ToolStripButtonNew";
            this.ToolStripButtonNew.Size = new System.Drawing.Size(65, 40);
            this.ToolStripButtonNew.Text = "&New";
            this.ToolStripButtonNew.Click += new System.EventHandler(this.ToolStripButtonNew_Click);
            // 
            // ToolStripButtonEdit
            // 
            this.ToolStripButtonEdit.AutoSize = false;
            this.ToolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonEdit.Name = "ToolStripButtonEdit";
            this.ToolStripButtonEdit.Size = new System.Drawing.Size(65, 40);
            this.ToolStripButtonEdit.Text = "&Edit";
            this.ToolStripButtonEdit.Click += new System.EventHandler(this.ToolStripButtonEdit_Click);
            // 
            // toolStripButtonMYUP
            // 
            this.toolStripButtonMYUP.AutoSize = false;
            this.toolStripButtonMYUP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMYUP.Name = "toolStripButtonMYUP";
            this.toolStripButtonMYUP.Size = new System.Drawing.Size(65, 40);
            this.toolStripButtonMYUP.Text = "&Update";
            this.toolStripButtonMYUP.Click += new System.EventHandler(this.toolStripButtonMYUP_Click);
            // 
            // ToolStripButtonUpdate
            // 
            this.ToolStripButtonUpdate.AutoSize = false;
            this.ToolStripButtonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonUpdate.Name = "ToolStripButtonUpdate";
            this.ToolStripButtonUpdate.Size = new System.Drawing.Size(65, 40);
            this.ToolStripButtonUpdate.Text = "&Save";
            this.ToolStripButtonUpdate.Click += new System.EventHandler(this.ToolStripButtonUpdate_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.AutoSize = false;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(65, 40);
            this.toolStripButtonDelete.Text = "&Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // ToolStripBCancel
            // 
            this.ToolStripBCancel.AutoSize = false;
            this.ToolStripBCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBCancel.Name = "ToolStripBCancel";
            this.ToolStripBCancel.Size = new System.Drawing.Size(65, 40);
            this.ToolStripBCancel.Text = "&Cancel";
            this.ToolStripBCancel.Click += new System.EventHandler(this.ToolStripBCancel_Click);
            // 
            // txtFeedCode
            // 
            this.txtFeedCode.BackColor = System.Drawing.Color.White;
            this.txtFeedCode.Location = new System.Drawing.Point(370, 111);
            this.txtFeedCode.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFeedCode.Multiline = true;
            this.txtFeedCode.Name = "txtFeedCode";
            this.txtFeedCode.Size = new System.Drawing.Size(1337, 61);
            this.txtFeedCode.TabIndex = 31;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(115, 141);
            this.Label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(177, 32);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "Feed Code  :";
            // 
            // txtFeedType
            // 
            this.txtFeedType.BackColor = System.Drawing.Color.White;
            this.txtFeedType.Location = new System.Drawing.Point(370, 186);
            this.txtFeedType.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFeedType.Multiline = true;
            this.txtFeedType.Name = "txtFeedType";
            this.txtFeedType.Size = new System.Drawing.Size(1337, 59);
            this.txtFeedType.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 32);
            this.label1.TabIndex = 32;
            this.label1.Text = "Feed Type :";
            // 
            // txtSacksColor
            // 
            this.txtSacksColor.BackColor = System.Drawing.Color.White;
            this.txtSacksColor.Location = new System.Drawing.Point(369, 259);
            this.txtSacksColor.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtSacksColor.Multiline = true;
            this.txtSacksColor.Name = "txtSacksColor";
            this.txtSacksColor.Size = new System.Drawing.Size(1338, 59);
            this.txtSacksColor.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 32);
            this.label2.TabIndex = 34;
            this.label2.Text = "Sacks Color :";
            // 
            // cboProdType
            // 
            this.cboProdType.BackColor = System.Drawing.Color.White;
            this.cboProdType.FormattingEnabled = true;
            this.cboProdType.Location = new System.Drawing.Point(370, 58);
            this.cboProdType.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboProdType.Name = "cboProdType";
            this.cboProdType.Size = new System.Drawing.Size(656, 39);
            this.cboProdType.TabIndex = 81;
            this.cboProdType.SelectedIndexChanged += new System.EventHandler(this.cboProdType_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(133, 60);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(160, 32);
            this.lblDepartment.TabIndex = 82;
            this.lblDepartment.Text = "Prod Type :";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeight = 30;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.SystemColors.Control;
            this.dgv1.Location = new System.Drawing.Point(97, 549);
            this.dgv1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 20;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.ShowCellErrors = false;
            this.dgv1.ShowCellToolTips = false;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.ShowRowErrors = false;
            this.dgv1.Size = new System.Drawing.Size(1759, 603);
            this.dgv1.TabIndex = 83;
            this.dgv1.CurrentCellChanged += new System.EventHandler(this.dgv1_CurrentCellChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(1541, 1399);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(187, 34);
            this.lblName.TabIndex = 84;
            this.lblName.Text = "Sacks Color :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1999, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 79);
            this.button1.TabIndex = 85;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(1213, 1294);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(575, 38);
            this.txtsearch.TabIndex = 86;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.Location = new System.Drawing.Point(1824, 1299);
            this.lblrecords.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(187, 34);
            this.lblrecords.TabIndex = 87;
            this.lblrecords.Text = "Sacks Color :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDepartment);
            this.groupBox1.Controls.Add(this.txtFeedCode);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFeedType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboProdType);
            this.groupBox1.Controls.Add(this.txtSacksColor);
            this.groupBox1.Location = new System.Drawing.Point(94, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1762, 369);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feed Code Informations";
            // 
            // frmFeedcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2269, 1370);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblrecords);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.ToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmFeedcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feed Code";
            this.Load += new System.EventHandler(this.frmFeedcode_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonNew;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonEdit;
        internal System.Windows.Forms.ToolStripButton toolStripButtonMYUP;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonUpdate;
        internal System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        internal System.Windows.Forms.ToolStripButton ToolStripBCancel;
        internal System.Windows.Forms.TextBox txtSacksColor;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtFeedType;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtFeedCode;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ComboBox cboProdType;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.DataGridView dgv1;
        internal System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtsearch;
        internal System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}