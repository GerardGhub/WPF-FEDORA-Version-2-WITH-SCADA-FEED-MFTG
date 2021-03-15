namespace WFFDR
{
    partial class frmTransactMoveOrderQtyUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactMoveOrderQtyUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblencodedby = new System.Windows.Forms.Label();
            this.lblorder = new System.Windows.Forms.Label();
            this.lblprodid = new System.Windows.Forms.Label();
            this.lbltotalmoveorder = new System.Windows.Forms.Label();
            this.lbladdition = new System.Windows.Forms.Label();
            this.lblsubtract = new System.Windows.Forms.Label();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.lblactual = new System.Windows.Forms.Label();
            this.lblavailable = new System.Windows.Forms.Label();
            this.txtmoveorder = new System.Windows.Forms.Label();
            this.lblfginventory = new System.Windows.Forms.Label();
            this.txtactualqty = new System.Windows.Forms.TextBox();
            this.txtdateandtime = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.btnHIDE = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtdatenow = new System.Windows.Forms.TextBox();
            this.lblqty = new System.Windows.Forms.Label();
            this.dgvUpdateSource = new System.Windows.Forms.DataGridView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateSource)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(444, 325);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 632;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(512, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 47);
            this.panel1.TabIndex = 633;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ActiveBorderThickness = 1;
            this.btnUpdate.ActiveCornerRadius = 2;
            this.btnUpdate.ActiveFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnUpdate.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.ButtonText = "UPDATE";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.IdleBorderThickness = 1;
            this.btnUpdate.IdleCornerRadius = 10;
            this.btnUpdate.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.IdleForecolor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnUpdate.IdleLineColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(20, 184);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 34);
            this.btnUpdate.TabIndex = 624;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblencodedby
            // 
            this.lblencodedby.AutoSize = true;
            this.lblencodedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblencodedby.Location = new System.Drawing.Point(387, 54);
            this.lblencodedby.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblencodedby.Name = "lblencodedby";
            this.lblencodedby.Size = new System.Drawing.Size(78, 13);
            this.lblencodedby.TabIndex = 633;
            this.lblencodedby.Text = "Production ID :";
            // 
            // lblorder
            // 
            this.lblorder.AutoSize = true;
            this.lblorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblorder.Location = new System.Drawing.Point(101, 55);
            this.lblorder.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblorder.Name = "lblorder";
            this.lblorder.Size = new System.Drawing.Size(78, 13);
            this.lblorder.TabIndex = 632;
            this.lblorder.Text = "Production ID :";
            // 
            // lblprodid
            // 
            this.lblprodid.AutoSize = true;
            this.lblprodid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprodid.Location = new System.Drawing.Point(103, 29);
            this.lblprodid.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblprodid.Name = "lblprodid";
            this.lblprodid.Size = new System.Drawing.Size(70, 13);
            this.lblprodid.TabIndex = 631;
            this.lblprodid.Text = "Encoded by :";
            // 
            // lbltotalmoveorder
            // 
            this.lbltotalmoveorder.AutoSize = true;
            this.lbltotalmoveorder.Location = new System.Drawing.Point(136, 187);
            this.lbltotalmoveorder.Name = "lbltotalmoveorder";
            this.lbltotalmoveorder.Size = new System.Drawing.Size(14, 13);
            this.lbltotalmoveorder.TabIndex = 630;
            this.lbltotalmoveorder.Text = "0";
            // 
            // lbladdition
            // 
            this.lbladdition.AutoSize = true;
            this.lbladdition.Location = new System.Drawing.Point(222, 299);
            this.lbladdition.Name = "lbladdition";
            this.lbladdition.Size = new System.Drawing.Size(13, 13);
            this.lbladdition.TabIndex = 629;
            this.lbladdition.Text = "0";
            // 
            // lblsubtract
            // 
            this.lblsubtract.AutoSize = true;
            this.lblsubtract.Location = new System.Drawing.Point(102, 134);
            this.lblsubtract.Name = "lblsubtract";
            this.lblsubtract.Size = new System.Drawing.Size(14, 13);
            this.lblsubtract.TabIndex = 628;
            this.lblsubtract.Text = "0";
            // 
            // txtinput
            // 
            this.txtinput.BackColor = System.Drawing.Color.Yellow;
            this.txtinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtinput.Location = new System.Drawing.Point(391, 77);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(118, 21);
            this.txtinput.TabIndex = 627;
            this.txtinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtinput.TextChanged += new System.EventHandler(this.txtinput_TextChanged);
            // 
            // lblactual
            // 
            this.lblactual.AutoSize = true;
            this.lblactual.Location = new System.Drawing.Point(154, 301);
            this.lblactual.Name = "lblactual";
            this.lblactual.Size = new System.Drawing.Size(13, 13);
            this.lblactual.TabIndex = 624;
            this.lblactual.Text = "0";
            // 
            // lblavailable
            // 
            this.lblavailable.AutoSize = true;
            this.lblavailable.Location = new System.Drawing.Point(388, 108);
            this.lblavailable.Name = "lblavailable";
            this.lblavailable.Size = new System.Drawing.Size(14, 13);
            this.lblavailable.TabIndex = 623;
            this.lblavailable.Text = "0";
            // 
            // txtmoveorder
            // 
            this.txtmoveorder.AutoSize = true;
            this.txtmoveorder.Location = new System.Drawing.Point(388, 134);
            this.txtmoveorder.Name = "txtmoveorder";
            this.txtmoveorder.Size = new System.Drawing.Size(14, 13);
            this.txtmoveorder.TabIndex = 620;
            this.txtmoveorder.Text = "0";
            // 
            // lblfginventory
            // 
            this.lblfginventory.AutoSize = true;
            this.lblfginventory.Location = new System.Drawing.Point(102, 108);
            this.lblfginventory.Name = "lblfginventory";
            this.lblfginventory.Size = new System.Drawing.Size(14, 13);
            this.lblfginventory.TabIndex = 619;
            this.lblfginventory.Text = "0";
            // 
            // txtactualqty
            // 
            this.txtactualqty.BackColor = System.Drawing.Color.White;
            this.txtactualqty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtactualqty.Enabled = false;
            this.txtactualqty.Location = new System.Drawing.Point(104, 82);
            this.txtactualqty.Name = "txtactualqty";
            this.txtactualqty.Size = new System.Drawing.Size(79, 14);
            this.txtactualqty.TabIndex = 616;
            this.txtactualqty.Text = "0";
            // 
            // txtdateandtime
            // 
            this.txtdateandtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdateandtime.Location = new System.Drawing.Point(391, 24);
            this.txtdateandtime.Name = "txtdateandtime";
            this.txtdateandtime.Size = new System.Drawing.Size(118, 21);
            this.txtdateandtime.TabIndex = 603;
            this.txtdateandtime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdateandtime.Visible = false;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(586, 45);
            this.lblid.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(19, 13);
            this.lblid.TabIndex = 634;
            this.lblid.Text = "00";
            this.lblid.Visible = false;
            // 
            // btnHIDE
            // 
            this.btnHIDE.ActiveBorderThickness = 1;
            this.btnHIDE.ActiveCornerRadius = 2;
            this.btnHIDE.ActiveFillColor = System.Drawing.Color.CornflowerBlue;
            this.btnHIDE.ActiveForecolor = System.Drawing.SystemColors.Window;
            this.btnHIDE.ActiveLineColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.BackColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHIDE.BackgroundImage")));
            this.btnHIDE.ButtonText = "X";
            this.btnHIDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHIDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHIDE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHIDE.IdleBorderThickness = 1;
            this.btnHIDE.IdleCornerRadius = 10;
            this.btnHIDE.IdleFillColor = System.Drawing.SystemColors.Window;
            this.btnHIDE.IdleForecolor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnHIDE.IdleLineColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnHIDE.Location = new System.Drawing.Point(610, 95);
            this.btnHIDE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHIDE.Name = "btnHIDE";
            this.btnHIDE.Size = new System.Drawing.Size(38, 34);
            this.btnHIDE.TabIndex = 616;
            this.btnHIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtdatenow
            // 
            this.txtdatenow.Location = new System.Drawing.Point(313, 299);
            this.txtdatenow.Name = "txtdatenow";
            this.txtdatenow.Size = new System.Drawing.Size(152, 20);
            this.txtdatenow.TabIndex = 605;
            this.txtdatenow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdatenow.Visible = false;
            // 
            // lblqty
            // 
            this.lblqty.AutoSize = true;
            this.lblqty.Location = new System.Drawing.Point(556, 325);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(72, 13);
            this.lblqty.TabIndex = 603;
            this.lblqty.Text = "Qty Received";
            this.lblqty.Visible = false;
            // 
            // dgvUpdateSource
            // 
            this.dgvUpdateSource.AllowUserToAddRows = false;
            this.dgvUpdateSource.AllowUserToDeleteRows = false;
            this.dgvUpdateSource.AllowUserToResizeColumns = false;
            this.dgvUpdateSource.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvUpdateSource.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUpdateSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateSource.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUpdateSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUpdateSource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUpdateSource.ColumnHeadersHeight = 30;
            this.dgvUpdateSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUpdateSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvUpdateSource.EnableHeadersVisualStyles = false;
            this.dgvUpdateSource.GridColor = System.Drawing.SystemColors.Control;
            this.dgvUpdateSource.Location = new System.Drawing.Point(617, 25);
            this.dgvUpdateSource.MultiSelect = false;
            this.dgvUpdateSource.Name = "dgvUpdateSource";
            this.dgvUpdateSource.ReadOnly = true;
            this.dgvUpdateSource.RowHeadersWidth = 50;
            this.dgvUpdateSource.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
            this.dgvUpdateSource.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUpdateSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateSource.Size = new System.Drawing.Size(49, 47);
            this.dgvUpdateSource.TabIndex = 634;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.label12);
            this.GroupBox3.Controls.Add(this.lbltotalmoveorder);
            this.GroupBox3.Controls.Add(this.label4);
            this.GroupBox3.Controls.Add(this.label3);
            this.GroupBox3.Controls.Add(this.label2);
            this.GroupBox3.Controls.Add(this.label1);
            this.GroupBox3.Controls.Add(this.lblsubtract);
            this.GroupBox3.Controls.Add(this.label11);
            this.GroupBox3.Controls.Add(this.label10);
            this.GroupBox3.Controls.Add(this.txtmoveorder);
            this.GroupBox3.Controls.Add(this.txtinput);
            this.GroupBox3.Controls.Add(this.lblencodedby);
            this.GroupBox3.Controls.Add(this.lblavailable);
            this.GroupBox3.Controls.Add(this.button2);
            this.GroupBox3.Controls.Add(this.lblorder);
            this.GroupBox3.Controls.Add(this.label6);
            this.GroupBox3.Controls.Add(this.lblfginventory);
            this.GroupBox3.Controls.Add(this.label7);
            this.GroupBox3.Controls.Add(this.lblprodid);
            this.GroupBox3.Controls.Add(this.label8);
            this.GroupBox3.Controls.Add(this.txtactualqty);
            this.GroupBox3.Controls.Add(this.label9);
            this.GroupBox3.Controls.Add(this.txtdateandtime);
            this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(11, 1);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(536, 207);
            this.GroupBox3.TabIndex = 635;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Update Transactions Move Order Quantity";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 13);
            this.label12.TabIndex = 638;
            this.label12.Text = "Actual Move Order :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 637;
            this.label4.Text = "Move Order :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 636;
            this.label3.Text = "Actual :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 635;
            this.label2.Text = "Available Qty :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 634;
            this.label1.Text = "Actual Quantity :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(298, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 633;
            this.label11.Text = "Encoded by :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 632;
            this.label10.Text = "Move Order Date :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(414, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 468;
            this.button2.Text = "&Save ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 460;
            this.label6.Text = "Bags :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Production ID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Quantity :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Order No :";
            // 
            // frmTransactMoveOrderQtyUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(558, 211);
            this.Controls.Add(this.lbladdition);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.lblactual);
            this.Controls.Add(this.dgvUpdateSource);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblqty);
            this.Controls.Add(this.txtdatenow);
            this.Controls.Add(this.btnHIDE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransactMoveOrderQtyUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTransactMoveOrderQtyUpdate_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateSource)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotalmoveorder;
        private System.Windows.Forms.Label lbladdition;
        private System.Windows.Forms.Label lblsubtract;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUpdate;
        private System.Windows.Forms.Label lblactual;
        private System.Windows.Forms.Label lblavailable;
        private System.Windows.Forms.Label txtmoveorder;
        private System.Windows.Forms.Label lblfginventory;
        private System.Windows.Forms.TextBox txtactualqty;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHIDE;
        private System.Windows.Forms.TextBox txtdatenow;
        private System.Windows.Forms.TextBox txtdateandtime;
        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.Label lblprodid;
        private System.Windows.Forms.Label lblorder;
        private System.Windows.Forms.Label lblencodedby;
        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.DataGridView dgvUpdateSource;
        private System.Windows.Forms.Label lblid;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label10;
    }
}