using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class TabOptions : Form
    {
        public Workspace workspace_ob = new Workspace();
        public TabOptions()
        {
            InitializeComponent();
        }

        private void radioButton_Junior_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_mystery_dis_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_mystery_dis.Checked == true)
            {
                label6.Visible = true;
                label5.Visible = true;
                label5.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label5.Visible = false;
                label5.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void radioButton_alg_hard_frac_equal_num_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage_basic_Click(object sender, EventArgs e)
        {

        }

        private void TabOptions_Shown(object sender, EventArgs e)
        {
            radioButton_even_odd.Select();
        }

        
    }
}
