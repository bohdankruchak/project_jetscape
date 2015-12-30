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
    }
}
