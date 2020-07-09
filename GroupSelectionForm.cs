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
    public partial class GroupSelectionForm : Form
    {
        public GroupSelectionForm()
        {
            InitializeComponent();
        }

        public bool G1 => checkBox1.Checked;
        public bool G2 => checkBox2.Checked;
        public bool G3 => checkBox3.Checked;
        public bool G4 => checkBox4.Checked;
        public bool G5 => checkBox5.Checked;
        public bool G6 => checkBox6.Checked;

        private void button1_Click(object sender, EventArgs e)
        {
            
         this.Close();
           
        }
    }
}
