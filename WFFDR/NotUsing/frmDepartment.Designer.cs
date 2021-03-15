namespace WFFDR
{
    partial class frmDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartment));
            this.lstDepartments = new System.Windows.Forms.ListBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMYUP = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ToolStripBCancel = new System.Windows.Forms.ToolStripButton();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDepartments
            // 
            this.lstDepartments.BackColor = System.Drawing.SystemColors.Control;
            this.lstDepartments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDepartments.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDepartments.FormattingEnabled = true;
            this.lstDepartments.ItemHeight = 37;
            this.lstDepartments.Location = new System.Drawing.Point(13, 227);
            this.lstDepartments.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstDepartments.Name = "lstDepartments";
            this.lstDepartments.Size = new System.Drawing.Size(943, 557);
            this.lstDepartments.TabIndex = 26;
            this.lstDepartments.Click += new System.EventHandler(this.lstDepartments_Click);
            this.lstDepartments.SelectedIndexChanged += new System.EventHandler(this.lstDepartments_SelectedIndexChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ToolStrip1.Size = new System.Drawing.Size(968, 79);
            this.ToolStrip1.TabIndex = 28;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButtonNew
            // 
            this.ToolStripButtonNew.AutoSize = false;
            this.ToolStripButtonNew.Image = global::WFFDR.Properties.Resources.add_user_male_50px;
            this.ToolStripButtonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(51, 145);
            this.Label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(187, 38);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "Department  :";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.White;
            this.txtDepartment.Location = new System.Drawing.Point(317, 138);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(575, 38);
            this.txtDepartment.TabIndex = 29;
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(261, 410);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(177, 32);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "Confirmation";
            // 
            // frmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(968, 813);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.lstDepartments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartment";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department";
            this.Load += new System.EventHandler(this.frmDepartment_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstDepartments;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonNew;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonEdit;
        internal System.Windows.Forms.ToolStripButton ToolStripButtonUpdate;
        internal System.Windows.Forms.ToolStripButton ToolStripBCancel;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtDepartment;
        internal System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.ToolStripButton toolStripButtonMYUP;
        internal System.Windows.Forms.ToolStripButton toolStripButtonCancel2;
    }
}