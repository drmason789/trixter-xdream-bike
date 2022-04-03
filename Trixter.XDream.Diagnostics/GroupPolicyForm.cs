using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trixter.XDream.Diagnostics
{
    public partial class GroupPolicyForm : Form
    {
        public GroupPolicyForm()
        {
            InitializeComponent();

            
            XDreamDeviceGroupPolicyUsbDeviceRestrictionReader xdr = new XDreamDeviceGroupPolicyUsbDeviceRestrictionReader();
            XDreamDeviceBlockingReport report = new XDreamDeviceBlockingReport(xdr);

            this.lbSummary.Text = report.GetSummary();
            this.cbBlocking.Checked = xdr.DenyDeviceIDs;
            this.cbRetroactive.Checked = xdr.DenyDeviceIDsRetroactive;

            foreach (var item in xdr.XDreamDevicesListed)
                this.lbDevices.Items.Add(item);
        }

        private void cbBlocking_CheckedChanged(object sender, EventArgs e)
        {
            this.pnBlocking.Enabled = this.cbBlocking.Checked;
            this.cbRetroactive.Enabled = this.cbBlocking.Checked;
        }
    }
}
