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
        public Workspace workspace_ob_last = new Workspace();
        public TabOptions()
        {
            InitializeComponent();
        }

        private void radioButton_Junior_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Junior.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.JUNIOR;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
            }
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
            button_save.DialogResult = DialogResult.OK;
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
            #region last_configuration
            if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD) radioButton_even_odd.Checked = true;
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_PRIM_COMP) radioButton_prime_comp.Checked = true;
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST) radioButton_mystery_dis.Checked = true; 
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_SIMP)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 0;
                if (workspace_ob.op.addition_act == true) check_box_Addition.Checked = true;
                if (workspace_ob.op.division_act == true) check_box_Division.Checked = true;
                if (workspace_ob.op.multiplication_act == true) check_box_Mult.Checked = true;
                if (workspace_ob.op.subtraction_act == true) check_box_Subtraction.Checked = true;
                if (workspace_ob.op.active_complexity == Workspace.options.complexity.BASIC) radioButton_Basic.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.JUNIOR) radioButton_Junior.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED) radioButton_Advanced.Checked = true;
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_COMA)
                {
                    radioButton_Advanced.Checked = true;
                    comboBox_alg_simpl_adv.SelectedIndex = 0;
                }
                else if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_HYPHEN)
                {
                    radioButton_Advanced.Checked = true;
                    comboBox_alg_simpl_adv.SelectedIndex = 1;
                }

            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 1;
                if (workspace_ob.op.addition_act == true) check_box_regr_add.Checked = true;
                if (workspace_ob.op.multiplication_act == true) check_box_regr_mult.Checked = true;
                if (workspace_ob.op.subtraction_act == true) check_box_regr_sub.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 1;
                if (workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.HUNDREDS) radioButton_rounds_hun.Checked = true;
                else if (workspace_ob.op.active_algebra_middle_round == Workspace.options.algebra_middle_round.TENS) radioButton_rounds_ten.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_DEC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_decimals.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_FRAC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_fractions.Checked = true;
                if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.DIFFERENT) { comboBox1.SelectedIndex = 0; }
                else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_DEN) { comboBox1.SelectedIndex = 2; }
                else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM) { comboBox1.SelectedIndex = 1; }
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_PERC)
            {
                algebraTab.SelectedIndex = 1;
                algebra_tabs.SelectedIndex = 2;
                radioButton_Percentages.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_ANGLES)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_angles.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_QUADR)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_qua.Checked = true;
            }
            else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_SHAPES)
            {
                algebraTab.SelectedIndex = 2;
                radioButton_shapes.Checked = true;
            }
            #endregion
        }

        private void check_box_regr_add_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_add.Checked == true)
            {
                workspace_ob.op.addition_act = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
            }
            else
                workspace_ob.op.addition_act = false;
        }

        private void check_box_regr_sub_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_sub.Checked == true)
            {
                workspace_ob.op.subtraction_act = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
            }
            else
                workspace_ob.op.subtraction_act = false;
        }

        private void check_box_regr_mult_CheckedChanged(object sender, EventArgs e)
        {
            if (check_box_regr_mult.Checked == true)
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING;
                workspace_ob.op.multiplication_act = true;
                radioButton_rounds_hun.Checked = false;
                radioButton_rounds_ten.Checked = false;
            }
            else
                workspace_ob.op.multiplication_act = false;
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
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
            }
            else
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
        }

        private void radioButton_Advanced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Advanced.Checked == true)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_SIMP;
                comboBox_alg_simpl_adv.SelectedIndex = 0;
                comboBox_alg_simpl_adv.Enabled = true;
            }
            else
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.NONE;
                comboBox_alg_simpl_adv.Enabled = false;
            }
        
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
                textBox_alg_hard_frst.MaxLength = 1;
                textBox_alg_hard_scnd.MaxLength = 1;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                textBox_alg_hard_frst.MaxLength = 3;
                textBox_alg_hard_scnd.MaxLength = 3;
            }
        }

        private void radioButton_Percentages_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Percentages.Checked == true)
            {
                comboBox_percent.SelectedIndex = 0;
                comboBox_percent.Enabled = true;
                workspace_ob.op.game_mod = Workspace.options.g_mod.ALGEBRA_HARD_PERC;
                textBox_alg_hard_frst.Enabled = true;
                textBox_alg_hard_scnd.Enabled = true;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                comboBox_percent.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 1)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_DEN;
            else if (comboBox1.SelectedIndex == 0)
                workspace_ob.op.active_fractions_mode = Workspace.options.fractions.EQUAL_NUM;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            #region save_Mystery_data
            if (algebraTab.SelectedTab == tabPage_basic)
            {
                if (radioButton_even_odd.Checked != true && radioButton_mystery_dis.Checked != true && radioButton_prime_comp.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
                if(workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
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
                    if (int.Parse(textBox_alg_bas_frst.Text) >= int.Parse(textBox_alfg_bas_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_bas_frst.Text) < 0 || int.Parse(textBox_alfg_bas_scnd.Text) < 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    }
                    workspace_ob.op.active_range_first = int.Parse(textBox_alg_bas_frst.Text);
                    workspace_ob.op.active_range_second = int.Parse(textBox_alfg_bas_scnd.Text);
                }
            }
            #endregion
            #region save_Algebra_simple_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_simple && algebraTab.SelectedTab == tabPage_alg)
            {
                if((radioButton_Advanced.Checked != true && radioButton_Junior.Checked != true && radioButton_Basic.Checked != true) 
                || (check_box_Addition.Checked != true && check_box_Mult.Checked != true && check_box_Subtraction.Checked != true && check_box_Division.Checked != true))
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
                if (int.Parse(textBox_alg_simple_frst.Text) >= int.Parse(textBox_alg_simple_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) >= int.Parse(textBox_alg_simple_scnd.Text))
                {
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_simple_frst.Text) < 0 || int.Parse(textBox_alg_simple_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                } 
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_simple_frst.Text);
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_simple_scnd.Text);
            }
            #endregion
            #region save_Algebra_Middle_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_middle && algebraTab.SelectedTab == tabPage_alg)
            {
                if ((check_box_regr_add.Checked != true && check_box_regr_mult.Checked != true && check_box_regr_sub.Checked != true)
                && (radioButton_rounds_ten.Checked != true && radioButton_rounds_hun.Checked != true))
                {
                    textBox_info_error.Text = "Select some actions value.";
                    return;
                }
                try
                {
                    int.Parse(textBox_alg_mid_regr_frst.Text);
                    int.Parse(textBox_alg_mid_regr_scnd.Text);
                }
                catch
                {
                    textBox_info_error.Text = "Please, enter the numbers.";
                    return;
                }
                if (radioButton_rounds_ten.Checked == true && (int.Parse(textBox_alg_mid_regr_scnd.Text) < 10 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 10))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 10.";
                    return;
                }
                else if((radioButton_rounds_hun.Checked == true && (int.Parse(textBox_alg_mid_regr_scnd.Text) < 100 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 100)))
                {
                    textBox_info_error.Text = "In this mode numbers must be bigger than 100.";
                    return;
                }

                if (int.Parse(textBox_alg_mid_regr_frst.Text) >= int.Parse(textBox_alg_mid_regr_scnd.Text)) 
                { 
                    textBox_info_error.Text = "Second number must be bigger then first";
                    return;
                }
                if (int.Parse(textBox_alg_mid_regr_frst.Text) < 0 || int.Parse(textBox_alg_mid_regr_scnd.Text) < 0)
                {
                    textBox_info_error.Text = "Numbers must be bigger then zero.";
                    return;
                } 
                workspace_ob.op.active_range_first = int.Parse(textBox_alg_mid_regr_frst.Text); 
                workspace_ob.op.active_range_second = int.Parse(textBox_alg_mid_regr_scnd.Text);
            }
            #endregion
            #region save_Algebra_Hard_data
            else if (algebra_tabs.SelectedTab == tabPage_alg_hard && algebraTab.SelectedTab == tabPage_alg)
            {
                if (radioButton_fractions.Checked != true && radioButton_decimals.Checked != true && radioButton_Percentages.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
                if (radioButton_fractions.Checked != true)
                {
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
                    if (int.Parse(textBox_alg_hard_frst.Text) >= int.Parse(textBox_alg_hard_scnd.Text))
                    {
                        textBox_info_error.Text = "Second number must be bigger then first";
                        return;
                    }
                    if (int.Parse(textBox_alg_hard_frst.Text) < 0 || int.Parse(textBox_alg_hard_scnd.Text) < 0)
                    {
                        textBox_info_error.Text = "Numbers must be bigger then zero.";
                        return;
                    } 
                    workspace_ob.op.active_range_first = int.Parse(textBox_alg_hard_frst.Text);
                    workspace_ob.op.active_range_second = int.Parse(textBox_alg_hard_scnd.Text);
                }
            }
            #endregion
            #region save_Geom_data
            else if (algebraTab.SelectedTab == tabPage_geom)
            {
                if (radioButton_angles.Checked != true && radioButton_qua.Checked != true && radioButton_shapes.Checked != true)
                {
                    textBox_info_error.Text = "Select some mode value.";
                    return;
                }
            }
            #endregion
            #region generate_new_keys
            if (workspace_ob.keys.Count != 0)
            {
                if (workspace_ob.keys.Count < 2)
                {
                    return;
                }
                else
                {
                    foreach (Workspace.key a in workspace_ob.keys)
                    {
                        a.str = "";
                    }
                    GenereteNumbers.workspace = workspace_ob;
                    GenereteNumbers.Generate_Number();
                }
            }
            #endregion
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
                check_box_regr_add.Checked = false;
                check_box_regr_mult.Checked = false;
                check_box_regr_sub.Checked = false;
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
                check_box_regr_add.Checked = false;
                check_box_regr_mult.Checked = false;
                check_box_regr_sub.Checked = false;
            }
            else
            {
                workspace_ob.op.game_mod = Workspace.options.g_mod.NONE;
                workspace_ob.op.active_algebra_middle_round = Workspace.options.algebra_middle_round.HUNDREDS;
            }
        }

        private void comboBox_alg_simpl_adv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_alg_simpl_adv.SelectedIndex == 0) { workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED_COMA; }
            else if (comboBox_alg_simpl_adv.SelectedIndex == 1) { workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED_HYPHEN; }
        }

       
        private void comboBox_percent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_percent.SelectedIndex == 0)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.BASIC;
            }
            else if (comboBox_percent.SelectedIndex == 1)
            {
                workspace_ob.op.active_complexity = Workspace.options.complexity.ADVANCED;
            }
        }




    }
}
