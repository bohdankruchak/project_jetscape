using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using test;

namespace test
{
    public static class OpenSave
    {

        private static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }
        public static string get_string_for_save(Workspace workspace)
        {
            int height = workspace.field_ex.heigth;
            int width = workspace.field_ex.width;
            int Rect_size = workspace.field_ex.size_rect;
            List<Workspace.key> keys = workspace.keys;
            List<List<System.Drawing.Color>> field_colors = workspace.field_ex.clr_fild;

            string output = "";
            output += (height + "/" + width + "/" + Rect_size + "/");

            output += keys.Count;
            output += "/";

            foreach(var key in keys)
            {
                string hex_color = HexConverter(key.clr);
                output += (hex_color + "!");
            }

            output += "/";
            foreach(var i_color in field_colors)
            {
                foreach(var j_color in i_color)
                {
                    string hex_color = "";
                    if (j_color.Name == System.Drawing.Color.Transparent.Name)
                        hex_color = "T";
                    else
                        hex_color = HexConverter(j_color);
                    output += (hex_color + "!");
                }
            }
            return output;
        }
        public static void interpretate_string_for_open(string input, Workspace workspace)
        {
            string[] allParams = input.Split('/');

            workspace.field_ex.heigth = int.Parse(allParams[0]);
            workspace.field_ex.width = int.Parse(allParams[1]);
            workspace.field_ex.size_rect = int.Parse(allParams[2]);
            int keys_Count = int.Parse(allParams[3]);
            string[] all_keys = allParams[4].Split('!');
            workspace.keys.Clear();

            for(int i = 0; i < keys_Count; i++)
            {
                System.Drawing.Color curveColor = System.Drawing.ColorTranslator.FromHtml(all_keys[i]);
                workspace.keys.Add(new Workspace.key("", curveColor));
            }
            string[] all_colors = allParams[5].Split('!');

            for(int i = 0, k = 0; i < workspace.field_ex.width; i++, k++)
            {
                for(int j = 0; j < workspace.field_ex.heigth; j++, k++)
                {
                    if (all_colors[k] == "T") continue;
                    System.Drawing.Color curveColor = System.Drawing.ColorTranslator.FromHtml(all_colors[k]);
                    workspace.field_ex.clr_fild[i][j] = curveColor;
                }
            }
        }
        public static string saves_string_for_save_conf(Workspace workspace)
        {
            string result = "";
            result = workspace.field_ex.width.ToString() + " " + workspace.field_ex.heigth.ToString() + "\n";
            result += workspace.op.game_mod.ToString() + "\n";
            result += workspace.op.addition_act.ToString() + "," + workspace.op.subtraction_act.ToString() + "," + workspace.op.division_act.ToString() + "," + workspace.op.multiplication_act.ToString() + "\n";
            result += workspace.op.active_fractions_mode.ToString() + "\n";
            result += workspace.op.active_complexity.ToString() + "\n";
            result += workspace.op.active_range_first.ToString() + " " + workspace.op.active_range_second.ToString() + "\n";
            result += workspace.op.active_algebra_middle_round.ToString() + "\n";
            for (int i = 0; i < 16; i++)
            {
                result += workspace.op.custom_colors[i] + " ";
            }
            result += "\n";

            return result;
        }
        public static void opens_string_for_save_conf(string input, Workspace workspace)
        {
            string[] str_arr = input.Split('\n');
            string[] temp = str_arr[0].Split(' ');
            workspace.field_ex.width = int.Parse(temp[0]);
            workspace.field_ex.heigth = int.Parse(temp[1]);
            workspace.op.game_mod = (Workspace.options.g_mod)Enum.Parse(typeof(Workspace.options.g_mod), str_arr[1]);
            temp = str_arr[2].Split(',');
            workspace.op.addition_act = bool.Parse(temp[0]);
            workspace.op.subtraction_act = bool.Parse(temp[1]);
            workspace.op.division_act = bool.Parse(temp[2]);
            workspace.op.multiplication_act = bool.Parse(temp[3]);
            workspace.op.active_fractions_mode = (Workspace.options.fractions)Enum.Parse(typeof(Workspace.options.fractions), str_arr[3]);
            workspace.op.active_complexity = (Workspace.options.complexity)Enum.Parse(typeof(Workspace.options.complexity), str_arr[4]);
            temp = str_arr[5].Split(' ');
            workspace.op.active_range_first = int.Parse(temp[0]);
            workspace.op.active_range_second = int.Parse(temp[1]);
            workspace.op.active_algebra_middle_round = (Workspace.options.algebra_middle_round)Enum.Parse(typeof(Workspace.options.algebra_middle_round), str_arr[6]);
            temp = str_arr[7].Split(' ');
            for (int i = 0; i < 16; i++)
            {
                workspace.op.custom_colors[i] = int.Parse(temp[i]);
            }
        }
    }
}
