using AxPDFXEdit;
using PDFXEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;


namespace test
{
    public partial class Form1 : Form
    {
        public Workspace workspace_ob = new Workspace();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                }
            }
            GenereteNumbers.workspace = workspace_ob;
            GenereteNumbers.Generate_Number();
            update_dataGridView1();
        }


        void update_dataGridView1()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                dataGridView1.Rows.Add(workspace_ob.keys[i].str, workspace_ob.keys[i].clr.Name);
                dataGridView1.Rows[i].Cells[1].Style.BackColor = workspace_ob.keys[i].clr;
            }
        }
        void clean_keys()
        {
            dataGridView1.Rows.Clear();
            workspace_ob.keys.Clear();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int current_width = 20;
            int current_heigth = 20;
            if (workspace_ob.field_ex.width > 20)
            {
                current_heigth = 20; current_width = 20; 
            }
            else
            {
                current_heigth = workspace_ob.field_ex.heigth;
                current_width = workspace_ob.field_ex.width;
            }
            if (workspace_ob.field_ex.width <= 20 && current_heigth > current_width)
            {
                current_width = workspace_ob.field_ex.width;
                current_heigth = current_width; 
            }
            for (int i = 0; i < current_width; i++)
            {
                for (int j = 0; j < current_heigth; j++)
                {
                    int i_curr = i + workspace_ob.field_ex.mudslide_for_hskroll;
                    int j_curr = j + workspace_ob.field_ex.mudslide_for_vskroll;
                    int x = i * workspace_ob.field_ex.size_rect + 15;
                    int y = j * workspace_ob.field_ex.size_rect + 27;
                    Pen myPen = new Pen(Color.Black, 1);
                    e.Graphics.DrawRectangle(myPen, x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                    //if clean color is not active filling rect
                    if (workspace_ob.clean_colors == false) e.Graphics.FillRectangle(new SolidBrush(workspace_ob.field_ex.clr_fild[i_curr][j_curr]), x + 1, y + 1, workspace_ob.field_ex.size_rect - 1, workspace_ob.field_ex.size_rect - 1);

                    SolidBrush br = new SolidBrush(Color.Black);
                    RectangleF temp_rc = new RectangleF(x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                    StringFormat sf = new StringFormat();
                    Font fn = this.Font;
                    if (workspace_ob.field_ex.str_fild[i_curr][j_curr].Length > 5)
                    {
                        float currentSize = fn.Size;
                        currentSize -= 1.5F;
                        fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                    }
                    else if (workspace_ob.field_ex.str_fild[i_curr][j_curr].Length > 6)
                    {
                        float currentSize = fn.Size;
                        currentSize -= 2.0F;

                        fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                    }
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    //if chosen "Regroping" aligment by right side
                    if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
                    {
                        sf.Alignment = StringAlignment.Far;
                        fn = new Font(fn.Name, fn.Size, FontStyle.Underline, fn.Unit);
                    }
                    int n = 0;
                    for(int m = 0; m < workspace_ob.keys.Count; m++){
                        if (workspace_ob.keys[m].clr == workspace_ob.field_ex.clr_fild[i_curr][j_curr]) { n = m; break; }
                    }
                    if (workspace_ob.keys[n].str == "") { workspace_ob.field_ex.str_fild[i_curr][j_curr] = ""; }
                    e.Graphics.DrawString(workspace_ob.field_ex.str_fild[i_curr][j_curr], fn, br, temp_rc, sf);
                }
            }
            textBox_info.Text = "";
            workspace_ob.clean_colors = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            butoon_generate_field.Select();
            if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
            {
                return;
            }
            if (workspace_ob.isLbuttonDown == true)
            {
                if (workspace_ob.keys.Count == 0)
                {
                    textBox_info.Text = "Please, add some keys.";
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = workspace_ob.active_rc_color;
                Refresh();
            }
            else if (workspace_ob.isRbuttonDown == true)
            {
                if (workspace_ob.keys.Count == 0)
                {
                    textBox_info.Text = "Please, add some keys.";
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = Color.Transparent;
                workspace_ob.field_ex.str_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = "";
                Refresh();
            }
        }

        private void cleanColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.clean_colors = true;
            Refresh();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (workspace_ob.keys.Count != 0) workspace_ob.active_rc_color = workspace_ob.keys[dataGridView1.CurrentRow.Index].clr;
        }
        
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (workspace_ob.keys.Count == 0)
            {
                textBox_info.Text = "Please, add some keys.";
                return;
            }
            if(workspace_ob.isLbuttonDown == true)
            {
                if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
                {
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = workspace_ob.active_rc_color;
                Refresh();
            }
            else if (workspace_ob.isRbuttonDown == true)
            {
                if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
                {
                    return;
                }
                int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
                int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
                workspace_ob.field_ex.clr_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = Color.Transparent;
                workspace_ob.field_ex.str_fild[x_index + workspace_ob.field_ex.mudslide_for_hskroll][y_index + workspace_ob.field_ex.mudslide_for_vskroll] = "";
                Refresh();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { workspace_ob.isLbuttonDown = true; }
            else if (e.Button == MouseButtons.Right) { workspace_ob.isRbuttonDown = true; }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { workspace_ob.isLbuttonDown = false; }
            else if(e.Button == MouseButtons.Right) { workspace_ob.isRbuttonDown = false; }
        }

        void GenerateStrings_of_Numbers()
        {
            string input = "";
            List<char> list_of_active_signs = new List<char>();
            if (workspace_ob.op.addition_act == true) list_of_active_signs.Add('+');
            if (workspace_ob.op.subtraction_act == true) list_of_active_signs.Add('-');
            if (workspace_ob.op.division_act == true) list_of_active_signs.Add('/');
            if (workspace_ob.op.multiplication_act == true) list_of_active_signs.Add('*');
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    if (workspace_ob.field_ex.clr_fild[i][j] == Color.Transparent) { continue; }
                    for (int z = 0; z < workspace_ob.keys.Count; z++)
                    {
                        if (workspace_ob.keys[z].clr == workspace_ob.field_ex.clr_fild[i][j]) 
                        { 
                            input = workspace_ob.keys[z].str;
                            continue;
                        }
                    }
                    if (input == "") { continue; }
                    
                    if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD)
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Even_Odd(input);
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_PRIM_COMP) 
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_PrimeOrComposite(input);
                    else if(workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_MYST)
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_NumbPatterns(input);
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_SIMP)
                    {
                        workspace_ob.sign = list_of_active_signs[MathTemplate.GenerateRandomNumber(list_of_active_signs.Count)];
                        if(workspace_ob.op.active_complexity == Workspace.options.complexity.BASIC)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Basic(input, workspace_ob.sign);
                        if (workspace_ob.op.active_complexity == Workspace.options.complexity.JUNIOR)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Jr(input, workspace_ob.sign);
                        if (workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_COMA || workspace_ob.op.active_complexity == Workspace.options.complexity.ADVANCED_HYPHEN)                  
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.MathFact_Advanced(input, workspace_ob.sign);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING)
                    {
                        workspace_ob.sign = list_of_active_signs[MathTemplate.GenerateRandomNumber(list_of_active_signs.Count)];
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_Regrouping(input, workspace_ob.sign);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.PlaceValue_Rounding(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_ANGLES)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_GeomAndMeasur(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_QUADR)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Quadrants(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.GEOM_SHAPES)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.AdvancedMath_NumbAndOps_Shapes_Names(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_FRAC)
                    {
                        if(workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Fractions_Numerators(input);
                        else if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_DEN)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Fractions_Denominators(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_PERC)
                    {
                        if (workspace_ob.op.active_fractions_mode == Workspace.options.fractions.EQUAL_NUM)
                            workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Percent_Equivalence(input);
                    }
                    else if (workspace_ob.op.game_mod == Workspace.options.g_mod.ALGEBRA_HARD_DEC)
                    {
                        workspace_ob.field_ex.str_fild[i][j] = MathTemplate.FDP_Decimal_Place_Value(input);
                    }
                }
            }
        }
        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workspace_ob.field_ex.clr_fild.Count; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.clr_fild.Count; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                    workspace_ob.field_ex.str_fild[i][j] = "";
                }
            }
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_add_color_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = workspace_ob.op.custom_colors;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                workspace_ob.keys.Add(new Workspace.key("", colorDialog1.Color));
                workspace_ob.op.custom_colors = colorDialog1.CustomColors;
            }
            if (workspace_ob.keys.Count < 2)
            {
                textBox_info.Text = "Please, add more keys."; 
                update_dataGridView1();
                return;
            }
            else
            {
                GenereteNumbers.Generate_Number();
                update_dataGridView1();
            }
        }

        private void button_delete_color_Click(object sender, EventArgs e)
        {
            if (workspace_ob.keys.Count > 0)
            {
                for (int i = 0; i < workspace_ob.field_ex.heigth; i++)
                {
                    for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                    {
                        if (workspace_ob.field_ex.clr_fild[i][j] == workspace_ob.keys[dataGridView1.CurrentRow.Index].clr)
                        {
                            workspace_ob.field_ex.str_fild[i][j] = "";
                            workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                        }
                    }
                }
                workspace_ob.keys.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            Refresh();
        }

        private void button_generate_num_Click(object sender, EventArgs e)
        {
            textBox_info.Text = "";
            
            if (workspace_ob.keys.Count != 0)
            {
                if (workspace_ob.keys.Count < 2)
                {
                    textBox_info.Text = "Please, add more keys.";
                    return;
                }
                else
                {
                    foreach(Workspace.key a in workspace_ob.keys){
                        a.str = "";
                    }
                    GenereteNumbers.workspace = workspace_ob;
                    GenereteNumbers.Generate_Number();
                    update_dataGridView1();
                } 
            }
        }
        private void butoon_generate_field_Click(object sender, EventArgs e)
        {
            GenerateStrings_of_Numbers(); 
            Refresh();
        }

        private void cleanNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j <= workspace_ob.field_ex.width; j++)
                    workspace_ob.field_ex.str_fild[i][j] = "";
            }
            Refresh();
        }

        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            string for_save = OpenSave.get_string_for_save(workspace_ob);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                File.WriteAllText(saveFileDialog1.FileName, for_save);
            }

        }

        

        public Image ResizeOrigImg(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }
        public Color Minimize_Image_Colors(Color clr)
        {
            double delta = 0;
            double min_delta = 1000;
            Color min_delta_clr = Color.Transparent;
            for (int i = 0; i < workspace_ob.keys.Count; i++) 
            {
                delta = Math.Sqrt((clr.R - workspace_ob.keys[i].clr.R) * (clr.R - workspace_ob.keys[i].clr.R)
                    + (clr.G - workspace_ob.keys[i].clr.G) * (clr.G - workspace_ob.keys[i].clr.G)
                    + (clr.B - workspace_ob.keys[i].clr.B) * (clr.B - workspace_ob.keys[i].clr.B));

                if (delta < min_delta) 
                { 
                    min_delta = delta;
                    min_delta_clr = workspace_ob.keys[i].clr;
                }
            } 
            return min_delta_clr;
        }
        public void Minimize_All_Image_Colors()
        {
            double delta = 0;
            double delta_two = 0;
            double min_delta = 1000;
            Color clr_one;
            Color clr_two;
            Color min_delta_clr = Color.Transparent;
            List<Color> new_main_colors = new List<Color>();
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                clr_one = workspace_ob.keys[i].clr;
                for (int j = 0; j < workspace_ob.keys.Count; j++)
                {
                    clr_two = workspace_ob.keys[j].clr;

                    delta = Math.Sqrt((clr_one.R - clr_two.R) * (clr_one.R - clr_two.R)
                    + (clr_one.G - clr_two.G) * (clr_one.G - clr_two.G)
                    + (clr_one.B - clr_two.B) * (clr_one.B - clr_two.B));

                    if (delta < workspace_ob.delta_for_open_image)
                    {
                        int r,g,b;
                        if(clr_one.R > clr_two.R)r = (clr_one.R - clr_two.R)/2 + clr_two.R;
                        else r = (clr_two.R - clr_one.R)/2 + clr_one.R;
                        if(clr_one.G > clr_two.G)g = (clr_one.G - clr_two.G)/2 + clr_two.G;
                        else g = (clr_two.G - clr_one.G)/2 + clr_one.G;
                        if(clr_one.B > clr_two.B)b = (clr_one.B - clr_two.B)/2 + clr_two.B;
                        else b = (clr_two.B - clr_one.B)/2 + clr_one.B;

                        Color myRgbColor = new Color();
                        myRgbColor = Color.FromArgb(r,g,b);
                        workspace_ob.keys[i].clr = myRgbColor;
                        workspace_ob.keys[j].clr = myRgbColor;

                    }
                }
            }
            List<Workspace.key> keys_temp = new List<Workspace.key>();
            for (int i = 0; i < workspace_ob.keys.Count; i++)
            {
                bool ifExist = false;
                for (int j = 0; j < keys_temp.Count; j++)
                {
                    if (workspace_ob.keys[i].clr.Name == keys_temp[j].clr.Name)
                    {
                        ifExist = true;
                    }
                }
                if (ifExist == false) keys_temp.Add(new Workspace.key("", workspace_ob.keys[i].clr));
            }
            workspace_ob.keys = keys_temp;
        }

        private void propetiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProperties vp = new ViewProperties();
            vp.workspace_ob = workspace_ob;
            vp.ShowDialog();
            workspace_ob = vp.workspace_ob;

            if (workspace_ob.field_ex.width > 20)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Minimum = 1;
                hScrollBar1.Maximum = (workspace_ob.field_ex.width - 19) * 5;
            }
            if (workspace_ob.field_ex.heigth > 20)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - 19) * 5;
            }
            if (workspace_ob.field_ex.width <= 20 && workspace_ob.field_ex.heigth > workspace_ob.field_ex.width)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Minimum = 1;
                vScrollBar1.Maximum = (workspace_ob.field_ex.heigth - workspace_ob.field_ex.width + 2) * 5;
            }
            Refresh();
        }

        private void generatePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            Pdf pdf = new Pdf();
            Pdf.workspace_ob = workspace_ob;
            pdf.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (workspace_ob.field_ex.heigth > 20) { }
            if (workspace_ob.field_ex.width > 20) { }
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            workspace_ob.field_ex.mudslide_for_hskroll = hScrollBar1.Value / 5;
            Refresh();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            workspace_ob.field_ex.mudslide_for_vskroll = vScrollBar1.Value / 5;
            Refresh();
        }

        private void SaveAsPNGImage(string imageDest)
        {
            IXC_PageFormat nFormat = IXC_PageFormat.PageFormat_8Indexed;
            IIXC_Inst inst = (IIXC_Inst)axPXV_Control1.Inst.GetExtension("IXC");
            IAUX_Inst inst_aux = (IAUX_Inst)axPXV_Control1.Inst.GetExtension("AUX");
            IIXC_Page page_ixc = inst.Page_CreateEmpty((uint)workspace_ob.field_ex.width, (uint)workspace_ob.field_ex.heigth, nFormat, 324345);
            page_ixc.PaletteSize = (uint)workspace_ob.keys.Count;
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    Color clr = workspace_ob.field_ex.clr_fild[i][j];
                    uint clgr = (uint)((byte)(clr.R) | ((UInt16)((byte)(clr.G)) << 8)) | (((UInt32)(byte)(clr.B)) << 16);
                    page_ixc.SetPixel(i, j, (uint)clgr, (uint)IXC_ColorFlags.Color_AddColor);
                }
            }
            page_ixc.ConvertToFormat(nFormat);
            IIXC_Image img = inst.CreateEmptyImage();
            img.InsertPage(page_ixc);
            page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_FILTER, 0);
            page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_FORMAT, (uint)IXC_ImageFileFormatIDs.FMT_PNG_ID);
            page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_ITYPE, 16);
            page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_COMP_LEVEL, 2);
            page_ixc.set_FmtInt((uint)IXC_FormatParametersIDS.FP_ID_COMP_TYPE, 0);
            img.Save(imageDest, IXC_CreationDisposition.CreationDisposition_Overwrite);
        }

        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile(false);
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
        }
        private void Form1_DragLeave(object sender, EventArgs e)
        {
            DragEventArgs arg = workspace_ob.dragAndDropEnterArg;
            string[] objects = (string[])arg.Data.GetData(DataFormats.FileDrop);
            if (objects.Count() > 1) { return; }
            string[] file_name = objects[0].Split('.');
            if (file_name[file_name.Count() - 1].ToLower() == "png" || file_name[file_name.Count() - 1].ToLower() == "jpeg" || file_name[file_name.Count() - 1].ToLower() == "gif" || file_name[file_name.Count() - 1].ToLower() == "bmp" || file_name[file_name.Count() - 1].ToLower() == "ico"|| file_name[file_name.Count() - 1].ToLower() == "jpg")
            {
                openFile(true, 1, objects[0]);
            }
            else if (file_name[file_name.Count() - 1].ToLower() == "cnf")
            {
                openFile(true, 2, objects[0]);
            }
            else if (file_name[file_name.Count() - 1].ToLower() == "tmpl")
            {
                openFile(true, 3, objects[0]);
            }
            else 
            {
                textBox_info.Text = "File is incorrect.";
                return;
            }
            this.Cursor = Cursors.Default;
            Refresh();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            workspace_ob.dragAndDropEnterArg = e;
            e.Data.ToString();
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
            e.Effect = DragDropEffects.Move;

            string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (objects.Count() > 1) { return; }
            string[] file_name = objects[0].Split('.');
            if (!(file_name[file_name.Count() - 1].ToLower() == "cnf" || file_name[file_name.Count() - 1].ToLower() == "tmpl" || file_name[file_name.Count() - 1].ToLower() == "png" || file_name[file_name.Count() - 1].ToLower() == "jpeg" || file_name[file_name.Count() - 1].ToLower() == "gif" || file_name[file_name.Count() - 1].ToLower() == "bmp" || file_name[file_name.Count() - 1].ToLower() == "ico"|| file_name[file_name.Count() - 1].ToLower() == "jpg"))
            {
                textBox_info.Text = "File is incorrect.";
                return;
            }         
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabOptions op = new TabOptions();
            if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD && workspace_ob.keys.Count < 2)
            {
                textBox_info.Text = "Please, add more keys.";
                return;
            }
            op.workspace_ob = this.workspace_ob;
            op.workspace_ob_last = this.workspace_ob;
            if (op.ShowDialog() == DialogResult.OK)
            {
                this.workspace_ob = op.workspace_ob;
                foreach (Workspace.key a in workspace_ob.keys)
                {
                    a.str = "";
                }
                GenereteNumbers.workspace = workspace_ob;
                GenereteNumbers.Generate_Number();
                update_dataGridView1();
                Refresh();
            }
            else return;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                saveFile();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                openFile(false);
            }
        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            workspace_ob.field_ex.mudslide_for_vskroll = vScrollBar1.Value / 5;
        }

        private void butoon_generate_field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                saveFile();
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                openFile(false);
            }
        }
        private void openFile(bool dragAndDrop, int slIndex = 0, string path_in = "")
        {
            string path = path_in;
            int selected = slIndex;
            if (dragAndDrop == false)
            {
                openFileDialog1.Filter = "Image Files| *.png; *.jpeg; *.gif; *bmp; *.jpg; *.ico|Template Files| *.tmpl|Configuration Files| *.cnf";
                openFileDialog1.DefaultExt = "png";
                openFileDialog1.FileName = "SmartColoring.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selected = openFileDialog1.FilterIndex;
                    path = openFileDialog1.FileName;
                }
                else{return;}
            }
            
            #region open_image
            if (selected == 1)
            {
                try
                {
                    Image img = Image.FromFile(path);
                    Bitmap temp = new Bitmap(img);
                    Graphics g = Graphics.FromImage(temp);
                    clean_keys();
                    img = ResizeOrigImg(img, workspace_ob.field_ex.width, workspace_ob.field_ex.heigth);
                    Bitmap bmp = new Bitmap(img);
                    for (int i = 0; i < workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                        {

                            bool ifColorExist = false;
                            for (int z = 0; z < workspace_ob.keys.Count; z++)
                            {
                                if (workspace_ob.keys[z].clr == bmp.GetPixel(i, j)) ifColorExist = true;
                            }
                            if (ifColorExist == false) workspace_ob.keys.Add(new Workspace.key("", bmp.GetPixel(i, j)));
                        }
                    }
                    Minimize_All_Image_Colors();
                    for (int i = 0; i < workspace_ob.field_ex.width; i++)
                    {
                        for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                        {
                            workspace_ob.field_ex.clr_fild[i][j] = Minimize_Image_Colors(bmp.GetPixel(i, j));
                            bool ifColorExist = false;
                            for (int z = 0; z < workspace_ob.keys.Count; z++)
                            {
                                if (workspace_ob.keys[z].clr == workspace_ob.field_ex.clr_fild[i][j]) ifColorExist = true;
                            }
                            if (ifColorExist == false) workspace_ob.keys.Add(new Workspace.key("", workspace_ob.field_ex.clr_fild[i][j]));
                        }
                    }
                    update_dataGridView1();
                    Refresh();
                }
                catch
                {
                    textBox_info.Text = "File is incorrect.";
                }
            }
            #endregion
            #region open_template
            else if (selected == 2)
            {
                clean_keys();
                for (int i = 0; i < workspace_ob.field_ex.clr_fild.Count; i++)
                {
                    for (int j = 0; j < workspace_ob.field_ex.clr_fild.Count; j++)
                    {
                        workspace_ob.field_ex.clr_fild[i][j] = Color.Transparent;
                        workspace_ob.field_ex.str_fild[i][j] = "";
                    }
                }

                string for_open;
                using (var streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    for_open = streamReader.ReadToEnd();
                }
                try
                {
                    OpenSave.interpretate_string_for_open(for_open, workspace_ob);
                }
                catch (System.FormatException)
                {
                    textBox_info.Text = "File is incorrect";
                }
                Refresh();
                update_dataGridView1();
            }
            #endregion
            #region open_configure
            else if (selected == 3)
            {
                string for_open;
                using (var streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    for_open = streamReader.ReadToEnd();
                }
                try
                {
                    OpenSave.opens_string_for_save_conf(for_open, workspace_ob);
                }
                catch (System.FormatException)
                {
                    textBox_info.Text = "File is incorrect.";
                }

                Refresh();
            }
            #endregion
            Refresh();
        }
        private void saveFile()
        {
            saveFileDialog1.Filter = "PNG Image Files| *.png|Template Files| *.tmpl|Configuration Files| *.cnf";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.FileName = "SmartColoring.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int selected = saveFileDialog1.FilterIndex;
                if (selected == 1)
                {
                    SaveAsPNGImage(saveFileDialog1.FileName);
                }
                else if (selected == 2)
                {
                    string for_save = OpenSave.get_string_for_save(workspace_ob);
                    File.WriteAllText(saveFileDialog1.FileName, for_save);
                }
                else if (selected == 3)
                {
                    string for_save = OpenSave.saves_string_for_save_conf(workspace_ob);
                    File.WriteAllText(saveFileDialog1.FileName, for_save);
                }
            }
        }
    }
}
