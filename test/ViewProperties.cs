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
    public partial class ViewProperties : Form
    {
        public Workspace workspace_ob = new Workspace();
        public ViewProperties()
        {
            InitializeComponent();
            workspace_ob = new Workspace();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            workspace_ob.field_ex.width = (int)numericUpDown_width.Value;
            workspace_ob.field_ex.heigth = (int)numericUpDown_height.Value;
            if (workspace_ob.field_ex.width <= 20) workspace_ob.field_ex.size_rect = 600 / (int)numericUpDown_width.Value;
            else workspace_ob.field_ex.size_rect = 30;
            workspace_ob.delta_for_open_image = trackBar_delta_for_colors_open_image.Value * 13;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void Options_Shown(object sender, EventArgs e)
        {
            if (workspace_ob.op.orientation_of_document == 0) radioButton_ver.Checked = true;
            else radioButton_hor.Checked = true;
            numericUpDown_width.Value = workspace_ob.field_ex.width;
            numericUpDown_height.Value = workspace_ob.field_ex.heigth;
            trackBar_delta_for_colors_open_image.Value = workspace_ob.delta_for_open_image / 26;
        }


        private void trackBar_qauntity_of_square_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown_height.Enabled = false;
                numericUpDown_height.Value = numericUpDown_width.Value;
            }
            else
            {
                numericUpDown_height.Enabled = true;
            }
        }

        private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown_height.Value = numericUpDown_width.Value;
            }
        }

        private void radioButton_ver_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ver.Checked == true)
            {
                workspace_ob.op.orientation_of_document = 0;
                numericUpDown_width.Maximum = 20;
                numericUpDown_height.Maximum = 25;
            }
            else
            {
                workspace_ob.op.orientation_of_document = 1;
                numericUpDown_width.Maximum = 25;
                numericUpDown_height.Maximum = 20;
            }
        }
    }
}
