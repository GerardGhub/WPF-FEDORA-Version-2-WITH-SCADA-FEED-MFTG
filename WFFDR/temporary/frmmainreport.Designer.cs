namespace WFFDR
{
    partial class frmmainreport
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
            this.MicroBook1 = new WFFDR.MicroBook();
            this.crV1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.MacroBook2 = new WFFDR.MacroBook();
            this.MacroBook1 = new WFFDR.MacroBook();
            this.SuspendLayout();
            // 
            // crV1
            // 
            this.crV1.ActiveViewIndex = -1;
            this.crV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crV1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crV1.Location = new System.Drawing.Point(0, 0);
            this.crV1.Name = "crV1";
            this.crV1.Size = new System.Drawing.Size(2540, 1148);
            this.crV1.TabIndex = 1;
            // 
            // MacroBook1
            // 
            this.MacroBook1.InitReport += new System.EventHandler(this.MacroBook1_InitReport);
            // 
            // frmmainreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2540, 1148);
            this.Controls.Add(this.crV1);
            this.Name = "frmmainreport";
            this.Text = "frmmainreport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmmainreport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crV1;
        private MicroBook MicroBook1;
        private MacroBook MacroBook1;
        private MacroBook MacroBook2;
    }
}