
namespace WFFDR.Reports
{
    partial class frmFGReceivingReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFGReceivingReports));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btndailyprod = new System.Windows.Forms.Button();
            this.dtpprod2 = new System.Windows.Forms.DateTimePicker();
            this.dtpprod1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Controls.Add(this.btndailyprod);
            this.groupBox5.Controls.Add(this.dtpprod2);
            this.groupBox5.Controls.Add(this.dtpprod1);
            this.groupBox5.Location = new System.Drawing.Point(9, 5);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(628, 331);
            this.groupBox5.TabIndex = 543;
            this.groupBox5.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Bright", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(47, 215);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 27);
            this.label14.TabIndex = 530;
            this.label14.Text = "TO :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Bright", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 122);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 27);
            this.label15.TabIndex = 530;
            this.label15.Text = "FROM :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(1, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(618, 81);
            this.panel5.TabIndex = 544;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(149, 12);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(304, 34);
            this.label16.TabIndex = 1;
            this.label16.Text = "FG Received Report";
            // 
            // btndailyprod
            // 
            this.btndailyprod.BackColor = System.Drawing.SystemColors.Window;
            this.btndailyprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndailyprod.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndailyprod.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btndailyprod.Location = new System.Drawing.Point(192, 276);
            this.btndailyprod.Margin = new System.Windows.Forms.Padding(4);
            this.btndailyprod.Name = "btndailyprod";
            this.btndailyprod.Size = new System.Drawing.Size(236, 41);
            this.btndailyprod.TabIndex = 5;
            this.btndailyprod.Text = "GENERATE";
            this.btndailyprod.UseVisualStyleBackColor = false;
            this.btndailyprod.Click += new System.EventHandler(this.btndailyprod_Click);
            // 
            // dtpprod2
            // 
            this.dtpprod2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.CustomFormat = "MM/dd/yyyy";
            this.dtpprod2.Font = new System.Drawing.Font("Lucida Bright", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod2.Location = new System.Drawing.Point(139, 206);
            this.dtpprod2.Margin = new System.Windows.Forms.Padding(4);
            this.dtpprod2.Name = "dtpprod2";
            this.dtpprod2.Size = new System.Drawing.Size(377, 47);
            this.dtpprod2.TabIndex = 7;
            // 
            // dtpprod1
            // 
            this.dtpprod1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.CustomFormat = "MM/dd/yyyy";
            this.dtpprod1.Font = new System.Drawing.Font("Lucida Bright", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod1.Location = new System.Drawing.Point(139, 116);
            this.dtpprod1.Margin = new System.Windows.Forms.Padding(4);
            this.dtpprod1.Name = "dtpprod1";
            this.dtpprod1.Size = new System.Drawing.Size(377, 47);
            this.dtpprod1.TabIndex = 4;
            // 
            // frmFGReceivingReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 340);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFGReceivingReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finished Goods Received Reports";
            this.Load += new System.EventHandler(this.frmFGReceivingReports_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btndailyprod;
        private System.Windows.Forms.DateTimePicker dtpprod2;
        private System.Windows.Forms.DateTimePicker dtpprod1;
    }
}