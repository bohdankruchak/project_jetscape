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
            //workspace_ob.keys[dataGridView1.CurrentRow.Index].str;
            if (workspace_ob.game_mod == Workspace.g_mod.ADDJR) {
                result = MathTemplate.MathFact_Jr(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADDBAS) {
                result = MathTemplate.MathFact_Basic(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADDADV) {
                result = MathTemplate.MathFact_Advanced(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.SUBJR) {
                result = MathTemplate.MathFact_Jr(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.SUBBAS)
            {
                result = MathTemplate.MathFact_Basic(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.SUBADV)
            {
                result = MathTemplate.MathFact_Advanced(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.MULTJR)
            {
                result = MathTemplate.MathFact_Jr(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.MULTBAS)
            {
                result = MathTemplate.MathFact_Basic(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.MULTADV)
            {
                result = MathTemplate.MathFact_Advanced(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.DIVJR)
            {
                result = MathTemplate.MathFact_Jr(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.DIVBAS)
            {
                result = MathTemplate.MathFact_Basic(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.DIVADV)
            {
                result = MathTemplate.MathFact_Advanced(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }

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
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        
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
            Options op = new Options();
            op.workspace_ob = this.workspace_ob;
            op.ShowDialog();
            this.workspace_ob = op.workspace_ob;
            Refresh();
        }

        private void btn_addKey_Click(object sender, EventArgs e)
        {
            NewKey nk = new NewKey();
            nk.workspace_ob = this.workspace_ob;
            nk.ShowDialog();
            this.workspace_ob = nk.workspace_ob;
            update_dataGridView1();
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
        #region templates_menu
        private void jrAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDJR;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "2 or 4";
        }

        private void basicAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDBAS;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "4";
        }

        private void advancedAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDADV;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
        }

        private void jrSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBJR;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "2 or 4";
        }

        private void basicSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBBAS;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "4";
        }

        private void advancedSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBADV;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
        }

        private void jrMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTJR;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "2 or 4";
        }

        private void basicMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTBAS;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "4";
        }

        private void advancedMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTADV;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
        }

        private void jrDivisionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVJR;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "2 or 4";
        }

        private void basicDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVBAS;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "4";
        }

        private void advancedDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVADV;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
        }

        private void mixedStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MIXED;
            workspace_ob.sign = '$';
        }

        private void counting1999ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.PLCVALCOUN;
            workspace_ob.sign = '$';
        }

        private void placeValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.PLCVALPLCV;
            workspace_ob.sign = '$';
        }

        private void roundingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ROUNDING;
            workspace_ob.sign = '$';
        }

        private void additionRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRADD;
            workspace_ob.sign = '+';
        }

        private void subtractionRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRSUB;
            workspace_ob.sign = '-';
        }

        private void multiplicationRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRMULT;
            workspace_ob.sign = '*';
        }

        private void numbersAndOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVNUMBANDOP;
            workspace_ob.sign = '$';
        }

        private void geometryAndMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.GEOMANDMES;
            workspace_ob.sign = '$';
        }

        private void colorByNumberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUM;
            workspace_ob.sign = '$';
        }

        private void numberPairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUMPAIR;
            workspace_ob.sign = '$';
        }

        private void numberRangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUMRANGES;
            workspace_ob.sign = '$';
        }

        private void fractionNumeratorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPFRNUM;
            workspace_ob.sign = '$';
        }

        private void fractionDenominatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPFRDET;
            workspace_ob.sign = '$';
        }

        private void decimalColoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPDECOL;
            workspace_ob.sign = '$';
        }

        private void percentColoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPPECOL;
            workspace_ob.sign = '$';
        }
        #endregion
    }
}
