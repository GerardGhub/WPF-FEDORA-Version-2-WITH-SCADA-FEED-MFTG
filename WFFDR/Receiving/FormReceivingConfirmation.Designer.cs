
namespace WFFDR.Receiving
{
    partial class FormReceivingConfirmation
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.confirmquan = new System.Windows.Forms.Label();
            this.lblconfirmtxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please confirm the total quantity:";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(273, 33);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(100, 22);
            this.txtconfirm.TabIndex = 1;
            // 
            // confirmbtn
            // 
            this.confirmbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confirmbtn.Location = new System.Drawing.Point(379, 30);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(75, 28);
            this.confirmbtn.TabIndex = 2;
            this.confirmbtn.Text = "Confirm";
            this.confirmbtn.UseVisualStyleBackColor = true;
            this.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
            // 
            // confirmquan
            // 
            this.confirmquan.AutoSize = true;
            this.confirmquan.Location = new System.Drawing.Point(201, 9);
            this.confirmquan.Name = "confirmquan";
            this.confirmquan.Size = new System.Drawing.Size(46, 17);
            this.confirmquan.TabIndex = 3;
            this.confirmquan.Text = "label2";
            // 
            // lblconfirmtxt
            // 
            this.lblconfirmtxt.AutoSize = true;
            this.lblconfirmtxt.Location = new System.Drawing.Point(273, 9);
            this.lblconfirmtxt.Name = "lblconfirmtxt";
            this.lblconfirmtxt.Size = new System.Drawing.Size(46, 17);
            this.lblconfirmtxt.TabIndex = 4;
            this.lblconfirmtxt.Text = "label2";
            this.lblconfirmtxt.TextChanged += new System.EventHandler(this.lblconfirmtxt_TextChanged);
            // 
            // FormReceivingConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 72);
            this.Controls.Add(this.lblconfirmtxt);
            this.Controls.Add(this.confirmquan);
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormReceivingConfirmation";
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.FormReceivingConfirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Button confirmbtn;
        private System.Windows.Forms.Label confirmquan;
        private System.Windows.Forms.Label lblconfirmtxt;
    }
}