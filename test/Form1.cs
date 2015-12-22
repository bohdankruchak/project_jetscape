using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace test
{

    public partial class Form1 : Form
    {
        enum color_rc { BLUE, TAN, ORANGE, GREEN, BROWN };
        color_rc active_color = color_rc.BROWN;
        int size_rect = 30;
        bool clean_colors = false;
        Rectangle rc_brown = new Rectangle(0, 0, 50, 20);
        Rectangle rc_orange = new Rectangle(0, 25, 50, 20);
        Rectangle rc_blue = new Rectangle(0, 50, 50, 20);
        Rectangle rc_green = new Rectangle(0, 75, 50, 20);
        Rectangle rc_tan = new Rectangle(0, 100, 50, 20);
        SolidBrush active_rc_color = new SolidBrush(Color.Brown);
        SolidBrush[,] field = new SolidBrush[20, 20];
        string [,] field_string = new string[20, 20]; 
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    field[i, j] = new SolidBrush(Color.Transparent);
                }
            }
            dataGridView1.Rows.Add("0", "Tan");
            dataGridView1.Rows.Add("1,2,3", "Brown");
            dataGridView1.Rows.Add("4,5,6", "Orange");
            dataGridView1.Rows.Add("7,8,9", "Green");
            dataGridView1.Rows.Add("10", "Blue");
        }
        string get_string_eq(Color this_color)
        {
            int numb = 0;
            int first_numb, second_num;
            Random rand= new Random();
            if (this_color == Color.Blue) { numb = 10; }
            else if (this_color == Color.Brown) 
            { 
                numb = rand.Next(1,3); 
            }
            else if (this_color == Color.Green)
            {
                numb = rand.Next(7, 9);
            }
            else if (this_color == Color.Tan)
            {
                numb = 0;
            }
            else if (this_color == Color.Orange) 
            { 
                numb = rand.Next(4, 6); 
            }
            first_numb = rand.Next(0, numb);
            second_num = numb - first_numb;
            return first_numb+"+"+second_num;
        }


        private void pnl_colors_Paint(object sender, PaintEventArgs e)
        {

            Pen myPen = new Pen(Color.Black, 1);

            e.Graphics.DrawRectangle(myPen, rc_blue);
            e.Graphics.DrawRectangle(myPen, rc_tan);
            e.Graphics.DrawRectangle(myPen, rc_orange);
            e.Graphics.DrawRectangle(myPen, rc_green);
            e.Graphics.DrawRectangle(myPen, rc_brown);
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), rc_blue);
            e.Graphics.FillRectangle(new SolidBrush(Color.Brown), rc_brown);
            e.Graphics.FillRectangle(new SolidBrush(Color.Tan), rc_tan);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), rc_green);
            e.Graphics.FillRectangle(new SolidBrush(Color.Orange), rc_orange);


            Pen chosen_pen = new Pen(Color.Black, 4);

            if(active_rc_color.Color == Color.Blue)
            {
                e.Graphics.DrawRectangle(chosen_pen, rc_blue);
            }
            else if (active_rc_color.Color == Color.Orange)
            {
                e.Graphics.DrawRectangle(chosen_pen, rc_orange);
            }
            else if (active_rc_color.Color == Color.Brown)
            {
                e.Graphics.DrawRectangle(chosen_pen, rc_brown);
            }
            else if (active_rc_color.Color == Color.Tan)
            {
                e.Graphics.DrawRectangle(chosen_pen, rc_tan);
            }
            else if (active_rc_color.Color == Color.Green)
            {
                e.Graphics.DrawRectangle(chosen_pen, rc_green);
            }
        }


        //Обробник подій нажаття на панель кольорів
        private void pnl_colors_MouseClick(object sender, MouseEventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 2);
            if (e.Location.X > rc_blue.X && e.Location.X < rc_blue.X + rc_blue.Width && e.Location.Y > rc_blue.Y && e.Location.Y < rc_blue.Y + rc_blue.Height)
            {
                active_color = color_rc.BLUE;
                active_rc_color = new SolidBrush(Color.Blue);
            }
            else if (e.Location.X > rc_orange.X && e.Location.X < rc_orange.X + rc_orange.Width && e.Location.Y > rc_orange.Y && e.Location.Y < rc_orange.Y + rc_orange.Height)
            {
                active_color = color_rc.ORANGE;
                active_rc_color = new SolidBrush(Color.Orange);
            }
            else if (e.Location.X > rc_brown.X && e.Location.X < rc_brown.X + rc_brown.Width && e.Location.Y > rc_brown.Y && e.Location.Y < rc_brown.Y + rc_brown.Height)
            {
                active_color = color_rc.BROWN;
                active_rc_color = new SolidBrush(Color.Brown);
            }
            else if (e.Location.X > rc_tan.X && e.Location.X < rc_tan.X + rc_tan.Width && e.Location.Y > rc_tan.Y && e.Location.Y < rc_tan.Y + rc_tan.Height)
            {
                active_color = color_rc.TAN;
                active_rc_color = new SolidBrush(Color.Tan);
            }
            else if (e.Location.X > rc_green.X && e.Location.X < rc_green.X + rc_green.Width && e.Location.Y > rc_green.Y && e.Location.Y < rc_green.Y + rc_green.Height)
            {
                active_color = color_rc.GREEN;
                active_rc_color = new SolidBrush(Color.Green);

            }

            pnl_colors.Refresh();
        }




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    int x = i * size_rect + 15;
                    int y = j * size_rect + 27;
                    Pen myPen = new Pen(Color.Black, 1);

                    if (field[i, j].Color == Color.Blue) { }
                    e.Graphics.DrawRectangle(myPen, x, y, size_rect, size_rect);
                    if(clean_colors == false)e.Graphics.FillRectangle(field[i, j], x + 1, y + 1, size_rect - 1, size_rect - 1);
                    if (field[i, j].Color != Color.Transparent)
                    {
                        SolidBrush br = new SolidBrush(Color.Black);
                        RectangleF temp_rc = new RectangleF(x, y, size_rect, size_rect);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString(field_string[i,j], this.Font, br, temp_rc, sf);
                    }
                }
            }
            clean_colors = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X < 15 || e.X > size_rect * 19 + 15) || (e.Y < 27 || e.Y > size_rect * 19 + 27))
            {
                return;
            }
            int x_index = (e.X -15) / size_rect;
            int y_index = (e.Y -27) / size_rect;
            if (active_color == color_rc.BLUE)
            {
                field[x_index, y_index] = new SolidBrush(Color.Blue);
            }
            else if (active_color == color_rc.TAN)
            {
                field[x_index, y_index] = new SolidBrush(Color.Tan);
            }
            else if (active_color == color_rc.ORANGE)
            {
                field[x_index, y_index] = new SolidBrush(Color.Orange);
            }
            else if (active_color == color_rc.GREEN)
            {
                field[x_index, y_index] = new SolidBrush(Color.Green);
            }
            else if (active_color == color_rc.BROWN)
            {
                field[x_index, y_index] = new SolidBrush(Color.Brown);
            }
            field_string[x_index, y_index] = get_string_eq(field[x_index, y_index].Color);
            Refresh();
        }

        private void cleanColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clean_colors = true;
            Refresh();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options op = new Options();
            op.ShowDialog();
        }
    }
}
