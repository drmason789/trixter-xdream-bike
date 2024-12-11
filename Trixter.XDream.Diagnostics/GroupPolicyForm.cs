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


            //XDreamDeviceGroupPolicyUsbDeviceRestrictionReader xdr = new XDreamDeviceGroupPolicyUsbDeviceRestrictionReader();
            //XDreamDeviceBlockingReport report = new XDreamDeviceBlockingReport(xdr);

            this.gpGroupPolicyControl.UpdateDetails();

        }

       
    }
}
