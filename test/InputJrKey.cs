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

    public partial class InputJrKey : Form
    {
        public Workspace workspace_ob = new Workspace();
        Color chosen_color = Color.Tomato;
        public InputJrKey()
        {
            InitializeComponent();
            if (workspace_ob.auto_generate == true) { 
                textBox_numbers.ReadOnly = true;
                textBox_numbers1.ReadOnly = true;
            }
        }

        private void textBox_color_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_color.BackColor = colorDialog1.Color;
                chosen_color = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_numbers.Text != "" && textBox_numbers1.Text != "" && workspace_ob.auto_generate == false)
            {

                workspace_ob.keys.Add(new Workspace.key(GenerateInputString.string_jr(int.Parse(textBox_numbers.Text), int.Parse(textBox_numbers1.Text)), chosen_color));
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox_numbers_TextChanged_1(object sender, EventArgs e)
        {
            textBox_error.Text = "Example: " + Environment.NewLine + workspace_ob.example_for_input;
        }

        private void InputJrKey_Shown(object sender, EventArgs e)
        {
            textBox_error.Text = "Example: " + Environment.NewLine + workspace_ob.example_for_input;
        }
    }
}
