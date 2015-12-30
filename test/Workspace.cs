using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace test
{
    public class Workspace
    {
        public class options
        {
            public enum g_mod
            {
                BASIC_EVEN_ODD, BASIC_PRIM_COMP, BASIC_MYST, ALGEBRA_SIMP, ALGEBRA_MIDD_REGROPING, ALGEBRA_MIDD_ROUNDING, ALGEBRA_HARD_FRAC, ALGEBRA_HARD_DEC, ALGEBRA_HARD_PERC, GEOM_ANGLES, GEOM_QUADR, GEOM_SHAPES, NONE
            };
            public enum complexity
            {
                JUNIOR, BASIC, ADVANCED, ADVANCED_COMA, ADVANCED_HYPHEN, NONE
            };
            public enum fractions
            {
                DIFFERENT, EQUAL_NUM, EQUAL_DEN, NONE
            }
            public enum algebra_middle_round{
                HUNDREDS, TENS, NONE
            }

            public g_mod game_mod = g_mod.BASIC_EVEN_ODD;
            public bool addition_act = false;
            public bool subtraction_act = false;
            public bool division_act = false;
            public bool multiplication_act = false;
            public fractions active_fractions_mode = fractions.DIFFERENT;
            public complexity active_complexity = complexity.NONE;
            public int active_range_first;
            public int active_range_second;
            public algebra_middle_round active_algebra_middle_round = algebra_middle_round.NONE;
            public int orientation_of_document = 0;
            public int[] custom_colors = new int[]{6916092, 15195440, 16107657, 1836924,
   3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
   3102017, 7324121, 14993507, 11730944};
            
        }
        public DragEventArgs dragAndDropEnterArg;
        public options op = new options();
        public class field
        {
            public int heigth;
            public int width;
            public int mudslide_for_hskroll;
            public int mudslide_for_vskroll;
            public int size_rect;
            public List<List<Color>> clr_fild;
            public List<List<string>> str_fild;
            public field()
            {
                int max_width_heigth = 40;
                width = 20;
                heigth = 20;
                mudslide_for_hskroll = 0;
                mudslide_for_vskroll = 0;
                clr_fild = new List<List<Color>>();
                str_fild = new List<List<string>>();
                size_rect = 30;
                for (int i = 0; i <= max_width_heigth; i++)
                {
                    clr_fild.Add(new List<Color>());
                    str_fild.Add(new List<string>());
                    for (int j = 0; j <= max_width_heigth; j++)
                    {
                        clr_fild[i].Add(Color.Transparent);
                        str_fild[i].Add(" ");
                    }
                }
            }
        }
        public class key
        {
            public string str = "";
            public Color clr = Color.Transparent;
            public key(string st, Color cl)
            {
                str = st;
                clr = cl;
            }
        }
        public bool isLbuttonDown = false;
        public bool isRbuttonDown = false;
        public bool clean_colors = false;
        public Color active_rc_color = Color.Brown;
        public field field_ex = new field();
        public List<key> keys;
        public List<Color> main_colors = new List<Color>();
        public char sign = '+';
        public ToolStripMenuItem checked_item_in_tmpl_menu;
        public List<string> vadil_data;
        public bool auto_generate = false;
        public int delta_for_open_image = 130;
        public Workspace()
        {
            keys = new List<key>();
            keys.Add(new Workspace.key("", Color.Tan));
            keys.Add(new Workspace.key("", Color.Brown));
        }
        

    }
    
}
