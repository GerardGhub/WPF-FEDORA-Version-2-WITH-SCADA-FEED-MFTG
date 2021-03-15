namespace WFFDR
{
    partial class frmPositions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPositions));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMYUP = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ToolStripBCancel = new System.Windows.Forms.ToolStripButton();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.position_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.lblSection);
            this.groupBox2.Controls.Add(this.cboSection);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 110);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Size = new System.Drawing.Size(997, 103);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.BackColor = System.Drawing.Color.Transparent;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.Black;
            this.lblSection.Location = new System.Drawing.Point(16, 36);
            this.lblSection.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(108, 38);
            this.lblSection.TabIndex = 97;
            this.lblSection.Text = "Section";
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(165, 31);
            this.cboSection.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(783, 40);
            this.cboSection.TabIndex = 95;
            this.cboSection.SelectedValueChanged += new System.EventHandler(this.cboSection_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox3.Controls.Add(this.txtPosition);
            this.groupBox3.Controls.Add(this.lblName);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(19, 227);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Size = new System.Drawing.Size(997, 105);
            this.groupBox3.TabIndex = 107;
            this.groupBox3.TabStop = false;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(155, 33);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(793, 39);
            this.txtPosition.TabIndex = 103;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(16, 41);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(127, 38);
            this.lblName.TabIndex = 101;
            this.lblName.Text = "Positions";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonNew,
            this.ToolStripButtonEdit,
            this.toolStripButtonMYUP,
            this.ToolStripButtonUpdate,
            this.toolStripButtonCancel2,
            this.toolStripButtonDelete,
            this.ToolStripBCancel});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ToolStrip1.Size = new System.Drawing.Size(1035, 76);
            this.ToolStrip1.TabIndex = 109;
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
            // toolStripButtonCancel2
            // 
            this.toolStripButtonCancel2.AutoSize = false;
            this.toolStripButtonCancel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel2.Name = "toolStripButtonCancel2";
            this.toolStripButtonCancel2.Size = new System.Drawing.Size(65, 40);
            this.toolStripButtonCancel2.Text = "&Cancel";
            this.toolStripButtonCancel2.Click += new System.EventHandler(this.toolStripButtonCancel2_Click);
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
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeight = 58;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.position_id,
            this.position_name,
            this.section_name,
            this.section_id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv1.Location = new System.Drawing.Point(43, 346);
            this.dgv1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 102;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.ShowCellErrors = false;
            this.dgv1.ShowCellToolTips = false;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.ShowRowErrors = false;
            this.dgv1.Size = new System.Drawing.Size(949, 300);
            this.dgv1.TabIndex = 110;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CurrentCellChanged += new System.EventHandler(this.dgv1_CurrentCellChanged);
            // 
            // position_id
            // 
            this.position_id.DataPropertyName = "position_id";
            this.position_id.HeaderText = "ID";
            this.position_id.MinimumWidth = 12;
            this.position_id.Name = "position_id";
            this.position_id.ReadOnly = true;
            this.position_id.Width = 50;
            // 
            // position_name
            // 
            this.position_name.DataPropertyName = "position_name";
            this.position_name.HeaderText = "Position";
            this.position_name.MinimumWidth = 12;
            this.position_name.Name = "position_name";
            this.position_name.ReadOnly = true;
            this.position_name.Width = 250;
            // 
            // section_name
            // 
            this.section_name.DataPropertyName = "section_name";
            this.section_name.HeaderText = "Section";
            this.section_name.MinimumWidth = 12;
            this.section_name.Name = "section_name";
            this.section_name.ReadOnly = true;
            this.section_name.Visible = false;
            this.section_name.Width = 250;
            // 
            // section_id
            // 
            this.section_id.DataPropertyName = "section_id";
            this.section_id.HeaderText = "Section ID";
            this.section_id.MinimumWidth = 12;
            this.section_id.Name = "section_id";
            this.section_id.ReadOnly = true;
            this.section_id.Visible = false;
            this.section_id.Width = 250;
            // 
            // frmPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1035, 1621);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Positions";
            this.Load += new System.EventHandler(this.frmPositions_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonNew;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonEdit;
        internal System.Windows.Forms.ToolStripButton toolStripButtonMYUP;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonUpdate;
        internal System.Windows.Forms.ToolStripButton toolStripButtonCancel2;
        internal System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        internal System.Windows.Forms.ToolStripButton ToolStripBCancel;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn section_id;
        private System.Windows.Forms.TextBox txtPosition;
    }
}