﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trixter.XDream.Diagnostics.Controls
{
    public partial class GroupPolicy : UserControl
    {
        public GroupPolicy()
        {
            InitializeComponent();
        }
        public void UpdateDetails()
        {
            XDreamDeviceGroupPolicyUsbDeviceRestrictionReader xdr = new XDreamDeviceGroupPolicyUsbDeviceRestrictionReader();
            XDreamDeviceBlockingReport report = new XDreamDeviceBlockingReport(xdr);

            this.lbSummary.Text = report.GetSummary();
            this.lblOpinion.Text = report.GetOpinion();
            this.cbBlocking.Checked = xdr.DenyDeviceIDs;
            this.cbRetroactive.Checked = xdr.DenyDeviceIDsRetroactive;
            this.pnBlocking.Enabled = this.cbBlocking.Checked;
            this.cbRetroactive.Enabled = this.cbBlocking.Checked;

            foreach (var item in xdr.XDreamDevicesListed)
                this.lbDevices.Items.Add(item);
        }

    }
}
