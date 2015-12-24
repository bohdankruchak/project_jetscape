using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;

namespace test
{
   
    public partial class NewKey : Form
    {
        public Workspace workspace_ob = new Workspace();
        Color chosen_color = Color.Tomato;
        public NewKey()
        {
            InitializeComponent();
        }
        
        private void textBox_color_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_color.BackColor = colorDialog1.Color;
                chosen_color = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_numbers.Text != "" && verification_input_data(textBox_numbers.Text) == true)
            {
                workspace_ob.keys.Add(new Workspace.key(textBox_numbers.Text, chosen_color));
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public bool verification_input_data(string str){
            if (workspace_ob.game_mod == Workspace.g_mod.ADDJR || workspace_ob.game_mod == Workspace.g_mod.SUBJR || workspace_ob.game_mod == Workspace.g_mod.MULTJR || workspace_ob.game_mod == Workspace.g_mod.DIVJR)
            {
                try
                {
                    valid_data_funk.data_or(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUM || workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN || workspace_ob.game_mod == Workspace.g_mod.ADDBAS || workspace_ob.game_mod == Workspace.g_mod.SUBBAS || workspace_ob.game_mod == Workspace.g_mod.MULTBAS || workspace_ob.game_mod == Workspace.g_mod.DIVBAS)
            {
                try
                {
                    valid_data_funk.single_num(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.MIXED || workspace_ob.game_mod == Workspace.g_mod.ADDADV || workspace_ob.game_mod == Workspace.g_mod.SUBADV || workspace_ob.game_mod == Workspace.g_mod.MULTADV || workspace_ob.game_mod == Workspace.g_mod.DIVADV)
            {
                int count_not_valid = 0;
                try
                {
                    valid_data_funk.single_num(str);
                }
                catch
                {
                    count_not_valid++;
                }
                try
                {
                    valid_data_funk.data_coma(str);
                }
                catch
                {
                    count_not_valid++;
                }
                try
                {
                    valid_data_funk.data_hyphen(str);
                }
                catch
                {
                    count_not_valid++;
                }
                if (count_not_valid != 2) {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false; }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN)
            {
                try
                {
                    valid_data_funk.data_in_once_place(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ROUNDING)
            {
                try
                {
                    valid_data_funk.data_rounding(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPODDEVEN)
            {
                if (valid_data_funk.data_odd_even(str) == false) return false;
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPNUMPATT)
            {
                try
                {
                    valid_data_funk.data_pattern(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPFACTORS)
            {
                if (valid_data_funk.data_factors(str) == false) return false;
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMESIANGL)
            {
                if (valid_data_funk.data_angles(str) == false) return false;
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMGRPHQA)
            {
                if (valid_data_funk.data_quadrant(str) == false) return false;
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMGRPHQA)
            {
                if (valid_data_funk.data_shapes(str) == false) return false;
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUM || workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN || workspace_ob.game_mod == Workspace.g_mod.ADDBAS || workspace_ob.game_mod == Workspace.g_mod.SUBBAS || workspace_ob.game_mod == Workspace.g_mod.MULTBAS || workspace_ob.game_mod == Workspace.g_mod.DIVBAS)
            {
                try
                {
                    valid_data_funk.single_num(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUMPAIR || workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN || workspace_ob.game_mod == Workspace.g_mod.ADDBAS || workspace_ob.game_mod == Workspace.g_mod.SUBBAS || workspace_ob.game_mod == Workspace.g_mod.MULTBAS || workspace_ob.game_mod == Workspace.g_mod.DIVBAS)
            {
                try
                {
                    valid_data_funk.data_coma(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUMRANGES || workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN || workspace_ob.game_mod == Workspace.g_mod.ADDBAS || workspace_ob.game_mod == Workspace.g_mod.SUBBAS || workspace_ob.game_mod == Workspace.g_mod.MULTBAS || workspace_ob.game_mod == Workspace.g_mod.DIVBAS)
            {
                try
                {
                    valid_data_funk.data_hyphen(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPFRNUM || workspace_ob.game_mod == Workspace.g_mod.FDPFRDEN)
            {
                try
                {
                    valid_data_funk.data_numerators_denumerators(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVREGRADD || workspace_ob.game_mod == Workspace.g_mod.ADVREGRMULT || workspace_ob.game_mod == Workspace.g_mod.ADVREGRSUB)
            {
                try
                {
                    valid_data_funk.data_from(str);
                }
                catch
                {
                    textBox_error.Text = "Numbers are not valid!" + Environment.NewLine + "Please, enter valid data like in example!";
                    return false;
                }
            }
            return true;
        }

         

        private void textBox_numbers_TextChanged_1(object sender, EventArgs e)
        {
            textBox_error.Text = "";
        }
    }
    static class valid_data_funk
    {
        
        static public bool data_or(string s1)
        {
            int first_nmb, second_nmb;
            string[] arr = s1.Split(' ');
            first_nmb = int.Parse(arr[0]);
            second_nmb = int.Parse(arr[2]);
            return true;
        }
        static public bool data_coma(string s1)
        {
            List<int> potential_numbers = new List<int>();
            string[] str_numbers = s1.Split(',');
            for (int i = 0; i < str_numbers.Length; i++)
                potential_numbers.Add(int.Parse(str_numbers[i]));
            return true;
        }
        static public bool single_num(string s1)
        {
            int.Parse(s1);
            return true;
        }

        static public bool data_hyphen(string s1)
        {
            string[] str_limits_numbers = s1.Split('-');
            int first_number = int.Parse(str_limits_numbers[0]);
            int last_number = int.Parse(str_limits_numbers[1]);
            return true;
        }
        static public bool data_in_once_place(string s1)
        {
            string[] all_words = s1.Split(' ');
            int number = 0;
            if (!(s1.Contains("Not") || s1.Contains("not") || s1.Contains("NOT")))
            {
                number = int.Parse(all_words[0]);
            }
            else
            {
                number = int.Parse(all_words[all_words.Length - 1]);
            }
            return true;
        }
        static public bool data_rounding(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);
            return true;
        }
        static public bool data_from(string s1)
        {
            int first_number = 0;
            int second_number = 0;
            string[] all_words = s1.Split(' ');
            first_number = int.Parse(all_words[1]);
            second_number = int.Parse(all_words[3]);
            return true;
        }
        static public bool data_odd_even(string s1)
        {
            if (s1.ToLower() != "odd" || s1.ToLower() != "even") return false;
            return true;
        }
        static public bool data_factors(string s1)
        {
            if (s1.ToLower() != "composite" || s1.ToLower() != "prime") return false;
            return true;
        }
        static public bool data_pattern(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);
            return true;
        }
        static public bool data_angles(string s1)
        {
            if (s1.ToLower() != "straight" || s1.ToLower() != "right" || s1.ToLower() != "accute" || s1.ToLower() != "obtuse") return false;
            return true;
        }
        static public bool data_quadrant(string s1)
        {
            if (s1.ToLower() != "quadrant 1" || s1.ToLower() != "quadrant 2" || s1.ToLower() != "quadrant 3" || s1.ToLower() != "quadrant 4") return false;
            return true;
        }
        static public bool data_shapes(string s1)
        {
            if (s1.ToLower() != "3 sides shapes" || s1.ToLower() != "4 sides shapes" || s1.ToLower() != "More than 4 sides") return false;
            return true;
        }
        static public bool data_numerators_denumerators(string s1)
        {
            int numerator, denominator;
            if ((s1.ToLower()).Contains("whole"))
            {
                string[] w = s1.Split(' ');
                int.Parse(w[w.Length - 2]);
                return true;
            }
            string[] words = s1.Split(' ');
            string[] s_numer_denom = words[2].Split('/');
            numerator = int.Parse(s_numer_denom[0]);
            denominator = int.Parse(s_numer_denom[1]);
            return true;
        }
    }
}
