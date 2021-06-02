using System;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateAcceptForm : Form
    {
        private ISharpUpdatable applicationInfo;
        private SharpUpdateXml updateInfo;
        private SharpUpdateInfoForm updateInfoform;

        internal SharpUpdateAcceptForm(ISharpUpdatable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();
            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;
            this.Text = this.applicationInfo.ApplicationName + " - Update Available";
            if (this.applicationInfo.ApplicationIcon != null)
                this.Icon = this.applicationInfo.ApplicationIcon;

            this.lblNewVersion.Text = string.Format("New Version: {0}", this.updateInfo.Version.ToString());
        }

        private void SharpUpdateAcceptForm_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
        //    if (this.updateInfoform == null)
        //        this.updateInfoform = new SharpUpdateInfoForm(this.applicationInfo, this.updateInfo);
        //            this.updateInfoform.ShowDialog(this);
        }
    }
}
