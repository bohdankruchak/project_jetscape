namespace test
{
    partial class NewKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_numbers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_example = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_color = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_numbers
            // 
            this.textBox_numbers.Location = new System.Drawing.Point(12, 35);
            this.textBox_numbers.Name = "textBox_numbers";
            this.textBox_numbers.Size = new System.Drawing.Size(100, 20);
            this.textBox_numbers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numbers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Example:";
            // 
            // textBox_example
            // 
            this.textBox_example.Location = new System.Drawing.Point(12, 74);
            this.textBox_example.Multiline = true;
            this.textBox_example.Name = "textBox_example";
            this.textBox_example.ReadOnly = true;
            this.textBox_example.ShortcutsEnabled = false;
            this.textBox_example.Size = new System.Drawing.Size(100, 81);
            this.textBox_example.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select color";
            // 
            // textBox_color
            // 
            this.textBox_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_color.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_color.Location = new System.Drawing.Point(143, 35);
            this.textBox_color.Name = "textBox_color";
            this.textBox_color.ReadOnly = true;
            this.textBox_color.ShortcutsEnabled = false;
            this.textBox_color.Size = new System.Drawing.Size(123, 20);
            this.textBox_color.TabIndex = 7;
            this.textBox_color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_color_MouseClick);
            // 
            // NewKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 167);
            this.Controls.Add(this.textBox_color);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_example);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_numbers);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "NewKey";
            this.Text = "New key";
            this.Shown += new System.EventHandler(this.NewKey_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_numbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_example;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_color;
    }
}