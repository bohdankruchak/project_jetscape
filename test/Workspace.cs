﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    public class Workspace
    {
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
        public enum g_mod { 
            ADDJR, ADDBAS, ADDADV, SUBJR, SUBBAS, SUBADV, MULTJR, MULTBAS, MULTADV, DIVJR, DIVBAS, DIVADV, MIXED, PLCVALCOUN, PLCVALPLCV, ROUNDING, ADVREGRADD, ADVREGRSUB, ADVREGRMULT, ADVNUMBANDOP, GEOMANDMES, CLRBYNUM, CLRBYNUMPAIR, CLRBYNUMRANGES, FDPFRNUM, FDPFRDET, FDPDECOL, FDPPECOL };
        public g_mod game_mod = g_mod.ADDJR;
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
        public Workspace(int height = 20, int width = 20)
        {
            keys = new List<key>();
            keys.Add(new Workspace.key("0,11", Color.Tan));
            keys.Add(new Workspace.key("1,2,3", Color.Brown));
            keys.Add(new Workspace.key("4,5,6", Color.Orange));
            keys.Add(new Workspace.key("7,8,9", Color.Green));
            keys.Add(new Workspace.key("10,23", Color.Blue));
        }
        Rectangle[] slot_for_color = new Rectangle[10];
    }
    
}
