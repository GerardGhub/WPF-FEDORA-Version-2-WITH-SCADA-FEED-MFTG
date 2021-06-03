﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;

namespace SharpUpdate
{
    public partial class SharpUpdateInfoForm : Form
    {
        public SharpUpdateInfoForm(ISharpUpdatable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();


            if(applicationInfo.ApplicationIcon != null)
            {
                this.Icon = applicationInfo.ApplicationIcon;
                this.Text = applicationInfo.ApplicationName + "- Update Info";
                this.lblVersions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(),
                    updateInfo.Version.ToString());
                this.txtDescription.Text = updateInfo.Description;

           
                    
            }

        }

        private void SharpUpdateInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}