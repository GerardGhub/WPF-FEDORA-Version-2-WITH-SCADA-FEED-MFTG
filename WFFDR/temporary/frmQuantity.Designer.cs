namespace WFFDR
{
    partial class frmQuantity
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
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboDescription = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboFeedType = new System.Windows.Forms.ComboBox();
            this.dgvQuantity = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(24, 73);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(65, 16);
            this.Label6.TabIndex = 173;
            this.Label6.Text = "Category :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(20, 103);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 16);
            this.Label3.TabIndex = 174;
            this.Label3.Text = "Feed Type :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(15, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 16);
            this.Label2.TabIndex = 175;
            this.Label2.Text = "Description :";
            // 
            // cboDescription
            // 
            this.cboDescription.BackColor = System.Drawing.SystemColors.Window;
            this.cboDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescription.FormattingEnabled = true;
            this.cboDescription.Location = new System.Drawing.Point(94, 47);
            this.cboDescription.Name = "cboDescription";
            this.cboDescription.Size = new System.Drawing.Size(281, 21);
            this.cboDescription.TabIndex = 176;
            this.cboDescription.SelectedIndexChanged += new System.EventHandler(this.cboDescription_SelectedIndexChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(94, 73);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(281, 21);
            this.cboCategory.TabIndex = 177;
            this.cboCategory.SelectedValueChanged += new System.EventHandler(this.cboCategory_SelectedValueChanged);
            // 
            // cboFeedType
            // 
            this.cboFeedType.BackColor = System.Drawing.SystemColors.Window;
            this.cboFeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeedType.FormattingEnabled = true;
            this.cboFeedType.Location = new System.Drawing.Point(94, 101);
            this.cboFeedType.Name = "cboFeedType";
            this.cboFeedType.Size = new System.Drawing.Size(281, 21);
            this.cboFeedType.TabIndex = 178;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.AllowUserToAddRows = false;
            this.dgvQuantity.AllowUserToDeleteRows = false;
            this.dgvQuantity.AllowUserToResizeColumns = false;
            this.dgvQuantity.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvQuantity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuantity.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuantity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuantity.ColumnHeadersHeight = 58;
            this.dgvQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQuantity.EnableHeadersVisualStyles = false;
            this.dgvQuantity.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvQuantity.Location = new System.Drawing.Point(13, 180);
            this.dgvQuantity.MultiSelect = false;
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.ReadOnly = true;
            this.dgvQuantity.RowHeadersWidth = 20;
            this.dgvQuantity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvQuantity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuantity.ShowCellErrors = false;
            this.dgvQuantity.ShowCellToolTips = false;
            this.dgvQuantity.ShowEditingIcon = false;
            this.dgvQuantity.ShowRowErrors = false;
            this.dgvQuantity.Size = new System.Drawing.Size(407, 260);
            this.dgvQuantity.TabIndex = 179;
            this.dgvQuantity.CurrentCellChanged += new System.EventHandler(this.dgvQuantity_CurrentCellChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 132);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 181;
            this.label1.Text = "Quantity :";
            // 
            // frmQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvQuantity);
            this.Controls.Add(this.cboFeedType);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cboDescription);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "frmQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantity";
            this.Load += new System.EventHandler(this.frmQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cboDescription;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboFeedType;
        private System.Windows.Forms.DataGridView dgvQuantity;
        private System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Label label1;
    }
}