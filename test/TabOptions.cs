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
            if (radioButton_Junior.Checked == true)
                workspace_ob.op.active_complexity = Workspace.options.complexity.JUNIOR;
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_mystery_dis_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_mystery_dis.Checked == true)
            {
                label6.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                textBox_alfg_bas_scnd.Visible = true;
                textBox_alg_bas_frst.Visible = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_MYST;
            }
            else
            {
                label6.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                textBox_alfg_bas_scnd.Visible = false;
                textBox_alg_bas_frst.Visible = false;
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
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
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
        }

        private void check_box_regr_add_CheckedChanged(object sender, EventArgs e)
        {
            if(check_box_regr_add.Checked == true)
                workspace_ob.op.addition_act = true;
            else
                workspace_ob.op.addition_act = false;
        }

        private void check_box_regr_sub_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_sub.Checked == true)
                workspace_ob.op.subtraction_act = true;
            else
                workspace_ob.op.subtraction_act = false;
        }

        private void check_box_regr_mult_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_add.Checked == true)
                workspace_ob.op.multiplication_act = true;
            else
                workspace_ob.op.multiplication_act = false;
        }

        private void radioButton_regr_jun_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_regr_jun.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.JUNIOR;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_regr_bas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_regr_bas.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_regr_adv_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_regr_adv.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void check_box_Addition_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Addition.Checked == true)
                workspace_ob.op.addition_act = true;
            else
                workspace_ob.op.addition_act = false;
        }

        private void check_box_Subtraction_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Subtraction.Checked == true)
                workspace_ob.op.subtraction_act = true;
            else
                workspace_ob.op.subtraction_act = false;
        }

        private void check_box_Mult_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Mult.Checked == true)
                workspace_ob.op.multiplication_act = true;
            else
                workspace_ob.op.multiplication_act = false;
        }

        private void Division_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_Division.Checked == true)
                workspace_ob.op.division_act = true;
            else
                workspace_ob.op.division_act = false;
        }

        private void radioButton_Basic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Basic.Checked == true)
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_Advanced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Advanced.Checked == true)
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_fractions_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fractions.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_FRAC;
                comboBox1.Enabled = true;
                textBox_alg_hard_frst.Enabled = false;
                textBox_alg_hard_scnd.Enabled = false;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                comboBox1.Enabled = false;
            }
        }

        private void radioButton_decimals_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_decimals.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_DEC;
                textBox_alg_hard_frst.Enabled = true;
                textBox_alg_hard_scnd.Enabled = true;
            }
            else
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
        }

        private void radioButton_Percentages_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Percentages.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_PERC;
                textBox_alg_hard_frst.Enabled = true;
                textBox_alg_hard_scnd.Enabled = true;
            }
            else
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_DEN;
            else if (comboBox1.SelectedIndex == 0)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.DIFFERENT;
            else if (comboBox1.SelectedIndex == 1)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_NUM;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (algebraTab.SelectedIndex == 0 && workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
            {
                try
                {
                    int.Parse(textBox_alg_bas_frst.Text);
                    int.Parse(textBox_alfg_bas_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_bas_frst.Text);
                workspace_ob.op.active_range_second = int.Parse(textBox_alfg_bas_scnd.Text);
            }
            else if (algebra_tabs.SelectedIndex == 0)
            {
                if((radioButton_Advanced.Checked != true || radioButton_Junior.Checked != true || radioButton_Basic.Checked != true) 
                    && (check_box_Addition.Checked != true || check_box_Mult.Checked != true || check_box_Subtraction.Checked != true || check_box_Division.Checked != true))
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_simple_frst.Text);
                    int.Parse(textBox_alg_simple_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_simple_frst.Text);
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_simple_scnd.Text);
            }
            else if (algebra_tabs.SelectedIndex == 1)
            {
                if ((check_box_regr_add.Checked != true || check_box_regr_mult.Checked != true || check_box_regr_sub.Checked != true) 
                && (radioButton_regr_jun.Checked != true || radioButton_regr_bas.Checked != true || radioButton_regr_adv.Checked != true )
                || (radioButton_rounds_ten.Checked != true || radioButton_rounds_hun.Checked != true))
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
            }
            else if (algebra_tabs.SelectedIndex == 2)
            {
                if (radioButton_fractions.Checked != true || radioButton_decimals.Checked != true || radioButton_angles.Checked != true)
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_hard_frst.Text);
                    int.Parse(textBox_alg_hard_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_hard_frst.Text);
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_hard_scnd.Text);
            }
            else if(algebraTab.SelectedIndex == 2){
                if (radioButton_angles.Checked != true || radioButton_qua.Checked != true || radioButton_shapes.Checked != true)
                {
                    textBox_info_error.Text = "Select some complexity and/or actions value.";
                    return;
                }
            }
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton_prime_comp_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_PRIM_COMP;
        }

        private void radioButton_even_odd_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.BASIC_EVEN_ODD;
        }

        private void radioButton_angles_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_ANGLES;
        }

        private void radioButton_qua_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_QUADR;
        }

        private void radioButton_shapes_CheckedChanged(object sender, EventArgs e)
        {
            workspace_ob.op.game_mod = Workspace.options.g_mod.GEOM_SHAPES;
        }

        private void tabPage_basic_CursorChanged(object sender, EventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_basic_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage4_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_alg_middle_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void tabPage_alg_hard_MouseMove(object sender, MouseEventArgs e)
        {
            textBox_info_error.Text = "";
        }

        private void radioButton_rounds_ten_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rounds_ten.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.TENS;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.TENS;
            }
        }

        private void radioButton_rounds_hun_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rounds_hun.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.HUNDREDS;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.HUNDREDS;
            }
        }



    }
}
