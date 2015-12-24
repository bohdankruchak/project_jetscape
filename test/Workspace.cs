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
                BASIC_EVEN_ODD, BASIC_PRIM_COMP, BASIC_EVEN_MYST, ALGEBRA_SIMP, ALGEBRA_MIDD, ALGEBRA_HARD_FRAC, ALGEBRA_HARD_DEC, ALGEBRA_HARD_PERC, 
            };
            public enum arithmetic_op
            {
                ADDITION, SUBSTRACTION, MULTIPLICATION, DIVISION, NONE
            };
            public enum complexity
            {
                JUNIOR, BASIC, ADVANCED, NONE
            };

            public g_mod game_mod = g_mod.BASIC_EVEN_ODD;
            public arithmetic_op active_arithmetic_op= arithmetic_op.NONE;
            public complexity active_complexity = complexity.NONE;
            int active_range_first;
            int active_range_second;
        }
        public string active_mode_name = "";
        public class field
        {
            public int heigth;
            public int width;
            public int size_rect;
            public List<List<SolidBrush>> clr_fild;
            public List<List<string>> str_fild;
            public field()
            {
                width = 20;
                heigth = 20;
                clr_fild = new List<List<SolidBrush>>();
                str_fild = new List<List<string>>();
                size_rect = 30;
                for (int i = 0; i <= width; i++)
                {
                    clr_fild.Add(new List<SolidBrush>());
                    str_fild.Add(new List<string>());
                    for(int j = 0; j <= heigth;j++){
                        clr_fild[i].Add(new SolidBrush(Color.Transparent));
                        str_fild[i].Add(" ");
                    }
                }
            }
        }
        
        
        public string example_for_input = "3 or 6";
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
        public bool clean_colors = false;
        public SolidBrush active_rc_color = new SolidBrush(Color.Brown);
        public field field_ex = new field();
        public List<key> keys;
        public char sign = '+';
        public ToolStripMenuItem checked_item_in_tmpl_menu;
        public List<string> vadil_data;
        public bool auto_generate = false;
        public Workspace(int height = 20, int width = 20)
        {
            keys = new List<key>();
            keys.Add(new Workspace.key("0 or 11", Color.Tan));
            keys.Add(new Workspace.key("1 or 3", Color.Brown));
            keys.Add(new Workspace.key("4 or 6", Color.Orange));
            keys.Add(new Workspace.key("7 or 9", Color.Green));
            keys.Add(new Workspace.key("10 or 3", Color.Blue));

            
        }

        

    }
    
}
