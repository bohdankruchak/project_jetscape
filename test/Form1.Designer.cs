namespace test
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_addKey = new System.Windows.Forms.Button();
            this.btn_deleteKey = new System.Windows.Forms.Button();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPDFToolStripMenuItem,
            this.generatePDFToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPDFToolStripMenuItem
            // 
            this.openPDFToolStripMenuItem.Name = "openPDFToolStripMenuItem";
            this.openPDFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openPDFToolStripMenuItem.Text = "Open PDF";
            // 
            // generatePDFToolStripMenuItem
            // 
            this.generatePDFToolStripMenuItem.Name = "generatePDFToolStripMenuItem";
            this.generatePDFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generatePDFToolStripMenuItem.Text = "Generate PDF";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanColorsToolStripMenuItem,
            this.cleanAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cleanColorsToolStripMenuItem
            // 
            this.cleanColorsToolStripMenuItem.Name = "cleanColorsToolStripMenuItem";
            this.cleanColorsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cleanColorsToolStripMenuItem.Text = "Clean colors";
            this.cleanColorsToolStripMenuItem.Click += new System.EventHandler(this.cleanColorsToolStripMenuItem_Click);
            // 
            // cleanAllToolStripMenuItem
            // 
            this.cleanAllToolStripMenuItem.Name = "cleanAllToolStripMenuItem";
            this.cleanAllToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cleanAllToolStripMenuItem.Text = "Clean all";
            this.cleanAllToolStripMenuItem.Click += new System.EventHandler(this.cleanAllToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(632, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Key:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(637, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(203, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numbers";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Color";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btn_addKey
            // 
            this.btn_addKey.Location = new System.Drawing.Point(637, 208);
            this.btn_addKey.Name = "btn_addKey";
            this.btn_addKey.Size = new System.Drawing.Size(99, 23);
            this.btn_addKey.TabIndex = 5;
            this.btn_addKey.Text = "Add Key";
            this.btn_addKey.UseVisualStyleBackColor = true;
            this.btn_addKey.Click += new System.EventHandler(this.btn_addKey_Click);
            // 
            // btn_deleteKey
            // 
            this.btn_deleteKey.Location = new System.Drawing.Point(741, 208);
            this.btn_deleteKey.Name = "btn_deleteKey";
            this.btn_deleteKey.Size = new System.Drawing.Size(99, 23);
            this.btn_deleteKey.TabIndex = 6;
            this.btn_deleteKey.Text = "Delete Key";
            this.btn_deleteKey.UseVisualStyleBackColor = true;
            this.btn_deleteKey.Click += new System.EventHandler(this.btn_deleteKey_Click);
            // 
            // textBox_info
            // 
            this.textBox_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_info.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_info.Location = new System.Drawing.Point(637, 276);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(203, 73);
            this.textBox_info.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 641);
            this.Controls.Add(this.textBox_info);
            this.Controls.Add(this.btn_deleteKey);
            this.Controls.Add(this.btn_addKey);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Smart Coloring";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem cleanColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button btn_addKey;
        private System.Windows.Forms.Button btn_deleteKey;
        private System.Windows.Forms.ToolStripMenuItem cleanAllToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

