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
            workspace_ob.checked_item_in_tmpl_menu = jrAdditionToolStripMenuItem;
            jrAdditionToolStripMenuItem.Checked = true;
            for (int i = 0; i < workspace_ob.field_ex.width; i++)
            {
                for (int j = 0; j < workspace_ob.field_ex.heigth; j++)
                {
                    workspace_ob.field_ex.clr_fild[i][j] = new SolidBrush(Color.Transparent);
                }
            }
            update_dataGridView1();
        }
        private void uncheck_all_menu_item(ToolStripMenuItem this_item)
        {
            workspace_ob.checked_item_in_tmpl_menu.Checked = false;
            workspace_ob.checked_item_in_tmpl_menu = this_item;
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
            else if (workspace_ob.game_mod == Workspace.g_mod.MIXED)
            {
                result = MathTemplate.MathFact_Mixed(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.PLCVALCOUN)
            {
                result = MathTemplate.PlaceValue_Counting(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.PLCVALPLCV)
            {
                result = MathTemplate.PlaceValue_PlaceValue(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ROUNDING)
            {
                result = MathTemplate.PlaceValue_Rounding(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVREGRADD)
            {
                result = MathTemplate.AdvancedMath_Regrouping(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVREGRMULT)
            {
                result = MathTemplate.AdvancedMath_Regrouping(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVREGRSUB)
            {
                result = MathTemplate.AdvancedMath_Regrouping(workspace_ob.keys[dataGridView1.CurrentRow.Index].str, workspace_ob.sign);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPODDEVEN)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_Even_Odd(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPNUMPATT)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_NumbPatterns(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.ADVNUMBANDOPFACTORS)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_PrimeOrComposite(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMESIANGL)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_GeomAndMeasur(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMGRPHQA)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_Quadrants(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.GEOMANDMESISHAP)
            {
                result = MathTemplate.AdvancedMath_NumbAndOps_Shapes_Names(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUM)
            {
                result = MathTemplate.Color_By_Numb_Color_By_Numb(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUMPAIR)
            {
                result = MathTemplate.Color_By_Numb_Number_Pairs(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.CLRBYNUMRANGES)
            {
                result = MathTemplate.Color_By_Numb_Number_Ranges(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPFRNUM)
            {
                result = MathTemplate.FDP_Fractions_Numerators(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPFRDEN)
            {
                result = MathTemplate.FDP_Fractions_Denominators(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPDECOLPLVAL)
            {
                result = MathTemplate.FDP_Decimal_Place_Value(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPPECOLNUMSEN)
            {
                result = MathTemplate.FDP_Decimal_Sense(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPPECOLEQU)
            {
                result = MathTemplate.FDP_Percent_Equivalence(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
            }
            else if (workspace_ob.game_mod == Workspace.g_mod.FDPPECOLNUMSEN)
            {
                result = MathTemplate.FDP_Percent_Number_Sense(workspace_ob.keys[dataGridView1.CurrentRow.Index].str);
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
                        //if chosen "Rouding" aligment by right side
                        if (workspace_ob.game_mod == test.Workspace.g_mod.ADVREGRMULT || workspace_ob.game_mod == test.Workspace.g_mod.ADVREGRADD || workspace_ob.game_mod == test.Workspace.g_mod.ADVREGRSUB)
                        {
                            sf.Alignment = StringAlignment.Far;
                            fn = new Font(fn.Name, fn.Size, FontStyle.Underline, fn.Unit);
                            
                        }
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
            Options op = new Options();
            op.workspace_ob = this.workspace_ob;
            op.ShowDialog();
            this.workspace_ob = op.workspace_ob;
            Refresh();
        }

        private void btn_addKey_Click(object sender, EventArgs e)
        {
            textBox_info.Text = "";
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
        #region templates_menu
        private void jrAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDJR;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "2 or 4";
            uncheck_all_menu_item(sender);
        }

        private void basicAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDBAS;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "4";
            uncheck_all_menu_item(sender);
        }

        private void advancedAdditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADDADV;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
            uncheck_all_menu_item(sender);
        }

        private void jrSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBJR;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "2 or 4";
            uncheck_all_menu_item(sender);
        }

        private void basicSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBBAS;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "4";
            uncheck_all_menu_item(sender);
        }

        private void advancedSubtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.SUBADV;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
            uncheck_all_menu_item(sender);
        }

        private void jrMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTJR;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "2 or 4";
            uncheck_all_menu_item(sender);
        }

        private void basicMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTBAS;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "4";
            uncheck_all_menu_item(sender);
        }

        private void advancedMultiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MULTADV;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
            uncheck_all_menu_item(sender);
        }

        private void jrDivisionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVJR;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "2 or 4";
            uncheck_all_menu_item(sender);
        }

        private void basicDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVBAS;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "4";
            uncheck_all_menu_item(sender);
        }

        private void advancedDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.DIVADV;
            workspace_ob.sign = '/';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
            uncheck_all_menu_item(sender);
        }

        private void mixedStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.MIXED;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "4" + Environment.NewLine + "or" + Environment.NewLine + "3-5" + Environment.NewLine + "or" + Environment.NewLine + "3,4,9";
            uncheck_all_menu_item(sender);
        }

        private void counting1999ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.PLCVALCOUN;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "4-89";
            uncheck_all_menu_item(sender);
        }

        private void placeValueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.PLCVALPLCV;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "4 in ones place" + Environment.NewLine + "or" + Environment.NewLine + "5 in tens place" + Environment.NewLine + "or" + Environment.NewLine + "8 in hundreds place" + Environment.NewLine + "or" + Environment.NewLine + "Does not have a 6";
            uncheck_all_menu_item(sender);
        }

        private void roundingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ROUNDING;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Rounds to 20" + Environment.NewLine + "or" + Environment.NewLine + "Rounds to 500";
            uncheck_all_menu_item(sender);
        }

        private void additionRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRADD;
            workspace_ob.sign = '+';
            workspace_ob.example_for_input = "From 2 to 43";
            uncheck_all_menu_item(sender);
        }

        private void subtractionRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRSUB;
            workspace_ob.sign = '-';
            workspace_ob.example_for_input = "From 2 to 43";
            uncheck_all_menu_item(sender);
        }

        private void multiplicationRegroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVREGRMULT;
            workspace_ob.sign = '*';
            workspace_ob.example_for_input = "From 2 to 43";
            uncheck_all_menu_item(sender);
        }
        
        private void oddAndEvenNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVNUMBANDOPODDEVEN;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Even" + Environment.NewLine + "or" + Environment.NewLine + "Odd";
            uncheck_all_menu_item(sender);
        }

        private void numberPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVNUMBANDOPNUMPATT;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Add 4";
            uncheck_all_menu_item(sender);
        }

        private void factorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.ADVNUMBANDOPFACTORS;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Prime" + Environment.NewLine + "or" + Environment.NewLine + "Composite";
            uncheck_all_menu_item(sender);
        }
        private void identifyAnglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.GEOMANDMESIANGL;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Straight" + Environment.NewLine + "or" + Environment.NewLine + "Right" + Environment.NewLine + "or" + Environment.NewLine  + "Accute" + Environment.NewLine + "or" + Environment.NewLine + "Obtuse";
            uncheck_all_menu_item(sender);
        }

        private void graphingQuadrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.GEOMANDMGRPHQA;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Quadrant 1" + Environment.NewLine + "or" + Environment.NewLine + "Quadrant 2" + Environment.NewLine + "or" + Environment.NewLine + "Quadrant 3" + Environment.NewLine + "or" + Environment.NewLine + "Quadrant 4";
            uncheck_all_menu_item(sender);
        }

        private void identifyShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.GEOMANDMESISHAP;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "3 sides shapes" + Environment.NewLine + "or" + Environment.NewLine + "4 sides shapes" + Environment.NewLine + "or" + Environment.NewLine + "More than 4 sides";
            uncheck_all_menu_item(sender);
        }

        private void colorByNumberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUM;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "5";
            uncheck_all_menu_item(sender);
        }

        private void numberPairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUMPAIR;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "3,5";
            uncheck_all_menu_item(sender);
        }

        private void numberRangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.CLRBYNUMRANGES;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "3-5";
            uncheck_all_menu_item(sender);
        }

        private void fractionNumeratorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPFRNUM;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Equal to 1/2" + Environment.NewLine +  Environment.NewLine + "In this template numerators of all \"Numbers\" value keys must be equal!";
            uncheck_all_menu_item(sender);
        }
        private void fractionDenominatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPFRDEN;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Equal to 1/8" + Environment.NewLine + Environment.NewLine + "In this template denominators of all \"Numbers\" value keys must be equal!";
            uncheck_all_menu_item(sender);
        }
        private void decimalPlaceValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPDECOLPLVAL;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "4 in the ones place" + Environment.NewLine + "or" + Environment.NewLine + "5 in the tenths place" + Environment.NewLine + "or" + Environment.NewLine + "8 in the hundredths place" + Environment.NewLine + "or" + Environment.NewLine + "Does not have a 6";
            uncheck_all_menu_item(sender);
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPDECOLNUMSEN;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "From 1.32 to 2" + Environment.NewLine + "or" + Environment.NewLine + "From 1.25 to 5.34";
            uncheck_all_menu_item(sender);
        }

        private void equivalentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPPECOLEQU;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "Equal to 67%" + Environment.NewLine + "or" + Environment.NewLine + "Equal to 50%";
            uncheck_all_menu_item(sender);
        }

        private void numberSenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace_ob.game_mod = test.Workspace.g_mod.FDPPECOLNUMSEN;
            workspace_ob.sign = '$';
            workspace_ob.example_for_input = "From 1 to 27%" + Environment.NewLine + "or" + Environment.NewLine + "From 28 to 50%";
            uncheck_all_menu_item(sender);
        }
        

        #endregion

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
        private void uncheck_all_menu_item(object sender)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            workspace_ob.checked_item_in_tmpl_menu.Checked = false;
            workspace_ob.checked_item_in_tmpl_menu = item;
            clean_keys();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        

        

        

        
    }
}
