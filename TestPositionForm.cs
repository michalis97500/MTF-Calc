using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTF_Calc
{
    public partial class TestPositionForm : Form
    {
        public TestPositionForm()
        {
            InitializeComponent();
            CenterCheckBox.Checked = true;
            RBCCheckBox.Checked = true;
            RTCCheckBox.Checked = true;
            LBCCheckBox.Checked = true;
            LTCCheckbox.Checked = true;
            LECheckbox.Checked = true;
            RECheckBox.Checked = true;
            BECheckBox.Checked = true;
            UECheckBox.Checked = true;
        }
        public bool Center => CenterCheckBox.Checked;

        
        public bool RBCorner
        {
            get
            {
                return RBCCheckBox.Checked;
            }
        }
        public bool RTCorner
        {
            get
            {
                return RTCCheckBox.Checked;
            }
        }
        public bool LBCorner
        {
            get
            {
                return LBCCheckBox.Checked;
            }
        }
        public bool LTCorner
        {
            get
            {
                return LTCCheckbox.Checked;
            }
        }
        public bool REdge
        {
            get
            {
                return RECheckBox.Checked;
            }
        }
        public bool LEdge
        {
            get
            {
                return LECheckbox.Checked;
            }
        }
        public bool UEdge
        {
            get
            {
                return UECheckBox.Checked;
            }
        }
        public bool BEdge
        {
            get
            {
                return BECheckBox.Checked;
            }
        }

    }
}
