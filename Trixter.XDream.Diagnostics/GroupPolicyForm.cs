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

            this.pbIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap();

            XDreamDeviceGroupPolicyUsbDeviceRestrictionReader xdr = new XDreamDeviceGroupPolicyUsbDeviceRestrictionReader();
            XDreamDeviceBlockingReport report = new XDreamDeviceBlockingReport(xdr);

            string summary = report.GetSummary();

            
            int intialLabelHeight = this.label1.Height;
            this.label1.Text = summary;                       
            int dH = this.label1.Height - intialLabelHeight;
                       

            // Adjust the height of the dialog
            this.Height += dH;

            // Center the system icon vertically
            this.pbIcon.Top = (this.ClientRectangle.Height - this.pbIcon.Height) / 2;

        }

    }
}
