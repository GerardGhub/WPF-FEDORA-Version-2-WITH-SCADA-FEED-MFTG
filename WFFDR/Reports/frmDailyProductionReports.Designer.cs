namespace WFFDR
{
    partial class frmDailyProductionReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailyProductionReports));
            this.panel300 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btndailyprod = new System.Windows.Forms.Button();
            this.dtpprod2 = new System.Windows.Forms.DateTimePicker();
            this.dtpprod1 = new System.Windows.Forms.DateTimePicker();
            this.panel300.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel300
            // 
            this.panel300.BackColor = System.Drawing.SystemColors.Window;
            this.panel300.Controls.Add(this.groupBox5);
            this.panel300.Location = new System.Drawing.Point(2, 0);
            this.panel300.Name = "panel300";
            this.panel300.Size = new System.Drawing.Size(486, 287);
            this.panel300.TabIndex = 549;
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
            this.groupBox5.Location = new System.Drawing.Point(8, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(471, 269);
            this.groupBox5.TabIndex = 542;
            this.groupBox5.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Bright", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 22);
            this.label14.TabIndex = 530;
            this.label14.Text = "TO :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lucida Bright", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 22);
            this.label15.TabIndex = 530;
            this.label15.Text = "FROM :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(1, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(464, 66);
            this.panel5.TabIndex = 544;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(80, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(296, 28);
            this.label16.TabIndex = 1;
            this.label16.Text = "Daily Production Report";
            // 
            // btndailyprod
            // 
            this.btndailyprod.BackColor = System.Drawing.SystemColors.Window;
            this.btndailyprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndailyprod.Font = new System.Drawing.Font("Lucida Bright", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndailyprod.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btndailyprod.Location = new System.Drawing.Point(144, 224);
            this.btndailyprod.Name = "btndailyprod";
            this.btndailyprod.Size = new System.Drawing.Size(177, 33);
            this.btndailyprod.TabIndex = 5;
            this.btndailyprod.Text = "GENERATE";
            this.btndailyprod.UseVisualStyleBackColor = false;
            this.btndailyprod.Click += new System.EventHandler(this.btndailyprod_Click);
            // 
            // dtpprod2
            // 
            this.dtpprod2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.CustomFormat = "M/d/yyyy";
            this.dtpprod2.Font = new System.Drawing.Font("Lucida Bright", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod2.Location = new System.Drawing.Point(104, 167);
            this.dtpprod2.Name = "dtpprod2";
            this.dtpprod2.Size = new System.Drawing.Size(284, 39);
            this.dtpprod2.TabIndex = 7;
            // 
            // dtpprod1
            // 
            this.dtpprod1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.CustomFormat = "M/d/yyyy";
            this.dtpprod1.Font = new System.Drawing.Font("Lucida Bright", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpprod1.Location = new System.Drawing.Point(104, 94);
            this.dtpprod1.Name = "dtpprod1";
            this.dtpprod1.Size = new System.Drawing.Size(284, 39);
            this.dtpprod1.TabIndex = 4;
            // 
            // frmDailyProductionReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 288);
            this.Controls.Add(this.panel300);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyProductionReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDailyProductionReports";
            this.panel300.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel300;
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