namespace test
{
    partial class Pdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pdf));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axPXV_Control1 = new AxPDFXEdit.AxPXV_Control();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_with_color = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // axPXV_Control1
            // 
            this.axPXV_Control1.Enabled = true;
            this.axPXV_Control1.Location = new System.Drawing.Point(12, 12);
            this.axPXV_Control1.Margin = new System.Windows.Forms.Padding(4);
            this.axPXV_Control1.Name = "axPXV_Control1";
            this.axPXV_Control1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPXV_Control1.OcxState")));
            this.axPXV_Control1.Size = new System.Drawing.Size(700, 352);
            this.axPXV_Control1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 547);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_with_color
            // 
            this.checkBox_with_color.AutoSize = true;
            this.checkBox_with_color.Location = new System.Drawing.Point(14, 519);
            this.checkBox_with_color.Name = "checkBox_with_color";
            this.checkBox_with_color.Size = new System.Drawing.Size(93, 21);
            this.checkBox_with_color.TabIndex = 2;
            this.checkBox_with_color.Text = "With color";
            this.checkBox_with_color.UseVisualStyleBackColor = true;
            this.checkBox_with_color.CheckedChanged += new System.EventHandler(this.checkBox_with_color_CheckedChanged);
            // 
            // Pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 579);
            this.Controls.Add(this.checkBox_with_color);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axPXV_Control1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pdf";
            this.Text = "Pdf";
            this.Shown += new System.EventHandler(this.Pdf_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axPXV_Control1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxPDFXEdit.AxPXV_Control axPXV_Control1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_with_color;
    }
}