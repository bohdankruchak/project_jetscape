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
                    workspace_ob.field_ex.clr_fild[i][j] = new SolidBrush(Color.Transparent);
                }
            }
            update_dataGridView1();
        }

        string get_string_eq(Color this_color)
        {
            string result = "";
           
            return result;
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
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    int x = i * workspace_ob.field_ex.size_rect + 15;
                    int y = j * workspace_ob.field_ex.size_rect + 27;
                    Pen myPen = new Pen(Color.Black, 1);
                    e.Graphics.DrawRectangle(myPen, x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                    //if clean color is not active filling rect
                    if (workspace_ob.clean_colors == false) e.Graphics.FillRectangle(workspace_ob.field_ex.clr_fild[i][j], x + 1, y + 1, workspace_ob.field_ex.size_rect - 1, workspace_ob.field_ex.size_rect - 1);
                    if (workspace_ob.field_ex.clr_fild[i][j].Color != Color.Transparent)
                    {
                        SolidBrush br = new SolidBrush(Color.Black);
                        RectangleF temp_rc = new RectangleF(x, y, workspace_ob.field_ex.size_rect, workspace_ob.field_ex.size_rect);
                        StringFormat sf = new StringFormat();
                        Font fn = this.Font;
                        if (workspace_ob.field_ex.str_fild[i][j].Length > 5)
                        {
                            float currentSize = fn.Size;
                            currentSize -= 1.5F;
                            fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                        }
                        else if (workspace_ob.field_ex.str_fild[i][j].Length > 6)
                        {
                            float currentSize = fn.Size;
                            currentSize -= 3.0F;
                            
                            fn = new Font(fn.Name, currentSize, fn.Style, fn.Unit);
                        }
                        
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        //if chosen "Regroping" aligment by right side
                        //if (workspace_ob.game_mod == test.Workspace.g_mod.ALGEBRA_MIDD)
                        //{
                        //    sf.Alignment = StringAlignment.Far;
                        //    fn = new Font(fn.Name, fn.Size, FontStyle.Underline, fn.Unit);
                        //}
                        e.Graphics.DrawString(workspace_ob.field_ex.str_fild[i][j], fn, br, temp_rc, sf);
                    }
                }
            }
            workspace_ob.clean_colors = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X < 15 || e.X > workspace_ob.field_ex.size_rect * 19 + 15 + workspace_ob.field_ex.size_rect) || (e.Y < 27 || e.Y > workspace_ob.field_ex.size_rect * 19 + 27 + +workspace_ob.field_ex.size_rect))
            {
                return;
            }
            if (workspace_ob.keys.Count == 0)
            {
                textBox_info.Text = "Please, add some keys.";
                return;
            }
            int x_index = (e.X - 15) / workspace_ob.field_ex.size_rect;
            int y_index = (e.Y - 27) / workspace_ob.field_ex.size_rect;
            workspace_ob.field_ex.clr_fild[x_index][y_index] = workspace_ob.active_rc_color;
            workspace_ob.field_ex.str_fild[x_index][y_index] = get_string_eq(workspace_ob.field_ex.clr_fild[x_index][y_index].Color);
            Refresh();
        }

        private void cleanColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.clean_colors = true;
            Refresh();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabOptions op = new TabOptions();

            op.workspace_ob = this.workspace_ob;
            op.ShowDialog();
            this.workspace_ob = op.workspace_ob;
            Refresh();
        }

        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(workspace_ob.keys.Count != 0)workspace_ob.active_rc_color = new SolidBrush(workspace_ob.keys[dataGridView1.CurrentRow.Index].clr);
        }
        private void btn_deleteKey_Click(object sender, EventArgs e)
        {
            if (workspace_ob.keys.Count > 0)
            {
                workspace_ob.keys.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
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
                workspace_ob.field_ex.clr_fild[x_index][y_index] = workspace_ob.active_rc_color;
                workspace_ob.field_ex.str_fild[x_index][y_index] = get_string_eq(workspace_ob.field_ex.clr_fild[x_index][y_index].Color);
                Refresh();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            workspace_ob.isLbuttonDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            workspace_ob.isLbuttonDown = false;
        }
        

        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workspace_ob.field_ex.clr_fild.Count; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.clr_fild.Count; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = new SolidBrush(Color.Transparent);
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
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                workspace_ob.keys.Add(new Workspace.key("", colorDialog1.Color));
            }
            update_dataGridView1();
        }

        private void button_delete_color_Click(object sender, EventArgs e)
        {
            if (workspace_ob.keys.Count > 0)
            {
                workspace_ob.keys.RemoveAt(dataGridView1.CurrentRow.Index);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void button_generate_num_Click(object sender, EventArgs e)
        {
            textBox_info.Text = "";
            
            if (workspace_ob.keys.Count != 0)
            {
                if (workspace_ob.op.game_mod == Workspace.options.g_mod.BASIC_EVEN_ODD && workspace_ob.keys.Count < 2)
                {
                    textBox_info.Text = "Please, add more keys.";
                    return;
                }
                else
                {
                    GenereteNumbers.workspace = workspace_ob;
                    GenereteNumbers.Generate_Number();
                    update_dataGridView1();
                } 
            }
        }

 
        
    }
}
